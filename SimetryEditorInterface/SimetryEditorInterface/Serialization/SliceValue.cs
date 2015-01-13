using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Simetry.Interface.Globals;

namespace Simetry.Interface.Serialization
{
    public class SliceValue : GameObjectValue
    {
        public enum SliceType
        {
            QUAD = 0,
            TRIANGLE_LEFT_TOP,
            TRIANGLE_RIGHT_TOP,
            TRIANGLE_LEFT_BOTTOM,
            TRIANGLE_RIGHT_BOTTOM,
            EXTRA
        }

        #region Values for Serialization
        public SliceType Type { get; set; }
        public bool Breakable { get; set; }
        public bool Lethal { get; set; }
        public bool Heavy { get; set; }
        public bool Slippery { get; set; }
        #endregion

        public SliceValue() : this(SliceType.QUAD) { }
        public SliceValue(SliceType type) : this(SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_ID, type, SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION, SerializationConstants.DEFAULT_VALUE_SLICE_BREAKABLE, SerializationConstants.DEFAULT_VALUE_SLICE_LETHAL, SerializationConstants.DEFAULT_VALUE_SLICE_HEAVY, SerializationConstants.DEFAULT_VALUE_SLICE_SLIPPERY) { }
        public SliceValue(SliceValue sliceValue) : this(sliceValue.ID, sliceValue.Type, sliceValue.Position, sliceValue.Breakable, sliceValue.Lethal, sliceValue.Heavy, sliceValue.Slippery) { }
        // for adding slice values of an area (only distinguished by grid position)
        public SliceValue(SliceValue sliceValue, Vector3 position) : this(sliceValue.ID, sliceValue.Type, position, sliceValue.Breakable, sliceValue.Lethal, sliceValue.Heavy, sliceValue.Slippery) { }

        public SliceValue(string id, SliceType type, Vector3 position, bool breakable, bool lethal, bool heavy, bool slippery)
        {
            ID = id;
            Type = type;
            Position = position;
            Breakable = breakable;
            Lethal = lethal;
            Heavy = heavy;
            Slippery = slippery;
        }

        public bool Compare(SliceValue value)
        {
            return (value.ID == null || value.ID == ID) && value.Type != SliceType.EXTRA
                && value.Type == Type && value.Breakable == Breakable && value.Lethal == Lethal && value.Heavy == Heavy && value.Slippery == Slippery;
        }
    }
}
