# ParkTicketControl.cs停车场优惠券控制器类

## 简介

该文件主要包含添加停车场优惠券和获取停车场有会员信息。

````CSharp
/// <summary>
/// 添加停车场的停车券类型
/// </summary>
/// <param name="parkId">停车场ID</param>
/// <param name="name">停车券名称</param>
/// <param name="freetime">停车券免费时长</param>
/// <returns>停车券ID</returns>
public int AddParkingTicketType(int parkId, string name, int freetime)

/// <summary>
/// 获取停车券信息
/// </summary>
/// <param name="typeId">停车券ID</param>
/// <returns>停车券信息</returns>
public TicketTypeEntity GetParkingTicketInfo(int typeId)
````