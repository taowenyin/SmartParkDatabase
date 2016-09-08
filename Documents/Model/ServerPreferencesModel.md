# ServerPreferencesModel.cs停车场系统持久化模型类

## 简介

该文件主要包含了对数据库服务器持久化配置信息的读写。

````CSharp
/// <summary>
/// 提交并保存到本地
/// </summary>
public void Commit()

/// <summary>
/// 在内存中修改服务器地址
/// </summary>
/// <param name="server">服务器地址</param>
public void SetServer(string server)

/// <summary>
/// 获取服务器地址
/// </summary>
/// <returns>服务器地址</returns>
public string GetServer()

/// <summary>
/// 在内存中修改服务器端口
/// </summary>
/// <param name="port">服务器端口</param>
public void SetPort(int port)

/// <summary>
/// 获取服务器端口
/// </summary>
/// <returns>服务器端口</returns>
public int GetPort()

/// <summary>
/// 设置服务器用户名
/// </summary>
/// <param name="user">服务器用户名</param>
public void SetUser(string user)

/// <summary>
/// 获取服务器用户名
/// </summary>
/// <returns>服务器用户名</returns>
public string GetUser()

/// <summary>
/// 设置服务器密码
/// </summary>
/// <param name="password">服务器密码</param>
public void SetPassword(string password)

/// <summary>
/// 获取服务器密码
/// </summary>
/// <returns>服务器密码</returns>
public string GetPassword()

/// <summary>
/// 设置链接的数据库名称
/// </summary>
/// <param name="database">数据库名称</param>
public void SetDatabase(string database)

/// <summary>
/// 获取数据库名称
/// </summary>
/// <returns>数据库名称</returns>
public string GetDatabase()
````