using CSharedPreferences;
using SmartParkDatabase.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Model
{
    class ParkPreferencesModel : IModel
    {
        private SharedPreferences preference = null;
        private IEditor editor = null;

        public ParkPreferencesModel()
        {
            preference = SharedPreferences.GetInstance(
                Common.SystemConfig.Park.SHARED_PREFERENCES);
            editor = preference.GetEditor();
        }

        /// <summary>
        /// 提交并保存到本地
        /// </summary>
        public void Commit()
        {
            editor.Commit();
        }

        /// <summary>
        /// 在内存中修改停车场ID
        /// </summary>
        /// <param name="parkId">停车场ID</param>
        public void SetParkId(long parkId)
        {
            IEditor editor = preference.GetEditor();
            editor.PutLong(ParkInfoEntity.Fields.Id, parkId);
        }

        /// <summary>
        /// 从本地获取停车场ID
        /// </summary>
        /// <returns>停车场ID</returns>
        public long GetParkId()
        {
            return preference.GetLong(ParkInfoEntity.Fields.Id, 0);
        }
    }
}
