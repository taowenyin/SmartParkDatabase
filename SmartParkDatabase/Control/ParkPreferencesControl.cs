using SmartParkDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkDatabase.Control
{
    class ParkPreferencesControl : IControl
    {
        private ParkPreferencesModel model = null;

        public ParkPreferencesControl()
        {
            model = new ParkPreferencesModel();
        }

        /// <summary>
        /// 设置停车场ID
        /// </summary>
        /// <param name="parkId">停车场ID</param>
        public void SetParkId(long parkId)
        {
            model.SetParkId(parkId);
            model.Commit();
        }

        /// <summary>
        /// 获取停车场ID
        /// </summary>
        /// <returns>停车场ID</returns>
        public long GetParkId()
        {
            return model.GetParkId();
        }
    }
}
