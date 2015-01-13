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
    public class ActionSetWanderSliceState : BaseAction
    {
        public string ID { get; private set; }
        public ActionSetSliceState.SliceState State { get; private set; }
        public bool StartLeft { get; private set; }
        public bool Cycle { get; private set; }
        public float Interval { get; private set; }
        public int Width { get; private set; }
        public int FormWidth { get; private set; }
        public int Repeat { get; private set; }

        private float passedTime;
        private int currentSlice;
        private int repeated;
        private GameObjectValue gameObject;
        private bool isMovingRight;

        public ActionSetWanderSliceState(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            Abortable = false;

            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_SET_WANDER_SLICE_STATE);
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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_STATE:
                            State = (ActionSetSliceState.SliceState)(int)actionProperty.Value;
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_START_LEFT:
                            StartLeft = Convert.ToBoolean(actionProperty.Value);
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_CYCLE:
                            Cycle = Convert.ToBoolean(actionProperty.Value);
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_INTERVAL:
                            Interval = (float)actionProperty.Value;
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_WIDTH:
                            Width = Convert.ToInt32(actionProperty.Value);
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_FORM_WIDTH:
                            FormWidth = Convert.ToInt32(actionProperty.Value);
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_REPEAT:
                            Repeat = Convert.ToInt32(actionProperty.Value);
                        break;
                    }
                    actionToken = actionToken.Next;
                }
            }

            isMovingRight = StartLeft;

            GameObjectValueManager.Instance.RegisterActionID(SerializationConstants.ACTION_SET_SLICE_STATE.Name, ID);
        }

        public override void Execute()
        {
            currentSlice = isMovingRight ? -Width : FormWidth - 1;
            passedTime = 0;
            repeated = 0;
            gameObject = GameObjectValueManager.Instance.GetGameObjectByID(ID);
            base.Execute();

            if (gameObject.OnSetWanderSliceState != null)
                gameObject.OnSetWanderSliceState(State, currentSlice, Width);
        }

// there is no gametime class for xna in windows forms
#if !EDITOR
        public override void Update(GameTime gameTime)
        {
            passedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            while (passedTime >= Interval)
            {
                if (isMovingRight)
                    ++currentSlice;
                else
                    --currentSlice;

                if (isMovingRight && currentSlice >= FormWidth)
                {
                    if (!Cycle)
                        currentSlice = -Width;
                    else
                    {
                        currentSlice = FormWidth - 1;
                        isMovingRight = false;
                    }

                    if (Repeat > 0)
                        ++repeated;
                }

                else if (!isMovingRight && currentSlice <= -Width)
                {
                    if (!Cycle)
                        currentSlice = FormWidth - 1;
                    else
                    {
                        currentSlice = -Width + 1;
                        isMovingRight = true;
                    }

                    if (Repeat > 0)
                        ++repeated;
                }

                if (gameObject.OnSetWanderSliceState != null)
                    gameObject.OnSetWanderSliceState(State, currentSlice, Width);

                passedTime -= Interval;
            }

            if (Repeat > 0 && repeated >= Repeat)
            {
                if (gameObject.OnSetWanderSliceState != null)
                    gameObject.OnSetWanderSliceState(State, FormWidth, Width);

                Finish();
            }
        }
#endif
    }
}
