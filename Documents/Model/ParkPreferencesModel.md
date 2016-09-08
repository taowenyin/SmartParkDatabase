# ParkPreferencesModel.cs停车场信息持久化模型类

## 简介

该文件主要包含了保存和读取本地停车场ID等。

````CSharp
/// <summary>
/// 提交并保存到本地
/// </summary>
public void Commit()

/// <summary>
/// 在内存中修改停车场ID
/// </summary>
/// <param name="parkId">停车场ID</param>
public void SetParkId(long parkId)

/// <summary>
/// 从本地获取停车场ID
/// </summary>
/// <returns>停车场ID</returns>
public long GetParkId()
````