using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Model.Entity
{
    class PayStatusEntity : IEntity
    {
        private int id = Common.SystemConfig.DefaultValue.DINT;
        private string name = Common.SystemConfig.DefaultValue.DSTRING;

        public static string TableName = "sps_pay_status";

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

        public static class Fields
        {
            public static string Id = "id";
            public static string Name = "name";
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

            return data;
        }

        public override string ToString()
        {
            return String.Format("付款状态ID={0}, 付款状态名称Name={1}",
                this.id, this.name);
        }
    }
}
