using System.Windows.Forms;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Simetry.Interface.Serialization;
using Simetry.Interface.Globals;

namespace SimetryEditor
{
    #region Level Size Handler
    public delegate void NotifyGridSizeChangedHandler();
    public delegate void NotifyLevelSizeChangedHandler();
    #endregion

    public delegate void NotifyCreationModeChangedHandler();
    public delegate void NotifySelectedItemValueChangedHandler(bool visible, GameObjectValue values);

    #region Forms Manager Handler
    public delegate void NotifySelectSliceValue(List<int> sliceValues);
    public delegate void NotifySliceValueChanged();
    #endregion

    #region Meta Data Manager Handler
    public delegate void NotifyGameObjectValueChanged();
    public delegate void NotifyTriggerZoneValueChanged();
    #endregion

    #region Main Form Handler
    public delegate void NotifyLevelDrawMouseMoveHandler(MouseEventArgs e);
    public delegate void NotifyLevelDrawMouseDownHandler(MouseEventArgs e);
    public delegate void NotifyLevelDrawMouseUpHandler(MouseEventArgs e);
    public delegate void NotifyLevelDrawMouseUpDelayedHandler(MouseEventArgs e);
    public delegate void NotifyKeyPressedHandler(Keys keyData);
    public delegate void NotifyKeyReleasedHandler();
    public delegate void NotifyZValueChangedHandler();
    #endregion

    public static class Notifier
    {
        public static NotifyGridSizeChangedHandler GridSizeChanged { get; set; }
        public static NotifyLevelSizeChangedHandler LevelSizeChanged { get; set; }
        public static NotifyCreationModeChangedHandler CreationModeChanged { get; set; }
        public static NotifySelectedItemValueChangedHandler SelectedItemValueChanged { get; set; }
        public static NotifySelectSliceValue SliceValueSelected { get; set; }
        public static NotifySliceValueChanged SliceValueChanged { get; set; }
        public static NotifyGameObjectValueChanged GameObjectValueChanged { get; set; }
        public static NotifyTriggerZoneValueChanged TriggerZoneValueChanged { get; set; }
        public static NotifyLevelDrawMouseMoveHandler LevelDrawMouseMove { get; set; }
        public static NotifyLevelDrawMouseDownHandler LevelDrawMouseDown { get; set; }
        public static NotifyLevelDrawMouseUpHandler LevelDrawMouseUp { get; set; }
        // mouse up: LevelDrawMouseUp --> LevelDrawMouseUpDelayed
        public static NotifyLevelDrawMouseUpDelayedHandler LevelDrawMouseUpDelayed { get; set; }
        public static NotifyKeyPressedHandler KeyPressed { get; set; }
        public static NotifyKeyReleasedHandler KeyReleased { get; set; }
        public static NotifyZValueChangedHandler ZValueChanged { get; set; }
    }
}
