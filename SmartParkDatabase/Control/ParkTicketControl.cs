using CDatabase;
using SmartParkDatabase.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Control
{
    public class ParkTicketControl : IControl
    {
        private IDatabase database = null;

        public ParkTicketControl()
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

        public int AddParkingTicketType(int parkId, string name, int freetime)
        {
            TicketTypeEntity entity = new TicketTypeEntity();
            entity.Name = name;
            entity.FreeTime = freetime;
            entity.ParkId = parkId;

            if (!database.IsOpen())
            {
                database.Open();
            }
            long insert = database.Insert(TicketTypeEntity.TableName, null, entity.GetDataFromEntity());
            if (insert <= 0)
            {
                insert = 0;
            }

            return Convert.ToInt32(insert);
        }

        public TicketTypeEntity GetParkingTicketInfo(int typeId)
        {
            TicketTypeEntity entity = null;

            if (!database.IsOpen())
            {
                database.Open();
            }

            ICursor cursor = database.Query(TicketTypeEntity.TableName, null,
                TicketTypeEntity.Fields.Id + "=?", 
                new string[] { Convert.ToString(typeId) }, 
                null, null, null);
            while(cursor.MoveToNext())
            {
                entity = new TicketTypeEntity();
                entity.Id = cursor.GetInt(TicketTypeEntity.Fields.Id);
                entity.Name = cursor.GetString(TicketTypeEntity.Fields.Name);
                entity.FreeTime = cursor.GetInt(TicketTypeEntity.Fields.FreeTime);
                entity.ParkId = cursor.GetInt(TicketTypeEntity.Fields.ParkId);
            }
            cursor.Close();

            return entity;
        }
    }
}
