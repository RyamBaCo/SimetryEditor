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
    public class ActionEnableDisable : BaseAction
    {
        public string ID { get; private set; }
        public bool Enable { get; private set; }

        public ActionEnableDisable(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_ENABLE_DISABLE);
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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ID:
                            ID = actionProperty.Value.ToString();
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ENABLE:
                            Enable = Convert.ToBoolean(actionProperty.Value);
                        break;
                    }
                    actionToken = actionToken.Next;
                }
            }

            GameObjectValueManager.Instance.RegisterActionID(SerializationConstants.ACTION_ENABLE_DISABLE.Name, ID);
        }

        public override void Execute()
        {
            GameObjectValue gameObject = GameObjectValueManager.Instance.GetGameObjectByID(ID);

            if (gameObject.OnEnableDisable != null)
                gameObject.OnEnableDisable(Enable);

            base.Execute();
            Finish();
        }
    }
}
