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
    public class ActionSetSliceState : BaseAction
    {
        public enum SliceState
        {
            DESTROY = -1,
            LIGHT = 0,
            HEAVY,
            LETHAL,
            LETHAL_SOLID,
            SOLID,
            SLIPPERY
        }

        public string ID { get; private set; }
        public SliceState[] States { get; private set; }
        public float Interval { get; private set; }
        public int Repeat { get; private set; }

        private int repeats;
        private int stateIndex;
        private float passedTime;
        private GameObjectValue gameObject;

        public ActionSetSliceState(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            Abortable = false;

            ActionValue = new SerializationConstants.ActionValue(SerializationConstants.ACTION_SET_SLICE_STATE);
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
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_STATES:
                            JArray actionStatesArray = (JArray)actionProperty.Value;
                            States = new SliceState[actionStatesArray.Count];
                            for (int i = 0; i < actionStatesArray.Count; ++i)
                                States[i] = (SliceState)actionStatesArray[i].Value<int>();
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_INTERVAL:
                            Interval = (float)actionProperty.Value;
                        break;
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_REPEAT:
                            Repeat = Convert.ToInt32(actionProperty.Value);
                        break;
                    }
                    actionToken = actionToken.Next;
                }
            }

            GameObjectValueManager.Instance.RegisterActionID(SerializationConstants.ACTION_SET_SLICE_STATE.Name, ID);
        }

        public override void Execute()
        {
            passedTime = 0;
            gameObject = GameObjectValueManager.Instance.GetGameObjectByID(ID);
            stateIndex = 0;
            repeats = 0;
            if (gameObject.OnSetSliceState != null)
                gameObject.OnSetSliceState(States[stateIndex]);
            base.Execute();
            if (States.Length <= 1)
                Finish();
        }

// there is no gametime class for xna in windows forms
#if !EDITOR
        public override void Update(GameTime gameTime)
        {
            passedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (passedTime >= Interval)
            {
                passedTime -= Interval;
                ++stateIndex;

                if (stateIndex >= States.Length)
                {
                    stateIndex = 0;
                    if(Repeat > 0)
                        ++repeats;
                }

                if (gameObject.OnSetSliceState != null)
                    gameObject.OnSetSliceState(States[stateIndex]);
            }

            if (Repeat > 0 && repeats > Repeat)
                Finish();
        }
#endif
    }
}
