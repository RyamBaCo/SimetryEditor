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
    public class ActionAllowWeaponReel : ActionAllow
    {
        public ActionAllowWeaponReel(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            : base(executeOnEnter, executeOnExit, executeOnKey, parameters)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_ALLOW_WEAPON_REEL);
            ActionValue.Parameters = parameters;
        }

        public override void Execute()
        {
            GameObjectValue gameObject = GameObjectValueManager.Instance.GetGameObjectByID(GlobalIDs.ID_PLAYER);

            if (gameObject.OnSetAllowWeaponReel != null)
                gameObject.OnSetAllowWeaponReel(Allow);

            base.Execute();
            Finish();
        }
    }
}
