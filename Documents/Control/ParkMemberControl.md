# ParkMemberControl.cs停车场管理员控制器类

## 简介

该文件主要包含停车场会员的注册，以及添加会员的类型。

````CSharp
/// <summary>
/// 添加新的会员类型
/// </summary>
/// <param name="name">会员名称</param>
/// <param name="time">会员时长</param>
/// <param name="price">会员价格</param>
/// <param name="parkId">对应的停车场ID</param>
/// <returns>新的会员类型ID</returns>
public int AddMemberType(string name, int time, int price, int parkId)

/// <summary>
/// 获取指定停车场的所有会员类型
/// </summary>
/// <param name="parkId">停车场ID</param>
/// <returns>会员类型列表</returns>
public List<MemberTypeEntity> GetAllMemberType(int parkId)

/// <summary>
/// 获取会员ID
/// </summary>
/// <param name="name">会员名称</param>
/// <param name="parkId">对应的停车场ID</param>
/// <returns>会员ID</returns>
public int GetMemberTypeId(string name, int parkId)

/// <summary>
/// 获取会员类型信息
/// </summary>
/// <param name="typeId">会员类型ID</param>
/// <returns>会员类型信息</returns>
public MemberTypeEntity GetMemberTypeInfo(int typeId)

/// <summary>
/// 向停车场添加会员
/// </summary>
/// <param name="license">会员的车牌号</param>
/// <param name="type">会员的类型ID</param>
/// <param name="name">会员的名称</param>
/// <param name="phone">会员的电话</param>
/// <returns>停车场新会员ID</returns>
public int AddParkMember(string license, int type, string name = null, string phone = null)

/// <summary>
/// 获取当前会员的信息
/// </summary>
/// <param name="license">会员的车牌号</param>
/// <param name="parkId">对应停车场ID</param>
/// <returns>如果该车牌是会员则返回对象，否则返回NULL</returns>
public ViewMemberInfoEntity GetCurrentMemberInfo(string license, int parkId)
````