using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartParkDatabase.Common.System;

namespace SmartParkDatabase.Model.Entity
{
    public class ServerEntity : IEntity
    {
        private string server = DefaultValue.DSTRING;
        private int port = DefaultValue.DINT;
        private string user = DefaultValue.DSTRING;
        private string password = DefaultValue.DSTRING;
        private string database = DefaultValue.DSTRING;

        public string Server
        {
            get
            {
                return server;
            }

            set
            {
                server = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public string User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Database
        {
            get
            {
                return database;
            }

            set
            {
                database = value;
            }
        }

        public class Fields
        {
            public static string Server = "server";
            public static string Port = "port";
            public static string User = "user";
            public static string Password = "password";
            public static string Database = "database";
        }

        public Dictionary<string, string> GetDataFromEntity()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            if (this.server != DefaultValue.DSTRING)
            {
                data.Add(Fields.Server, this.server);
            }
            if (this.port != DefaultValue.DINT)
            {
                data.Add(Fields.Port, Convert.ToString(this.port));
            }
            if (this.user != DefaultValue.DSTRING)
            {
                data.Add(Fields.User, this.user);
            }
            if (this.password != DefaultValue.DSTRING)
            {
                data.Add(Fields.Password, this.password);
            }
            if (this.database != DefaultValue.DSTRING)
            {
                data.Add(Fields.Database, this.database);
            }

            return data;
        }

        public void FillEntityFromData(Dictionary<string, string> data)
        {
            foreach (KeyValuePair<string, string> item in data)
            {
                if (item.Key.Equals(Fields.Server))
                {
                    this.server = item.Value;
                }
                if (item.Key.Equals(Fields.Port))
                {
                    this.port = Convert.ToInt32(item.Value);
                }
                if (item.Key.Equals(Fields.User))
                {
                    this.user = item.Value;
                }
                if (item.Key.Equals(Fields.Password))
                {
                    this.password = item.Value;
                }
                if (item.Key.Equals(Fields.Database))
                {
                    this.database = item.Value;
                }
            }
        }

        public override string ToString()
        {
            return String.Format("服务器地址Server={0}, 服务器端口Port={1}, 服务器用户名User={2}, 服务器密码Password={3}, 数据库名称Database={4}",
                this.server, this.port, this.user, this.password, this.database);
        }
    }
}
