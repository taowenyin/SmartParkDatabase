# IEntity.cs数据库实体类

## 简介

该文件是所有实体的接口类，在所有实体中必须要实现把实体数据转为字典数据，以及使用字典数据来填充实体。

````CSharp
/// <summary>
/// 把实体转化为字典数据
/// </summary>
/// <returns>返回实体的字典数据</returns>
Dictionary<string, string> GetDataFromEntity()

/// <summary>
/// 把字典数据填充实体
/// </summary>
/// <param name="data">字典数据</param>
void FillEntityFromData(Dictionary<string, string> data)
````