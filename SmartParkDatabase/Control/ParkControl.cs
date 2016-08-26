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
    }
}
