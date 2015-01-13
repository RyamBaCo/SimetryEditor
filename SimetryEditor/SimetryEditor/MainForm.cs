using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;
using Newtonsoft.Json;
using Simetry.Interface.Serialization;
using Simetry.Interface.Globals;
using Simetry.Interface.Actions;

namespace SimetryEditor
{
    // System.Drawing and the XNA Framework both define Color types.
    // To avoid conflicts, we define shortcut names for them both.
    using GdiColor = System.Drawing.Color;
    using XnaColor = Microsoft.Xna.Framework.Color;
    using System.Drawing;

    public partial class MainForm : Form, IGlobalJunkValueAdder
    {
        // is here to avoid irregular placed slices after loading a level (as the mask causes mouse click events on level control)
        private bool ignoreMouseEvents = false;
        // set the ignore mouse events flag not immediately back but after a few ms
        private System.Timers.Timer ignoreMouseEventsTimer;
        // when space bar is pressed just select the form of the slice clicked on
        private bool doFormSelect = false;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keyData)
        {
            if (Notifier.KeyPressed != null)
                Notifier.KeyPressed(keyData);
            return base.ProcessCmdKey(ref message, keyData);
        }

        protected override bool ProcessKeyPreview(ref Message message)
        {
            const int WM_KEYUP = 0x101;
            if (message.Msg == WM_KEYUP && Notifier.KeyReleased != null)
                Notifier.KeyReleased();
            return base.ProcessKeyPreview(ref message);
        }

        private void UpdateComboBoxEntries()
        {
            comboBoxForms.Items.Clear();
            foreach (FormValue formValue in FormsManager.Instance.FormValues)
                comboBoxForms.Items.Add(formValue.ID);

            if(comboBoxForms.Items.Count > 0)
                comboBoxForms.SelectedIndex = FormsManager.Instance.CurrentFormIndex;

            buttonRemoveForm.Enabled = FormsManager.Instance.FormValues.Count > 1;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region Data Bindings
            trackBarGridSize.DataBindings.Add("Value", GlobalValues.Instance, "GridSize", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxShowTagForms.DataBindings.Add("Checked", GlobalValues.Instance, "ShowFormTags", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxShowTagSlices.DataBindings.Add("Checked", GlobalValues.Instance, "ShowSliceTags", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxShowTagMetadata.DataBindings.Add("Checked", GlobalValues.Instance, "ShowMetadataTags", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxShowTagObjects.DataBindings.Add("Checked", GlobalValues.Instance, "ShowObjectTags", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxShowAll.DataBindings.Add("Checked", GlobalValues.Instance, "ShowAll", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxDrawBackground.DataBindings.Add("Checked", GlobalValues.Instance, "DrawBackground", false, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDownCurrentZValue.DataBindings.Add("Value", GlobalValues.Instance, "ZValue", true, DataSourceUpdateMode.OnPropertyChanged);
            #endregion

            // recreate variable because of value changed events
            Vector2 initialSize = new Vector2(GlobalValues.Instance.LevelSize.X, GlobalValues.Instance.LevelSize.Y);
            numericUpDownLevelSizeWidth.Value = Convert.ToDecimal(initialSize.X);
            numericUpDownLevelSizeHeight.Value = Convert.ToDecimal(initialSize.Y);

            comboBoxForms.Items.Add(FormsManager.Instance.FormValues.Count - 1);
            comboBoxForms.SelectedIndex = 0;
            elementsColumnType.ImageGetter = slicesColumnID.ImageGetter = specialSlicesColumnID.ImageGetter = delegate(object rowObject)
            {
                return LevelItemManager.Instance.GetAssetNameForSliceType(rowObject as SliceValue);
            };

            objectListViewElements.SetObjects(
                new SliceValue[12] 
                {
                    new SliceValue(SliceValue.SliceType.QUAD),
                    new SliceValue(SliceValue.SliceType.TRIANGLE_LEFT_TOP),
                    new SliceValue(SliceValue.SliceType.TRIANGLE_RIGHT_TOP),
                    new SliceValue(SliceValue.SliceType.TRIANGLE_LEFT_BOTTOM),
                    new SliceValue(SliceValue.SliceType.TRIANGLE_RIGHT_BOTTOM),
                    new SpecialSliceValue(SpecialSliceValue.SpecialType.CHECKPOINT),
                    new SpecialSliceValue(SpecialSliceValue.SpecialType.STAMPER, "{\"" + SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_PARAMETER_INTERVAL + "\":0.5,\"" + SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_PARAMETER_OFFSET + "\":0,\"" + SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_PARAMETER_SPEED + "\":20}"),
                    new SpecialSliceValue(SpecialSliceValue.SpecialType.SWITCH),
                    new SpecialSliceValue(SpecialSliceValue.SpecialType.DOOR),
                    new SpecialSliceValue(SpecialSliceValue.SpecialType.TREADMILL_RIGHT, "{\"" + SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_PARAMETER_SPEED + "\":10}"),
                    new SpecialSliceValue(SpecialSliceValue.SpecialType.TREADMILL_LEFT, "{\"" + SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_PARAMETER_SPEED + "\":10}"),
                    new SpecialSliceValue(SpecialSliceValue.SpecialType.SCALE, "{\"" + SerializationConstants.JSON_PROPERTY_SPECIAL_SLICE_PARAMETER_CONNECTED_TO + "\":\"\"}")
                });
            objectListViewElements.Items[0].Selected = true;

            comboBoxActions.Items.Add(SerializationConstants.ACTION_MOVE_OBJECT);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_ROTATE_OBJECT);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_PLAY_ANIMATION);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_PLAY_ANIMATION_REVERSE);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_PLAY_SOUND);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_DELAY);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_ENABLE_DISABLE);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_ARRIVE_CHECKPOINT);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_SET_SLICE_STATE);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_SET_WANDER_SLICE_STATE);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_ZOOM_CAMERA);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_SPAWN_QUAD);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_SPAWN_TRIANGLE);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_ALLOW_BUILDING);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_ALLOW_WEAPON_REEL);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_ALLOW_BUILDING_HEAVY_SLICES);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_ALLOW_COLLECTING);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_ALLOW_TUTORIAL);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_DESTROY_VISIBLE_SLICES);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_DESTROY_SLICES_IN_TRIGGER_ZONE);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_SCALE_AND_MOVE_TO_PLAYER);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_SHOW_FULLSCREEN_TEXTURE);
            comboBoxActions.Items.Add(SerializationConstants.ACTION_CHANGE_AMBIENT_LIGHT);
            comboBoxActions.SelectedIndex = 0;

            foreach (string backgroundName in SerializationConstants.BackgroundAssetNames.Keys)
                comboBoxBackgroundNames.Items.Add(backgroundName);
            comboBoxBackgroundNames.SelectedIndex = 0;

            toolTipEditor.SetToolTip(comboBoxActions, HelperFunctions.MessageTexts.GetActionsTooltipText());

            // force selected index changed event to fire on startup
            tabControlCreation.SelectedIndex = -1;
            tabControlCreation.SelectedIndex = 0;

            Notifier.KeyPressed += new NotifyKeyPressedHandler(KeyPressed);
            // update object list view once new slice values have been added or removed
            Notifier.SliceValueChanged += new NotifySliceValueChanged(UpdateObjectListViewSlices);
            Notifier.SliceValueSelected += new NotifySelectSliceValue(SliceValueSelected);
            Notifier.GameObjectValueChanged += delegate { objectListViewMetadataObjects.SetObjects(MetaDataManager.Instance.MetadataGameObjects); };
            Notifier.TriggerZoneValueChanged += new NotifyTriggerZoneValueChanged(UpdateObjectListViewTriggerZones);

            ignoreMouseEventsTimer = new System.Timers.Timer();
            ignoreMouseEventsTimer.Interval = 200;
            ignoreMouseEventsTimer.Elapsed += delegate { ignoreMouseEvents = false; };

            SerializationManager.Instance.JunkAddInterface = this;
        }

        private void UpdateObjectListViewTriggerZones()
        {
            objectListViewTriggerZones.SetObjects(MetaDataManager.Instance.TriggerZones);
        }

        private void UpdateObjectListViewSlices()
        {
            objectListViewSlices.SetObjects(FormsManager.Instance.CurrentFormValue.Slices);
            List<SpecialSliceValue> specialSliceValues = new List<SpecialSliceValue>();
            foreach (SliceValue sliceValue in FormsManager.Instance.CurrentFormValue.Slices)
                if (sliceValue is SpecialSliceValue)
                    specialSliceValues.Add(sliceValue as SpecialSliceValue);
            objectListViewSpecialSlices.SetObjects(specialSliceValues);
        }

        private void UpdateObjectListViewActions()
        {
            if (MetaDataManager.Instance.SelectedTriggerZone != null)
            {
                groupBoxActions.Enabled = true;
                objectListViewActions.SetObjects(MetaDataManager.Instance.SelectedTriggerZone.Actions);
                buttonRemoveAction.Enabled = MetaDataManager.Instance.SelectedTriggerZone.Actions.Count > 0;
            }

            else
                groupBoxActions.Enabled = false;
        }

        private void KeyPressed(Keys keyData)
        {
            if (ActiveControl is TextBox || ActiveControl is ComboBox)
                return;

            // key shortcuts for form creation
            if (GlobalValues.Instance.CreationMode == GlobalValues.CreationModeType.CREATE_FORMS)
            {
                if (keyData >= Keys.D1 && keyData < Keys.D1 + objectListViewElements.GetItemCount())
                {
                    objectListViewElements.Items[keyData - Keys.D1].Selected = true;
                    if (Notifier.SelectedItemValueChanged != null)
                        Notifier.SelectedItemValueChanged(true, objectListViewElements.SelectedObject as SliceValue);
                }

                else if (keyData == Keys.R)
                    ActiveControl = numericUpDownRotation;

                else if (keyData == Keys.N && buttonAddForm.Enabled)
                    buttonAddForm_Click(null, null);

                else if (keyData == Keys.S)
                    doFormSelect = !doFormSelect;
            }
        }

        // TODO multi select on list not working
        private void SliceValueSelected(List<int> sliceValues)
        {
            List<int> newSliceValues = new List<int>(sliceValues);
            objectListViewSlices.SelectedIndices.Clear();
            foreach (int sliceIndex in newSliceValues)
                objectListViewSlices.Items[sliceIndex].Selected = true;
        }

        private void numericUpDownLevelSizeHeightWidth_ValueChanged(object sender, EventArgs e)
        {
            GlobalValues.Instance.LevelSize = new Vector2(Convert.ToInt32(numericUpDownLevelSizeWidth.Value), Convert.ToInt32(numericUpDownLevelSizeHeight.Value));
        }

        private void objectListViewElements_SubItemChecking(object sender, BrightIdeasSoftware.SubItemCheckingEventArgs e)
        {
            // when checking checkboxes the associated element in objectlistview is not selected by default
            objectListViewElements.Select();
            objectListViewElements.SelectObject(e.RowObject);
        }

        private void objectListViewSlices_SubItemChecking(object sender, BrightIdeasSoftware.SubItemCheckingEventArgs e)
        {
            // TODO find a more elegant solution
            // sets breakable, lethal or heavy state for all slices in selection
            bool active = e.NewValue == CheckState.Checked;
            foreach (SliceValue sliceValue in objectListViewSlices.SelectedObjects)
            {
                if (e.Column == slicesColumnBreakable)
                    sliceValue.Breakable = active;
                else if (e.Column == slicesColumnHeavy)
                    sliceValue.Heavy = active;
                else if (e.Column == slicesColumnLethal)
                    sliceValue.Lethal = active;
                else if (e.Column == slicesColumnSlippery)
                    sliceValue.Slippery = active;

                objectListViewSlices.RefreshObject(sliceValue);
            }
        }

        // TODO data binding not working evaluate why...
        private void objectListViewSpecialSlices_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (objectListViewSpecialSlices.SelectedObjects.Count == 0)
                return;

            SpecialSliceValue currentSpecialSliceValue = objectListViewSpecialSlices.SelectedObjects[0] as SpecialSliceValue;

            if (e.Column == specialSlicesColumnWidth)
                currentSpecialSliceValue.Size = new Vector2((float)Convert.ToDouble(e.NewValue), currentSpecialSliceValue.Size.Y);
            else if (e.Column == specialSlicesColumnHeight)
                currentSpecialSliceValue.Size = new Vector2(currentSpecialSliceValue.Size.X, (float)Convert.ToDouble(e.NewValue));
        }

        private void objectListViewTriggerZones_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (objectListViewTriggerZones.SelectedObjects.Count == 0)
                return;

            TriggerZoneValue currentTriggerZoneValue = objectListViewTriggerZones.SelectedObjects[0] as TriggerZoneValue;

            if (e.Column == triggerZoneColumnWidth)
                currentTriggerZoneValue.Size = new Vector2((float)Convert.ToDouble(e.NewValue), currentTriggerZoneValue.Size.Y);
            else if (e.Column == triggerZoneColumnHeight)
                currentTriggerZoneValue.Size = new Vector2(currentTriggerZoneValue.Size.X, (float)Convert.ToDouble(e.NewValue));
        }

        private void levelDrawControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (Notifier.LevelDrawMouseMove != null && !ignoreMouseEvents && !doFormSelect)
                Notifier.LevelDrawMouseMove(e);

            labelCurrentPosition.Text = "X: " + (int)(e.X / GlobalValues.Instance.GridSize) + " Y: " + (int)(e.Y / GlobalValues.Instance.GridSize);
        }

        private void levelDrawControl_MouseEnter(object sender, EventArgs e)
        {
            if (Notifier.SelectedItemValueChanged != null)
                Notifier.SelectedItemValueChanged(true, objectListViewElements.SelectedObject as SliceValue);
        }

        private void levelDrawControl_MouseLeave(object sender, EventArgs e)
        {
            if (Notifier.SelectedItemValueChanged != null)
                Notifier.SelectedItemValueChanged(false, null);
        }

        private void levelDrawControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (Notifier.LevelDrawMouseDown != null && !ignoreMouseEvents && !doFormSelect)
                Notifier.LevelDrawMouseDown(e);

            objectListViewSlices.SelectedIndices.Clear();

            if (doFormSelect)
            {
                Vector2 gridPosition = new Vector2(Convert.ToInt32(e.X / GlobalValues.Instance.GridSize), Convert.ToInt32(e.Y / GlobalValues.Instance.GridSize));
                bool found = false;
                for (int i = 0; i < FormsManager.Instance.FormValues.Count; ++i)
                {
                    foreach (SliceValue sliceValue in FormsManager.Instance.FormValues[i].Slices)
                        if (new Vector2(FormsManager.Instance.FormValues[i].Position.X + sliceValue.Position.X, FormsManager.Instance.FormValues[i].Position.Y + sliceValue.Position.Y) == gridPosition)
                        {
                            comboBoxForms.SelectedIndex = i;
                            found = true;
                            break;
                        }

                        else if (sliceValue is SpecialSliceValue)
                        {
                            Rectangle specialSpliceRectangle = new Rectangle((int)(FormsManager.Instance.FormValues[i].Position.X + sliceValue.Position.X), (int)(FormsManager.Instance.FormValues[i].Position.Y + sliceValue.Position.Y), (int)((SpecialSliceValue)sliceValue).Size.X, (int)((SpecialSliceValue)sliceValue).Size.Y);
                            if (specialSpliceRectangle.Contains(new Point((int)gridPosition.X, (int)gridPosition.Y)))
                            {
                                comboBoxForms.SelectedIndex = i;
                                found = true;
                                break;
                            }
                        }

                    if (found)
                        break;
                }
            }
        }

        private void levelDrawControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (ignoreMouseEvents || doFormSelect)
                return;

            if (Notifier.LevelDrawMouseUp != null)
                Notifier.LevelDrawMouseUp(e);

            if (Notifier.LevelDrawMouseUpDelayed != null)
                Notifier.LevelDrawMouseUpDelayed(e);
        }

        private void comboBoxForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormsManager.Instance.CurrentFormIndex = comboBoxForms.SelectedIndex;
            comboBoxForms.Text = FormsManager.Instance.CurrentFormValue.ID;
            numericUpDownRotation.Value = FormsManager.Instance.CurrentFormValue.Rotation;
            numericUpDownCurrentZValue.Value = Convert.ToInt32(FormsManager.Instance.CurrentFormValue.Position.Z);
            UpdateObjectListViewSlices();
        }

        private void objectListViewSlices_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormsManager.Instance.UpdateSelectedSlices(objectListViewSlices.SelectedIndices);
        }

        private void objectListViewSlices_ItemsChanged(object sender, BrightIdeasSoftware.ItemsChangedEventArgs e)
        {
            // when adding new elements to list selected index changed event is not triggered
            // but it needs to be triggered to reset the selection
            objectListViewSlices_SelectedIndexChanged(sender, null);
        }

        private void buttonAddForm_Click(object sender, EventArgs e)
        {
            FormsManager.Instance.AddFormValue();
            comboBoxForms.Items.Add(FormsManager.Instance.CurrentFormValue.ID);
            comboBoxForms.SelectedIndex = FormsManager.Instance.FormValues.Count - 1;
            buttonRemoveForm.Enabled = true;
        }

        private void buttonRemoveForm_Click(object sender, EventArgs e)
        {
            if (!FormsManager.Instance.DeleteSlices(true))
                return;

            UpdateComboBoxEntries();
        }

        private void comboBoxForms_TextUpdate(object sender, EventArgs e)
        {
            FormsManager.Instance.CurrentFormValue.ID = comboBoxForms.Text;
            comboBoxForms.Items[FormsManager.Instance.CurrentFormIndex] = comboBoxForms.Text;
        }

        private void numericUpDownRotation_ValueChanged(object sender, EventArgs e)
        {
            FormsManager.Instance.CurrentFormValue.Rotation = Convert.ToInt32(numericUpDownRotation.Value);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialogLevel.ShowDialog() == DialogResult.OK)
            {
                FormsManager.Instance.PrecomputeForSave();
                // TODO refactor this shit once there is more information in junk value class
                GlobalJunkValue junkValue = new GlobalJunkValue(GlobalValues.Instance.LevelSize);
                if (!SerializationManager.Instance.WriteJunkValuesToJSON(saveFileDialogLevel.FileName, junkValue, FormsManager.Instance.FormValues, MetaDataManager.Instance.MetadataGameObjects, MetaDataManager.Instance.TriggerZones))
                    HelperFunctions.ShowErrorMessage(HelperFunctions.MessageTexts.GetSaveFailedError(saveFileDialogLevel.FileName));
                FormsManager.Instance.RestoreAfterLoad();
            }
        }
        
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ignoreMouseEventsTimer.Stop();
            ignoreMouseEvents = true;

            if (openFileDialogLevel.ShowDialog() == DialogResult.OK)
            {
                GameObjectValueManager.Instance.UnregisterAllGameObjects();

                FormsManager.Instance.FormValues.Clear();
                MetaDataManager.Instance.MetadataGameObjects.Clear();
                MetaDataManager.Instance.TriggerZones.Clear();

                try
                {
                    SerializationManager.Instance.ReadJunkValuesFromJSON(openFileDialogLevel.FileName);
                }
                catch(Exception exception)
                {
                    FormsManager.Instance.AddFormValue();
                    HelperFunctions.ShowErrorMessage(HelperFunctions.MessageTexts.GetLoadFailedError(openFileDialogLevel.FileName, exception.Message));
                }

                FormsManager.Instance.RestoreAfterLoad();

                objectListViewMetadataObjects.SetObjects(MetaDataManager.Instance.MetadataGameObjects);
                UpdateObjectListViewTriggerZones();
                UpdateComboBoxEntries();
            }

            ignoreMouseEventsTimer.Start();
        }

        private void tabControlCreation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalValues.Instance.CreationMode = tabControlCreation.SelectedIndex == 0 ? GlobalValues.CreationModeType.CREATE_FORMS : GlobalValues.CreationModeType.CREATE_METADATA;

            if (tabControlCreation.SelectedTab == tabPageTriggerZones)
                objectListViewMetadataObjects.DeselectAll();
            else if (tabControlCreation.SelectedTab == tabPageMetadata)
                objectListViewTriggerZones.DeselectAll();
        }

        private void objectListViewTriggerZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetaDataManager.Instance.UpdateSelectedTriggerZones(objectListViewTriggerZones.SelectedIndices);
            UpdateObjectListViewActions();
        }

        private void objectListViewMetadataObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetaDataManager.Instance.UpdateSelectedGameObjects(objectListViewMetadataObjects.SelectedIndices);

            MetadataGameObjectValue selectedObject = MetaDataManager.Instance.SelectedMetaDataGameObject;

            if (selectedObject == null || selectedObject.Type == SerializationConstants.METADATA_TYPE_POSITION)
            {
                buttonAddEditBackground.Text = GlobalValues.BUTTON_ADD;
                buttonAddEditPointLight.Text = GlobalValues.BUTTON_ADD;
            }

            else if (selectedObject.Type == SerializationConstants.METADATA_TYPE_BACKGROUND)
            {
                buttonAddEditPointLight.Text = GlobalValues.BUTTON_ADD;
                buttonAddEditBackground.Text = GlobalValues.BUTTON_EDIT;

                BackgroundValue value = (BackgroundValue)selectedObject;
                textBoxBackgroundPosition.Text = HelperFunctions.Vector3ToString(value.Position);
                textBoxBackgroundRotation.Text = HelperFunctions.Vector3ToString(value.Rotation);
                textBoxBackgroundScale.Text = HelperFunctions.Vector3ToString(value.Scale);
                textBoxBackgroundRepeat.Text = HelperFunctions.Vector2ToString(value.Repeat);
                textBoxBackgroundRepeatGap.Text = HelperFunctions.Vector4ToString(value.RepeatGap);
                numericUpDownBackgroundAnimationDelay.Value = value.AnimationDelay;
                comboBoxBackgroundNames.SelectedItem = value.AssetName;
            }

            else if (selectedObject.Type == SerializationConstants.METADATA_TYPE_POINT_LIGHT)
            {
                buttonAddEditBackground.Text = GlobalValues.BUTTON_ADD;
                buttonAddEditPointLight.Text = GlobalValues.BUTTON_EDIT;

                PointLightValue value = (PointLightValue)selectedObject;
                textBoxPointLightPosition.Text = HelperFunctions.Vector3ToString(value.Position);
                numericUpDownPointLightRadius.Value = Convert.ToDecimal(value.Radius);
                XnaColor color = new XnaColor(value.Color);
                panelPointLightColor.BackColor = Color.FromArgb(color.A, color.R, color.G, color.B);
                numericUpDownPointLightIntensity.Value = Convert.ToDecimal(value.Intensity);
                numericUpDownPointLightAttenuation.Value = Convert.ToDecimal(value.Attenuation);
                checkBoxPointLightShadows.Checked = value.Shadows;
                numericUpDownPointLightResolution.Value = value.Resolution;
            }
        }

        private void buttonAddAction_Click(object sender, EventArgs e)
        {
            MetaDataManager.Instance.SelectedTriggerZone.Actions.Add(BaseAction.CreateActionByParameters(comboBoxActions.SelectedItem as SerializationConstants.ActionValue));
            UpdateObjectListViewActions();            
        }

        private void buttonRemoveAction_Click(object sender, EventArgs e)
        {
            MetaDataManager.Instance.SelectedTriggerZone.Actions.Remove(objectListViewActions.SelectedObject as BaseAction);
            UpdateObjectListViewActions();
        }

        public void AddGlobalJunkValue(GlobalJunkValue value)
        {
            numericUpDownLevelSizeWidth.Value = Convert.ToDecimal(value.LevelSize.X);
            numericUpDownLevelSizeHeight.Value = Convert.ToDecimal(value.LevelSize.Y);
        }

        private void optimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptimizationForm form = new OptimizationForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                FormsManager.Instance.Optimize(form.MaximumSlicesPerForm);
                UpdateComboBoxEntries();
            }
        }

        private void buttonAddEditBackground_Click(object sender, EventArgs e)
        {
            MetadataGameObjectValue newMetadataGameObject = MetadataGameObjectValue.CreateMetadataGameObject(new MetadataGameObjectValue("", SerializationConstants.METADATA_TYPE_BACKGROUND, 
                HelperFunctions.BuildBackgroundParameters(
                    comboBoxBackgroundNames.SelectedItem.ToString(), 
                    textBoxBackgroundPosition.Text, 
                    textBoxBackgroundRotation.Text, 
                    textBoxBackgroundScale.Text, 
                    textBoxBackgroundRepeat.Text, 
                    textBoxBackgroundRepeatGap.Text, 
                    (int)numericUpDownBackgroundAnimationDelay.Value)));

            if (buttonAddEditBackground.Text == GlobalValues.BUTTON_ADD)
                MetaDataManager.Instance.MetadataGameObjects.Add(newMetadataGameObject);
            else
                MetaDataManager.Instance.UpdateParametersOfSelectedMetadataGameObject(newMetadataGameObject.Parameters);

            if (Notifier.GameObjectValueChanged != null)
                Notifier.GameObjectValueChanged();
        }

        private void buttonAddPointLight_Click(object sender, EventArgs e)
        {
            XnaColor color = new XnaColor(panelPointLightColor.BackColor.R, panelPointLightColor.BackColor.G, panelPointLightColor.BackColor.B, panelPointLightColor.BackColor.A);
            MetadataGameObjectValue newMetadataGameObject = MetadataGameObjectValue.CreateMetadataGameObject(new MetadataGameObjectValue("", SerializationConstants.METADATA_TYPE_POINT_LIGHT,
                HelperFunctions.BuildPointLightParameters(
                    textBoxPointLightPosition.Text,
                    (float)numericUpDownPointLightRadius.Value,
                    HelperFunctions.Vector4ToString(color.ToVector4()),
                    (float)numericUpDownPointLightIntensity.Value,
                    (float)numericUpDownPointLightAttenuation.Value,
                    checkBoxPointLightShadows.Checked,
                    (int)numericUpDownPointLightResolution.Value)));

            if (buttonAddEditPointLight.Text == GlobalValues.BUTTON_ADD)
                MetaDataManager.Instance.MetadataGameObjects.Add(newMetadataGameObject);
            else
                MetaDataManager.Instance.UpdateParametersOfSelectedMetadataGameObject(newMetadataGameObject.Parameters);

            if (Notifier.GameObjectValueChanged != null)
                Notifier.GameObjectValueChanged();
        }

        private void shiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShiftForm form = new ShiftForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                foreach (FormValue formValue in FormsManager.Instance.FormValues)
                    formValue.Position += form.Offset;

                foreach (GameObjectValue gameObject in MetaDataManager.Instance.MetadataGameObjects)
                    gameObject.Position += form.Offset;

                foreach (TriggerZoneValue triggerZone in MetaDataManager.Instance.TriggerZones)
                    triggerZone.Position += form.Offset;
            }
        }

        private void panelPointLightColor_Click(object sender, EventArgs e)
        {
            if (colorDialogLight.ShowDialog() == DialogResult.OK)
                panelPointLightColor.BackColor = colorDialogLight.Color;
        }
    }
}
