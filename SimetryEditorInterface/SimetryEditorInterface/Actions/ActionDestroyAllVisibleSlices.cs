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
    public class ActionDestroyAllVisibleSlices : BaseAction
    {
        public string ID { get; private set; }

        public ActionDestroyAllVisibleSlices(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            : base(executeOnEnter, executeOnExit, executeOnKey)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_DESTROY_VISIBLE_SLICES);
            ActionValue.Parameters = parameters;

            if (parameters == SerializationConstants.DEFAULT_VALUE_METADATA_GAME_OBJECT_PARAMETERS)
                return;

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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ID:
                            ID = actionProperty.Value.ToString();
                            break;
                    }
                    actionToken = actionToken.Next;
                }
            }
        }

        public override void Execute()
        {
            GameObjectValue gameObject = GameObjectValueManager.Instance.GetGameObjectByID(GlobalIDs.ID_PLAYER);

            if (gameObject.OnDestroyVisibleSlices != null)
                gameObject.OnDestroyVisibleSlices(GameObjectValueManager.Instance.GetGameObjectByID(ID).Position);

            base.Execute();
            Finish();
        }
    }
}
