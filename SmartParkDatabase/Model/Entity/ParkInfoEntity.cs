using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Model.Entity
{
    public class ParkInfoEntity : IEntity
    {
        private int id = Common.SystemConfig.DefaultValue.DINT;
        private string name = Common.SystemConfig.DefaultValue.DSTRING;
        private int freeTime = Common.SystemConfig.DefaultValue.DINT;
        private int price = Common.SystemConfig.DefaultValue.DINT;
        private int spaces = Common.SystemConfig.DefaultValue.DINT;
        private string address = Common.SystemConfig.DefaultValue.DSTRING;
        private double longitude = Common.SystemConfig.DefaultValue.DDOUBLE;
        private double latitude = Common.SystemConfig.DefaultValue.DDOUBLE;

        public static string TableName = "sps_park_info";

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

        public int FreeTime
        {
            get
            {
                return freeTime;
            }

            set
            {
                freeTime = value;
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

        public int Spaces
        {
            get
            {
                return spaces;
            }

            set
            {
                spaces = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
            }
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }

        public static class Fields
        {
            public static string Id = "id";
            public static string Name = "name";
            public static string FreeTime = "freetime";
            public static string Price = "price";
            public static string Spaces = "spaces";
            public static string Address = "address";
            public static string Longitude = "longitude";
            public static string Latitude = "latitude";
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
                if (item.Key.Equals(Fields.FreeTime))
                {
                    this.freeTime = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.Price))
                {
                    this.price = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.Spaces))
                {
                    this.spaces = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.Address))
                {
                    this.address = item.Value;
                }
                if (item.Key.Equals(Fields.Longitude))
                {
                    this.longitude = Convert.ToDouble(item.Value);
                }
                if (item.Key.Equals(Fields.Latitude))
                {
                    this.latitude = Convert.ToDouble(item.Value);
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
            if (this.freeTime != Common.SystemConfig.DefaultValue.DINT)
            {
                data.Add(Fields.FreeTime, Convert.ToString(this.freeTime));
            }
            if (this.price != Common.SystemConfig.DefaultValue.DINT)
            {
                data.Add(Fields.Price, Convert.ToString(this.price));
            }
            if (this.spaces != Common.SystemConfig.DefaultValue.DINT)
            {
                data.Add(Fields.Spaces, Convert.ToString(this.spaces));
            }
            if (this.address != Common.SystemConfig.DefaultValue.DSTRING)
            {
                data.Add(Fields.Address, this.address);
            }
            if (this.longitude != Common.SystemConfig.DefaultValue.DDOUBLE)
            {
                data.Add(Fields.Longitude, Convert.ToString(this.longitude));
            }
            if (this.latitude != Common.SystemConfig.DefaultValue.DDOUBLE)
            {
                data.Add(Fields.Latitude, Convert.ToString(this.latitude));
            }

            return data;
        }

        public override string ToString()
        {
            return String.Format("停车场ID={0}, 停车场名称Name={1}, 停车场免费时长Freetime={2}, 停车场价格Price={3}, 停车场车位数Spaces={4}, 停车场地址Address={5}, 停车场经度Longitude={6}, 停车场纬度Latitude={7}",
                this.id, this.name, this.freeTime, this.price, this.spaces, this.address, this.longitude, this.latitude);
        }
    }
}
