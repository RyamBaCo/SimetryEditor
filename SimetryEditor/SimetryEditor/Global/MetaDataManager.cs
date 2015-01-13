using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simetry.Interface.Serialization;
using Simetry.Interface.Globals;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace SimetryEditor
{
    class MetaDataManager : IMetadataGameObjectAdder, ITriggerZoneAdder
    {
        #region Singleton Pattern
        private static readonly MetaDataManager instance = new MetaDataManager();
        public static MetaDataManager Instance { get { return instance; } }
        #endregion

        public List<MetadataGameObjectValue> MetadataGameObjects { get; private set; }
        public List<TriggerZoneValue> TriggerZones { get; private set; }

        public TriggerZoneValue SelectedTriggerZone 
        { 
            get 
            {
                if (selectedTriggerZones.Count == 0)
                    return null;
                return TriggerZones[selectedTriggerZones[0]];
            } 
        }

        public MetadataGameObjectValue SelectedMetaDataGameObject
        {
            get
            {
                if (selectedGameObjects.Count == 0)
                    return null;
                return MetadataGameObjects[selectedGameObjects[0]];
            }
        }

        private Vector2 lastMouseDownPosition = new Vector2(-1, -1);

        private NotifyLevelDrawMouseMoveHandler levelDrawMouseMove;
        private NotifyLevelDrawMouseDownHandler levelDrawMouseDown;
        private NotifyLevelDrawMouseUpHandler levelDrawMouseUp;
        private NotifyKeyPressedHandler keyPressed;
        private NotifyZValueChangedHandler zValueChanged;

        private List<int> selectedGameObjects = new List<int>();
        private List<int> selectedTriggerZones = new List<int>();

        private MetaDataManager()
        {
            MetadataGameObjects = new List<MetadataGameObjectValue>();
            TriggerZones = new List<TriggerZoneValue>();

            levelDrawMouseMove = new NotifyLevelDrawMouseMoveHandler(OnMouseMove);
            levelDrawMouseDown = new NotifyLevelDrawMouseDownHandler(OnMouseDown);
            levelDrawMouseUp = new NotifyLevelDrawMouseUpHandler(OnMouseUp);
            keyPressed = new NotifyKeyPressedHandler(KeyPressed);
            zValueChanged = new NotifyZValueChangedHandler(ZValueChanged);

            Notifier.CreationModeChanged += new NotifyCreationModeChangedHandler(CreationModeChanged);
            SerializationManager.Instance.MetadataGameObjectAddInterface = this;
            SerializationManager.Instance.TriggerZoneAddInterface = this;
        }

        public bool UpdateParametersOfSelectedMetadataGameObject(string parameters)
        {
            if (selectedGameObjects.Count == 0)
                return false;

            MetadataGameObjects[selectedGameObjects[0]].Parameters = parameters;
            MetadataGameObjects[selectedGameObjects[0]] = MetadataGameObjectValue.CreateMetadataGameObject(MetadataGameObjects[selectedGameObjects[0]]);
            return true;
        }

        // called by Main Form
        public void UpdateSelectedGameObjects(ListView.SelectedIndexCollection selectedIndices)
        {
            selectedGameObjects.Clear();
            foreach (int selectedIndex in selectedIndices)
                selectedGameObjects.Add(selectedIndex);
        }

        // called by Main Form
        public void UpdateSelectedTriggerZones(ListView.SelectedIndexCollection selectedIndices)
        {
            selectedTriggerZones.Clear();
            foreach (int selectedIndex in selectedIndices)
                selectedTriggerZones.Add(selectedIndex);
        }

        private void CreationModeChanged()
        {
            // let the forms manager only "work" when forms creation is active
            if (GlobalValues.Instance.CreationMode == GlobalValues.CreationModeType.CREATE_METADATA)
            {
                Notifier.LevelDrawMouseMove += levelDrawMouseMove;
                Notifier.LevelDrawMouseDown += levelDrawMouseDown;
                Notifier.LevelDrawMouseUp += levelDrawMouseUp;
                Notifier.KeyPressed += keyPressed;
                Notifier.ZValueChanged += zValueChanged;
            }

            else
            {
                Notifier.LevelDrawMouseMove -= levelDrawMouseMove;
                Notifier.LevelDrawMouseDown -= levelDrawMouseDown;
                Notifier.LevelDrawMouseUp -= levelDrawMouseUp;
                Notifier.KeyPressed -= keyPressed;
                Notifier.ZValueChanged -= zValueChanged;
            }
        }

        private void ZValueChanged()
        {
            foreach (int gameObjectIndex in selectedGameObjects)
                MetadataGameObjects[gameObjectIndex].Position = new Vector3(MetadataGameObjects[gameObjectIndex].Position.X, MetadataGameObjects[gameObjectIndex].Position.Y, GlobalValues.Instance.ZValue);
        }

        private void KeyPressed(Keys keyData)
        {
            // delete selected game objects and trigger zones
            if (keyData == Keys.Delete)
            {
                // delete selected game objects (if any)
                if (selectedGameObjects.Count > 0 &&
                    HelperFunctions.ShowWarningMessage(HelperFunctions.MessageTexts.GetDeleteGameObjectsWarning(selectedGameObjects.Count)) == DialogResult.OK)
                {
                    // when going through the indices in reverse order we do not need to care about index changes when deleting
                    foreach (int gameObjectIndex in Enumerable.Reverse(selectedGameObjects))
                        MetadataGameObjects.RemoveAt(gameObjectIndex);

                    selectedGameObjects.Clear();

                    if (Notifier.GameObjectValueChanged != null)
                        Notifier.GameObjectValueChanged();
                }

                // delete selected trigger zones (if any)
                if (selectedTriggerZones.Count > 0 &&
                    HelperFunctions.ShowWarningMessage(HelperFunctions.MessageTexts.GetDeleteTriggerZonesWarning(selectedTriggerZones.Count)) == DialogResult.OK)
                {
                    // when going through the indices in reverse order we do not need to care about index changes when deleting
                    foreach (int sliceIndex in Enumerable.Reverse(selectedTriggerZones))
                        TriggerZones.RemoveAt(sliceIndex);

                    selectedTriggerZones.Clear();

                    if (Notifier.TriggerZoneValueChanged != null)
                        Notifier.TriggerZoneValueChanged();
                }
            }
        }

        private void OnMouseMove(MouseEventArgs e)
        {
        }

        // TODO check for selected item and stuff
        private void OnMouseDown(MouseEventArgs e)
        {
            lastMouseDownPosition = HelperFunctions.TruncateToGrid(new Vector2(e.X, e.Y)) / GlobalValues.Instance.GridSize;
        }

        private void OnMouseUp(MouseEventArgs e)
        {
            if (lastMouseDownPosition.X < 0 || GameObjectMover.Instance.SelectedGameObject != null || GameObjectScaler.Instance.SelectedGameObject != null)
                return;

            Vector2 currentMouseDownPosition = HelperFunctions.TruncateToGrid(new Vector2(e.X, e.Y)) / GlobalValues.Instance.GridSize;

            if (currentMouseDownPosition.X == lastMouseDownPosition.X || currentMouseDownPosition.Y == lastMouseDownPosition.Y)
            {
                MetadataGameObjects.Add(new MetadataGameObjectValue("g_" + MetadataGameObjects.Count.ToString(), new Vector3(currentMouseDownPosition.X, currentMouseDownPosition.Y, GlobalValues.Instance.ZValue), SerializationConstants.METADATA_TYPE_POSITION));
                if (Notifier.GameObjectValueChanged != null)
                    Notifier.GameObjectValueChanged();
            }

            else
            {
                TriggerZoneValue triggerZone = new TriggerZoneValue();
                triggerZone.ID = "t_" + TriggerZones.Count.ToString();
                triggerZone.Position = new Vector3(
                    Math.Min(lastMouseDownPosition.X, currentMouseDownPosition.X),
                    Math.Min(lastMouseDownPosition.Y, currentMouseDownPosition.Y), GlobalValues.Instance.ZValue);
                triggerZone.Size = new Vector2(
                    Math.Max(lastMouseDownPosition.X, currentMouseDownPosition.X),
                    Math.Max(lastMouseDownPosition.Y, currentMouseDownPosition.Y)) - HelperFunctions.Vector3ToVector2(triggerZone.Position);
                
                TriggerZones.Add(triggerZone);

                if (Notifier.TriggerZoneValueChanged != null)
                    Notifier.TriggerZoneValueChanged();
            }
        }

        // called by interface
        public void AddMetadataGameObject(MetadataGameObjectValue value)
        {
            MetadataGameObjects.Add(value);
        }

        public void AddTriggerZone(TriggerZoneValue value)
        {
            TriggerZones.Add(value);
        }
    }
}
