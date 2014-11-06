using System;
using System.Diagnostics;
using System.Threading;

namespace 加锁性能的影响
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            const int iterationNumber = 5000000;
            // 不采用锁的情况
            // StartNew方法 对新的 Stopwatch 实例进行初始化，将运行时间属性设置为零，然后开始测量运行时间。
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < iterationNumber; i++)
            {
                x++;
            }
            Console.WriteLine("Use the all time is :{0} ms", sw.ElapsedMilliseconds);
            sw.Restart();
            for (int i = 0; i < iterationNumber; i++)
            {
                Interlocked.Increment(ref x);
            }
            Console.WriteLine("Use the all time is :{0} ms", sw.ElapsedMilliseconds);
            Console.Read();
        }
    }
}
