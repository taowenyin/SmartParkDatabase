# UserParkingControl.cs用户停车控制器类

## 简介

该文件主要包含了用户驶入停车场、驶出停车场、计算支付信息等。

````CSharp
/// <summary>
/// 用户车辆驶入停车场
/// </summary>
/// <param name="license">用户车牌号</param>
/// <param name="intoPic">车辆驶入照片</param>
/// <param name="parkId">停车场ID</param>
/// <returns>用户车辆驶入ID</returns>
public int UserParkingIn(string license, string intoPic, int parkId)

/// <summary>
/// 用户车辆驶出停车场
/// </summary>
/// <param name="license">用户车牌号</param>
/// <param name="outPic">车辆驶出照片</param>
/// <param name="parkId">停车场ID</param>
/// <returns>大于0表示驶出成功，否则驶出失败</returns>
public int UserParkngOut(string license, string outPic, int parkId)

/// <summary>
/// 计算用户支付信息
/// </summary>
/// <param name="payId">支付ID</param>
/// <returns>停车场支付信息</returns>
public ParkingPayInfoEntity FiguringUserPayInfo(int payId)

/// <summary>
/// 用户使用停车券
/// </summary>
/// <param name="currentParkingPay">当前用户的支付信息</param>
/// <param name="type">停车券的ID</param>
/// <param name="no">停车券编号</param>
/// <returns>停车场支付信息</returns>
public ParkingPayInfoEntity UseParkingTicket(ParkingPayInfoEntity currentParkingPay, int type, string no = null)

/// <summary>
/// 完成用户支付
/// </summary>
/// <param name="parkingId"></param>
/// <returns>大于0表示完成支付成功，否则完成支付失败</returns>
public int UserFinishPay(int parkingId)
````