using System;
using System.Threading;

namespace 线程基础
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个新线程（默认为前台线程）
            Thread backThread = new Thread(Worker);
            backThread.IsBackground = true;
            backThread.Start("parameter");
            //join后会先执行Worker再执行main
            backThread.Join();

            Console.WriteLine("Return from Main Thread.");
            Console.Read();
        }

        private static void Worker(object obj)
        {
            Thread.Sleep(3000);
            Console.WriteLine(obj + " Return from Worker thread!");
        }
    }
}
