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
    }
}
