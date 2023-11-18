using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Program_2;
using System.Linq;

namespace UnitTest_Program2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Queue queue = new Queue(10);
            queue.Push(1);
            if(queue.Pop() != 1)
            {
                Assert.Fail();
            }
            queue.Push(2);
            if(queue.Front() != 2) 
            {
                Assert.Fail();
            }
        }
    }
}
