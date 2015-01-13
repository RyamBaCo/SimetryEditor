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
using Simetry.Interface.Globals;

namespace Simetry.Interface.Actions
{
    public class ActionChangeAmbientLight : BaseAction
    {
        public Vector4 Color { get; private set; }
        public float Speed { get; private set; }

        public ActionChangeAmbientLight(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_CHANGE_AMBIENT_LIGHT);
            ActionValue.Parameters = parameters;

            using (TextReader stringReader = new StringReader(ActionValue.Parameters))
            using (JsonReader reader = new JsonTextReader(stringReader))
            {
                JObject actionValue = JObject.Load(reader);
                JToken actionToken = actionValue.First;

                while (actionToken != null)
                {
                    JProperty actionProperty = (JProperty)actionToken;
                    switch (actionProperty.Name)
                    {
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_COLOR:
                            Color = GameObjectValue.Vector4FromJArray((JArray)actionProperty.Value);
                            break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_SPEED:
                            Speed = (float)actionProperty.Value;
                            break;
                    }
                    actionToken = actionToken.Next;
                }
            }
        }

        public override void Execute()
        {
            GameObjectValue gameObject = GameObjectValueManager.Instance.GetGameObjectByID(GlobalIDs.ID_PLAYER);

            if (gameObject.OnChangeAmbientLight != null)
                gameObject.OnChangeAmbientLight(Color, Speed);

            base.Execute();
            Finish();
        }
    }
}
