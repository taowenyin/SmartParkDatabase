using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Model.Entity
{
    public class MemberTypeEntity : IEntity
    {
        private int id = Common.SystemConfig.DefaultValue.DINT;
        private string name = Common.SystemConfig.DefaultValue.DSTRING;
        private int time = Common.SystemConfig.DefaultValue.DINT;
        private int price = Common.SystemConfig.DefaultValue.DINT;
        private int parkId = Common.SystemConfig.DefaultValue.DINT;

        public static string TableName = "sps_member_type";

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

        public int Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
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
            public static string Time = "time";
            public static string Price = "price";
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
                if (item.Key.Equals(Fields.Time))
                {
                    this.time = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.Price))
                {
                    this.price = Convert.ToInt32(item.Value);
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
            if (this.time != Common.SystemConfig.DefaultValue.DINT)
            {
                data.Add(Fields.Time, Convert.ToString(this.time));
            }
            if (this.price != Common.SystemConfig.DefaultValue.DINT)
            {
                data.Add(Fields.Price, Convert.ToString(this.price));
            }
            if (this.parkId != Common.SystemConfig.DefaultValue.DINT)
            {
                data.Add(Fields.ParkId, Convert.ToString(this.parkId));
            }

            return data;
        }

        public override string ToString()
        {
            return String.Format("会员类型ID={0}, 会员类型名称Name={1}, 会员单位时长Time={2}, 会员单位价格Price={3}, 停车场ID={4}",
                this.id, this.name, this.time, this.price, this.parkId);
        }
    }
}
