namespace 简单工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Food food1 = SimpleFactory.CreatFood("西红柿");
            Food food2 = SimpleFactory.CreatFood("鸡蛋");

        }
    }

    /// <summary>
    /// 简单工厂类, 负责 炒菜
    /// </summary>
    static class SimpleFactory
    {
        public static Food CreatFood(string type)
        {
            switch (type)
            {
                case "西红柿":
                    return new Tomato();
                case "鸡蛋":
                    return new Eggs();
                default:
                    return null;
            }
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
