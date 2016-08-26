using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkDatabase.Control;
using SmartParkDatabase.Model.Entity;

namespace Test
{
    [TestClass]
    public class ParkManagerControlTest
    {
        [TestMethod]
        public void RegisterManagerTestMethod()
        {
            ParkManagerControl control = new ParkManagerControl();

            int managerId = control.RegisterParkManager(1, "admin", "admin");
            Assert.AreEqual(managerId > 0, true, "添加管理员失败");

            int doormanId = control.RegisterDoorman(1, "doorman", "doorman");
            Assert.AreEqual(doormanId > 0, true, "添加门卫失败");
        }

        [TestMethod]
        public void GetManagerTestMethod()
        {
            ParkManagerControl control = new ParkManagerControl();

            ParkManagerEntity manager = control.GetParkManager(1);
            Assert.IsNotNull(manager, "获取停车场管理员失败");
            ParkManagerEntity doorman = control.GetParkDoorman(2);
            Assert.IsNotNull(doorman, "获取停车场门卫失败");
        }

        [TestMethod]
        public void ManagerLoginTestMethod()
        {
            ParkManagerControl control = new ParkManagerControl();

            ManagerLoginEntity managerLogin = control.ParkManagerLogin("admin", "admin", 1);
            Assert.IsNotNull(managerLogin, "管理员登录失败");
            ManagerLoginEntity dooormanLogin = control.DoormanLogin("doorman", "doorman", 1);
            Assert.IsNotNull(dooormanLogin, "门卫登录失败");

            int managerLogout = control.ParkManagerLogout(1);
            Assert.AreEqual(managerLogout > 0, true, "管理员登出失败");
            int doormanLogout = control.DoormanLogout(1);
            Assert.AreEqual(doormanLogout > 0, true, "门卫登出失败");
        }
    }
}
