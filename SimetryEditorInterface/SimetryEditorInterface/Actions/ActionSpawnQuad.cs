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
    public class ActionSpawnQuad : BaseAction
    {
        public string TargetID { get; private set; }
        public ActionSetSliceState.SliceState State { get; private set; }
        public float Interval { get; private set; }

        private float passedTime;
        private GameObjectValue gameObject;
        private Vector3 targetPosition;

        public ActionSpawnQuad(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            Abortable = false;

            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_SPAWN_QUAD);
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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_TARGET_ID:
                            TargetID = actionProperty.Value.ToString();
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_STATE:
                            State = (ActionSetSliceState.SliceState)(int)actionProperty.Value;
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_INTERVAL:
                            Interval = (float)actionProperty.Value;
                        break;
                    }
                    actionToken = actionToken.Next;
                }
            }
        }

        public override void Execute()
        {
            passedTime = 0;
            gameObject = GameObjectValueManager.Instance.GetGameObjectByID(GlobalIDs.ID_PLAYER);
            targetPosition = GameObjectValueManager.Instance.GetGameObjectByID(TargetID).Position;
            if (gameObject.OnSpawnQuad != null)
                gameObject.OnSpawnQuad(State, targetPosition);
            
            base.Execute();
            if (Interval <= 0)
                Finish();
        }

// there is no gametime class for xna in windows forms
#if !EDITOR
        public override void Update(GameTime gameTime)
        {
            passedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (passedTime >= Interval)
            {
                passedTime = 0;
                if (gameObject.OnSpawnQuad != null)
                    gameObject.OnSpawnQuad(State, targetPosition);
            }
        }
#endif
    }
}
