using CDatabase;
using CDatabase.Common;
using SmartParkDatabase.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Control
{
    public class SystemControl : IControl
    {
        private IDatabase database = null;

        public SystemControl()
        {
            ServerPreferencesControl server = new ServerPreferencesControl();
            ServerEntity entity = server.GetServerConfig();
            DbConfig config = new DbConfig();
            config.Server = entity.Server;
            config.Port = entity.Port;
            config.User = entity.User;
            config.Password = entity.Password;
            config.Database = entity.Database;

            database = DatabaseFactory.CreateDatabase(config, DbConfig.DbType.MYSQL);
        }

        /// <summary>
        /// 验证数据库，如果没有数据库则创建数据库
        /// </summary>
        /// <returns>True：验证或创建成功，Flase：验证或创建失败</returns>
        public bool CheckDatabaseOrCreate()
        {
            try
            {
                database.Open();
                return true;
            }
            catch (DatabaseException e)
            {
                if(e.GetErrorCode() == Error.ErrorCode.UNKNOWN_DATABASE)
                {
                    int effect = database.ExecSQL(Resource.InitSql, null);
                    if(effect > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 关闭数据库
        /// </summary>
        public void Close()
        {
            database.Close();
        }
    }
}
