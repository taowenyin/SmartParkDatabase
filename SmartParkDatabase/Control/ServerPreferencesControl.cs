using SmartParkDatabase.Model;
using SmartParkDatabase.Model.Entity;

namespace SmartParkDatabase.Control
{
    public class ServerPreferencesControl : IControl
    {
        private ServerPreferencesModel model = null;

        public ServerPreferencesControl()
        {
            model = new ServerPreferencesModel();
        }

        /// <summary>
        /// 载入系统默认的数据库配置信息
        /// </summary>
        public void LoadDefaultConfig()
        {
            model.SetServer(Common.SystemConfig.Database.SERVER);
            model.SetPort(Common.SystemConfig.Database.PORT);
            model.SetUser(Common.SystemConfig.Database.USER);
            model.SetPassword(Common.SystemConfig.Database.PASSWORD);
            model.SetDatabase(Common.SystemConfig.Database.DATABASE);
            model.Commit();
        }

        /// <summary>
        /// 获取数据库配置信息
        /// </summary>
        /// <returns>数据库配置信息</returns>
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

        /// <summary>
        /// 保存新的数据库配置信息
        /// </summary>
        /// <param name="entity">数据库配置信息</param>
        public void SetServerConfig(ServerEntity entity)
        {
            if(entity.Server != Common.SystemConfig.DefaultValue.DSTRING)
            {
                model.SetServer(entity.Server);
            }
            if(entity.Port != Common.SystemConfig.DefaultValue.DINT)
            {
                model.SetPort(entity.Port);
            }
            if(entity.User != Common.SystemConfig.DefaultValue.DSTRING)
            {
                model.SetUser(entity.User);
            }
            if(entity.Password != Common.SystemConfig.DefaultValue.DSTRING)
            {
                model.SetPassword(entity.Password);
            }
            if(entity.Database != Common.SystemConfig.DefaultValue.DSTRING)
            {
                model.SetDatabase(entity.Database);
            }

            model.Commit();
        }

        /// <summary>
        /// 保存新的数据库地址
        /// </summary>
        /// <param name="server">新的数据库地址</param>
        public void SetServer(string server)
        {
            model.SetServer(server);
            model.Commit();
        }

        /// <summary>
        /// 获取数据库地址
        /// </summary>
        /// <returns>数据库地址</returns>
        public string GetServer()
        {
            return model.GetServer();
        }

        /// <summary>
        /// 设置数据库端口
        /// </summary>
        /// <param name="port">数据库端口</param>
        public void SetPort(int port)
        {
            model.SetPort(port);
            model.Commit();
        }

        /// <summary>
        /// 获取数据库端口
        /// </summary>
        /// <returns>数据库端口</returns>
        public int GetPort()
        {
            return model.GetPort();
        }

        /// <summary>
        /// 设置数据库用户名
        /// </summary>
        /// <param name="user">数据库用户名</param>
        public void SetUser(string user)
        {
            model.SetUser(user);
            model.Commit();
        }

        /// <summary>
        /// 获取数据库用户名
        /// </summary>
        /// <returns>数据库用户名</returns>
        public string GetUser()
        {
            return model.GetUser();
        }

        /// <summary>
        /// 设置数据库密码
        /// </summary>
        /// <param name="password">数据库密码</param>
        public void SetPassword(string password)
        {
            model.SetPassword(password);
            model.Commit();
        }

        /// <summary>
        /// 获取数据库密码
        /// </summary>
        /// <returns>数据库密码</returns>
        public string GetPassword()
        {
            return model.GetPassword();
        }

        /// <summary>
        /// 设置数据库名称
        /// </summary>
        /// <param name="database">数据库名称</param>
        public void SetDatabase(string database)
        {
            model.SetDatabase(database);
            model.Commit();
        }

        /// <summary>
        /// 获取数据库名称
        /// </summary>
        /// <returns>数据库名称</returns>
        public string GetDatabase()
        {
            return model.GetDatabase();
        }
    }
}
