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
    public class BackgroundValue : MetadataGameObjectValue
    {
        public string AssetName { get; private set; }
        public new Vector3 Rotation { get; private set; }
        public Vector3 Scale { get; private set; }
        public Vector2 Repeat { get; private set; }
        public Vector4 RepeatGap { get; private set; }
        public int AnimationDelay { get; private set; }

        public BackgroundValue(MetadataGameObjectValue value) : base(value.ID, value.Type, value.Parameters)
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
                        case SerializationConstants.JSON_PROPERTY_BACKGROUND_ASSET:
                            AssetName = objectProperty.Value.ToString();
                            break;
                        case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION:
                            Position = Vector3FromJArray((JArray)objectProperty.Value);
                            break;
                        case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ROTATION:
                            Rotation = Vector3FromJArray((JArray)objectProperty.Value);
                            break;
                        case SerializationConstants.JSON_PROPERTY_BACKGROUND_SCALE:
                            Scale = Vector3FromJArray((JArray)objectProperty.Value);
                            break;
                        case SerializationConstants.JSON_PROPERTY_BACKGROUND_REPEAT:
                            Repeat = Vector2FromJArray((JArray)objectProperty.Value);
                            break;
                        case SerializationConstants.JSON_PROPERTY_BACKGROUND_REPEAT_GAP:
                            RepeatGap = Vector4FromJArray((JArray)objectProperty.Value);
                            break;
                        case SerializationConstants.JSON_PROPERTY_BACKGROUND_ANIMATION_DELAY:
                            AnimationDelay = (int)objectProperty.Value;
                            break;
                    }
                    objectToken = objectToken.Next;
                }
            }
        }
    }
}
