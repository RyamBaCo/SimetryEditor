using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simetry.Interface.Actions;
using Simetry.Interface.Globals;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Simetry.Interface.Serialization
{
    public class TriggerZoneValue : GameObjectValue
    {
        public enum ExecuteActionType
        {
            ENTER,
            EXIT,
            KEY
        }

        #region Values for Serialization
        public Vector2 Size { get; set; }
        public bool TriggerByAll { get; set; } // if false only triggers by player
        public bool ExecuteOnce { get; set; }
        public bool ExecuteParallel { get; set; }
        public List<BaseAction> Actions { get; set; }
        #endregion

        public TriggerZoneValue() : this(SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID, SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION, SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_SIZE, SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_TRIGGER_BY_ALL, SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_EXECUTE_ONCE, SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_EXECUTE_PARALLEL) { }

        public TriggerZoneValue(string id, Vector3 position, Vector2 size, bool triggerByAll, bool executeOnce, bool executeParallel)
            : base(id, position)
        {
            Actions = new List<BaseAction>();
            Size = size;
            TriggerByAll = triggerByAll;
            ExecuteOnce = executeOnce;
            ExecuteParallel = executeParallel;
        }

        public TriggerZoneValue(TriggerZoneValue value) : this(value.ID, value.Position, value.Size, value.TriggerByAll, value.ExecuteOnce, value.ExecuteParallel)
        {
            foreach (BaseAction action in value.Actions)
            {
                BaseAction savedAction = BaseAction.CreateActionByParameters(action.ActionValue);
                savedAction.CopyValuesFromAction(action);
                Actions.Add(savedAction);
            }
        }

        public void ExecuteActions(ExecuteActionType executeType)
        {
            foreach (BaseAction action in Actions)
                if (!action.HasStarted &&
                    (   action.ExecuteOnEnter && executeType == ExecuteActionType.ENTER ||
                        action.ExecuteOnExit && executeType == ExecuteActionType.EXIT ||
                        action.ExecuteOnKey && executeType == ExecuteActionType.KEY))
                {
                    action.Execute();

                    // in sequental execution mode search for the next action if action has finished
                    if (!ExecuteParallel && action.HasFinished)
                        for (int j = 0; j < Actions.Count; ++j)
                        {
                            if (!Actions[j].HasStarted &&
                                ((Actions[j].ExecuteOnEnter && action.ExecuteOnEnter) ||
                                    (Actions[j].ExecuteOnExit && action.ExecuteOnExit) ||
                                    (Actions[j].ExecuteOnKey && action.ExecuteOnKey)))
                            {
                                Actions[j].Execute();

                                if (!Actions[j].HasFinished)
                                    break;
                            }
                        }

                    // on sequental execution only execute the first action found
                    if(!ExecuteParallel)
                        break;
                }
        }

        public void ResetActions(ExecuteActionType executeType)
        {
            foreach (BaseAction action in Actions)
                if (action.Abortable &&
                    (   action.ExecuteOnEnter && executeType == ExecuteActionType.ENTER ||
                        action.ExecuteOnExit && executeType == ExecuteActionType.EXIT ||
                        action.ExecuteOnKey && executeType == ExecuteActionType.KEY))
                {
                    action.Reset();
                }
        }

        public bool HasActionDestroySlicesInTriggerZone()
        {
            for (int i = 0; i < Actions.Count; ++i)
                if (Actions[i] is ActionDestroySlicesInTriggerZone)
                    return true;
            return false;
        }

        // there is no gametime class for xna in windows forms
#if !EDITOR
        public void Update(GameTime gameTime) 
        {
            for(int i = 0; i < Actions.Count; ++i)
                if (Actions[i].HasStarted && !Actions[i].HasFinished)
                {
                    Actions[i].Update(gameTime);

                    // in sequental execution mode search for the next action
                    if(!ExecuteParallel && Actions[i].HasFinished)
                        for (int j = 0; j < Actions.Count; ++j)
                        {
                            if (!Actions[j].HasStarted &&
                                ((Actions[j].ExecuteOnEnter && Actions[i].ExecuteOnEnter) ||
                                    (Actions[j].ExecuteOnExit && Actions[i].ExecuteOnExit) ||
                                    (Actions[j].ExecuteOnKey && Actions[i].ExecuteOnKey)))
                            {
                                Actions[j].Execute();

                                if (!Actions[j].HasFinished)
                                    break;
                            }
                        }
                }
        }
#endif

        public static new TriggerZoneValue CreateFromJson(JObject triggerZoneValue)
        {
            // standard values
            string id = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID;
            Vector3 position = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION;
            int rotation = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ROTATION;
            Vector2 size = SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_SIZE;
            bool triggerByAll = SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_TRIGGER_BY_ALL;
            bool executeOnce = SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_EXECUTE_ONCE;
            bool executeParallel = SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_EXECUTE_PARALLEL;
            List<BaseAction> actions = new List<BaseAction>();

            JToken triggerZoneToken = triggerZoneValue.First;

            while (triggerZoneToken != null)
            {
                JProperty triggerZoneProperty = (JProperty)triggerZoneToken;

                switch (triggerZoneProperty.Name)
                {
                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ID:
                        id = triggerZoneProperty.Value.ToString();
                    break;
                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION:
                        position = Vector3FromJArray((JArray)triggerZoneProperty.Value);
                    break;
                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ROTATION:
                        rotation = Convert.ToInt32(triggerZoneProperty.Value);
                    break;
                    case SerializationConstants.JSON_PROPERTY_TRIGGER_ZONE_SIZE:
                        JArray triggerZoneSizeArray = (JArray)triggerZoneProperty.Value;
                        size = new Vector2(triggerZoneSizeArray[0].Value<float>(), triggerZoneSizeArray[1].Value<float>());
                    break;
                    case SerializationConstants.JSON_PROPERTY_TRIGGER_ZONE_TRIGGER_BY_ALL:
                        triggerByAll = Convert.ToBoolean(triggerZoneProperty.Value);
                    break;
                    case SerializationConstants.JSON_PROPERTY_TRIGGER_ZONE_EXECUTE_ONCE:
                        executeOnce = Convert.ToBoolean(triggerZoneProperty.Value);
                    break;
                   case SerializationConstants.JSON_PROPERTY_TRIGGER_ZONE_EXECUTE_PARALLEL:
                        executeParallel = Convert.ToBoolean(triggerZoneProperty.Value);
                    break;
                    case SerializationConstants.JSON_PROPERTY_TRIGGER_ZONE_ACTIONS:
                        JArray actionsArray = (JArray)triggerZoneProperty.Value;
                        for (int i = 0; i < actionsArray.Count; ++i)
                            actions.Add(BaseAction.CreateFromJson(actionsArray[i].First));
                    break;
                }

                triggerZoneToken = triggerZoneToken.Next;
            }

            TriggerZoneValue triggerZone = new TriggerZoneValue(id, position, size, triggerByAll, executeOnce, executeParallel);
            triggerZone.Actions = actions;
            triggerZone.RegisterGameObject();
            return triggerZone;
        }

        public override bool WriteToJSON(JsonTextWriter writer)
        {
            writer.WriteStartObject();

            // write game object values
            base.WriteToJSON(writer);

            if(Size != SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_SIZE)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_TRIGGER_ZONE_SIZE);
                writer.WriteStartArray();
                writer.WriteValue(Size.X);
                writer.WriteValue(Size.Y);
                writer.WriteEndArray();
            }
            if (TriggerByAll != SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_TRIGGER_BY_ALL)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_TRIGGER_ZONE_TRIGGER_BY_ALL);
                writer.WriteValue(TriggerByAll);
            }
            if (ExecuteOnce != SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_EXECUTE_ONCE)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_TRIGGER_ZONE_EXECUTE_ONCE);
                writer.WriteValue(ExecuteOnce);
            }
            if (ExecuteParallel != SerializationConstants.DEFAULT_VALUE_TRIGGER_ZONE_EXECUTE_PARALLEL)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_TRIGGER_ZONE_EXECUTE_PARALLEL);
                writer.WriteValue(ExecuteParallel);
            }

            writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_TRIGGER_ZONE_ACTIONS);
            writer.WriteStartArray();
            foreach (BaseAction action in Actions)
                action.WriteToJSON(writer);
            writer.WriteEndArray();

            writer.WriteEndObject();
            return true;
        }
    }
}
