using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkDatabase.Control;
using SmartParkDatabase.Model.Entity;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class ParkTicketControlTest
    {
        public ParkTicketControlTest()
        {
            SystemControl control = new SystemControl();
            bool res = control.CheckDatabaseOrCreate();
        }

        [TestMethod]
        public void AddTicketTypeTestMethod()
        {
            ParkTicketControl control = new ParkTicketControl();
            int ticket = control.AddParkingTicketType(1, "3小时免费券", 3);
            Assert.AreEqual(ticket > 0, true, "添加停车券失败");
        }

        [TestMethod]
        public void GetAllParkingTicketTypeTestMethod()
        {
            ParkTicketControl control = new ParkTicketControl();
            List<TicketTypeEntity> ticketTypeList = control.GetAllParkingTicketType(1);
            Assert.IsNotNull(ticketTypeList);
        }
    }
}
