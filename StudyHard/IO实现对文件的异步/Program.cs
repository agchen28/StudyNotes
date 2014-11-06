using System;
using System.IO;
using System.Text;
using System.Threading;

namespace IO实现对文件的异步
{
    class Program
    {
        const int Maxsize = 1024;
        static readonly byte[] Readbytes = new byte[Maxsize];
        static void Main(string[] args)
        {
            #region 写
            //ThreadPool.SetMaxThreads(1000, 1000);
            //PrintMessage("Main Thread Start..");

            //// 初始化FileStream对象
            //FileStream fileStream = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 100, true);

            ////打印文件流打开的方式
            //Console.WriteLine("filestream is {0} opened Asynchronously", fileStream.IsAsync ? "" : "not");

            //const string writemessage = "An operation Use asynchronous method to write message.......................";
            //byte[] writeBytes = Encoding.Unicode.GetBytes(writemessage);
            //Console.WriteLine("message size is {0} bytes/n", writeBytes.Length);
            //// 调用异步写入方法比信息写入到文件中
            //fileStream.BeginWrite(writeBytes, 0, writeBytes.Length, EndWriteCallback, fileStream);
            //fileStream.Flush();
            //Console.Read(); 
            #endregion

            #region 读
            ThreadPool.SetMaxThreads(1000, 1000);
            PrintMessage("Main Thread Start...");

            // 初始化FileStream对象
            FileStream fileStream = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 100, true);
            // 异步读取文件内容
            fileStream.BeginRead(Readbytes, 0, Readbytes.Length, EndReadCallback, fileStream);
            Console.Read(); 
            #endregion
        }

        // 当把数据写入文件完成后调用此方法来结束异步写操作
        private static void EndWriteCallback(IAsyncResult asyncResult)
        {
            Thread.Sleep(500);
            PrintMessage("Asynchronous Method start");

            FileStream filestream = asyncResult.AsyncState as FileStream;

            // 结束异步写入数据
            if (filestream == null) return;
            filestream.EndWrite(asyncResult);
            filestream.Close();
        }

        private static void EndReadCallback(IAsyncResult asyncResult)
        {
            Thread.Sleep(1000);
            PrintMessage("Asynchronous Method start");

            // 把AsyncResult.AsyncState转换为State对象
            FileStream readstream = (FileStream)asyncResult.AsyncState;
            int readlength = readstream.EndRead(asyncResult);
            if (readlength <= 0)
            {
                Console.WriteLine("Read error");
                return;
            }

            string readmessage = Encoding.Unicode.GetString(Readbytes, 0, readlength);
            Console.WriteLine("Read Message is :" + readmessage);
            readstream.Close();
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
