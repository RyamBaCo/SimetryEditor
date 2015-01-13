using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Simetry.Interface.Globals;

namespace Simetry.Interface.Serialization
{
    /// <summary>
    /// for meta data such as background, lights,...
    /// </summary>
    public class MetadataGameObjectValue : GameObjectValue
    {
        public string Type { get; set; }
        public string Parameters { get; set; }

        public MetadataGameObjectValue() { }

        public MetadataGameObjectValue(string id, Vector3 position) : base(id, position) { }

        public MetadataGameObjectValue(string id, string type, string parameters) : this(id, SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION, SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ROTATION, type, parameters) { }

        public MetadataGameObjectValue(string id, Vector3 position, string type) : this(id, position, SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ROTATION, type, SerializationConstants.DEFAULT_VALUE_METADATA_GAME_OBJECT_PARAMETERS) { }

        public MetadataGameObjectValue(string id, Vector3 position, int rotation, string type, string parameters) : base(id, position, rotation)
        {
            Type = type;
            Parameters = parameters;
        }

        public static new MetadataGameObjectValue CreateFromJson(JObject gameObjectValue)
        {
            // standard values
            string id = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID;
            Vector3 position = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION;
            int rotation = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ROTATION;
            string type = SerializationConstants.DEFAULT_VALUE_METADATA_GAME_OBJECT_TYPE;
            string parameters = SerializationConstants.DEFAULT_VALUE_METADATA_GAME_OBJECT_PARAMETERS;
          
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
                    case SerializationConstants.JSON_PROPERTY_METADATA_GAME_OBJECT_TYPE:
                        type = gameObjectProperty.Value.ToString();
                        break;
                    case SerializationConstants.JSON_PROPERTY_METADATA_GAME_OBJECT_PARAMETERS:
                        parameters = gameObjectProperty.Value.ToString();
                        break;
                }

                gameObjectToken = gameObjectToken.Next;
            }

            MetadataGameObjectValue newGameObject = CreateMetadataGameObject(new MetadataGameObjectValue(id, position, rotation, type, parameters));
            newGameObject.RegisterGameObject();

            return newGameObject;
        }

        public static MetadataGameObjectValue CreateMetadataGameObject(MetadataGameObjectValue value)
        {
            if (value.Type == SerializationConstants.METADATA_TYPE_POSITION)
                return value;
            else if (value.Type == SerializationConstants.METADATA_TYPE_BACKGROUND)
                return new BackgroundValue(value);
            else if (value.Type == SerializationConstants.METADATA_TYPE_POINT_LIGHT)
                return new PointLightValue(value);

            throw new Exception("MetadataGameObjectValue::CreateMetadataGameObject: Value Type " + value.Type + " not defined.");
        }

        public override bool WriteToJSON(JsonTextWriter writer)
        {
            writer.WriteStartObject();

            // write game object values
            base.WriteToJSON(writer);

            if (Type != SerializationConstants.DEFAULT_VALUE_METADATA_GAME_OBJECT_TYPE)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_METADATA_GAME_OBJECT_TYPE);
                writer.WriteValue(Type);
            }

            if (Parameters != SerializationConstants.DEFAULT_VALUE_METADATA_GAME_OBJECT_PARAMETERS)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_METADATA_GAME_OBJECT_PARAMETERS);
                writer.WriteValue(Parameters);
            }

            writer.WriteEndObject();
            return true;
        }
    }
}
