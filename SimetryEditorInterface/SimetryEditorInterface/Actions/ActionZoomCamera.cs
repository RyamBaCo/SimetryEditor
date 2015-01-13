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
    public class ActionZoomCamera : BaseAction
    {
        public float From { get; private set; }
        public float Zoom { get; private set; }
        public int Speed { get; private set; }

        private float passedTime;
        private GameObjectValue gameObject;

        public ActionZoomCamera(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            : base(executeOnEnter, executeOnExit, executeOnKey)
        {
            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_ZOOM_CAMERA);
            ActionValue.Parameters = parameters;
            From = 1.0f;

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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_FROM:
                            From = (float)actionProperty.Value;
                            break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ZOOM:
                            Zoom = (float)actionProperty.Value;
                            break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_SPEED:
                            Speed = Convert.ToInt32(actionProperty.Value);
                            break;
                    }
                    actionToken = actionToken.Next;
                }
            }
        }

        public override void Execute()
        {
            passedTime = 0;
            gameObject = GameObjectValueManager.Instance.GetGameObjectByID(GlobalIDs.ID_CAMERA);
            base.Execute();
        }

        // there is no gametime class for xna in windows forms
#if !EDITOR
        public override void Update(GameTime gameTime)
        {
            passedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            float currentZoom = MathHelper.Lerp(From, Zoom, Math.Min(1.0f, passedTime * Speed / 10.0f));

            if(gameObject.OnSetCameraZoom != null)
                gameObject.OnSetCameraZoom(currentZoom);

            if (currentZoom == Zoom)
                Finish();
        }
#endif
    }
}