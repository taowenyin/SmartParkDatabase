# ServerPreferencesControl.cs停车场服务器控制器类

## 简介

该文件主要包含在数据库服务器的默认配置和修改服务器的默认配置。

````CSharp
/// <summary>
/// 载入系统默认的数据库配置信息
/// </summary>
public void LoadDefaultConfig()

/// <summary>
/// 获取数据库配置信息
/// </summary>
/// <returns>数据库配置信息</returns>
public ServerEntity GetServerConfig()

/// <summary>
/// 保存新的数据库配置信息
/// </summary>
/// <param name="entity">数据库配置信息</param>
public void SetServerConfig(ServerEntity entity)

/// <summary>
/// 保存新的数据库地址
/// </summary>
/// <param name="server">新的数据库地址</param>
public void SetServer(string server)

/// <summary>
/// 获取数据库地址
/// </summary>
/// <returns>数据库地址</returns>
public string GetServer()

/// <summary>
/// 设置数据库端口
/// </summary>
/// <param name="port">数据库端口</param>
public void SetPort(int port)

/// <summary>
/// 获取数据库端口
/// </summary>
/// <returns>数据库端口</returns>
public int GetPort()

/// <summary>
/// 设置数据库用户名
/// </summary>
/// <param name="user">数据库用户名</param>
public void SetUser(string user)

/// <summary>
/// 获取数据库用户名
/// </summary>
/// <returns>数据库用户名</returns>
public string GetUser()

/// <summary>
/// 设置数据库密码
/// </summary>
/// <param name="password">数据库密码</param>
public void SetPassword(string password)

/// <summary>
/// 获取数据库密码
/// </summary>
/// <returns>数据库密码</returns>
public string GetPassword()

/// <summary>
/// 设置数据库名称
/// </summary>
/// <param name="database">数据库名称</param>
public void SetDatabase(string database)

/// <summary>
/// 获取数据库名称
/// </summary>
/// <returns>数据库名称</returns>
public string GetDatabase()
````