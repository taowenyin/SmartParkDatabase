using CDatabase;
using SmartParkDatabase.Model;
using SmartParkDatabase.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Control
{
    public class ParkControl : IControl
    {
        private IDatabase database = null;

        public ParkControl()
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
        /// 注册新的停车场
        /// </summary>
        /// <param name="name">停车场名称</param>
        /// <param name="freetime">停车场免费时长</param>
        /// <param name="price">停车场每小时价格</param>
        /// <param name="spaces">停车场车位数</param>
        /// <param name="address">停车场地址</param>
        /// <param name="longitude">停车场经度</param>
        /// <param name="latitude">停车场纬度</param>
        /// <returns>新停车场ID</returns>
        public int RegisterPark(string name, int freetime, int price, int spaces, 
            string address = null, double longitude = 0, double latitude = 0)
        {
            ParkInfoEntity entity = new ParkInfoEntity();
            entity.Name = name;
            entity.FreeTime = freetime;
            entity.Price = price;
            entity.Spaces = spaces;
            if (address != null)
            {
                entity.Address = address;
            }
            if (longitude != 0 && longitude > 0)
            {
                entity.Longitude = longitude;
            }
            if (latitude != 0 && latitude > 0)
            {
                entity.Latitude = latitude;
            }

            if (!database.IsOpen())
            {
                database.Open();
            }
            long insert = database.Insert(ParkInfoEntity.TableName, 
                null, entity.GetDataFromEntity());
            if(insert <= 0)
            {
                insert = 0;
            } 
            else
            {
                ParkPreferencesControl control = new ParkPreferencesControl();
                control.SetParkId(insert);
            }

            return Convert.ToInt32(insert);
        }

        /// <summary>
        /// 获取停车场信息
        /// </summary>
        /// <param name="parkId">停车场ID</param>
        /// <returns>停车场信息</returns>
        public ParkInfoEntity GetParkInfo(long parkId)
        {
            ParkInfoEntity entity = null;

            if(!database.IsOpen())
            {
                database.Open();
            }
            ICursor cursor = database.Query(ParkInfoEntity.TableName, null, 
                ParkInfoEntity.Fields.Id + "=?", 
                new string[] { Convert.ToString(parkId) }, 
                null, null, null, null);
            while(cursor.MoveToNext())
            {
                entity = new ParkInfoEntity();

                entity.Id = cursor.GetInt(ParkInfoEntity.Fields.Id);
                entity.Name = cursor.GetString(ParkInfoEntity.Fields.Name);
                entity.FreeTime = cursor.GetInt(ParkInfoEntity.Fields.FreeTime);
                entity.Price = cursor.GetInt(ParkInfoEntity.Fields.Price);
                entity.Spaces = cursor.GetInt(ParkInfoEntity.Fields.Spaces);
                if (!cursor.IsDBNull(cursor.GetFieldIndex(ParkInfoEntity.Fields.Address)))
                {
                    entity.Address = cursor.GetString(ParkInfoEntity.Fields.Address);
                }
                if (!cursor.IsDBNull(cursor.GetFieldIndex(ParkInfoEntity.Fields.Longitude)))
                {
                    entity.Longitude = cursor.GetDouble(ParkInfoEntity.Fields.Longitude);
                }
                if (!cursor.IsDBNull(cursor.GetFieldIndex(ParkInfoEntity.Fields.Latitude)))
                {
                    entity.Latitude = cursor.GetDouble(ParkInfoEntity.Fields.Latitude);
                }
            }
            cursor.Close();

            return entity;
        }

        /// <summary>
        /// 获取当前停车场ID
        /// </summary>
        /// <returns>停车场ID</returns>
        public long GetCurrentParkId()
        {
            ParkPreferencesControl control = new ParkPreferencesControl();
            
            return control.GetParkId();
        }
    }
}
