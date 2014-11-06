using System;
using System.Threading;

namespace Monitor实现线程同步
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
            Console.Read();
        }

        public static int Number = 1;
        private static readonly object Lockobj = new object();
        private static void Add()
        {
            //Thread.Sleep(1000);
            //Monitor.Enter(Lockobj);
            //Console.WriteLine("the current value of number is: {0}", Number++);
            //Monitor.Exit(Lockobj);
            lock (Lockobj)//lock可以理解为Monitor.Enter和Monitor.Exit方法的语法糖
            {
                Console.WriteLine("the current value of number is: {0}", Number++); 
            }
        }
    }
}
