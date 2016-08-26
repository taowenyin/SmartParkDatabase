using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkDatabase.Control;

namespace Test
{
    [TestClass]
    public class SystemControlTest
    {
        [TestMethod]
        public void CheckDatabaseOrCreateTestMethod()
        {
            SystemControl control = new SystemControl();
            bool res = control.CheckDatabaseOrCreate();
            Assert.IsTrue(res, "验证数据库或创建数据库失败");
        }
    }
}
