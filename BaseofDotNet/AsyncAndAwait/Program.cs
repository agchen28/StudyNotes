using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("同步操作开始。。。。。。。。");
            SyncMethod(0);
            Console.WriteLine("同步操作结束。。。。。。。。");
            Console.WriteLine("异步操作开始。。。。。。。。");
            AsyncMethod(0);
            Console.WriteLine("异步操作结束。。。。。。。。");
            Console.ReadKey();
        }

        /// <summary>
        /// 同步方法
        /// </summary>
        /// <param name="input"></param>
        private static void SyncMethod(int input)
        {
            Console.WriteLine("同步方法开始");
            int result = SyncWork(input);
            Console.WriteLine("最终结果{0}", result);
            Console.WriteLine("同步方法结束");
        }

        /// <summary>
        /// 模拟耗时操作（同步）
        /// </summary>
        /// <param name="value"></param>
        private static int SyncWork(int value)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("耗时操作{0}", i);
                Thread.Sleep(1000);
                value++;
            }
            return value;
        }

        // 模拟耗时操作（同步方法）
        private static int SyncWork2(object input)
        {
            int val = (int)input;
            for (int i = 0; i < 5; ++i)
            {
                Console.WriteLine("耗时操作{0}", i);
                Thread.Sleep(100);
                val++;
            }
            return val;
        }

        /// <summary>
        /// 异步方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static async void AsyncMethod(int input)
        {
            Console.WriteLine("异步方法开始");
            //var result = await AsyncWork(input);
            var result = await Task.Factory.StartNew((Func<object, int>)SyncWork2, input);
            Console.WriteLine("最终结果{0}", result);
            Console.WriteLine("异步方法结束");
        }

        private static async Task<int> AsyncWork(int value)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("耗时操作{0}", i);
                await Task.Delay(1000);
                value++;
            }
            return value;
        }
    }
}
