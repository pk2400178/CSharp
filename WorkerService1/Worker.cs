using Microsoft.Extensions.Hosting;
using SchedulingPractice.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private int threadCount = 5;
        private BlockingCollection<JobInfo> blockingCollection = new BlockingCollection<JobInfo>();

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1);

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < threadCount; i++)
            {
                Thread T = new Thread(ProcessJob);
                threads.Add(T);
                T.Start();
            }

            using (JobsRepo repo = new JobsRepo())
            {
                while (stoppingToken.IsCancellationRequested == false)
                {
                    foreach (var job in repo.GetReadyJobs())
                    {
                        if (stoppingToken.IsCancellationRequested == true) goto shutdown;

                        if (repo.GetJob(job.Id).State == (int)JobStateEnum.CREATE
                            && repo.AcquireJobLock(job.Id))
                        {

                            if (job.RunAt > DateTime.Now)
                            {
                                await Task.Delay(job.RunAt - DateTime.Now);
                            }

                            blockingCollection.Add(job);
                        }
                    }

                    try
                    {
                        await Task.Delay(JobSettings.MinPrepareTime, stoppingToken);
                    }
                    catch (TaskCanceledException) { break; }
                }

            }
        shutdown:
            this.blockingCollection.CompleteAdding();

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine($"End");
        }

        private void ProcessJob()
        {
            using (JobsRepo repo = new JobsRepo())
            {
                foreach (var jobInfo in blockingCollection.GetConsumingEnumerable())
                {
                    repo.ProcessLockedJob(jobInfo.Id);
                }
            }
        }
    }
}
