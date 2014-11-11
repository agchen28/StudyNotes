namespace 工厂方法模式
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 抽象工厂类
    /// </summary>
    abstract class Factory
    {
        public abstract Food CreadFood();
    }

    class TomatoFactory : Factory
    {
        public override Food CreadFood()
        {
            return new Tomato();
        }
    }

    class EggsFactory : Factory
    {
        public override Food CreadFood()
        {
            return new Eggs();
        }
    }

    abstract class Food
    {
        public abstract string Print();
    }

    class Tomato : Food
    {
        public override string Print()
        {
            return "西红柿";
        }
    }

    class Eggs : Food
    {
        public override string Print()
        {
            return "鸡蛋";
        }
    }
}
