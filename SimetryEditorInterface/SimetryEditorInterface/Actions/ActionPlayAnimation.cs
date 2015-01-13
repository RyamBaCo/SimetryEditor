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
    public class ActionPlayAnimation : BaseAction
    {
        public string ID { get; private set; }
        public int Clip { get; private set; }

        float animationCount;
        float duration = -1f;

        public ActionPlayAnimation(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_PLAY_ANIMATION);
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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ANIMATION_CLIP:
                            Clip = Convert.ToInt32(actionProperty.Value);
                        break;
                    }
                    actionToken = actionToken.Next;
                }
            }

            GameObjectValueManager.Instance.RegisterActionID(SerializationConstants.ACTION_PLAY_ANIMATION.Name, ID);
        }

        public override void Execute()
        {
            GameObjectValue gameObject = GameObjectValueManager.Instance.GetGameObjectByID(ID);

            if (gameObject.OnPlayAnimationClip != null)
                gameObject.OnPlayAnimationClip(Clip, out duration);

            animationCount = 0f;

            base.Execute();
        }

// there is no gametime class for xna in windows forms
#if !EDITOR
        public override void Update(GameTime gameTime)
        {
            if (duration < 0)
                return;

            animationCount += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (animationCount >= duration)
                Finish();
        }
#endif
    }
}
