using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    public class ThreadPoolDemo
    {
        public void Run()
        {
            //ThreadPool.QueueUserWorkItem(DownloadFile, "xyz.iso");
            //若不使用執行緒集區，而要自行建立新的專屬執行緒 new Thread(DownloadFile).Start();

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Token.Register(() =>
            {
                Console.WriteLine("工作取消 callback #1.");
            });
            ThreadPool.QueueUserWorkItem(status => MyTask(cts.Token));
            ThreadPool.QueueUserWorkItem(status => MyTask(cts.Token));
            //ThreadPool.QueueUserWorkItem(state => MyTask(CancellationToken.None));

            Console.WriteLine("按 Enter 鍵可取消背景工作...");
            Console.ReadLine(); // 這會使 cts 的 IsCancellationRequested 屬性變成 true。
            cts.Cancel();

            Console.ReadLine();
        }
        private void MyTask(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("使用者要求取消工作!");
                    return;
                }
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}:{i}");
                Thread.Sleep(200);
            }
            Console.WriteLine("MyTask 工作執行完畢。");
        }

        private void DownloadFile(object fileName)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : Downloading file {fileName}");
        }
    }
}
