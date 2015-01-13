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
    public class ActionScaleAndMoveToPlayer : BaseAction
    {
        public string ID { get; private set; }
        public int Speed { get; private set; }

        private float finalArrivalTime;
        private float passedTime;
        private GameObjectValue gameObject;
        private Vector3 startPosition;
        private Vector3 endPosition;
        private float startMovementAfter;

        public ActionScaleAndMoveToPlayer(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_SCALE_AND_MOVE_TO_PLAYER);
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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_SPEED:
                            Speed = Convert.ToInt32(actionProperty.Value);
                        break;
                    }
                    actionToken = actionToken.Next;
                }
            }

            GameObjectValueManager.Instance.RegisterActionID(SerializationConstants.ACTION_SCALE_AND_MOVE_TO_PLAYER.Name, ID);
        }

        public override void Execute()
        {
            passedTime = 0;
            gameObject = GameObjectValueManager.Instance.GetGameObjectByID(ID);
            startPosition = gameObject.Position;

            if (gameObject.OnScaleAndMoveToPlayer != null)
                gameObject.OnScaleAndMoveToPlayer(startPosition, out endPosition, 1.0f);

            finalArrivalTime = (startPosition - endPosition).Length() / (Speed / 10.0f);
            startMovementAfter = .4f;

            base.Execute();
        }

// there is no gametime class for xna in windows forms
#if !EDITOR
        public override void Update(GameTime gameTime)
        {
            passedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            float currentProgress = Math.Min(1.0f, passedTime / finalArrivalTime);
            float scale;
            Vector3 currentPosition;

            if (currentProgress < startMovementAfter)
            {
                if(currentProgress < startMovementAfter *.5f)
                    scale = MathHelper.Lerp(1.0f, 1.5f, currentProgress / (startMovementAfter * .5f));
                else
                    scale = MathHelper.Lerp(1.5f, 1.0f, (currentProgress - startMovementAfter * .5f) / (startMovementAfter * .5f));
                currentPosition = startPosition;
            }

            else
            {
                scale = MathHelper.Lerp(1.0f, 0f, (currentProgress - startMovementAfter) / (1.0f - startMovementAfter));
                currentPosition = Vector3.Lerp(startPosition, endPosition, (currentProgress - startMovementAfter) / (1.0f - startMovementAfter));
            }

            if (gameObject.OnScaleAndMoveToPlayer != null)
                gameObject.OnScaleAndMoveToPlayer(currentPosition, out endPosition, scale);

            if (passedTime >= finalArrivalTime)
                Finish();
        }
#endif
    }
}
