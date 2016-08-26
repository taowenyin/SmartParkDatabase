using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartParkDatabase.Common.System;

namespace SmartParkDatabase.Model.View
{
    public class ViewMemberInfoEntity : IEntity
    {
        private int id = DefaultValue.DINT;
        private string license = DefaultValue.DSTRING;
        private string name = DefaultValue.DSTRING;
        private string phone = DefaultValue.DSTRING;
        private int typeId = DefaultValue.DINT;
        private string typeName = DefaultValue.DSTRING;
        private int typeTime = DefaultValue.DINT;
        private int typePrice = DefaultValue.DINT;
        private int parkId = DefaultValue.DINT;
        private int deadlineId = DefaultValue.DINT;
        private Nullable<DateTime> beginTime = DefaultValue.DDATATIME;
        private Nullable<DateTime> endTime = DefaultValue.DDATATIME;

        public static string TableName = "sps_view_member_info";

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

        public int TypeId
        {
            get
            {
                return typeId;
            }

            set
            {
                typeId = value;
            }
        }

        public string TypeName
        {
            get
            {
                return typeName;
            }

            set
            {
                typeName = value;
            }
        }

        public int TypeTime
        {
            get
            {
                return typeTime;
            }

            set
            {
                typeTime = value;
            }
        }

        public int TypePrice
        {
            get
            {
                return typePrice;
            }

            set
            {
                typePrice = value;
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

        public int DeadlineId
        {
            get
            {
                return deadlineId;
            }

            set
            {
                deadlineId = value;
            }
        }

        public DateTime? BeginTime
        {
            get
            {
                return beginTime;
            }

            set
            {
                beginTime = value;
            }
        }

        public DateTime? EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
            }
        }

        public static class Fields
        {
            public static string Id = "id";
            public static string License = "license";
            public static string Name = "name";
            public static string Phone = "phone";
            public static string TypeId = "type_id";
            public static string TypeName = "type_name";
            public static string TypeTime = "type_time";
            public static string TypePrice = "type_price";
            public static string ParkId = "park_id";
            public static string DeadlineId = "deadline_id";
            public static string BeginTime = "begin_time";
            public static string EndTime = "end_time";
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
                if (item.Key.Equals(Fields.TypeId))
                {
                    this.typeId = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.TypeName))
                {
                    this.typeName = item.Value;
                }
                if (item.Key.Equals(Fields.TypeTime))
                {
                    this.typeTime = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.TypePrice))
                {
                    this.typePrice = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.ParkId))
                {
                    this.parkId = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.DeadlineId))
                {
                    this.deadlineId = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.BeginTime))
                {
                    this.beginTime = Convert.ToDateTime(item.Value);
                }
                if (item.Key.Equals(Fields.EndTime))
                {
                    this.endTime = Convert.ToDateTime(item.Value);
                }
            }
        }

        public Dictionary<string, string> GetDataFromEntity()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            if (this.id != DefaultValue.DINT)
            {
                data.Add(Fields.Id, Convert.ToString(this.Id));
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
            if (this.typeId != DefaultValue.DINT)
            {
                data.Add(Fields.TypeId, Convert.ToString(this.typeId));
            }
            if (this.typeName != DefaultValue.DSTRING)
            {
                data.Add(Fields.TypeName, Convert.ToString(this.typeName));
            }
            if (this.typeTime != DefaultValue.DINT)
            {
                data.Add(Fields.TypeTime, Convert.ToString(this.typeTime));
            }
            if (this.typePrice != DefaultValue.DINT)
            {
                data.Add(Fields.TypePrice, Convert.ToString(this.typePrice));
            }
            if (this.parkId != DefaultValue.DINT)
            {
                data.Add(Fields.ParkId, Convert.ToString(this.parkId));
            }
            if (this.deadlineId != DefaultValue.DINT)
            {
                data.Add(Fields.DeadlineId, Convert.ToString(this.deadlineId));
            }
            if (this.beginTime != DefaultValue.DDATATIME)
            {
                data.Add(Fields.BeginTime, Convert.ToString(this.beginTime));
            }
            if (this.endTime != DefaultValue.DDATATIME)
            {
                data.Add(Fields.EndTime, Convert.ToString(this.endTime));
            }

            return data;
        }

        public override string ToString()
        {
            return String.Format("会员ID={0}, 会员车牌号License={1}, 会员姓名Name={2}, 会员电话Phone={3}, 会员类型Type={4}, 会员类型名称TypeName={5}, 会员类型单位时长TypeTime={6}, 会员类型单价TypePrice={7}, 停车场ID={8} ,会员时间线DeadlineId={9}, 会员开始时间BeginTime={10}, 会员结束时间EndTime={11},",
                this.id, this.license, this.name, this.phone, this.typeId, this.typeName, this.typeTime, this.typePrice, this.parkId, this.deadlineId, Convert.ToString(this.beginTime.Value), Convert.ToString(this.endTime.Value));
        }
    }
}
