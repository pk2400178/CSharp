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
            ThreadPool.QueueUserWorkItem(DownloadFile, "123");
            ThreadPool.QueueUserWorkItem(status => MyTask(cts.Token,"456"));
            ThreadPool.QueueUserWorkItem(status => MyTask(cts.Token,"789"));
            //ThreadPool.QueueUserWorkItem(state => MyTask(CancellationToken.None));

            Task.Factory.StartNew(() => MyTask2(100,cts.Token));

            Task.Run(() => MyTask2(100, cts.Token));

            Console.WriteLine("按 Enter 鍵可取消背景工作...");
            Console.ReadLine(); // 這會使 cts 的 IsCancellationRequested 屬性變成 true。
            cts.Cancel();

            Console.ReadLine();
        }
        private void MyTask(CancellationToken cancellationToken, string t)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("使用者要求取消工作!");
                    return;
                }
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}:{i}, t: {t}");
                Thread.Sleep(200);
            }
            Console.WriteLine("MyTask 工作執行完畢。");
        }

        private void DownloadFile(object fileName)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : Downloading file {fileName}");
        }

        private void MyTask2(int i, CancellationToken cancellationToken)
        {
            for (int a = 0; a < i; a++)
            {

                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("MyTask2使用者要求取消工作!");
                    return;
                }
                Thread.Sleep(200);
                Console.WriteLine("工作執行緒 #{0}", Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}
