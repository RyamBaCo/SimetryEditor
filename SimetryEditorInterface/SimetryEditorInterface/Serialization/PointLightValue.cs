using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Simetry.Interface.Globals;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Simetry.Interface.Serialization
{
    public class PointLightValue : MetadataGameObjectValue
    {
        public float Radius { get; private set; }
        public Vector4 Color { get; private set; }
        public float Intensity { get; private set; }
        public float Attenuation { get; private set; }
        public bool Shadows { get; private set; }
        public int Resolution { get; private set; }

        public PointLightValue(MetadataGameObjectValue value)
            : base(value.ID, value.Type, value.Parameters)
        {
            using (TextReader stringReader = new StringReader(Parameters))
            using (JsonReader reader = new JsonTextReader(stringReader))
            {
                JObject objectValue = JObject.Load(reader);
                JToken objectToken = objectValue.First;

                while (objectToken != null)
                {
                    JProperty objectProperty = (JProperty)objectToken;
                    switch (objectProperty.Name)
                    {
                        case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION:
                            Position = Vector3FromJArray((JArray)objectProperty.Value);
                            break;
                        case SerializationConstants.JSON_PROPERTY_POINT_LIGHT_RADIUS:
                            Radius = (float)objectProperty.Value;
                            break;
                        case SerializationConstants.JSON_PROPERTY_POINT_LIGHT_COLOR:
                            Color = Vector4FromJArray((JArray)objectProperty.Value);
                            break;
                        case SerializationConstants.JSON_PROPERTY_POINT_LIGHT_INTENSITY:
                            Intensity = (float)objectProperty.Value;
                            break;
                        case SerializationConstants.JSON_PROPERTY_POINT_LIGHT_ATTENUATION:
                            Attenuation = (float)objectProperty.Value;
                            break;
                        case SerializationConstants.JSON_PROPERTY_POINT_LIGHT_SHADOWS:
                            Shadows = Convert.ToBoolean(objectProperty.Value);
                            break;
                        case SerializationConstants.JSON_PROPERTY_POINT_LIGHT_RESOLUTION:
                            Resolution = (int)objectProperty.Value;
                            break;
                    }
                    objectToken = objectToken.Next;
                }
            }
        }
    }
}
