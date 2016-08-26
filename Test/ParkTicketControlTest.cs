using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkDatabase.Control;

namespace Test
{
    [TestClass]
    public class ParkTicketControlTest
    {
        [TestMethod]
        public void AddTicketTypeTestMethod()
        {
            ParkTicketControl control = new ParkTicketControl();
            int ticket = control.AddParkingTicketType(1, "3小时免费券", 3);
            Assert.AreEqual(ticket > 0, true, "添加停车券失败");
        }
    }
}
