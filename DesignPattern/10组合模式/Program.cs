using System;
using System.Collections.Generic;

namespace _10组合模式
{
    /// 安全式的组合模式
    /// 此方式实现的组合模式把管理子对象的方法声明在树枝构件ComplexGraphics类中
    /// 这样如果叶子节点Line、Circle使用了Add或Remove方法时，就能在编译期间出现错误
    /// 但这种方式虽然解决了透明式组合模式的问题，但是它使得叶子节点和树枝构件具有不一样的接口。
    /// 所以这两种方式实现的组合模式各有优缺点，具体使用哪个，可以根据问题的实际情况而定
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public abstract class Grafics
    {
        public string Name { get; set; }

        protected Grafics(string name)
        {
            Name = name;
        }

        public abstract void Draw();
    }

    public class Line : Grafics
    {
        public Line(string name)
            : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("画" + base.Name);
        }
    }

    public class Circle : Grafics
    {
        public Circle(string name)
            : base(name)
        {
        }

        public override void Draw()
        {
            Console.WriteLine("画" + base.Name);
        }
    }

    public class CompelxGrafics:Grafics{
        private readonly List<Grafics> _complexGraficsList=new List<Grafics>(); 

        public CompelxGrafics(string name) : base(name)
        {
        }

        public override void Draw()
        {
            foreach (var graficse in _complexGraficsList)
            {
                graficse.Draw();
            }
        }

        public void Add(Grafics g)
        {
            _complexGraficsList.Add(g);
        }

        public void Remove(Grafics g)
        {
            _complexGraficsList.Remove(g);
        }
    }
}
