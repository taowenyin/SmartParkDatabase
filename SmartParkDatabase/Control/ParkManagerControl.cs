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

        public int RegisterParkManager(int parkId, string name, string password, string nickname = null)
        {
            return RegisterManager(parkId, name, password, ParkManagerEntity.ManagerType.MANAGER, nickname);
        }

        public ParkManagerEntity GetParkManager(int managerId)
        {
            return GetParkManagerInfo(managerId, ParkManagerEntity.ManagerType.MANAGER);
        }

        public int RegisterDoorman(int parkId, string name, string password, string nickname = null)
        {
            return RegisterManager(parkId, name, password, ParkManagerEntity.ManagerType.DOORMAN, nickname); ;
        }

        public ParkManagerEntity GetParkDoorman(int doormanId)
        {
            return GetParkManagerInfo(doormanId, ParkManagerEntity.ManagerType.DOORMAN);
        }

        public ManagerLoginEntity ParkManagerLogin(string name, string password, int parkId)
        {
            return ManagerLogin(name, password, ParkManagerEntity.ManagerType.MANAGER, parkId);
        }

        public ManagerLoginEntity DoormanLogin(string name, string password, int parkId)
        {
            return ManagerLogin(name, password, ParkManagerEntity.ManagerType.DOORMAN, parkId);
        }

        public int DoormanLogout(int parkId)
        {
            return ManagerLogout(ParkManagerEntity.ManagerType.DOORMAN, parkId);
        }

        public int ParkManagerLogout(int parkId)
        {
            return ManagerLogout(ParkManagerEntity.ManagerType.MANAGER, parkId);
        }

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
