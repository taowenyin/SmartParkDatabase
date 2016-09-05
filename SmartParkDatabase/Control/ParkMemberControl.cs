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
    public class ParkMemberControl : IControl
    {
        private IDatabase database = null;

        public ParkMemberControl()
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
        /// 添加新的会员类型
        /// </summary>
        /// <param name="name">会员名称</param>
        /// <param name="time">会员时长</param>
        /// <param name="price">会员价格</param>
        /// <param name="parkId">对应的停车场ID</param>
        /// <returns>新的会员类型ID</returns>
        public int AddMemberType(string name, int time, int price, int parkId)
        {
            MemberTypeEntity entity = new MemberTypeEntity();
            entity.Name = name;
            entity.Time = time;
            entity.Price = price;
            entity.ParkId = parkId;

            if (!database.IsOpen())
            {
                database.Open();
            }
            long insert = database.Insert(MemberTypeEntity.TableName, null, entity.GetDataFromEntity());
            if (insert <= 0)
            {
                insert = 0;
            }

            return Convert.ToInt32(insert);
        }

        /// <summary>
        /// 获取会员ID
        /// </summary>
        /// <param name="name">会员名称</param>
        /// <param name="parkId">对应的停车场ID</param>
        /// <returns>会员ID</returns>
        public int GetMemberTypeId(string name, int parkId)
        {
            if (!database.IsOpen())
            {
                database.Open();
            }
            ICursor cursor = database.Query(MemberTypeEntity.TableName, null,
                MemberTypeEntity.Fields.Name + "='?' AND " + MemberTypeEntity.Fields.ParkId + "=?",
                new string[] { name, Convert.ToString(parkId) },
                null, null, null);
            while (cursor.MoveToNext())
            {
                int typeId = cursor.GetInt(MemberTypeEntity.Fields.Id);
                cursor.Close();
                if (typeId > 0)
                {
                    return typeId;
                }
                break;
            }
            cursor.Close();

            return 0;
        }

        /// <summary>
        /// 获取会员类型信息
        /// </summary>
        /// <param name="typeId">会员类型ID</param>
        /// <returns>会员类型信息</returns>
        public MemberTypeEntity GetMemberTypeInfo(int typeId)
        {
            if (!database.IsOpen())
            {
                database.Open();
            }
            ICursor cursor = database.Query(MemberTypeEntity.TableName, null,
                MemberTypeEntity.Fields.Id + "=?",
                new string[] { Convert.ToString(typeId) },
                null, null, null);
            while (cursor.MoveToNext())
            {
                MemberTypeEntity entity = new MemberTypeEntity();
                entity.Id = cursor.GetInt(MemberTypeEntity.Fields.Id);
                entity.Name = cursor.GetString(MemberTypeEntity.Fields.Name);
                entity.Time = cursor.GetInt(MemberTypeEntity.Fields.Time);
                entity.Price = cursor.GetInt(MemberTypeEntity.Fields.Price);
                entity.ParkId = cursor.GetInt(MemberTypeEntity.Fields.ParkId);
                cursor.Close();

                return entity;
            }
            cursor.Close();

            return null;
        }

        /// <summary>
        /// 向停车场添加会员
        /// </summary>
        /// <param name="license">会员的车牌号</param>
        /// <param name="type">会员的类型ID</param>
        /// <param name="name">会员的名称</param>
        /// <param name="phone">会员的电话</param>
        /// <returns>停车场新会员ID</returns>
        public int AddParkMember(string license, int type, string name = null, string phone = null)
        {
            if (!database.IsOpen())
            {
                database.Open();
            }
            ParkMemberEntity entity = new ParkMemberEntity();
            entity.License = license;
            entity.Type = type;
            if (name != null)
            {
                entity.Name = name;
            }
            if (phone != null)
            {
                entity.Phone = phone;
            }

            long insert = database.Insert(ParkMemberEntity.TableName, null, entity.GetDataFromEntity());
            if (insert <= 0)
            {
                insert = 0;
            }
            else
            {
                MemberTypeEntity typeEntity = GetMemberTypeInfo(type);
                MemberDeadLineEntity deadlineEntity = new MemberDeadLineEntity();
                deadlineEntity.BeginTime = DateTime.Now;
                deadlineEntity.EndTime = deadlineEntity.BeginTime.Value.AddDays(typeEntity.Time);
                deadlineEntity.MemberId = Convert.ToInt32(insert);
                database.Insert(MemberDeadLineEntity.TableName, null, deadlineEntity.GetDataFromEntity());
            }

            return Convert.ToInt32(insert);
        }

        /// <summary>
        /// 获取当前会员的信息
        /// </summary>
        /// <param name="license">会员的车牌号</param>
        /// <param name="parkId">对应停车场ID</param>
        /// <returns>如果该车牌是会员则返回对象，否则返回NULL</returns>
        public ViewMemberInfoEntity GetCurrentMemberInfo(string license, int parkId)
        {
            if (!database.IsOpen())
            {
                database.Open();
            }

            ICursor cursor = database.Query(ViewMemberInfoEntity.TableName, null,
                ViewMemberInfoEntity.Fields.License + "='?' AND " + 
                ViewMemberInfoEntity.Fields.ParkId + "=? AND NOW() > " + 
                ViewMemberInfoEntity.Fields.BeginTime + " AND NOW() < " + 
                ViewMemberInfoEntity.Fields.EndTime,
                new string[] { license, Convert.ToString(parkId) },
                null, null, null);

            while (cursor.MoveToNext())
            {
                ViewMemberInfoEntity entity = new ViewMemberInfoEntity();
                entity.Id = cursor.GetInt(ViewMemberInfoEntity.Fields.Id);
                entity.License = cursor.GetString(ViewMemberInfoEntity.Fields.License);
                if (!cursor.IsDBNull(cursor.GetFieldIndex(ViewMemberInfoEntity.Fields.Name)))
                {
                    entity.Name = cursor.GetString(ViewMemberInfoEntity.Fields.Name);
                }
                if (!cursor.IsDBNull(cursor.GetFieldIndex(ViewMemberInfoEntity.Fields.Phone)))
                {
                    entity.Phone = cursor.GetString(ViewMemberInfoEntity.Fields.Phone);
                }
                entity.TypeId = cursor.GetInt(ViewMemberInfoEntity.Fields.TypeId);
                entity.TypeName = cursor.GetString(ViewMemberInfoEntity.Fields.TypeName);
                entity.TypeTime = cursor.GetInt(ViewMemberInfoEntity.Fields.TypeTime);
                entity.TypePrice = cursor.GetInt(ViewMemberInfoEntity.Fields.TypePrice);
                entity.ParkId = cursor.GetInt(ViewMemberInfoEntity.Fields.ParkId);
                entity.DeadlineId = cursor.GetInt(ViewMemberInfoEntity.Fields.DeadlineId);
                entity.BeginTime = cursor.GetDateTime(ViewMemberInfoEntity.Fields.BeginTime);
                entity.EndTime = cursor.GetDateTime(ViewMemberInfoEntity.Fields.EndTime);

                cursor.Close();
                return entity;
            }
            cursor.Close();

            return null;
        }
    }
}
