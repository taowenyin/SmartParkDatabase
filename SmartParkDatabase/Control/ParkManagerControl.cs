using CDatabase;
using SmartParkDatabase.Model.Entity;
using SmartParkDatabase.Model.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Control
{
    public class ParkManagerControl : IControl
    {
        private IDatabase database = null;

        public ParkManagerControl()
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
        /// 注册新停车场管理员
        /// </summary>
        /// <param name="parkId">停车场ID</param>
        /// <param name="name">管理员登录名</param>
        /// <param name="password">管理员密码</param>
        /// <param name="nickname">管理员昵称</param>
        /// <returns>新停车场管理员ID</returns>
        public int RegisterParkManager(int parkId, string name, string password, string nickname = null)
        {
            return RegisterManager(parkId, name, password, ParkManagerEntity.ManagerType.MANAGER, nickname);
        }

        /// <summary>
        /// 获取停车场管理员信息
        /// </summary>
        /// <param name="managerId">管理员ID</param>
        /// <returns>管理员信息</returns>
        public ParkManagerEntity GetParkManager(int managerId)
        {
            return GetParkManagerInfo(managerId, ParkManagerEntity.ManagerType.MANAGER);
        }

        /// <summary>
        /// 注册新停车场门卫
        /// </summary>
        /// <param name="parkId">停车场ID</param>
        /// <param name="name">门卫登录名</param>
        /// <param name="password">门卫登录密码</param>
        /// <param name="nickname">门卫昵称</param>
        /// <returns>新停车场门卫ID</returns>
        public int RegisterDoorman(int parkId, string name, string password, string nickname = null)
        {
            return RegisterManager(parkId, name, password, ParkManagerEntity.ManagerType.DOORMAN, nickname); ;
        }

        /// <summary>
        /// 获取停车场门卫信息
        /// </summary>
        /// <param name="doormanId">门卫ID</param>
        /// <returns>门卫信息</returns>
        public ParkManagerEntity GetParkDoorman(int doormanId)
        {
            return GetParkManagerInfo(doormanId, ParkManagerEntity.ManagerType.DOORMAN);
        }

        /// <summary>
        /// 停车场管理员登录
        /// </summary>
        /// <param name="name">管理员登录名</param>
        /// <param name="password">管理员登录密码</param>
        /// <param name="parkId">停车场ID</param>
        /// <returns>管理员登录信息</returns>
        public ManagerLoginEntity ParkManagerLogin(string name, string password, int parkId)
        {
            return ManagerLogin(name, password, ParkManagerEntity.ManagerType.MANAGER, parkId);
        }

        /// <summary>
        /// 停车场门卫登录
        /// </summary>
        /// <param name="name">门卫登录名</param>
        /// <param name="password">门卫登录密码</param>
        /// <param name="parkId">停车场ID</param>
        /// <returns>门卫登录信息</returns>
        public ManagerLoginEntity DoormanLogin(string name, string password, int parkId)
        {
            return ManagerLogin(name, password, ParkManagerEntity.ManagerType.DOORMAN, parkId);
        }

        /// <summary>
        /// 停车场门卫登出
        /// </summary>
        /// <param name="parkId">停车场ID</param>
        /// <returns>如果返回值>0，表示登出成功，否则等处失败</returns>
        public int DoormanLogout(int parkId)
        {
            return ManagerLogout(ParkManagerEntity.ManagerType.DOORMAN, parkId);
        }

        /// <summary>
        /// 停车场管理员登出
        /// </summary>
        /// <param name="parkId">停车场ID</param>
        /// <returns>如果返回值>0，表示登出成功，否则等处失败</returns>
        public int ParkManagerLogout(int parkId)
        {
            return ManagerLogout(ParkManagerEntity.ManagerType.MANAGER, parkId);
        }

        /// <summary>
        /// 注册停车场管理员
        /// </summary>
        /// <param name="parkId">停车场ID</param>
        /// <param name="name">管理员登录名</param>
        /// <param name="password">管理员登录密码</param>
        /// <param name="type">管理员类型</param>
        /// <param name="nickname">管理员昵称</param>
        /// <returns>新停车场管理员ID</returns>
        private int RegisterManager(int parkId, string name, string password, ParkManagerEntity.ManagerType type, string nickname = null)
        {
            ParkManagerEntity entity = new ParkManagerEntity();
            entity.Name = name;
            entity.Password = password;
            if (nickname != null)
            {
                entity.Nickname = nickname;
            }
            entity.Type = type;
            entity.ParkId = parkId;

            if (!database.IsOpen())
            {
                database.Open();
            }
            long insert = database.Insert(ParkManagerEntity.TableName, null,
                entity.GetDataFromEntity());
            if (insert <= 0)
            {
                insert = 0;
            }

            return Convert.ToInt32(insert);
        }

        /// <summary>
        /// 获取停车场管理员信息
        /// </summary>
        /// <param name="managerId">停车场管理员ID</param>
        /// <param name="type">停车场管理员类型</param>
        /// <returns>停车场管理员信息</returns>
        private ParkManagerEntity GetParkManagerInfo(int managerId, ParkManagerEntity.ManagerType type)
        {
            ParkManagerEntity entity = null;

            if (!database.IsOpen())
            {
                database.Open();
            }
            ICursor cursor = database.Query(ParkManagerEntity.TableName, null,
                ParkManagerEntity.Fields.Id + "=? AND " + ParkManagerEntity.Fields.Type + "=?",
                new string[] { Convert.ToString(managerId), Convert.ToString((int)type) },
                null, null, null);
            while(cursor.MoveToNext())
            {
                entity = new ParkManagerEntity();
                entity.Id = cursor.GetInt(ParkManagerEntity.Fields.Id);
                entity.Name = cursor.GetString(ParkManagerEntity.Fields.Name);
                entity.Password = cursor.GetString(ParkManagerEntity.Fields.Password);
                if (!cursor.IsDBNull(cursor.GetFieldIndex(ParkManagerEntity.Fields.Nickname)))
                {
                    entity.Nickname = cursor.GetString(ParkManagerEntity.Fields.Nickname);
                }
                switch (cursor.GetInt(ParkManagerEntity.Fields.Type))
                {
                    case 1:
                        entity.Type = ParkManagerEntity.ManagerType.MANAGER;
                        break;
                    case 2:
                        entity.Type = ParkManagerEntity.ManagerType.DOORMAN;
                        break;
                }
                entity.ParkId = cursor.GetInt(ParkManagerEntity.Fields.ParkId);
            }
            cursor.Close();

            return entity;
        }

        /// <summary>
        /// 停车场管理员登录
        /// </summary>
        /// <param name="name">停车场管理员登录名</param>
        /// <param name="password">停车场管理员登录密码</param>
        /// <param name="type">停车场管理员登录类型</param>
        /// <param name="parkId">停车场ID</param>
        /// <returns>停车场登录信息</returns>
        private ManagerLoginEntity ManagerLogin(string name, string password, ParkManagerEntity.ManagerType type, int parkId)
        {
            if (!database.IsOpen())
            {
                database.Open();
            }
            ICursor cursor = database.Query(ParkManagerEntity.TableName, null,
                ParkManagerEntity.Fields.Name + "='?' AND " + ParkManagerEntity.Fields.Password + "='?' AND " + ParkManagerEntity.Fields.Type + "='?' AND " + ParkManagerEntity.Fields.ParkId + "='?'",
                new string[] { name, password, Convert.ToString((int)type), Convert.ToString(parkId) },
                null, null, null);
            while(cursor.MoveToNext())
            {
                int managerId = cursor.GetInt(ParkManagerEntity.Fields.Id);
                cursor.Close();

                ManagerLoginEntity entity = new ManagerLoginEntity();
                entity.LoginTime = DateTime.Now;
                entity.ManagerId = managerId;
                long insert = database.Insert(ManagerLoginEntity.TableName, null, entity.GetDataFromEntity());
                if (insert > 0)
                {
                    entity.Id = Convert.ToInt32(insert);
                    return entity;
                }
            }
            cursor.Close();

            return null;
        }

        /// <summary>
        /// 停车场管理员登出
        /// </summary>
        /// <param name="type">停车场管理员类型</param>
        /// <param name="parkId">停车场ID</param>
        /// <returns>如果返回值>0，表示登出成功，否则等处失败</returns>
        private int ManagerLogout(ParkManagerEntity.ManagerType type, int parkId)
        {
            if (!database.IsOpen())
            {
                database.Open();
            }
            ICursor cursor = database.Query(ViewManagerLoginEntity.TableName, null,
                ViewManagerLoginEntity.Fields.ParkId + "=? AND " + ViewManagerLoginEntity.Fields.Type + "=? AND ISNULL(" + ViewManagerLoginEntity.Fields.LogoutTime + ") IS TRUE",
                new string[] { Convert.ToString(parkId), Convert.ToString((int)type) },
                null, null, null);
            while (cursor.MoveToNext())
            {
                int loginId = cursor.GetInt(ViewManagerLoginEntity.Fields.LoginId);
                cursor.Close();
                ManagerLoginEntity entity = new ManagerLoginEntity();
                entity.LogoutTime = DateTime.Now;
                int effect = database.Update(ManagerLoginEntity.TableName, entity.GetDataFromEntity(),
                    ManagerLoginEntity.Fields.Id + "=?",
                    new string[] { Convert.ToString(loginId) });
                if (effect > 0)
                {
                    return Convert.ToInt32(effect);
                }
                break;
            }
            cursor.Close();

            return 0;
        }
    }
}
