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
    public class ActionPlayAnimationReverse : BaseAction
    {
        public string ID { get; private set; }

        float duration = -1f;

        public ActionPlayAnimationReverse(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_PLAY_ANIMATION_REVERSE);
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
                    }
                    actionToken = actionToken.Next;
                }
            }

            GameObjectValueManager.Instance.RegisterActionID(SerializationConstants.ACTION_PLAY_ANIMATION_REVERSE.Name, ID);
        }

        public override void Execute()
        {
            GameObjectValue gameObject = GameObjectValueManager.Instance.GetGameObjectByID(ID);

            if (gameObject.OnPlayAnimationClipReverse != null)
                gameObject.OnPlayAnimationClipReverse(out duration);

            base.Execute();
        }

        // there is no gametime class for xna in windows forms
#if !EDITOR
        public override void Update(GameTime gameTime)
        {
            if (duration < 0)
                return;

            duration -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (duration <= 0f)
                Finish();
        }
#endif
    }
}
