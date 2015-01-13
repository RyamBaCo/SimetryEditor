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
    public class ActionPlaySound : BaseAction
    {
        public string Asset { get; private set; }
        public float Volume { get; private set; }
        public bool Loop { get; private set; }
        public bool FadeIn { get; private set; }

        public ActionPlaySound(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_PLAY_SOUND);
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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ASSET:
                            Asset = actionProperty.Value.ToString();
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_VOLUME:
                            Volume = (float)actionProperty.Value;
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_LOOP:
                            Loop = Convert.ToBoolean(actionProperty.Value);
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_FADE_IN:
                            FadeIn = Convert.ToBoolean(actionProperty.Value);
                        break;
                    }
                    actionToken = actionToken.Next;
                }
            }
        }

        public override void Execute()
        {
            GameObjectValue gameObject = GameObjectValueManager.Instance.GetGameObjectByID(GlobalIDs.ID_PLAYER);

            if (gameObject.OnPlaySound != null)
                gameObject.OnPlaySound(Asset, Volume, Loop, FadeIn);

            base.Execute();
            Finish();
        }
    }
}
