using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Model.Entity
{
    public class ParkManagerEntity : IEntity
    {
        public enum ManagerType
        {
            MANAGER = 1,
            DOORMAN = 2,
            UNKNOWN = 3
        }

        private int id = Common.SystemConfig.DefaultValue.DINT;
        private string name = Common.SystemConfig.DefaultValue.DSTRING;
        private string password = Common.SystemConfig.DefaultValue.DSTRING;
        private string nickname = Common.SystemConfig.DefaultValue.DSTRING;
        private ManagerType type = ManagerType.UNKNOWN;
        private int parkId = Common.SystemConfig.DefaultValue.DINT;

        public static string TableName = "sps_park_manager";

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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }

            set
            {
                nickname = value;
            }
        }

        internal ManagerType Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public int ParkId
        {
            get
            {
                return parkId;
            }

            set
            {
                parkId = value;
            }
        }

        public static class Fields
        {
            public static string Id = "id";
            public static string Name = "name";
            public static string Password = "password";
            public static string Nickname = "nickname";
            public static string Type = "type";
            public static string ParkId = "park_id";
        }

        public void FillEntityFromData(Dictionary<string, string> data)
        {
            foreach (KeyValuePair<string, string> item in data)
            {
                if (item.Key.Equals(Fields.Id))
                {
                    this.id = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.Name))
                {
                    this.name = item.Value;
                }
                if (item.Key.Equals(Fields.Password))
                {
                    this.password = item.Value;
                }
                if (item.Key.Equals(Fields.Nickname))
                {
                    this.nickname = item.Value;
                }
                if (item.Key.Equals(Fields.Type))
                {
                    if (Convert.ToInt32(item.Value) == 1)
                    {
                        this.type = ManagerType.MANAGER;
                    }
                    else if (Convert.ToInt32(item.Value) == 2)
                    {
                        this.type = ManagerType.DOORMAN;
                    }
                    else
                    {
                        this.type = ManagerType.UNKNOWN;
                    }
                }
                if (item.Key.Equals(Fields.ParkId))
                {
                    this.parkId = Convert.ToInt32(item.Value);
                }
            }
        }

        public Dictionary<string, string> GetDataFromEntity()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            if (this.id != Common.SystemConfig.DefaultValue.DINT)
            {
                data.Add(Fields.Id, Convert.ToString(this.id));
            }
            if (this.name != Common.SystemConfig.DefaultValue.DSTRING)
            {
                data.Add(Fields.Name, this.name);
            }
            if (this.password != Common.SystemConfig.DefaultValue.DSTRING)
            {
                data.Add(Fields.Password, this.password);
            }
            if (this.nickname != Common.SystemConfig.DefaultValue.DSTRING)
            {
                data.Add(Fields.Nickname, this.nickname);
            }
            if (this.type != ManagerType.UNKNOWN)
            {
                if (this.type.HasFlag(ManagerType.MANAGER))
                {
                    data.Add(Fields.Type, ((int)ManagerType.MANAGER).ToString());
                }
                if (this.type.HasFlag(ManagerType.DOORMAN))
                {
                    data.Add(Fields.Type, ((int)ManagerType.DOORMAN).ToString());
                }
            }
            if (this.parkId != Common.SystemConfig.DefaultValue.DINT)
            {
                data.Add(Fields.ParkId, Convert.ToString(this.parkId));
            }

            return data;
        }

        public override string ToString()
        {
            string managerType = null;
            if (this.type.HasFlag(ManagerType.MANAGER))
            {
                managerType = "管理员";
            }
            else if (this.type.HasFlag(ManagerType.DOORMAN))
            {
                managerType = "门卫";
            }
            else
            {
                managerType = "未知";
            }

            return String.Format("管理员ID={0}, 管理员名称Name={1}, 管理员密码Password={2}, 管理员昵称Nickname={3}, 管理员类型Type={4}, 停车场ID={5}",
                this.id, this.name, this.password, this.nickname, managerType, this.parkId);
        }
    }
}
