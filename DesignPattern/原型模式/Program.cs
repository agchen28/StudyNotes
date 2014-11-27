namespace 原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 孙悟空原型
    /// </summary>
    public abstract class MonkeyKingPrototype
    {
        private string Id { get; set; }

        protected MonkeyKingPrototype(string id)
        {
            this.Id = id;
        }

        protected abstract MonkeyKingPrototype Clone();
    }

    /// <summary>
    /// 创建具体原型
    /// </summary>
    public class ConcretePrototype : MonkeyKingPrototype
    {
        public ConcretePrototype(string id)
            : base(id)
        {

        }

        protected override MonkeyKingPrototype Clone()
        {
            // 调用MemberwiseClone方法实现的是浅拷贝，另外还有深拷贝
            return this.MemberwiseClone() as MonkeyKingPrototype;
        }
    }
}
