using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkDatabase.Control;
using SmartParkDatabase.Model.Entity;
using System.Diagnostics;

namespace Test
{
    /// <summary>
    /// ParkControlTest 的摘要说明
    /// </summary>
    [TestClass]
    public class ParkControlTest
    {

        public ParkControlTest()
        {
            SystemControl control = new SystemControl();
            bool res = control.CheckDatabaseOrCreate();
        }
        [TestMethod]
        public void TestRegisterParkMethod()
        {
            ParkControl control = new ParkControl();
            int parkId = control.RegisterPark("独墅湖停车场", 3, 0, 300);
            Assert.AreEqual(parkId > 0, true, "添加停车场失败");
        }

        [TestMethod]
        public void TestGetParkMethod()
        {
            ParkControl control = new ParkControl();
            ParkInfoEntity entity = control.GetParkInfo(1);
            Debug.WriteLine(entity.ToString());
        }
    }
}
