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
    public class ActionRotateGameObject : BaseAction
    {
        public string ID { get; private set; }
        public int Speed { get; private set; }
        public float Repeat { get; private set; }
        public float Stepping { get; private set; }

        private GameObjectValue gameObject;
        private float lastRotation;
        private float currentRotation;
        private int rotationCount;

        public ActionRotateGameObject(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            : base(executeOnEnter, executeOnExit, executeOnKey)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_ROTATE_OBJECT);
            ActionValue.Parameters = parameters;
            Stepping = 0;

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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_STEPPING:
                            Stepping = (float)actionProperty.Value;
                            break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_REPEAT:
                            Repeat = (float)actionProperty.Value;
                            break;
                    }
                    actionToken = actionToken.Next;
                }
            }

            GameObjectValueManager.Instance.RegisterActionID(SerializationConstants.ACTION_ROTATE_OBJECT.Name, ID);
        }

        public override void Execute()
        {
            lastRotation = 0;
            currentRotation = 0;
            rotationCount = 0;
            gameObject = GameObjectValueManager.Instance.GetGameObjectByID(ID);
            base.Execute();
        }

        // there is no gametime class for xna in windows forms
#if !EDITOR
        public override void Update(GameTime gameTime)
        {
            currentRotation += (float)gameTime.ElapsedGameTime.TotalSeconds * Speed / 100.0f;

            while (Math.Abs(currentRotation) >= 2 * Math.PI)
            {
                if(currentRotation > 0)
                    currentRotation -= 2 * (float)Math.PI;
                else
                    currentRotation += 2 * (float)Math.PI;

                if(Repeat > 0)
                    ++rotationCount;
            }

            if (Repeat > 0) 
            {
                if(rotationCount == Repeat)
                {
                    currentRotation = 0;
                    Finish();
                }

                if (Repeat < 1.0f && Math.Abs(currentRotation) >= Repeat * 2 * Math.PI)
                {
                    currentRotation = Repeat * 2 * (float)Math.PI * ((currentRotation < 0) ? -1 : 1);
                    Finish();
                }
            }

            if (gameObject.OnSetRotation != null && Math.Abs(currentRotation - lastRotation) > Stepping)
            {
                lastRotation = currentRotation;
                gameObject.OnSetRotation(currentRotation);
            }
        }
#endif
    }
}