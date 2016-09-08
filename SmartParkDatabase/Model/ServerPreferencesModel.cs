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

        /// <summary>
        /// 提交并保存到本地
        /// </summary>
        public void Commit()
        {
            editor.Commit();
        }

        /// <summary>
        /// 在内存中修改服务器地址
        /// </summary>
        /// <param name="server">服务器地址</param>
        public void SetServer(string server)
        {
            IEditor editor = preference.GetEditor();
            editor.PutString(ServerEntity.Fields.Server, server);
        }

        /// <summary>
        /// 获取服务器地址
        /// </summary>
        /// <returns>服务器地址</returns>
        public string GetServer()
        {
            return preference.GetString(ServerEntity.Fields.Server, Common.SystemConfig.Database.SERVER);
        }

        /// <summary>
        /// 在内存中修改服务器端口
        /// </summary>
        /// <param name="port">服务器端口</param>
        public void SetPort(int port)
        {
            IEditor editor = preference.GetEditor();
            editor.PutInt(ServerEntity.Fields.Port, port);
        }

        /// <summary>
        /// 获取服务器端口
        /// </summary>
        /// <returns>服务器端口</returns>
        public int GetPort()
        {
            return preference.GetInt(ServerEntity.Fields.Port, Common.SystemConfig.Database.PORT);
        }

        /// <summary>
        /// 设置服务器用户名
        /// </summary>
        /// <param name="user">服务器用户名</param>
        public void SetUser(string user)
        {
            IEditor editor = preference.GetEditor();
            editor.PutString(ServerEntity.Fields.User, user);
        }

        /// <summary>
        /// 获取服务器用户名
        /// </summary>
        /// <returns>服务器用户名</returns>
        public string GetUser()
        {
            return preference.GetString(ServerEntity.Fields.User, Common.SystemConfig.Database.USER);
        }

        /// <summary>
        /// 设置服务器密码
        /// </summary>
        /// <param name="password">服务器密码</param>
        public void SetPassword(string password)
        {
            IEditor editor = preference.GetEditor();
            editor.PutString(ServerEntity.Fields.Password, password);
        }

        /// <summary>
        /// 获取服务器密码
        /// </summary>
        /// <returns>服务器密码</returns>
        public string GetPassword()
        {
            return preference.GetString(ServerEntity.Fields.Password, Common.SystemConfig.Database.PASSWORD);
        }

        /// <summary>
        /// 设置链接的数据库名称
        /// </summary>
        /// <param name="database">数据库名称</param>
        public void SetDatabase(string database)
        {
            IEditor editor = preference.GetEditor();
            editor.PutString(ServerEntity.Fields.Database, database);
        }

        /// <summary>
        /// 获取数据库名称
        /// </summary>
        /// <returns>数据库名称</returns>
        public string GetDatabase()
        {
            return preference.GetString(ServerEntity.Fields.Database, Common.SystemConfig.Database.DATABASE);
        }
    }
}
