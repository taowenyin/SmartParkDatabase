using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartParkDatabase.Common.System;

namespace SmartParkDatabase.Model.Entity
{
    class ParkMemberEntity : IEntity
    {
        private int id = DefaultValue.DINT;
        private string license = DefaultValue.DSTRING;
        private string name = DefaultValue.DSTRING;
        private string phone = DefaultValue.DSTRING;
        private int type = DefaultValue.DINT;

        public static string TableName = "sps_park_member";

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

        public string License
        {
            get
            {
                return license;
            }

            set
            {
                license = value;
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

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public int Type
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

        public static class Fields
        {
            public static string Id = "id";
            public static string License = "license";
            public static string Name = "name";
            public static string Phone = "price";
            public static string Type = "type";
        }

        public void FillEntityFromData(Dictionary<string, string> data)
        {
            foreach (KeyValuePair<string, string> item in data)
            {
                if (item.Key.Equals(Fields.Id))
                {
                    this.id = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.License))
                {
                    this.license = item.Value;
                }
                if (item.Key.Equals(Fields.Name))
                {
                    this.name = item.Value;
                }
                if (item.Key.Equals(Fields.Phone))
                {
                    this.phone = item.Value;
                }
                if (item.Key.Equals(Fields.Type))
                {
                    this.type = Convert.ToInt32(item.Value);
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
            if (this.license != DefaultValue.DSTRING)
            {
                data.Add(Fields.License, this.license);
            }
            if (this.name != DefaultValue.DSTRING)
            {
                data.Add(Fields.Name, this.name);
            }
            if (this.phone != DefaultValue.DSTRING)
            {
                data.Add(Fields.Phone, this.phone);
            }
            if (this.type != DefaultValue.DINT)
            {
                data.Add(Fields.Type, Convert.ToString(this.type));
            }

            return data;
        }

        public override string ToString()
        {
            return String.Format("会员ID={0}, 会员车牌号License={1}, 会员姓名Name={2}, 会员电话Phone={3}, 会员类型Type={4}",
                this.id, this.license, this.name, this.phone, this.type);
        }
    }
}
