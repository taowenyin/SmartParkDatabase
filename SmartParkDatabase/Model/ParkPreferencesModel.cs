using CSharedPreferences;
using SmartParkDatabase.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmartParkDatabase.Common.System;

namespace SmartParkDatabase.Model
{
    class ParkPreferencesModel : IModel
    {
        private SharedPreferences preference = null;
        private IEditor editor = null;

        public ParkPreferencesModel()
        {
            preference = SharedPreferences.GetInstance(Park.SHARED_PREFERENCES);
            editor = preference.GetEditor();
        }

        public void Commit()
        {
            editor.Commit();
        }

        public void SetParkId(long parkId)
        {
            IEditor editor = preference.GetEditor();
            editor.PutLong(ParkInfoEntity.Fields.Id, parkId);
        }

        public long GetParkId()
        {
            return preference.GetLong(ParkInfoEntity.Fields.Id, 0);
        }
    }
}
