using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Simetry.Interface.Actions;
using Simetry.Interface.Globals;

namespace Simetry.Interface.Serialization
{
    public class GameObjectValue
    {
        #region Delegates for Action Events
        public NotifySetMovementValues OnSetMovementValues;
        public NotifySetPosition OnSetPosition;
        public NotifySetRotation OnSetRotation;
        public NotifyEnableDisable OnEnableDisable;
        public NotifyPlayAnimationClip OnPlayAnimationClip;
        public NotifyPlayAnimationClipReverse OnPlayAnimationClipReverse;
        public NotifyPlaySound OnPlaySound;
        public NotifyArriveCheckpoint OnArriveCheckpoint;
        public NotifySetSliceState OnSetSliceState;
        public NotifySetWanderSliceState OnSetWanderSliceState;
        public NotifySetCameraZoom OnSetCameraZoom;
        public NotifySpawnQuad OnSpawnQuad;
        public NotifySpawnTriangle OnSpawnTriangle;
        public NotifySetAllowBuilding OnSetAllowBuilding;
        public NotifySetAllowWeaponReel OnSetAllowWeaponReel;
        public NotifySetAllowBuildingHeavySlices OnSetAllowBuildingHeavySlices;
        public NotifySetAllowCollecting OnSetAllowCollecting;
        public NotifySetIsTutorial OnSetIsTutorial;
        public NotifyDestroyVisibleSlices OnDestroyVisibleSlices;
        public NotifyDestroySlicesInTriggerZone OnDestroySlicesInTriggerZone;
        public NotifyScaleAndMoveToPlayer OnScaleAndMoveToPlayer;
        public NotifyShowFullScreenTexture OnShowFullScreenTexture;
        public NotifyChangeAmbientLight OnChangeAmbientLight;
        #endregion

        // for identification purpose (for instance for action sequences)
        public string ID { get; set; }
        public Vector3 Position { get; set; }
        // in degrees
        public int Rotation { get; set; }

        public GameObjectValue() : this(SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID, SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION, SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ROTATION) { }

        public GameObjectValue(string id, Vector3 position) : this(id, position, SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ROTATION) { }

        public GameObjectValue(string id, Vector3 position, int rotation)
        {
            ID = id;
            Position = position;
            Rotation = rotation;
            
            // for continuous movements the current position should always be stored
            if (ID != SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID)
                OnSetPosition += new NotifySetPosition(delegate(Vector3 gridPosition) { Position = gridPosition; });
        }

        // if the game object has an id, register it so that it can be found by the game object manager
        public bool RegisterGameObject()
        {
            if (ID == SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID)
                return false;

            GameObjectValueManager.Instance.RegisterGameObject(this);
            return true;
        }

        public static Vector2 Vector2FromJArray(JArray positionArray)
        {
            return new Vector2(positionArray[0].Value<float>(), positionArray[1].Value<float>());
        }

        public static Vector3 Vector3FromJArray(JArray positionArray)
        {
            if (positionArray.Count == 2)
                return new Vector3(positionArray[0].Value<float>(), positionArray[1].Value<float>(), SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION_Z);

            return new Vector3(positionArray[0].Value<float>(), positionArray[1].Value<float>(), positionArray[2].Value<float>());
        }

        public static Vector4 Vector4FromJArray(JArray positionArray)
        {
            return new Vector4(positionArray[0].Value<float>(), positionArray[1].Value<float>(), positionArray[2].Value<float>(), positionArray[3].Value<float>());
        }

        // TODO encapsulate parsing of slice values into slice value class
        public static GameObjectValue CreateFromJson(JObject gameObjectValue)
        {
            // standard values
            string id = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID;
            Vector3 position = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION;
            int rotation = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ROTATION;
          
            JToken gameObjectToken = gameObjectValue.First;

            while (gameObjectToken != null)
            {
                JProperty gameObjectProperty = (JProperty)gameObjectToken;

                switch (gameObjectProperty.Name)
                {
                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ID:
                        id = gameObjectProperty.Value.ToString();
                        break;
                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION:
                        position = Vector3FromJArray((JArray)gameObjectProperty.Value);
                        break;
                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ROTATION:
                        rotation = Convert.ToInt32(gameObjectProperty.Value);
                        break;
                }

                gameObjectToken = gameObjectToken.Next;
            }

            GameObjectValue newGameObject = new GameObjectValue(id, position, rotation);
            newGameObject.RegisterGameObject();

            return newGameObject;
        }

        public virtual bool WriteToJSON(JsonTextWriter writer)
        {
            if (ID != SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ID);
                writer.WriteValue(ID);
            }
            if (Position != SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION);
                writer.WriteStartArray();
                writer.WriteValue(Position.X);
                writer.WriteValue(Position.Y);
                if (Position.Z != SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION_Z)
                    writer.WriteValue(Position.Z);
                writer.WriteEndArray();
            }
            if (Rotation != SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ROTATION)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ROTATION);
                writer.WriteValue(Rotation);
            }

            return true;
        }
    }
}
