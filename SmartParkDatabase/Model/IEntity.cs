using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Model
{
    interface IEntity
    {
        /// <summary>
        /// 把实体转化为字典数据
        /// </summary>
        /// <returns>返回实体的字典数据</returns>
        Dictionary<string, string> GetDataFromEntity();

        /// <summary>
        /// 把字典数据填充实体
        /// </summary>
        /// <param name="data">字典数据</param>
        void FillEntityFromData(Dictionary<string, string> data);
    }
}
