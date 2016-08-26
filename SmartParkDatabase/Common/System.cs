using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Common
{
    public class System
    {
        /// <summary>
        /// 系统常用的默认值
        /// </summary>
        public class DefaultValue
        {
            public static string DSTRING = null;
            public static int DINT = -1;
            public static double DDOUBLE = -1;
            public static Nullable<DateTime> DDATATIME = null;
        }

        /// <summary>
        /// 数据库配置信息
        /// </summary>
        public class Database
        {
            public static string SHARED_PREFERENCES = "database";

            public static string SERVER = "localhost";
            public static int PORT = 3306;
            public static string USER = "root";
            //public static string PASSWORD = "05200902";
            public static string PASSWORD = "Password12!";
            public static string DATABASE = "spslocal";
        }

        /// <summary>
        /// 停车场配置信息
        /// </summary>
        public class Park
        {
            public static string SHARED_PREFERENCES = "park";
        }
    }
}
