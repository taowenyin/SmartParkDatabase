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

        /// <summary>
        /// 添加停车场的停车券类型
        /// </summary>
        /// <param name="parkId">停车场ID</param>
        /// <param name="name">停车券名称</param>
        /// <param name="freetime">停车券免费时长</param>
        /// <returns>停车券ID</returns>
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

        /// <summary>
        /// 获取指定停车场的所有停车券类型
        /// </summary>
        /// <param name="parkId">停车场ID</param>
        /// <returns>停车券类型列表</returns>
        public List<TicketTypeEntity> GetAllParkingTicketType(int parkId)
        {
            List<TicketTypeEntity> ticketTypeList = null;

            if (!database.IsOpen())
            {
                database.Open();
            }

            ICursor cursor = database.Query(TicketTypeEntity.TableName, null,
                TicketTypeEntity.Fields.ParkId + "=?",
                new string[] { Convert.ToString(parkId) },
                null, null, null);
            while (cursor.MoveToNext())
            {
                if (ticketTypeList == null)
                {
                    ticketTypeList = new List<TicketTypeEntity>();
                }
                TicketTypeEntity entity = new TicketTypeEntity();
                entity.Id = cursor.GetInt(TicketTypeEntity.Fields.Id);
                entity.Name = cursor.GetString(TicketTypeEntity.Fields.Name);
                entity.FreeTime = cursor.GetInt(TicketTypeEntity.Fields.FreeTime);
                entity.ParkId = cursor.GetInt(TicketTypeEntity.Fields.ParkId);

                ticketTypeList.Add(entity);
            }
            cursor.Close();

            return ticketTypeList;
        }

        /// <summary>
        /// 获取停车券信息
        /// </summary>
        /// <param name="typeId">停车券ID</param>
        /// <returns>停车券信息</returns>
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
