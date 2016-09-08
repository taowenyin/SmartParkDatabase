# ParkManagerControl.cs停车场管理员控制器类

## 简介

该文件主要包含停车场管理员和门卫的注册，以及管理员和门卫的登录和登出。

````CSharp
/// <summary>
/// 注册新停车场管理员
/// </summary>
/// <param name="parkId">停车场ID</param>
/// <param name="name">管理员登录名</param>
/// <param name="password">管理员密码</param>
/// <param name="nickname">管理员昵称</param>
/// <returns>新停车场管理员ID</returns>
public int RegisterParkManager(int parkId, string name, string password, string nickname = null)

/// <summary>
/// 获取停车场管理员信息
/// </summary>
/// <param name="managerId">管理员ID</param>
/// <returns>管理员信息</returns>
public ParkManagerEntity GetParkManager(int managerId)

/// <summary>
/// 注册新停车场门卫
/// </summary>
/// <param name="parkId">停车场ID</param>
/// <param name="name">门卫登录名</param>
/// <param name="password">门卫登录密码</param>
/// <param name="nickname">门卫昵称</param>
/// <returns>新停车场门卫ID</returns>
public int RegisterDoorman(int parkId, string name, string password, string nickname = null)

/// <summary>
/// 获取停车场门卫信息
/// </summary>
/// <param name="doormanId">门卫ID</param>
/// <returns>门卫信息</returns>
public ParkManagerEntity GetParkDoorman(int doormanId)

/// <summary>
/// 停车场管理员登录
/// </summary>
/// <param name="name">管理员登录名</param>
/// <param name="password">管理员登录密码</param>
/// <param name="parkId">停车场ID</param>
/// <returns>管理员登录信息</returns>
public ManagerLoginEntity ParkManagerLogin(string name, string password, int parkId)

/// <summary>
/// 停车场门卫登录
/// </summary>
/// <param name="name">门卫登录名</param>
/// <param name="password">门卫登录密码</param>
/// <param name="parkId">停车场ID</param>
/// <returns>门卫登录信息</returns>
public ManagerLoginEntity DoormanLogin(string name, string password, int parkId)

/// <summary>
/// 停车场门卫登出
/// </summary>
/// <param name="parkId">停车场ID</param>
/// <returns>如果返回值>0，表示登出成功，否则等处失败</returns>
public int DoormanLogout(int parkId)

/// <summary>
/// 停车场管理员登出
/// </summary>
/// <param name="parkId">停车场ID</param>
/// <returns>如果返回值>0，表示登出成功，否则等处失败</returns>
public int ParkManagerLogout(int parkId)
````