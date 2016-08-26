using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartParkDatabase.Control;
using SmartParkDatabase.Model.Entity;
using SmartParkDatabase.Model.View;

namespace Test
{
    [TestClass]
    public class ParkMemberTest
    {
        public ParkMemberTest()
        {
            SystemControl control = new SystemControl();
            bool res = control.CheckDatabaseOrCreate();
        }

        [TestMethod]
        public void AddMemberTypeTestMethod()
        {
            ParkMemberControl control = new ParkMemberControl();

            int type = control.AddMemberType("月卡", 30, 100, 1);
            Assert.AreEqual(type > 0, true, "添加会员卡类型失败");

            int typeId = control.GetMemberTypeId("月卡", 1);
            Assert.AreEqual(typeId > 0, true, "获取会员卡ID失败");

            MemberTypeEntity entity = control.GetMemberTypeInfo(typeId);
            Assert.IsNotNull(entity, "获取会员类型失败");
        }

        [TestMethod]
        public void AddMemberTestMethod()
        {
            ParkMemberControl control = new ParkMemberControl();

            int id = control.AddParkMember("苏E84X76", 1);
            Assert.AreEqual(id > 0, true, "添加会员失败");
        }

        [TestMethod]
        public void GetCurrentMemberTestMethod()
        {
            ParkMemberControl control = new ParkMemberControl();

            //ViewMemberInfoEntity member = control.GetCurrentMemberInfo("苏E84X76", 1);
            //Assert.IsNotNull(member, "获取会员信息失败");
        }
    }
}
