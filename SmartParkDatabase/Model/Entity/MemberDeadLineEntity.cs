﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartParkDatabase.Common.System;

namespace SmartParkDatabase.Model.Entity
{
    class MemberDeadLineEntity : IEntity
    {
        private int id = DefaultValue.DINT;
        private Nullable<DateTime> beginTime = DefaultValue.DDATATIME;
        private Nullable<DateTime> endTime = DefaultValue.DDATATIME;
        private int memberId = DefaultValue.DINT;

        public static string TableName = "sps_member_deadline";

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

        public int MemberId
        {
            get
            {
                return memberId;
            }

            set
            {
                memberId = value;
            }
        }

        public static class Fields
        {
            public static string Id = "id";
            public static string BeginTime = "begin_time";
            public static string EndTime = "end_time";
            public static string MemberId = "member_id";
        }

        public void FillEntityFromData(Dictionary<string, string> data)
        {
            foreach (KeyValuePair<string, string> item in data)
            {
                if (item.Key.Equals(Fields.Id))
                {
                    this.id = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.BeginTime))
                {
                    this.beginTime = Convert.ToDateTime(item.Value);
                }
                if (item.Key.Equals(Fields.EndTime))
                {
                    this.endTime = Convert.ToDateTime(item.Value);
                }
                if (item.Key.Equals(Fields.MemberId))
                {
                    this.memberId = Convert.ToInt32(item.Value);
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
            if (this.beginTime != DefaultValue.DDATATIME)
            {
                data.Add(Fields.BeginTime, Convert.ToString(this.beginTime));
            }
            if (this.endTime != DefaultValue.DDATATIME)
            {
                data.Add(Fields.EndTime, Convert.ToString(this.endTime));
            }
            if (this.memberId != DefaultValue.DINT)
            {
                data.Add(Fields.MemberId, Convert.ToString(this.memberId));
            }

            return data;
        }

        public override string ToString()
        {
            return String.Format("会员截止时间ID={0}, 会员开始时间BeginTime={1}, 会员结束时间EndTime={2}, 会员ID={3}",
                this.id, this.beginTime, this.endTime, this.memberId);
        }
    }
}