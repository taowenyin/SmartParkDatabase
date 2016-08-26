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

        public void SetParkId(long parkId)
        {
            model.SetParkId(parkId);
            model.Commit();
        }

        public long GetParkId()
        {
            return model.GetParkId();
        }
    }
}
