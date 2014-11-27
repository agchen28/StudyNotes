using System;

namespace 桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个遥控器
            RemoteControl remoteControl = new ConcreteControl();
            remoteControl.Implementor = new Changhong();
            remoteControl.On();
            remoteControl.TurnChannel();
            remoteControl.Off();
            Console.WriteLine();

            remoteControl.Implementor = new Xiaomi();
            remoteControl.On();
            remoteControl.TurnChannel();
            remoteControl.Off();
            Console.Read();
        }
    }

    /// <summary>
    /// 抽象概念中的遥控器，扮演抽象化角色
    /// </summary>
    public class RemoteControl
    {
        public TV Implementor { get; set; }

        public virtual void On()
        {
            Implementor.On();
        }
        public virtual void Off()
        {
            Implementor.Off();
        }
        public virtual void TurnChannel()
        {
            Implementor.TurnChannel();
        }
    }

    /// <summary>
    /// 具体实现类
    /// </summary>
    public class ConcreteControl : RemoteControl
    {
        public override void TurnChannel()
        {
            Console.WriteLine("---------------------");
            base.TurnChannel();
            Console.WriteLine("---------------------");
        }
    }
}
