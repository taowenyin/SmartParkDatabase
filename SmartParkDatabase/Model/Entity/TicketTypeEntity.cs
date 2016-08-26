using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartParkDatabase.Common.System;

namespace SmartParkDatabase.Model.Entity
{
    public class TicketTypeEntity : IEntity
    {
        private int id = DefaultValue.DINT;
        private string name = DefaultValue.DSTRING;
        private int freeTime = DefaultValue.DINT;
        private int parkId = DefaultValue.DINT;

        public static string TableName = "sps_ticket_type";

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
            public static string FreeTime = "freetime";
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
                if (item.Key.Equals(Fields.FreeTime))
                {
                    this.freeTime = Convert.ToInt32(item.Value);
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

            if (this.id != DefaultValue.DINT)
            {
                data.Add(Fields.Id, Convert.ToString(this.id));
            }
            if (this.name != DefaultValue.DSTRING)
            {
                data.Add(Fields.Name, Convert.ToString(this.name));
            }
            if (this.freeTime != DefaultValue.DINT)
            {
                data.Add(Fields.FreeTime, Convert.ToString(this.freeTime));
            }
            if (this.parkId != DefaultValue.DINT)
            {
                data.Add(Fields.ParkId, Convert.ToString(this.parkId));
            }

            return data;
        }

        public override string ToString()
        {
            return String.Format("优惠券ID={0}, 优惠券名称Name={1}, 优惠券免费时长Freetime={2}, 停车场Id={3}",
                this.id, this.name, this.freeTime, this.parkId);
        }
    }
}
