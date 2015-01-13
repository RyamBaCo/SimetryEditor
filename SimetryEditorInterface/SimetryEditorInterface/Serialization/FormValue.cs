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
    public class FormValue : GameObjectValue
    {
        #region Values for Serialization
        public List<SliceValue> Slices { get; set; }
        public List<SpecialSliceValue> SpecialSlices { get; set; }
        #endregion

        public FormValue()
        {
            Slices = new List<SliceValue>();
            SpecialSlices = new List<SpecialSliceValue>();
        }

        public FormValue(string id, Vector3 position, int rotation)
            : base(id, position, rotation)
        {
            Slices = new List<SliceValue>();
            SpecialSlices = new List<SpecialSliceValue>();
        }

        // TODO encapsulate parsing of slice values into slice value class
        public static new FormValue CreateFromJson(JObject formValue)
        {
            // standard values
            string id = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID;
            Vector3 position = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION;
            int rotation = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ROTATION;
            List<SliceValue> sliceValues = new List<SliceValue>();
            List<SpecialSliceValue> specialSliceValues = new List<SpecialSliceValue>();

            JToken formToken = formValue.First;

            while (formToken != null)
            {
                JProperty formProperty = (JProperty)formToken;

                switch (formProperty.Name)
                {
                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ID:
                        id = formProperty.Value.ToString();
                    break;
                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION:
                        position = Vector3FromJArray((JArray)formProperty.Value);
                    break;
                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ROTATION:
                        rotation = Convert.ToInt32(formProperty.Value);
                    break;
                    case SerializationConstants.JSON_PROPERTY_FORM_SLICES:
                        JArray slicesArray = (JArray)formProperty.Value;
                        for (int i = 0; i < slicesArray.Count; ++i)
                        {
                            JToken sliceToken = slicesArray[i].First;
                            Vector2 areaSize = Vector2.Zero;
                            SliceValue firstSlice = new SliceValue();
                            while (sliceToken != null)
                            {
                                JProperty sliceProperty = (JProperty)sliceToken;
                                switch (sliceProperty.Name)
                                {
                                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ID:
                                        firstSlice.ID = sliceProperty.Value.ToString();
                                    break;
                                    case SerializationConstants.JSON_PROPERTY_SLICE_TYPE:
                                        firstSlice.Type = (SliceValue.SliceType)Convert.ToInt32(sliceProperty.Value);
                                    break;
                                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION:
                                        firstSlice.Position = Vector3FromJArray((JArray)sliceProperty.Value);
                                    break;
                                    case SerializationConstants.JSON_PROPERTY_SLICE_AREA_SIZE:
                                        JArray areaSizeArray = (JArray)sliceProperty.Value;
                                        areaSize = new Vector2(areaSizeArray[0].Value<int>(), areaSizeArray[1].Value<int>());
                                    break;
                                    case SerializationConstants.JSON_PROPERTY_SLICE_BREAKABLE:
                                        firstSlice.Breakable = Convert.ToBoolean(sliceProperty.Value);
                                    break;
                                    case SerializationConstants.JSON_PROPERTY_SLICE_LETHAL:
                                        firstSlice.Lethal = Convert.ToBoolean(sliceProperty.Value);
                                    break;
                                    case SerializationConstants.JSON_PROPERTY_SLICE_HEAVY:
                                        firstSlice.Heavy = Convert.ToBoolean(sliceProperty.Value);
                                    break;
                                    case SerializationConstants.JSON_PROPERTY_SLICE_SLIPPERY:
                                        firstSlice.Slippery = Convert.ToBoolean(sliceProperty.Value);
                                    break;
                                }
                                sliceToken = sliceToken.Next;
                            }

                            for(int x = 0; x <= areaSize.X; ++x)
                                for (int y = 0; y <= areaSize.Y; ++y)
                                    sliceValues.Add(new SliceValue(firstSlice, firstSlice.Position + new Vector3(x, y, 0)));

                            firstSlice.RegisterGameObject();
                        }
                    break;
                    case SerializationConstants.JSON_PROPERTY_FORM_SPECIAL_SLICES:
                        JArray specialSlicesArray = (JArray)formProperty.Value;
                        for (int i = 0; i < specialSlicesArray.Count; ++i)
                        {
                            JToken sliceToken = specialSlicesArray[i].First;
                            Vector2 areaSize = Vector2.Zero;
                            SpecialSliceValue specialSlice = new SpecialSliceValue();
                            while (sliceToken != null)
                            {
                                JProperty sliceProperty = (JProperty)sliceToken;
                                switch (sliceProperty.Name)
                                {
                                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ID:
                                        specialSlice.ID = sliceProperty.Value.ToString();
                                    break;
                                    case SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_TYPE:
                                        specialSlice.Special = (SpecialSliceValue.SpecialType)Convert.ToInt32(sliceProperty.Value);
                                    break;
                                    case SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION:
                                        specialSlice.Position = Vector3FromJArray((JArray)sliceProperty.Value);
                                    break;
                                    case SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_SIZE:
                                        JArray sliceSize = (JArray)sliceProperty.Value;
                                        specialSlice.Size = new Vector2(sliceSize[0].Value<float>(), sliceSize[1].Value<float>());
                                    break;
                                    case SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_PARAMETERS:
                                        specialSlice.Parameters = sliceProperty.Value.ToString();
                                    break;
                                }
                                sliceToken = sliceToken.Next;
                            }
                            specialSliceValues.Add(specialSlice);
                            specialSlice.RegisterGameObject();
                        }
                    break;
                }
                
                formToken = formToken.Next;
            }

            FormValue newFormValue = new FormValue(id, position, rotation);
            newFormValue.Slices = sliceValues;
            newFormValue.SpecialSlices = specialSliceValues;
            newFormValue.RegisterGameObject();

            return newFormValue;
        }

        public override bool WriteToJSON(JsonTextWriter writer)
        {
            if (Slices.Count == 0 && SpecialSlices.Count == 0)
                return false;

            writer.WriteStartObject();

            // write game object values
            base.WriteToJSON(writer);

            if (Slices.Count > 0)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_FORM_SLICES);
                writer.WriteStartArray();

                Dictionary<Vector3, SliceValue> orderedSlices = new Dictionary<Vector3, SliceValue>();
                foreach (SliceValue sliceValue in Slices)
                    orderedSlices.Add(sliceValue.Position, sliceValue);

                foreach (SliceValue sliceValue in Slices)
                {
                    Vector3 positionToStart = sliceValue.Position;
                    Vector3 areaSize = Vector3.Zero;

                    if (orderedSlices.ContainsKey(positionToStart))
                    {
                        #region calculate area size
                        // get the leftest topmost neighbor with the same properties
                        while (orderedSlices.ContainsKey(positionToStart) && orderedSlices[positionToStart].Compare(sliceValue))
                            --positionToStart.X;
                        ++positionToStart.X;
                        while (orderedSlices.ContainsKey(positionToStart) && orderedSlices[positionToStart].Compare(sliceValue))
                            --positionToStart.Y;
                        ++positionToStart.Y;
                        // go to the rightest neighbor
                        while (orderedSlices.ContainsKey(positionToStart + areaSize) && orderedSlices[positionToStart + areaSize].Compare(sliceValue))
                            ++areaSize.X;

                        // check for neighbors beyond --> only accept if the whole row is filled!
                        bool sliceInSizeArea = true;
                        while (sliceInSizeArea)
                        {
                            ++areaSize.Y;
                            for (int x = 0; x < areaSize.X; ++x)
                            {
                                Vector3 offsetPosition = new Vector3(x, areaSize.Y, 0);
                                if (!orderedSlices.ContainsKey(positionToStart + offsetPosition) || !orderedSlices[positionToStart + offsetPosition].Compare(sliceValue))
                                {
                                    sliceInSizeArea = false;
                                    break;
                                }
                            }
                        }

                        // remove all processed slices from the dictionary
                        for (int x = 0; x < areaSize.X; ++x)
                            for (int y = 0; y < areaSize.Y; ++y)
                                orderedSlices.Remove(positionToStart + new Vector3(x, y, 0));

                        if (areaSize != Vector3.Zero)
                        {
                            --areaSize.X;
                            --areaSize.Y;
                        }
                        #endregion

                        writer.WriteStartObject();

                        if (sliceValue.ID != SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID)
                        {
                            writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ID);
                            writer.WriteValue(sliceValue.ID);
                        }
                        writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_SLICE_TYPE);
                        writer.WriteValue(sliceValue.Type);
                        writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION);
                        writer.WriteStartArray();
                        writer.WriteValue(positionToStart.X);
                        writer.WriteValue(positionToStart.Y);
                        writer.WriteEndArray();
                        if (areaSize != Vector3.Zero)
                        {
                            writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_SLICE_AREA_SIZE);
                            writer.WriteStartArray();
                            writer.WriteValue(areaSize.X);
                            writer.WriteValue(areaSize.Y);
                            writer.WriteEndArray();
                        }
                        if (sliceValue.Breakable != SerializationConstants.DEFAULT_VALUE_SLICE_BREAKABLE)
                        {
                            writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_SLICE_BREAKABLE);
                            writer.WriteValue(sliceValue.Breakable);
                        }
                        if (sliceValue.Lethal != SerializationConstants.DEFAULT_VALUE_SLICE_LETHAL)
                        {
                            writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_SLICE_LETHAL);
                            writer.WriteValue(sliceValue.Lethal);
                        }
                        if (sliceValue.Heavy != SerializationConstants.DEFAULT_VALUE_SLICE_HEAVY)
                        {
                            writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_SLICE_HEAVY);
                            writer.WriteValue(sliceValue.Heavy);
                        }
                        if (sliceValue.Slippery != SerializationConstants.DEFAULT_VALUE_SLICE_SLIPPERY)
                        {
                            writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_SLICE_SLIPPERY);
                            writer.WriteValue(sliceValue.Slippery);
                        }

                        writer.WriteEndObject();
                    }
                }
                writer.WriteEndArray();
            }

            if (SpecialSlices.Count > 0)
            {
                writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_FORM_SPECIAL_SLICES);
                writer.WriteStartArray();
                foreach (SpecialSliceValue specialSliceValue in SpecialSlices)
                {
                    writer.WriteStartObject();

                    if (specialSliceValue.ID != SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID)
                    {
                        writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_GAME_OBJECT_ID);
                        writer.WriteValue(specialSliceValue.ID);
                    }
                    writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_TYPE);
                    writer.WriteValue(specialSliceValue.Special);
                    writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_GAME_OBJECT_POSITION);
                    writer.WriteStartArray();
                    writer.WriteValue(specialSliceValue.Position.X);
                    writer.WriteValue(specialSliceValue.Position.Y);
                    writer.WriteEndArray();
                    if (specialSliceValue.Size != SerializationConstants.DEFAULT_VALUE_SPECIAL_SLICE_SIZE)
                    {
                        writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_SIZE);
                        writer.WriteStartArray();
                        writer.WriteValue(specialSliceValue.Size.X);
                        writer.WriteValue(specialSliceValue.Size.Y);
                        writer.WriteEndArray();
                    }
                    if (specialSliceValue.Parameters != SerializationConstants.DEFAULT_VALUE_SPECIAL_SLICE_PARAMETERS)
                    {
                        writer.WritePropertyName(SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_PARAMETERS);
                        writer.WriteValue(specialSliceValue.Parameters);
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }

            writer.WriteEndObject();
            return true;
        }
    }
}
