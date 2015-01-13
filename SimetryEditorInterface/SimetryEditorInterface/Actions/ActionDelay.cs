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
    public class ActionDelay : BaseAction
    {
        public float Delay { get; set; }

        float passedTime;

        public ActionDelay(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_DELAY);
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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_DELAY:
                            Delay = (float)actionProperty.Value;
                        break;
                    }
                    actionToken = actionToken.Next;
                }
            }
        }

        public override void Execute()
        {
            passedTime = 0f;
            base.Execute();
        }

// there is no gametime class for xna in windows forms
#if !EDITOR
        public override void Update(GameTime gameTime)
        {
            passedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (passedTime >= Delay)
                Finish();
        }
#endif
    }
}
