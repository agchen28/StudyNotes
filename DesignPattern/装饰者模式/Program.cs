using System;

namespace 装饰者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone=new Iphone();

            Decorator stickerPhone=new Sticker(phone);

            Decorator accessories=new Accessories(stickerPhone);
            accessories.Print();
            Console.Read();
        }
    }

    /// <summary>
    /// 手机抽象类，即装饰者模式中的抽象组件类
    /// </summary>
    public abstract class Phone
    {
        public abstract void Print();
    }

    /// <summary>
    /// 苹果手机，即装饰着模式中的具体组件类
    /// </summary>
    public class Iphone : Phone
    {
        public override void Print()
        {
            Console.WriteLine("Iphone.");
        }
    }

    /// <summary>
    /// 装饰抽象类,要让装饰完全取代抽象组件，所以必须继承自Photo
    /// </summary>
    public abstract class Decorator : Phone
    {
        private readonly Phone _phone;

        protected Decorator(Phone p)
        {
            this._phone = p;
        }

        public override void Print()
        {
            if (_phone != null)
            {
                _phone.Print();
            }
        }
    }

    /// <summary>
    /// 贴膜，即具体装饰者
    /// </summary>
    public class Sticker : Decorator
    {
        public Sticker(Phone p)
            : base(p)
        {
        }

        public override void Print()
        {
            base.Print();

            // 添加新的行为
            AddSticker();
        }

        private static void AddSticker()
        {
            Console.WriteLine("手机贴膜");
        }
    }

    /// <summary>
    /// 手机挂件
    /// </summary>
    public class Accessories : Decorator
    {
        public Accessories(Phone p)
            : base(p)
        {
        }

        public override void Print()
        {
            base.Print();

            AddAccessories();
        }

        /// <summary>
        /// 新的行为方法
        /// </summary>
        public static void AddAccessories()
        {
            Console.WriteLine("挂件");
        }
    }
}
