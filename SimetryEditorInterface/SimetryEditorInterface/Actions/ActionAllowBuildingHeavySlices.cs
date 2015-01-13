using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simetry.Interface.Globals;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Xna.Framework;
using Simetry.Interface.Serialization;

namespace Simetry.Interface.Actions
{
    public class ActionAllowBuildingHeavySlices : ActionAllow
    {
        public ActionAllowBuildingHeavySlices(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            : base(executeOnEnter, executeOnExit, executeOnKey, parameters)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_ALLOW_BUILDING_HEAVY_SLICES);
            ActionValue.Parameters = parameters;
        }

        public override void Execute()
        {
            GameObjectValue gameObject = GameObjectValueManager.Instance.GetGameObjectByID(GlobalIDs.ID_PLAYER);

            if (gameObject.OnSetAllowBuildingHeavySlices != null)
                gameObject.OnSetAllowBuildingHeavySlices(Allow);

            base.Execute();
            Finish();
        }
    }
}
