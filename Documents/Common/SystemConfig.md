# SystemConfig.cs系统的配置信息

## 简介

该文件主要存放系统默认的配置信息。

#### 1. 数据库配置信息

````CSharp
/// <summary>
/// 保存在本地数据库配置文件名
/// </summary>
public static string SHARED_PREFERENCES = "database";

public static string SERVER = "localhost";
public static int PORT = 3306;
public static string USER = "root";
public static string PASSWORD = "Password12!";
public static string DATABASE = "spslocal";
````

#### 2. 停车场配置信息

````CSharp
/// <summary>
/// 保存在本地停车场配置文件名
/// </summary>
public static string SHARED_PREFERENCES = "park";
````