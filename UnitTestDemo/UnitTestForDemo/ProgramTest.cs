using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestDemo;

namespace UnitTestForDemo
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void AddTest()
        {
            const int num1 = 100;
            const int num2 = 200;
            Assert.AreEqual(Program.Add(num1, num2), 300);
        }

        [TestMethod]
        public void SubTest()
        {
            const int num1 = 300;
            const int num2 = 200;
            Assert.AreEqual(Program.Sub(num1, num2), 100);
        }
    }
}
