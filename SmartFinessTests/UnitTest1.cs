using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartFinessTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod()]
        public void SaveTest()
        {
            Assert.Fail();
        }
    }
}
