using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simetry.Interface.Globals;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Xna.Framework;

namespace Simetry.Interface.Actions
{
    public partial class BaseAction
    {
        // for identification through serialization
        public SerializationConstants.ActionValue ActionValue { get; set; }

        public bool ExecuteOnEnter { get; set; }
        public bool ExecuteOnExit { get; set; }
        public bool ExecuteOnKey { get; set; }

        public bool HasStarted { get; private set; }
        public bool HasFinished { get; private set; }
        public bool Abortable { get; protected set; }

        // by default execute on enter
        public BaseAction() : this(SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_ENTER, SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_EXIT, SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_KEY) { }

        public BaseAction(bool executeOnEnter, bool executeOnExit, bool executeOnKey)
        {
            ActionValue = SerializationConstants.ACTION_BASE;
            ExecuteOnEnter = executeOnEnter;
            ExecuteOnExit = executeOnExit;
            ExecuteOnKey = executeOnKey;
            Abortable = true;

            Reset();
        }

        public void CopyValuesFromAction(BaseAction action)
        {
            ActionValue = action.ActionValue;
            ExecuteOnEnter = action.ExecuteOnEnter;
            ExecuteOnExit = action.ExecuteOnExit;
            ExecuteOnKey = action.ExecuteOnKey;
            Abortable = action.Abortable;
            HasStarted = action.HasStarted;
            HasFinished = action.HasFinished;
            Abortable = action.Abortable;
            ActionValue = action.ActionValue;

            HasStarted = action.HasStarted;
            HasFinished = action.HasFinished;

            if (HasStarted && !HasFinished)
                Execute();
        }

        public virtual void Reset() 
        { 
            HasStarted = false; 
            HasFinished = false; 
        }

        public virtual void Execute() { HasStarted = true; }
        public virtual void Finish() 
        {
            Abortable = true;
            HasFinished = true; 
        }

// there is no gametime class for xna in windows forms
#if !EDITOR
        public virtual void Update(GameTime gameTime) { }
#endif

        public virtual bool WriteToJSON(JsonTextWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_ACTION_NAME);
            writer.WriteValue(ActionValue.Name);
            writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_ACTION_PARAMETERS);
            writer.WriteValue(ActionValue.Parameters);
            if (ExecuteOnEnter != SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_ENTER)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_ACTION_EXECUTE_ON_ENTER);
                writer.WriteValue(ExecuteOnEnter);
            }
            if (ExecuteOnExit != SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_EXIT)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_ACTION_EXECUTE_ON_EXIT);
                writer.WriteValue(ExecuteOnExit);
            }
            if (ExecuteOnKey != SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_KEY)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_ACTION_EXECUTE_ON_KEY);
                writer.WriteValue(ExecuteOnKey);
            }

            writer.WriteEndObject();
            return true;
        }

        public static BaseAction CreateFromJson(JToken actionToken)
        {
            SerializationConstants.ActionValue actionValue = new SerializationConstants.ActionValue();
            bool executeOnEnter = SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_ENTER;
            bool executeOnExit = SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_EXIT;
            bool executeOnKey = SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_KEY;

            while (actionToken != null)
            {
                JProperty actionProperty = (JProperty)actionToken;

                switch (actionProperty.Name)
                {
                    case SerializationConstants.JSON_PROPERTY_ACTION_NAME:
                        actionValue.Name = actionProperty.Value.ToString();
                    break;
                    case SerializationConstants.JSON_PROPERTY_ACTION_PARAMETERS:
                        actionValue.Parameters = actionProperty.Value.ToString();
                    break;
                    case SerializationConstants.JSON_PROPERTY_ACTION_EXECUTE_ON_ENTER:
                        executeOnEnter = Convert.ToBoolean(actionProperty.Value);
                    break;
                    case SerializationConstants.JSON_PROPERTY_ACTION_EXECUTE_ON_EXIT:
                        executeOnExit = Convert.ToBoolean(actionProperty.Value);
                    break;
                    case SerializationConstants.JSON_PROPERTY_ACTION_EXECUTE_ON_KEY:
                        executeOnKey = Convert.ToBoolean(actionProperty.Value);
                    break;
                }
                actionToken = actionToken.Next;
            }

            return CreateActionByParameters(actionValue, executeOnEnter, executeOnExit, executeOnKey);
        }

        public static BaseAction CreateActionByParameters(SerializationConstants.ActionValue actionValue)
        {
            return CreateActionByParameters(actionValue, SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_ENTER, SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_EXIT, SerializationConstants.DEFAULT_VALUE_BASE_ACTION_EXECUTE_ON_KEY);
        }

        public static BaseAction CreateActionByParameters(SerializationConstants.ActionValue actionValue, bool executeOnEnter, bool executeOnExit, bool executeOnKey)
        {
            if (actionValue.Name == SerializationConstants.ACTION_MOVE_OBJECT.Name)
                return new ActionMoveGameObject(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_ROTATE_OBJECT.Name)
                return new ActionRotateGameObject(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_PLAY_ANIMATION.Name)
                return new ActionPlayAnimation(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_PLAY_ANIMATION_REVERSE.Name)
                return new ActionPlayAnimationReverse(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_PLAY_SOUND.Name)
                return new ActionPlaySound(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_DELAY.Name)
                return new ActionDelay(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_ENABLE_DISABLE.Name)
                return new ActionEnableDisable(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_ARRIVE_CHECKPOINT.Name)
                return new ActionArriveCheckpoint(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_SET_SLICE_STATE.Name)
                return new ActionSetSliceState(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_SET_WANDER_SLICE_STATE.Name)
                return new ActionSetWanderSliceState(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_ZOOM_CAMERA.Name)
                return new ActionZoomCamera(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_SPAWN_QUAD.Name)
                return new ActionSpawnQuad(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_SPAWN_TRIANGLE.Name)
                return new ActionSpawnTriangle(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_ALLOW_BUILDING.Name)
                return new ActionAllowBuilding(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_ALLOW_WEAPON_REEL.Name)
                return new ActionAllowWeaponReel(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_ALLOW_BUILDING_HEAVY_SLICES.Name)
                return new ActionAllowBuildingHeavySlices(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_ALLOW_COLLECTING.Name)
                return new ActionAllowCollecting(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_ALLOW_TUTORIAL.Name)
                return new ActionSetIsTutorial(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_DESTROY_VISIBLE_SLICES.Name)
                return new ActionDestroyAllVisibleSlices(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_DESTROY_SLICES_IN_TRIGGER_ZONE.Name)
                return new ActionDestroySlicesInTriggerZone(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_SCALE_AND_MOVE_TO_PLAYER.Name)
                return new ActionScaleAndMoveToPlayer(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_SHOW_FULLSCREEN_TEXTURE.Name)
                return new ActionShowFullscreenTexture(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);
            else if (actionValue.Name == SerializationConstants.ACTION_CHANGE_AMBIENT_LIGHT.Name)
                return new ActionChangeAmbientLight(executeOnEnter, executeOnExit, executeOnKey, actionValue.Parameters);

            throw new Exception("BaseAction::CreateActionByParameters: Action Name " + actionValue.Name + " not defined.");
        }
    }
}
