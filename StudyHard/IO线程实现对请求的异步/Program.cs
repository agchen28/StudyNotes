using System;
using System.Net;
using System.Threading;

namespace IO线程实现对请求的异步
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.SetMaxThreads(1000, 1000);
            PrintMessage("Main Thread start...");
            WebRequest request = WebRequest.Create("http://www.fanhuan.com/");
            request.BeginGetResponse(ProcessWebResponse, request);
            Console.ReadKey();
        }

        private static void ProcessWebResponse(IAsyncResult result)
        {
            Thread.Sleep(500);
            PrintMessage("Asynchronous Method start");
            WebRequest webRequest = (WebRequest)result.AsyncState;
            using (WebResponse response=webRequest.EndGetResponse(result))
            {
                Console.WriteLine("Content Length is : " + response.ContentLength);
            }
        }

        // 打印线程池信息
        private static void PrintMessage(String data)
        {
            int workthreadnumber;
            int iothreadnumber;

            // 获得线程池中可用的线程，把获得的可用工作者线程数量赋给workthreadnumber变量
            // 获得的可用I/O线程数量给iothreadnumber变量
            ThreadPool.GetAvailableThreads(out workthreadnumber, out iothreadnumber);

            Console.WriteLine("{0}\n CurrentThreadId is {1}\n CurrentThread is background :{2}\n WorkerThreadNumber is:{3}\n IOThreadNumbers is: {4}\n",
                data,
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.IsBackground,
                workthreadnumber,
                iothreadnumber);
        }
    }
}
