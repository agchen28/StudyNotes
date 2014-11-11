using System;
using System.Collections.Generic;

namespace 建造者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            Builder builderWang = new BuildreWang();
            Builder buildreLi = new BuildreLi();
            director.Construct(builderWang);
            Computer computer1 = builderWang.GetComputer();
            computer1.Show();
            director.Construct(buildreLi);
            Computer computer2 = buildreLi.GetComputer();
            computer2.Show();
            Console.Read();
        }
    }

    /// <summary>
    /// 指挥者
    /// </summary>
    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }
    }

    /// <summary>
    /// 抽象建造者，这个场景下为 "组装人" ，这里也可以定义为接口
    /// </summary>
    public abstract class Builder
    {
        // 装CPU
        public abstract void BuildPartCPU();
        // 装主板
        public abstract void BuildPartMainBoard();

        // 当然还有装硬盘，电源等组件，这里省略

        // 获得组装好的电脑
        public abstract Computer GetComputer();
    }

    public class BuildreLi : Builder
    {
        readonly Computer _computer = new Computer();

        public override void BuildPartCPU()
        {
            _computer.Add("CPU1");
        }

        public override void BuildPartMainBoard()
        {
            _computer.Add("主板1");
        }

        public override Computer GetComputer()
        {
            return _computer;
        }
    }

    public class BuildreWang : Builder
    {
        readonly Computer _computer = new Computer();

        public override void BuildPartCPU()
        {
            _computer.Add("CPU2");
        }

        public override void BuildPartMainBoard()
        {
            _computer.Add("主板2");
        }

        public override Computer GetComputer()
        {
            return _computer;
        }
    }

    public class Computer
    {
        private readonly IList<string> _parts = new List<string>();

        //把单个组件添加到电脑组件集合中
        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("电脑正在组装中。。。。");
            foreach (var part in _parts)
            {
                Console.WriteLine("组件" + part + "已安装好。");
            }
            Console.WriteLine("电脑安装好了。");
        }
    }
}
