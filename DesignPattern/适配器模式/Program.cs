using System;

namespace 适配器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            // 现在客户端可以通过电适配要使用2个孔的插头了
            IThreeHole threehole = new ClassAdapter();
            threehole.Request();
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 三个孔的插头，也就是适配器模式中的目标角色
    /// </summary>
    public interface IThreeHole
    {
        void Request();
    }

    /// <summary>
    /// 两个孔的插头，源角色——需要适配的类
    /// </summary>
    public  class TwoHole
    {
        public void SpecificRequest()
        {
            Console.WriteLine("两个口的插头");
        }
    }

    /// <summary>
    /// 适配器类，接口要放在类的后面
    /// 适配器类提供了三个孔插头的行为，但其本质是调用两个孔插头的方法
    /// 类的适配器
    /// </summary>
    public class ClassAdapter : TwoHole, IThreeHole
    {
        /// <summary>
        /// 实现三个孔插头接口方法
        /// </summary>
        public void Request()
        {
            // 调用两个孔插头方法
            this.SpecificRequest();
        }
    }

    /// <summary>
    /// 适配器类，这里适配器类没有TwoHole类，
    /// 而是引用了TwoHole对象，所以是对象的适配器模式的实现
    /// </summary>
    public class ObjectAdapter:IThreeHole
    {
        private readonly TwoHole _twoHole = new TwoHole();
        public void Request()
        {
            _twoHole.SpecificRequest();
        }
    }
}
