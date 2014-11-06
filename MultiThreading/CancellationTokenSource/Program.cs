using System;
using System.Threading;

namespace 协作式取消
{
    class Program
    {
        private delegate void MyTestdelegate();
        static void Main(string[] args)
        {
            ThreadPool.SetMaxThreads(1000, 1000);
            Console.WriteLine("Main Thread run");
            PrintMessage("start");
            MyTestdelegate testdelegate = Run;

            // 异步调用委托
            IAsyncResult result = testdelegate.BeginInvoke(null, null);
            Run();
            Console.ReadKey();
        }
        private static void Run()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            // 这里用Lambda表达式的方式和使用委托的效果一样的，只是用了Lambda后可以少定义一个方法。
            // 这在这里就是让大家明白怎么lambda表达式如何由委托转变的
            ////ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 1000));

            ThreadPool.QueueUserWorkItem(Callback, cts.Token);

            Console.WriteLine("Press Enter key to cancel the operation\n");
            Console.ReadLine();

            // 传达取消请求
            cts.Cancel();
        }

        private static void Callback(object state)
        {
            Thread.Sleep(1000);
            PrintMessage("Asynchoronous Method Start");
            CancellationToken token = (CancellationToken)state;
            Count(token, 1000);
        }

        // 执行的操作，当受到取消请求时停止数数
        private static void Count(CancellationToken token, int countto)
        {
            for (int i = 0; i < countto; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is canceled");
                    break;
                }

                Console.WriteLine(i);
                Thread.Sleep(300);
            }

            Console.WriteLine("Cout has done");
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
