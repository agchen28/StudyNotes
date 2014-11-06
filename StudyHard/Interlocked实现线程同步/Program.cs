using System;
using System.Threading;

namespace Interlocked实现线程同步
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(Add);
                thread.Start();
            }
            Console.ReadKey();
        }

        public static int Number = 1;

        private static void Add()
        {
            Thread.Sleep(1000);
            Console.WriteLine("the current value of number is:{0}\n CurrentThreadId is {1}\n", Interlocked.Increment(ref Number), Thread.CurrentThread.ManagedThreadId);
        }
    }
}
