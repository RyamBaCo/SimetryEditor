using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Simetry.Interface.Globals;

namespace Simetry.Interface.Serialization
{
    public class SpecialSliceValue : SliceValue
    {
        public enum SpecialType
        {
            CHECKPOINT = 0,
            STAMPER,
            SWITCH,
            DOOR,
            TREADMILL_RIGHT,
            TREADMILL_LEFT,
            SCALE
        }

        #region Values for Serialization
        public SpecialType Special { get; set; }
        public Vector2 Size { get; set; }
        public string Parameters { get; set; }
        #endregion

        public SpecialSliceValue() : this(SpecialType.CHECKPOINT) { }
        public SpecialSliceValue(SpecialType special) : this(special, SerializationConstants.DEFAULT_VALUE_SPECIAL_SLICE_PARAMETERS) { }

        public SpecialSliceValue(SpecialSliceValue sliceValue)
            : base(sliceValue)
        {
            Special = sliceValue.Special;
            Size = sliceValue.Size;
            Parameters = sliceValue.Parameters;
        }

        public SpecialSliceValue(SpecialType special, string parameters) : base(SliceType.EXTRA)
        {
            Special = special;
            Size = SerializationConstants.DEFAULT_VALUE_SPECIAL_SLICE_SIZE;
            Parameters = parameters;
        }
    }
}
