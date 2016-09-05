using CSharedPreferences;
using SmartParkDatabase.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Model
{
    class ServerPreferencesModel : IModel
    {
        private SharedPreferences preference = null;
        private IEditor editor = null;

        public ServerPreferencesModel()
        {
            preference = SharedPreferences.GetInstance(Common.SystemConfig.Database.SHARED_PREFERENCES);
            editor = preference.GetEditor();
        }

        public void Commit()
        {
            editor.Commit();
        }

        public void SetServer(string server)
        {
            IEditor editor = preference.GetEditor();
            editor.PutString(ServerEntity.Fields.Server, server);
        }

        public string GetServer()
        {
            return preference.GetString(ServerEntity.Fields.Server, Common.SystemConfig.Database.SERVER);
        }

        public void SetPort(int port)
        {
            IEditor editor = preference.GetEditor();
            editor.PutInt(ServerEntity.Fields.Port, port);
        }

        public int GetPort()
        {
            return preference.GetInt(ServerEntity.Fields.Port, Common.SystemConfig.Database.PORT);
        }

        public void SetUser(string user)
        {
            IEditor editor = preference.GetEditor();
            editor.PutString(ServerEntity.Fields.User, user);
        }

        public string GetUser()
        {
            return preference.GetString(ServerEntity.Fields.User, Common.SystemConfig.Database.USER);
        }

        public void SetPassword(string password)
        {
            IEditor editor = preference.GetEditor();
            editor.PutString(ServerEntity.Fields.Password, password);
        }

        public string GetPassword()
        {
            return preference.GetString(ServerEntity.Fields.Password, Common.SystemConfig.Database.PASSWORD);
        }

        public void SetDatabase(string database)
        {
            IEditor editor = preference.GetEditor();
            editor.PutString(ServerEntity.Fields.Database, database);
        }

        public string GetDatabase()
        {
            return preference.GetString(ServerEntity.Fields.Database, Common.SystemConfig.Database.DATABASE);
        }
    }
}
