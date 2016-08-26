using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartParkDatabase.Common.System;

namespace SmartParkDatabase.Model.Entity
{
    public class ParkingPayInfoEntity : IEntity
    {
        public enum PayStatus
        {
            NO_PAY = 1,
            HAS_PAY = 2,
            UNKNOWN = 3
        }

        private int id = DefaultValue.DINT;
        private int hours = DefaultValue.DINT;
        private int price = DefaultValue.DINT;
        private PayStatus status = PayStatus.UNKNOWN;
        private int parkingId = DefaultValue.DINT;

        public static string TableName = "sps_parking_pay_info";

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

        public int Hours
        {
            get
            {
                return hours;
            }

            set
            {
                hours = value;
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

        internal PayStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int ParkingId
        {
            get
            {
                return parkingId;
            }

            set
            {
                parkingId = value;
            }
        }

        public static class Fields
        {
            public static string Id = "id";
            public static string Hours = "hours";
            public static string Price = "price";
            public static string Status = "status";
            public static string ParkingId = "parking_id";
        }

        public void FillEntityFromData(Dictionary<string, string> data)
        {
            foreach (KeyValuePair<string, string> item in data)
            {
                if (item.Key.Equals(Fields.Id))
                {
                    this.id = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.Hours))
                {
                    this.hours = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.Price))
                {
                    this.price = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.Status))
                {
                    if (Convert.ToInt32(item.Value) == 1)
                    {
                        this.status = PayStatus.NO_PAY;
                    }
                    else if (Convert.ToInt32(item.Value) == 2)
                    {
                        this.status = PayStatus.HAS_PAY;
                    }
                    else
                    {
                        this.status = PayStatus.UNKNOWN;
                    }
                }
                if (item.Key.Equals(Fields.ParkingId))
                {
                    this.parkingId = Convert.ToInt32(item.Value);
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
            if (this.hours != DefaultValue.DINT)
            {
                data.Add(Fields.Hours, Convert.ToString(this.hours));
            }
            if (this.price != DefaultValue.DINT)
            {
                data.Add(Fields.Price, Convert.ToString(this.price));
            }
            if (this.status != PayStatus.UNKNOWN)
            {
                if (this.status.HasFlag(PayStatus.NO_PAY))
                {
                    data.Add(Fields.Status, ((int)PayStatus.NO_PAY).ToString());
                }
                if (this.status.HasFlag(PayStatus.HAS_PAY))
                {
                    data.Add(Fields.Status, ((int)PayStatus.HAS_PAY).ToString());
                }
            }
            if (this.parkingId != DefaultValue.DINT)
            {
                data.Add(Fields.ParkingId, Convert.ToString(this.parkingId));
            }

            return data;
        }

        public override string ToString()
        {
            string payStatus = null;
            if (this.status.HasFlag(PayStatus.NO_PAY))
            {
                payStatus = "未支付";
            }
            else if (this.status.HasFlag(PayStatus.HAS_PAY))
            {
                payStatus = "已支付";
            }
            else
            {
                payStatus = "未知";
            }

            return String.Format("停车付款ID={0}, 停车时长Hours={1} 停车费用Price={2}, 支付状态Password={3}, 停车场ID={4}",
                this.id, this.hours, this.price, payStatus, this.parkingId);
        }
    }
}
