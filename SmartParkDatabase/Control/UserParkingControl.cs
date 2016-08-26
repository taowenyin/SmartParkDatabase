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
    public class UserParkingControl : IControl
    {
        private IDatabase database = null;

        public UserParkingControl()
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

        public int UserParkingIn(string license, string intoPic, int parkId)
        {
            UserParkingInfoEntity entity = new UserParkingInfoEntity();
            entity.License = license;
            entity.IntoTime = DateTime.Now;
            entity.IntoPic = intoPic;
            entity.ParkId = parkId;

            if (!database.IsOpen())
            {
                database.Open();
            }
            long insert = database.Insert(UserParkingInfoEntity.TableName, null, entity.GetDataFromEntity());
            if (insert <= 0)
            {
                insert = 0;
            }

            return Convert.ToInt32(insert);
        }

        public int UserParkngOut(string license, string outPic, int parkId)
        {
            ParkControl control = new ParkControl();

            UserParkingInfoEntity parkingInfo = new UserParkingInfoEntity();
            parkingInfo.OutTime = DateTime.Now;
            parkingInfo.OutPic = outPic;

            if (!database.IsOpen())
            {
                database.Open();
            }
            ICursor cursor = database.Query(UserParkingInfoEntity.TableName, null,
                UserParkingInfoEntity.Fields.License + "='?' AND " +
                UserParkingInfoEntity.Fields.ParkId + "=? AND ISNULL(" +
                UserParkingInfoEntity.Fields.OutTime + ") IS TRUE AND ISNULL(" +
                UserParkingInfoEntity.Fields.OutPic + ") IS TRUE",
                new string[] { license, Convert.ToString(parkId) },
                null, null, null);
            while (cursor.MoveToNext())
            {
                int parkingId = cursor.GetInt(UserParkingInfoEntity.Fields.Id);
                DateTime inTime = Convert.ToDateTime(cursor.GetDateTime(UserParkingInfoEntity.Fields.IntoTime));
                DateTime outTime = parkingInfo.OutTime.Value;
                TimeSpan t = outTime - inTime;
                cursor.Close();

                int hours = ((Convert.ToInt32(t.TotalMinutes) / 60) + ((Convert.ToInt32(t.TotalMinutes) % 60) > 10 ? 1 : 0));
                int effect = database.Update(UserParkingInfoEntity.TableName, parkingInfo.GetDataFromEntity(),
                    UserParkingInfoEntity.Fields.Id + "=?",
                    new string[] { Convert.ToString(parkingId) });
                if (effect > 0)
                {
                    ParkInfoEntity entity = control.GetParkInfo(parkId);

                    ParkingPayInfoEntity parkingPay = new ParkingPayInfoEntity();
                    parkingPay.ParkingId = parkingId;
                    parkingPay.Hours = hours;
                    parkingPay.Price = hours * entity.Price;
                    parkingPay.Status = ParkingPayInfoEntity.PayStatus.NO_PAY;

                    long insert = database.Insert(ParkingPayInfoEntity.TableName, null, parkingPay.GetDataFromEntity());
                    if (insert > 0)
                    {
                        return Convert.ToInt32(insert);
                    }

                    return 0;
                }
                break;
            }

            return 0;
        }

        public ParkingPayInfoEntity FiguringUserPayInfo(int payId)
        {
            if (!database.IsOpen())
            {
                database.Open();
            }
            ICursor cursor = database.Query(ParkingPayInfoEntity.TableName, null, 
                ParkingPayInfoEntity.Fields.Id + "=?", 
                new string[] { Convert.ToString(payId) }, 
                null, null, null, null);
            while (cursor.MoveToNext())
            {
                // Step1：获取用户本次的付款信息
                ParkingPayInfoEntity parkingPayInfo = new ParkingPayInfoEntity();
                parkingPayInfo.Id = cursor.GetInt(ParkingPayInfoEntity.Fields.Id);
                parkingPayInfo.Hours = cursor.GetInt(ParkingPayInfoEntity.Fields.Hours);
                parkingPayInfo.Price = cursor.GetInt(ParkingPayInfoEntity.Fields.Price);
                switch(cursor.GetInt(ParkingPayInfoEntity.Fields.Status))
                {
                    case 1:
                        parkingPayInfo.Status = ParkingPayInfoEntity.PayStatus.NO_PAY;
                        break;
                    case 2:
                        parkingPayInfo.Status = ParkingPayInfoEntity.PayStatus.HAS_PAY;
                        break;
                    default:
                        parkingPayInfo.Status = ParkingPayInfoEntity.PayStatus.UNKNOWN;
                        break;
                }
                parkingPayInfo.ParkingId = cursor.GetInt(ParkingPayInfoEntity.Fields.ParkingId);
                cursor.Close();

                cursor = database.Query(UserParkingInfoEntity.TableName, null,
                    UserParkingInfoEntity.Fields.Id + "=?",
                    new string[] { Convert.ToString(parkingPayInfo.ParkingId) },
                    null, null, null, null);
                while(cursor.MoveToNext())
                {
                    string license = cursor.GetString(UserParkingInfoEntity.Fields.License);
                    int parkId = cursor.GetInt(UserParkingInfoEntity.Fields.ParkId);
                    cursor.Close();

                    // Step2：判断是否为会员，会员直接放行
                    ParkMemberControl parkMemberControl = new ParkMemberControl();
                    ViewMemberInfoEntity memberInfo = parkMemberControl.GetCurrentMemberInfo(license, parkId);
                    if (memberInfo == null)
                    {
                        // Step3：计算扣去免费时间后的价格
                        ParkControl parkControl = new ParkControl();
                        ParkInfoEntity parkInfo = parkControl.GetParkInfo(parkId);
                        int freePrice = parkInfo.FreeTime * parkInfo.Price;
                        parkingPayInfo.Price = (parkingPayInfo.Price - freePrice) > 0 ? (parkingPayInfo.Price - freePrice) : 0;
                    }
                    else
                    {
                        parkingPayInfo.Price = 0;
                    }
                    return parkingPayInfo;
                }
                cursor.Close();
            }
            cursor.Close();
            return null;
        }

        public ParkingPayInfoEntity UseParkingTicket(ParkingPayInfoEntity currentParkingPay, int type, string no = null)
        {
            ParkingTicketInfoEntity ticketInfo = new ParkingTicketInfoEntity();
            ticketInfo.UseTime = DateTime.Now;
            ticketInfo.PayId = currentParkingPay.Id;
            ticketInfo.Type = type;

            if (!database.IsOpen())
            {
                database.Open();
            }
            long insert = database.Insert(ParkingTicketInfoEntity.TableName, null, ticketInfo.GetDataFromEntity());
            if (insert > 0)
            {
                ParkTicketControl parkTicketControl = new ParkTicketControl();
                TicketTypeEntity ticketTypeEntity = parkTicketControl.GetParkingTicketInfo(type);
                if(ticketTypeEntity != null)
                {
                    ParkControl parkControl = new ParkControl();
                    ParkInfoEntity parkInfoEntity = parkControl.GetParkInfo(ticketTypeEntity.ParkId);
                    int freePrice = parkInfoEntity.Price * ticketTypeEntity.FreeTime;
                    currentParkingPay.Price = (currentParkingPay.Price - freePrice) > 0 ? (currentParkingPay.Price - freePrice) : 0;
                }
            }

            return currentParkingPay;
        }

        public int UserFinishPay(int parkingId)
        {
            if (!database.IsOpen())
            {
                database.Open();
            }

            ParkingPayInfoEntity entity = new ParkingPayInfoEntity();
            entity.Status = ParkingPayInfoEntity.PayStatus.HAS_PAY;

            int effect = database.Update(ParkingPayInfoEntity.TableName, 
                entity.GetDataFromEntity(),
                ParkingPayInfoEntity.Fields.Id + "=?", 
                new string[] { Convert.ToString(parkingId) });

            return effect;
        }
    }
}
