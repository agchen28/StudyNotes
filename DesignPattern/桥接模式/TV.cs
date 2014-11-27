using System;

namespace 桥接模式
{
    public abstract class TV
    {

        public abstract void On();
        public abstract void Off();
        public abstract void TurnChannel();
    }

    public class Changhong : TV
    {
        public override void On()
        {
            Console.WriteLine("长虹电视打开");
        }

        public override void Off()
        {
            Console.WriteLine("长虹电视关闭");
        }

        public override void TurnChannel()
        {
            Console.WriteLine("长虹电视切换频道");
        }
    }

    public class Xiaomi : TV
    {
        public override void On()
        {
            Console.WriteLine("小米电视打开");
        }

        public override void Off()
        {
            Console.WriteLine("小米电视关闭");
        }

        public override void TurnChannel()
        {
            Console.WriteLine("小米电视切换频道");
        }
    }
}
