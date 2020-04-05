using System;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //SharedStateDemo sharedStateDemo = new SharedStateDemo();
            //sharedStateDemo.Run();

            ThreadPoolDemo threadPoolDemo = new ThreadPoolDemo();
            threadPoolDemo.Run();

            Console.ReadLine();
        }
    }
}
