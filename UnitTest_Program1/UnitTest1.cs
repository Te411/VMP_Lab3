using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Program;

namespace UnitTest_Program1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stack stack = new Stack(100);
            stack.Push(1);
            if(stack.Pop() != 1)
            {
                Assert.Fail();
            }
            stack.Push(5);
            if(stack.Back() != 5)
            {
                Assert.Fail();
            }
        }
    }
}
