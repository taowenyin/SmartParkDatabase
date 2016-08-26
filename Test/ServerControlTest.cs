using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkDatabase.Control;
using static SmartParkDatabase.Common.System;
using SmartParkDatabase.Model.Entity;

namespace Test
{
    [TestClass]
    public class ServerControlTest
    {
        [TestMethod]
        public void TestServerMethod()
        {
            ServerPreferencesControl control = new ServerPreferencesControl();
            control.LoadDefaultConfig();

            Assert.AreEqual(control.GetServer(), Database.SERVER, "获取默认服务器地址错误");
            Assert.AreEqual(control.GetPort(), Database.PORT, "获取默认服务器端口错误");
            Assert.AreEqual(control.GetUser(), Database.USER, "获取默认用户名错误");
            Assert.AreEqual(control.GetPassword(), Database.PASSWORD, "获取默认密码错误");
            Assert.AreEqual(control.GetDatabase(), Database.DATABASE, "获取默认数据库错误");
        }

        [TestMethod]
        public void TestChangeServerMethod()
        {
            ServerPreferencesControl control = new ServerPreferencesControl();

            control.SetDatabase("123");
        }

        [TestMethod]
        public void TestServerEntityMethod()
        {
            ServerPreferencesControl control = new ServerPreferencesControl();
            control.LoadDefaultConfig();

            ServerEntity entity = control.GetServerConfig();
            Assert.AreEqual(entity.Server, Database.SERVER, "获取默认服务器地址错误");
            Assert.AreEqual(entity.Port, Database.PORT, "获取默认服务器端口错误");
            Assert.AreEqual(entity.User, Database.USER, "获取默认用户名错误");
            Assert.AreEqual(entity.Password, Database.PASSWORD, "获取默认密码错误");
            Assert.AreEqual(entity.Database, Database.DATABASE, "获取默认数据库错误");
        }
    }
}
