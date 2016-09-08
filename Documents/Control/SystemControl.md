# SystemControl.cs停车场系统控制器类

## 简介

该文件主要包含了验证数据库服务器是否存在，如果不存在就创建，以及关闭数据库服务器。

````CSharp
/// <summary>
/// 验证数据库，如果没有数据库则创建数据库
/// </summary>
/// <returns>True：验证或创建成功，Flase：验证或创建失败</returns>
public bool CheckDatabaseOrCreate()

/// <summary>
/// 关闭数据库
/// </summary>
public void Close()
````