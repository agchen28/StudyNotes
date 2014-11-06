﻿using System;
using System.Threading;

namespace 线程池
{
    class Program
    {
        static void Main(string[] args)
        {
            // 设置线程池中处于活动的线程的最大数目
            // 设置线程池中工作者线程数量为1000，I/O线程数量为1000
            ThreadPool.SetMaxThreads(1000, 1000);

            Console.WriteLine("Main Thread :queue an asynchoronous method.");
            PrintMessage("Main Thread start");

            ThreadPool.QueueUserWorkItem(AsyncMethod);
            ThreadPool.QueueUserWorkItem(delegate
            {
                Thread.Sleep(1000);
                PrintMessage("Asynchoronous Method");
                Console.WriteLine("Asynchoronous method has worked.");
            });
            Console.Read();

        }

        private static void AsyncMethod(object data)
        {
            Thread.Sleep(1000);
            PrintMessage("Asynchoronous Method");
            Console.WriteLine("Asynchoronous method has worked.");
        }

        private static void PrintMessage(string data)
        {
            int workThreadNumber;
            int ioThreadNumber;
            // 获得线程池中可用的线程，把获得的可用工作者线程数量赋给workthreadnumber变量
            // 获得的可用I/O线程数量给iothreadnumber变量
            ThreadPool.GetAvailableThreads(out workThreadNumber, out ioThreadNumber);

            Console.WriteLine("{0}\n CurrentThreadId is {1}\n CurrentThread is background :{2}\n WorkerThreadNumber is:{3}\n IOThreadNumbers is: {4}\n",
                data,
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.IsBackground,
                workThreadNumber,
                ioThreadNumber);
        }
    }
}
