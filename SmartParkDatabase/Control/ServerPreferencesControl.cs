using SmartParkDatabase.Model;
using SmartParkDatabase.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartParkDatabase.Common.System;

namespace SmartParkDatabase.Control
{
    public class ServerPreferencesControl : IControl
    {
        private ServerPreferencesModel model = null;

        public ServerPreferencesControl()
        {
            model = new ServerPreferencesModel();
        }

        public void LoadDefaultConfig()
        {
            model.SetServer(Database.SERVER);
            model.SetPort(Database.PORT);
            model.SetUser(Database.USER);
            model.SetPassword(Database.PASSWORD);
            model.SetDatabase(Database.DATABASE);
            model.Commit();
        }

        public ServerEntity GetServerConfig()
        {
            ServerEntity entity = new ServerEntity();
            entity.Server = GetServer();
            entity.Port = GetPort();
            entity.User = GetUser();
            entity.Password = GetPassword();
            entity.Database = GetDatabase();

            return entity;
        }

        public void SetServerConfig(ServerEntity entity)
        {
            if(entity.Server != DefaultValue.DSTRING)
            {
                model.SetServer(entity.Server);
            }
            if(entity.Port != DefaultValue.DINT)
            {
                model.SetPort(entity.Port);
            }
            if(entity.User != DefaultValue.DSTRING)
            {
                model.SetUser(entity.User);
            }
            if(entity.Password != DefaultValue.DSTRING)
            {
                model.SetPassword(entity.Password);
            }
            if(entity.Database != DefaultValue.DSTRING)
            {
                model.SetDatabase(entity.Database);
            }

            model.Commit();
        }

        public void SetServer(string server)
        {
            model.SetServer(server);
            model.Commit();
        }

        public string GetServer()
        {
            return model.GetServer();
        }

        public void SetPort(int port)
        {
            model.SetPort(port);
            model.Commit();
        }

        public int GetPort()
        {
            return model.GetPort();
        }

        public void SetUser(string user)
        {
            model.SetUser(user);
            model.Commit();
        }

        public string GetUser()
        {
            return model.GetUser();
        }

        public void SetPassword(string password)
        {
            model.SetPassword(password);
            model.Commit();
        }

        public string GetPassword()
        {
            return model.GetPassword();
        }

        public void SetDatabase(string database)
        {
            model.SetDatabase(database);
            model.Commit();
        }

        public string GetDatabase()
        {
            return model.GetDatabase();
        }
    }
}
