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
    public class ActionShowFullscreenTexture : BaseAction
    {
        public enum AlphaMode
        {
            Stay = 0,
            Increase,
            Sink
        }

        public string Texture { get; private set; }
        public AlphaMode Mode { get; private set; }
        public float AlphaStart { get; private set; }
        public float AlphaSpeed { get; private set; }

        public ActionShowFullscreenTexture(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_SHOW_FULLSCREEN_TEXTURE);
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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_TEXTURE:
                            Texture = actionProperty.Value.ToString();
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ALPHAMODE:
                            Mode = (AlphaMode)Convert.ToInt32(actionProperty.Value);
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ALPHASTART:
                            AlphaStart = (float)actionProperty.Value;
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ALPHASPEED:
                            AlphaSpeed = (float)actionProperty.Value;
                        break;
                    }
                    actionToken = actionToken.Next;
                }
            }
        }

        public override void Execute()
        {
            GameObjectValue gameObject = GameObjectValueManager.Instance.GetGameObjectByID(GlobalIDs.ID_PLAYER);
            if(gameObject.OnShowFullScreenTexture != null)
                gameObject.OnShowFullScreenTexture(Texture, Mode, AlphaStart, AlphaSpeed);

            base.Execute();
            Finish();
        }
    }
}
