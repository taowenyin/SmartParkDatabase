using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Model.Entity
{
    class ParkCurrentSpacesEntity : IEntity
    {
        private int id = Common.SystemConfig.DefaultValue.DINT;
        private int count = Common.SystemConfig.DefaultValue.DINT;
        private int parkId = Common.SystemConfig.DefaultValue.DINT;

        public static string TableName = "sps_park_current_spaces";

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

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
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
            public static string Count = "count";
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
                if (item.Key.Equals(Fields.Count))
                {
                    this.count = Convert.ToInt32(item.Value);
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
            if (this.count != Common.SystemConfig.DefaultValue.DINT)
            {
                data.Add(Fields.Count, Convert.ToString(this.count));
            }
            if (this.parkId != Common.SystemConfig.DefaultValue.DINT)
            {
                data.Add(Fields.ParkId, Convert.ToString(this.parkId));
            }

            return data;
        }

        public override string ToString()
        {
            return String.Format("停车场已占车位ID={0}, 停车场已占车位数Count={1}, 停车场ParkId={2}",
                this.id, this.count, this.parkId);
        }
    }
}
