﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Model.Entity
{
    class UserParkingInfoEntity : IEntity
    {
        private int id = Common.SystemConfig.DefaultValue.DINT;
        private string license = Common.SystemConfig.DefaultValue.DSTRING;
        private Nullable<DateTime> intoTime = Common.SystemConfig.DefaultValue.DDATATIME;
        private string intoPic = Common.SystemConfig.DefaultValue.DSTRING;
        private Nullable<DateTime> outTime = Common.SystemConfig.DefaultValue.DDATATIME;
        private string outPic = Common.SystemConfig.DefaultValue.DSTRING;
        private int parkId = Common.SystemConfig.DefaultValue.DINT;

        public static string TableName = "sps_user_parking_info";

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

        public DateTime? IntoTime
        {
            get
            {
                return intoTime;
            }

            set
            {
                intoTime = value;
            }
        }

        public string IntoPic
        {
            get
            {
                return intoPic;
            }

            set
            {
                intoPic = value;
            }
        }

        public DateTime? OutTime
        {
            get
            {
                return outTime;
            }

            set
            {
                outTime = value;
            }
        }

        public string OutPic
        {
            get
            {
                return outPic;
            }

            set
            {
                outPic = value;
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
            public static string License = "license";
            public static string IntoTime = "into_time";
            public static string IntoPic = "into_pic";
            public static string OutTime = "out_time";
            public static string OutPic = "out_pic";
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
                if (item.Key.Equals(Fields.License))
                {
                    this.license = item.Value;
                }
                if (item.Key.Equals(Fields.IntoTime))
                {
                    this.intoTime = Convert.ToDateTime(item.Value);
                }
                if (item.Key.Equals(Fields.IntoPic))
                {
                    this.intoPic = item.Value;
                }
                if (item.Key.Equals(Fields.OutTime))
                {
                    this.outTime = Convert.ToDateTime(item.Value);
                }
                if (item.Key.Equals(Fields.OutPic))
                {
                    this.outPic = item.Value;
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
            if (this.license != Common.SystemConfig.DefaultValue.DSTRING)
            {
                data.Add(Fields.License, this.license);
            }
            if (this.intoTime != Common.SystemConfig.DefaultValue.DDATATIME)
            {
                data.Add(Fields.IntoTime, this.intoTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (this.intoPic != Common.SystemConfig.DefaultValue.DSTRING)
            {
                data.Add(Fields.IntoPic, this.intoPic);
            }
            if (this.outTime != Common.SystemConfig.DefaultValue.DDATATIME)
            {
                data.Add(Fields.OutTime, this.outTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (this.outPic != Common.SystemConfig.DefaultValue.DSTRING)
            {
                data.Add(Fields.OutPic, this.outPic);
            }
            if (this.parkId != Common.SystemConfig.DefaultValue.DINT)
            {
                data.Add(Fields.ParkId, Convert.ToString(this.parkId));
            }

            return data;
        }

        public override string ToString()
        {
            return String.Format("用户停车ID={0}, 用户车牌号License={1}, 用户进入停车场时间IntoTime={2}, 用户进入停车场照片IntoPic={3}, 用户离开停车场时间OutTime={4}, 用户离开停车场照片OutPic={5}, 停车场Id={6}",
                this.id, this.license, this.intoTime, this.intoPic, this.outTime, this.outPic, this.parkId);
        }
    }
}
