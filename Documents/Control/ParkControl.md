# ParkControl.cs停车场基本信息控制器类

## 简介

该文件主要包含停车场基本信息控制，比如停车场注册、获取停车场信息、获取停车场ID。

````CSharp
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
public int RegisterPark(string name, int freetime, int price, int spaces, string address = null, double longitude = 0, double latitude = 0)

/// <summary>
/// 获取停车场信息
/// </summary>
/// <param name="parkId">停车场ID</param>
/// <returns>停车场信息</returns>
public ParkInfoEntity GetParkInfo(long parkId)

/// <summary>
/// 获取当前停车场ID
/// </summary>
/// <returns>停车场ID</returns>
public long GetCurrentParkId()
````