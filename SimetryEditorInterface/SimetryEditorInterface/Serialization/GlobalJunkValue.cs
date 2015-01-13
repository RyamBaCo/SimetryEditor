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
    /// this class contains general information about the level junk, like size, background, sound,...
    /// </summary>
    public class GlobalJunkValue
    {
        // TODO add and synchronize information regarding neighboring junks
        public Vector2 LevelSize { get; set; }

        public GlobalJunkValue(Vector2 levelSize)
        {
            LevelSize = levelSize;
        }

        public static GlobalJunkValue CreateFromJson(JObject junkValue)
        {
            Vector2 levelSize = Vector2.Zero;

            JToken junkValueToken = junkValue.First;

            while (junkValueToken != null)
            {
                JProperty junkValueProperty = (JProperty)junkValueToken;

                switch (junkValueProperty.Name)
                {
                    case SerializationConstants.JSON_PROPERTY_LEVEL_JUNK_SIZE:
                        JArray levelJunkSizeArray = (JArray)junkValueProperty.Value;
                        levelSize = new Vector2(levelJunkSizeArray[0].Value<float>(), levelJunkSizeArray[1].Value<float>());
                    break;
                }

                junkValueToken = junkValueToken.Next;
            }

            return new GlobalJunkValue(levelSize);
        }

        public bool WriteToJSON(JsonTextWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_LEVEL_JUNK_SIZE);
            writer.WriteStartArray();
            writer.WriteValue(LevelSize.X);
            writer.WriteValue(LevelSize.Y);
            writer.WriteEndArray();

            writer.WriteEndObject();
            return true;
        }
    }
}
