using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Simetry.Interface.Globals;

namespace Simetry.Interface.Serialization
{
    /// <summary>
    /// responsible for saving and loading data structures from json files
    /// serialization is done manually as it should be the fastest way depending on json.net documentation
    /// </summary>
    public class SerializationManager
    {
        #region Singleton Pattern
        private static readonly SerializationManager instance = new SerializationManager();
        public static SerializationManager Instance { get { return instance; } }
        #endregion
        public IGlobalJunkValueAdder JunkAddInterface { get; set; }
        public IFormAdder FormAddInterface { get; set; }
        public IMetadataGameObjectAdder MetadataGameObjectAddInterface { get; set; }
        public ITriggerZoneAdder TriggerZoneAddInterface { get; set; }

        private SerializationManager() 
        { 
            FormAddInterface = null; 
            MetadataGameObjectAddInterface = null;
            TriggerZoneAddInterface = null;
        }

        // TODO add error handling
        public bool WriteJunkValuesToJSON(string fileName, GlobalJunkValue junkValue, List<FormValue> formValues, List<MetadataGameObjectValue> metadataGameObjects, List<TriggerZoneValue> triggerZones)
        {
            using (TextWriter textWriter = new StreamWriter(fileName))
            using (JsonTextWriter writer = new JsonTextWriter(textWriter))
            {
                writer.WriteStartArray();
                writer.WriteStartObject();
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_GLOBAL_JUNK_VALUES);
                junkValue.WriteToJSON(writer);
                writer.WriteEndObject();
                if (formValues.Count > 0)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_FORMS);
                    writer.WriteStartArray();
                    foreach (FormValue formValue in formValues)
                        formValue.WriteToJSON(writer);
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
                if (metadataGameObjects.Count > 0)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_GAME_OBJECTS);
                    writer.WriteStartArray();
                    foreach (MetadataGameObjectValue metadataGameObject in metadataGameObjects)
                        metadataGameObject.WriteToJSON(writer);
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
                if (triggerZones.Count > 0)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_TRIGGER_ZONES);
                    writer.WriteStartArray();
                    foreach (TriggerZoneValue triggerZone in triggerZones)
                        triggerZone.WriteToJSON(writer);
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
            return true;
        }

        // TODO add error handling
        public void ReadJunkValuesFromJSON(string fileName)
        {
            if (JunkAddInterface == null)
                throw new Exception("SerializationManager::ReadJunkValuesFromJSON: JunkAddInterface is null!");
            if (FormAddInterface == null)
                throw new Exception("SerializationManager::ReadJunkValuesFromJSON: FormAddInterface is null!");
            if (MetadataGameObjectAddInterface == null)
                throw new Exception("SerializationManager::ReadJunkValuesFromJSON: GameObjectAddInterface is null!");
            if (TriggerZoneAddInterface == null)
                throw new Exception("SerializationManager::ReadJunkValuesFromJSON: TriggerZoneAddInterface is null!");

            using (StreamReader textReader = new StreamReader(fileName))
            using (JsonReader reader = new JsonTextReader(textReader))
            {
                JArray junkValues = JArray.Load(reader);
                for (int i = 0; i < junkValues.Count; ++i)
                {
                    JObject junkValue = (JObject)junkValues[i];
                    JToken junkToken = junkValue.First;
                    while (junkToken != null)
                    {
                        JProperty junkProperty = (JProperty)junkToken;
                        switch (junkProperty.Name)
                        {
                            case SerializationConstants.JSON_PROPERTY_GLOBAL_JUNK_VALUES:
                                JunkAddInterface.AddGlobalJunkValue(GlobalJunkValue.CreateFromJson((JObject)junkProperty.Value));
                            break;
                            case SerializationConstants.JSON_PROPERTY_FORMS:
                                JArray formValues = (JArray)junkProperty.Value;
                                for (int j = 0; j < formValues.Count; ++j)
                                    FormAddInterface.AddFormValue(FormValue.CreateFromJson((JObject)formValues[j]));
                            break;
                            case SerializationConstants.JSON_PROPERTY_GAME_OBJECTS:
                                JArray gameObjectValues = (JArray)junkProperty.Value;
                                for (int j = 0; j < gameObjectValues.Count; ++j)
                                    MetadataGameObjectAddInterface.AddMetadataGameObject(MetadataGameObjectValue.CreateFromJson((JObject)gameObjectValues[j]));
                            break;
                            case SerializationConstants.JSON_PROPERTY_TRIGGER_ZONES:
                                JArray triggerZoneValues = (JArray)junkProperty.Value;
                                for (int j = 0; j < triggerZoneValues.Count; ++j)
                                    TriggerZoneAddInterface.AddTriggerZone(TriggerZoneValue.CreateFromJson((JObject)triggerZoneValues[j]));
                            break;
                        }

                        junkToken = junkToken.Next;
                    }
                }
            }
        }
    }
}
