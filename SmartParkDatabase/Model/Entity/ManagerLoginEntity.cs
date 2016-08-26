using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartParkDatabase.Common.System;

namespace SmartParkDatabase.Model.Entity
{
    public class ManagerLoginEntity : IEntity
    {
        private int id = DefaultValue.DINT;
        private Nullable<DateTime> loginTime = DefaultValue.DDATATIME;
        private Nullable<DateTime> logoutTime = DefaultValue.DDATATIME;
        private int managerId = DefaultValue.DINT;

        public static string TableName = "sps_manager_login";

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public DateTime? LoginTime
        {
            get
            {
                return loginTime;
            }

            set
            {
                loginTime = value;
            }
        }

        public DateTime? LogoutTime
        {
            get
            {
                return logoutTime;
            }

            set
            {
                logoutTime = value;
            }
        }

        public int ManagerId
        {
            get
            {
                return managerId;
            }

            set
            {
                managerId = value;
            }
        }

        public static class Fields
        {
            public static string Id = "id";
            public static string LoginTime = "login_time";
            public static string LogoutTime = "logout_time";
            public static string ManagerId = "manager_id";
        }

        public void FillEntityFromData(Dictionary<string, string> data)
        {
            foreach (KeyValuePair<string, string> item in data)
            {
                if (item.Key.Equals(Fields.Id))
                {
                    this.id = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.LoginTime))
                {
                    this.loginTime = Convert.ToDateTime(item.Value);
                }
                if (item.Key.Equals(Fields.LogoutTime))
                {
                    this.logoutTime = Convert.ToDateTime(item.Value);
                }
                if (item.Key.Equals(Fields.ManagerId))
                {
                    this.managerId = Convert.ToInt32(item.Value);
                }
            }
        }

        public Dictionary<string, string> GetDataFromEntity()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            if (this.id != DefaultValue.DINT)
            {
                data.Add(Fields.Id, Convert.ToString(this.id));
            }
            if (this.loginTime != DefaultValue.DDATATIME)
            {
                data.Add(Fields.LoginTime, Convert.ToString(this.loginTime));
            }
            if (this.logoutTime != DefaultValue.DDATATIME)
            {
                data.Add(Fields.LogoutTime, Convert.ToString(this.logoutTime));
            }
            if (this.managerId != DefaultValue.DINT)
            {
                data.Add(Fields.ManagerId, Convert.ToString(this.managerId));
            }

            return data;
        }

        public override string ToString()
        {
            return String.Format("停车场管理员登录ID={0}, 管理员登入时间LoginTime={1}, 管理员登出时间LogoutTime={2}, 管理员Id={3}",
                this.id, this.loginTime, this.logoutTime, this.managerId);
        }
    }
}
