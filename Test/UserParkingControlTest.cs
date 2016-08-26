using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkDatabase.Control;
using SmartParkDatabase.Model.Entity;

namespace Test
{
    [TestClass]
    public class UserParkingControlTest
    {
        [TestMethod]
        public void UserParkingInTestMethod()
        {
            UserParkingControl control = new UserParkingControl();
            int parkingIn = control.UserParkingIn("123", "123", 1);
            Assert.AreEqual(parkingIn > 0, true, "汽车驶入失败");
        }

        [TestMethod]
        public void UserParkingOutTestMethod()
        {
            UserParkingControl control = new UserParkingControl();
            int payId = control.UserParkngOut("123", "1234", 1);
            Assert.AreEqual(payId > 0, true, "汽车驶出失败");
        }

        [TestMethod]
        public void FiguringUserPayInfoTestMethod()
        {
            UserParkingControl control = new UserParkingControl();
            ParkingPayInfoEntity entity = control.FiguringUserPayInfo(3);
            Assert.IsNotNull(entity, "计算用户费用失败");

            entity = control.UseParkingTicket(entity, 1);
        }

        [TestMethod]
        public void UserFinishPayTestMethod()
        {
            UserParkingControl control = new UserParkingControl();
            int effect = control.UserFinishPay(3);
            Assert.AreEqual(effect > 0, true, "更新支付状态失败");
        }
    }
}
