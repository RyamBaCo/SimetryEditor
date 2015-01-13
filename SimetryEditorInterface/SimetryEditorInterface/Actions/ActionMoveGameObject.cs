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
    public class ActionMoveGameObject : BaseAction
    {
        public string ID { get; private set; }
        public string TargetID { get; private set; }
        public int Speed { get; private set; }
        public bool UseVelocity { get; private set; }

        private float finalArrivalTime;
        private float passedTime;
        private GameObjectValue gameObject;
        private Vector3 startPosition;
        private Vector3 endPosition;

        public ActionMoveGameObject(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            UseVelocity = true;

            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_MOVE_OBJECT);
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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_TARGET_ID:
                            TargetID = actionProperty.Value.ToString();
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_SPEED:
                            Speed = Convert.ToInt32(actionProperty.Value);
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_USE_VELOCITY:
                            UseVelocity = Convert.ToBoolean(actionProperty.Value);
                        break;
                    }
                    actionToken = actionToken.Next;
                }
            }

            GameObjectValueManager.Instance.RegisterActionID(SerializationConstants.ACTION_MOVE_OBJECT.Name, ID);
        }

        public override void Execute()
        {
            passedTime = 0;
            gameObject = GameObjectValueManager.Instance.GetGameObjectByID(ID);
            startPosition = gameObject.Position;
            endPosition = GameObjectValueManager.Instance.GetGameObjectByID(TargetID).Position;
            finalArrivalTime = (startPosition - endPosition).Length() / Speed;

            if (UseVelocity && gameObject.OnSetMovementValues != null)
                gameObject.OnSetMovementValues(endPosition, Speed);

            base.Execute();

            if (UseVelocity)
                Finish();
        }

// there is no gametime class for xna in windows forms
#if !EDITOR
        public override void Update(GameTime gameTime)
        {
            passedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!UseVelocity && gameObject.OnSetPosition != null)
                gameObject.OnSetPosition(Vector3.Lerp(startPosition, endPosition, Math.Min(1.0f, passedTime / finalArrivalTime)));

            if (passedTime >= finalArrivalTime)
                Finish();
        }
#endif
    }
}
