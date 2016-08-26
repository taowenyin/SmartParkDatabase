using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartParkDatabase.Common.System;

namespace SmartParkDatabase.Model.Entity
{
    class ParkingTicketInfoEntity : IEntity
    {
        private int id = DefaultValue.DINT;
        private string no = DefaultValue.DSTRING;
        private Nullable<DateTime> useTime = DefaultValue.DDATATIME;
        private int type = DefaultValue.DINT;
        private int payId = DefaultValue.DINT;

        public static string TableName = "sps_parking_ticket_info";

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

        public string No
        {
            get
            {
                return no;
            }

            set
            {
                no = value;
            }
        }

        public DateTime? UseTime
        {
            get
            {
                return useTime;
            }

            set
            {
                useTime = value;
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

        public int PayId
        {
            get
            {
                return payId;
            }

            set
            {
                payId = value;
            }
        }

        public static class Fields
        {
            public static string Id = "id";
            public static string No = "no";
            public static string UseTime = "use_time";
            public static string Type = "type";
            public static string PayId = "pay_id";
        }

        public void FillEntityFromData(Dictionary<string, string> data)
        {
            foreach (KeyValuePair<string, string> item in data)
            {
                if (item.Key.Equals(Fields.Id))
                {
                    this.id = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.No))
                {
                    this.no = item.Value;
                }
                if (item.Key.Equals(Fields.UseTime))
                {
                    this.useTime = Convert.ToDateTime(item.Value);
                }
                if (item.Key.Equals(Fields.Type))
                {
                    this.type = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.PayId))
                {
                    this.payId = Convert.ToInt32(item.Value);
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
            if (this.no != DefaultValue.DSTRING)
            {
                data.Add(Fields.No, this.no);
            }
            if (this.useTime != DefaultValue.DDATATIME)
            {
                data.Add(Fields.UseTime, this.useTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (this.type != DefaultValue.DINT)
            {
                data.Add(Fields.Type, Convert.ToString(this.type));
            }
            if (this.payId != DefaultValue.DINT)
            {
                data.Add(Fields.PayId, Convert.ToString(this.payId));
            }

            return data;
        }

        public override string ToString()
        {
            return String.Format("停车用券ID={0}, 优惠券号码No={1}, 使用时间UseTime={2},优惠券类型Type={3}, 支付ID={4}",
                this.id, this.no, this.useTime, this.type, this.payId);
        }
    }
}
