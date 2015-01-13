using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Windows.Forms;
using Simetry.Interface.Serialization;
using Simetry.Interface.Actions;
using Simetry.Interface.Globals;

namespace SimetryEditor
{
    /// <summary>
    /// this class is responsible for storing and modifying all forms values in the level
    /// </summary>
    class FormsManager : IFormAdder
    {
        #region Singleton Pattern
        private static readonly FormsManager instance = new FormsManager();
        public static FormsManager Instance { get { return instance; } }
        #endregion

        public List<FormValue> FormValues { get; private set; }

        private int currentFormIndex;
        public int CurrentFormIndex 
        { 
            get { return currentFormIndex; }
            set
            {
                if (SelectedSlices.Count > 0 && currentFormIndex != value && FormValues[value].Slices.Count == 0 &&
                    HelperFunctions.ShowYesNoMessage(HelperFunctions.MessageTexts.GetMoveSelectedSlicesToFormMessage(SelectedSlices.Count, FormValues[value].ID)) == DialogResult.Yes)
                {
                    FormValues[value].Position = CurrentFormValue.Position;
                    foreach (int sliceIndex in SelectedSlices)
                        FormValues[value].Slices.Add(CurrentFormValue.Slices[sliceIndex]);
                    foreach (int sliceIndex in Enumerable.Reverse(SelectedSlices))
                        CurrentFormValue.Slices.RemoveAt(sliceIndex);
                }

                currentFormIndex = value;
                SelectedSlices.Clear();
            }
        }

        public FormValue CurrentFormValue { get { return FormValues[CurrentFormIndex]; } }
        public List<int> SelectedSlices { get; set; }

        private SliceValue selectedItem = null;

        private NotifyLevelDrawMouseMoveHandler levelDrawMouseMove;
        private NotifyLevelDrawMouseUpHandler levelDrawMouseUp;
        private NotifyKeyPressedHandler keyPressed;
        private NotifyZValueChangedHandler zValueChanged;

        private FormsManager()
        {
            SelectedSlices = new List<int>();
            FormValues = new List<FormValue>();
            AddFormValue();

            levelDrawMouseMove = new NotifyLevelDrawMouseMoveHandler(CreateOrRemoveShapeByMouseDrag);
            levelDrawMouseUp = new NotifyLevelDrawMouseUpHandler(ModifyOrSelectShape);
            keyPressed = new NotifyKeyPressedHandler(KeyPressed);
            zValueChanged = new NotifyZValueChangedHandler(ZValueChanged);

            Notifier.CreationModeChanged += new NotifyCreationModeChangedHandler(CreationModeChanged);
            SerializationManager.Instance.FormAddInterface = this;
        }

        private void ZValueChanged()
        {
            CurrentFormValue.Position = new Vector3(CurrentFormValue.Position.X, CurrentFormValue.Position.Y, GlobalValues.Instance.ZValue);
        }

        public void AddFormValue()
        {
            List<string> formIDs = new List<string>();
            foreach (FormValue formValue in FormValues)
                formIDs.Add(formValue.ID);

            AddFormValue(new FormValue(GetNextValidID("f_", ref formIDs), SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION, 0));
        }

        // from the interface --> called by serializationconstants
        public void AddFormValue(FormValue value)
        {
            FormValues.Add(value);
            CurrentFormIndex = FormValues.Count - 1;
        }

        private void CreationModeChanged()
        {
            // let the forms manager only "work" when forms creation is active
            if (GlobalValues.Instance.CreationMode == GlobalValues.CreationModeType.CREATE_FORMS)
            {
                Notifier.LevelDrawMouseMove += levelDrawMouseMove;
                Notifier.LevelDrawMouseUp += levelDrawMouseUp;
                Notifier.KeyPressed += keyPressed;
                Notifier.ZValueChanged += zValueChanged;
            }

            else
            {
                Notifier.LevelDrawMouseMove -= levelDrawMouseMove;
                Notifier.LevelDrawMouseUp -= levelDrawMouseUp;
                Notifier.KeyPressed -= keyPressed;
                Notifier.ZValueChanged -= zValueChanged;
            }
        }

        private void KeyPressed(Keys keyData)
        {
            // delete selected slices
            if (keyData == Keys.Delete)
                DeleteSlices(false);
            // set breakable/lethal/heavy values of selected slices
            else if (keyData == Keys.B || keyData == Keys.L || keyData == Keys.H)
                UpdateSelectedSliceValues(keyData);
        }

        private void UpdateSelectedSliceValues(Keys keyData)
        {
            foreach (int sliceIndex in SelectedSlices)
            {
                if(keyData == Keys.B)
                    CurrentFormValue.Slices[sliceIndex].Breakable = !CurrentFormValue.Slices[sliceIndex].Breakable;
                else if(keyData == Keys.L)
                    CurrentFormValue.Slices[sliceIndex].Lethal = !CurrentFormValue.Slices[sliceIndex].Lethal;
                else if (keyData == Keys.H)
                    CurrentFormValue.Slices[sliceIndex].Heavy = !CurrentFormValue.Slices[sliceIndex].Heavy;
            }
        }

        public bool DeleteSlices(bool deleteParentForm)
        {
            int slicesToDelete = deleteParentForm ? CurrentFormValue.Slices.Count : SelectedSlices.Count;
            if (slicesToDelete > 0 && 
                HelperFunctions.ShowWarningMessage(HelperFunctions.MessageTexts.GetDeleteSlicesWarning(slicesToDelete)) != DialogResult.OK)
                return false;

            // delete all slices
            if (deleteParentForm)
            {
                FormValues.RemoveAt(CurrentFormIndex);
                if (CurrentFormIndex > 0)
                    CurrentFormIndex--;
            }

            // otherwise delete only the selected slices
            else
            {
                // when going through the indices in reverse order we do not need to care about index changes when deleting
                foreach (int sliceIndex in Enumerable.Reverse(SelectedSlices))
                    CurrentFormValue.Slices.RemoveAt(sliceIndex);

                if (CurrentFormValue.Slices.Count == 0)
                    CurrentFormValue.Position = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION;

                SelectedSlices.Clear();

                if (Notifier.SliceValueChanged != null)
                    Notifier.SliceValueChanged();
            }

            return true;
        }

        public void RegisterSelectedItem(SliceValue selectedItem)
        {
            this.selectedItem = selectedItem;

            if (selectedItem is SpecialSliceValue)
                (selectedItem as SpecialSliceValue).Size = LevelItemManager.Instance.GetGridSizeForSpecialSliceType((selectedItem as SpecialSliceValue).Special);
        }

        // called by Main Form
        public void UpdateSelectedSlices(ListView.SelectedIndexCollection selectedIndices)
        {
            SelectedSlices.Clear();
            foreach (int selectedIndex in selectedIndices)
                SelectedSlices.Add(selectedIndex);
        }

        public void PrecomputeForSave()
        {
            // look for 3x2 slices beyond scale and remove them
            foreach (FormValue formValue in FormValues)
                for (int i = 0; i < formValue.Slices.Count; ++i)
                    if (formValue.Slices[i] is SpecialSliceValue && ((SpecialSliceValue)formValue.Slices[i]).Special == SpecialSliceValue.SpecialType.SCALE)
                    {
                        Vector2 scaleSize = ((SpecialSliceValue)formValue.Slices[i]).Size;
                        if(scaleSize.X % 2 == 1)
                            scaleSize -= new Vector2(1, 0);

                        Vector3 positionToSearch = formValue.Position + formValue.Slices[i].Position + new Vector3(scaleSize.X / 2 - 1, scaleSize.Y, 0);

                        for(int x = 0; x < 3; ++x)
                            for (int y = 0; y < 2; ++y)
                            {
                                Vector3 currentPosition = positionToSearch + new Vector3(x, y, 0);

                                foreach (FormValue formValueDelete in FormValues)
                                    for (int j = formValueDelete.Slices.Count - 1; j >= 0; --j)
                                        if (formValueDelete.Position + formValueDelete.Slices[j].Position == currentPosition)
                                            formValueDelete.Slices.RemoveAt(j);
                            }
                    }

            foreach (FormValue formValue in FormValues)
            {
                if (formValue.Slices.Count == 0)
                    continue;

                foreach (SliceValue sliceValue in formValue.Slices)
                    sliceValue.Position += formValue.Position;

                Vector2 topMostPosition = new Vector2(float.MaxValue, float.MaxValue);

                for (int i = 0; i < formValue.Slices.Count; ++i)
                {
                    if (formValue.Slices[i].Position.X < topMostPosition.X)
                        topMostPosition.X = formValue.Slices[i].Position.X;
                    if (formValue.Slices[i].Position.Y < topMostPosition.Y)
                        topMostPosition.Y = formValue.Slices[i].Position.Y;
                }

                formValue.Position = new Vector3(topMostPosition.X, topMostPosition.Y, formValue.Position.Z);
                foreach (SliceValue sliceValue in formValue.Slices)
                    sliceValue.Position -= formValue.Position;

                for (int i = 0; i < formValue.Slices.Count; ++i)
                    if (formValue.Slices[i] is SpecialSliceValue)
                        formValue.SpecialSlices.Add(formValue.Slices[i] as SpecialSliceValue);
                formValue.Slices.RemoveAll(s => s is SpecialSliceValue);
            }
        }

        public void RestoreAfterLoad()
        {
            foreach (FormValue formValue in FormValues)
            {
                foreach (SpecialSliceValue specialSliceValue in formValue.SpecialSlices)
                    formValue.Slices.Add(specialSliceValue);
                formValue.SpecialSlices.Clear();
                RecalculateCenterPoint(formValue);
            }
        }

        private void RecalculateCenterPoint(FormValue formValue)
        {
            Vector2 leftTop = new Vector2(int.MaxValue, int.MaxValue);
            Vector2 rightBottom = new Vector2(int.MinValue, int.MinValue);

            foreach (SliceValue sliceValue in formValue.Slices)
            {
                // reset to absolute world positions
                sliceValue.Position += formValue.Position;

                if (sliceValue.Position.X < leftTop.X)
                    leftTop.X = sliceValue.Position.X;
                if (sliceValue.Position.X > rightBottom.X)
                    rightBottom.X = sliceValue.Position.X;
                if (sliceValue.Position.Y < leftTop.Y)
                    leftTop.Y = sliceValue.Position.Y;
                if (sliceValue.Position.Y > rightBottom.Y)
                    rightBottom.Y = sliceValue.Position.Y;
            }

            rightBottom += new Vector2(1, 1);
            formValue.Position = new Vector3((leftTop + rightBottom) / 2, formValue.Position.Z);
            formValue.Position = new Vector3((float)Math.Round(formValue.Position.X, 1), (float)Math.Round(formValue.Position.Y, 1), formValue.Position.Z);

            // reset back to relative positions
            foreach (SliceValue sliceValue in formValue.Slices)
                sliceValue.Position -= formValue.Position;
        }

        private void CreateOrRemoveShapeByMouseDrag(MouseEventArgs e)
        {
            if (SelectionManager.Instance.Mode == SelectionManager.SelectionMode.NONE && GameObjectMover.Instance.SelectedGameObject == null && GameObjectScaler.Instance.SelectedGameObject == null)
                ModifyOrSelectShape(e.Button, new Vector2(e.X, e.Y));
        }

        // TODO refactor selection/deletion code...
        private void ModifyOrSelectShape(MouseEventArgs e)
        {
            if (selectedItem == null || GameObjectMover.Instance.SelectedGameObject != null || GameObjectScaler.Instance.SelectedGameObject != null)
                return;

            if (SelectionManager.Instance.Mode == SelectionManager.SelectionMode.NONE)
            {
                ModifyOrSelectShape(e.Button, new Vector2(e.X, e.Y));
                if (Notifier.SliceValueChanged != null)
                    Notifier.SliceValueChanged();
            }
            else
            {
                SelectedSlices.Clear();

                // TODO optimize performance!
                int stepping = GlobalValues.Instance.GridSize / 2;
                for (int x = SelectionManager.Instance.SelectionRectangle.Left; x < SelectionManager.Instance.SelectionRectangle.Right - stepping; x += stepping)
                    for (int y = SelectionManager.Instance.SelectionRectangle.Top; y < SelectionManager.Instance.SelectionRectangle.Bottom - stepping; y += stepping)
                        ModifyOrSelectShape(e.Button, new Vector2(x, y));

                if (SelectionManager.Instance.Mode == SelectionManager.SelectionMode.SELECT)
                {
                    SelectedSlices = SelectedSlices.Distinct().ToList();
                    if (Notifier.SliceValueSelected != null)
                        Notifier.SliceValueSelected(SelectedSlices);
                }

                else if (Notifier.SliceValueChanged != null)
                    Notifier.SliceValueChanged();
            }
        }

        private void ModifyOrSelectShape(MouseButtons button, Vector2 mousePosition)
        {
            if (button == MouseButtons.None)
                return;

            Vector2 gridPositionOffset = new Vector2(
                CurrentFormValue.Position.X - Convert.ToInt32(CurrentFormValue.Position.X),
                CurrentFormValue.Position.Y - Convert.ToInt32(CurrentFormValue.Position.Y));

            mousePosition -= gridPositionOffset * GlobalValues.Instance.GridSize;

            // calculate rotated position
            float radianRotation = -MathHelper.ToRadians(CurrentFormValue.Rotation);
            // set position relative to rotation point (= grid position of parent form)
            if(CurrentFormValue.Slices.Count > 0)
                mousePosition -= HelperFunctions.Vector3ToVector2(CurrentFormValue.Position) * GlobalValues.Instance.GridSize;
            double rotatedX = (mousePosition.X * Math.Cos(radianRotation) - mousePosition.Y * Math.Sin(radianRotation));
            double rotatedY = (mousePosition.X * Math.Sin(radianRotation) + mousePosition.Y * Math.Cos(radianRotation));

            // normalize to raster
            Vector3 rotatedGridPosition = new Vector3(
                Convert.ToInt32(rotatedX / GlobalValues.Instance.GridSize), 
                Convert.ToInt32(rotatedY / GlobalValues.Instance.GridSize), 0);

            rotatedGridPosition += new Vector3(gridPositionOffset, 0);
            
            // check if there is actually a slice within the same grid position
            List<SliceValue> currentSliceValues = CurrentFormValue.Slices;
            SliceValue targetValue = currentSliceValues.Find(x => x.Position == rotatedGridPosition);
            int oldSlicesCount = currentSliceValues.Count;

            // select
            if (SelectionManager.Instance.Mode == SelectionManager.SelectionMode.SELECT)
            {
                if (targetValue != null)
                    SelectedSlices.Add(currentSliceValues.IndexOf(targetValue));
            }

            // add
            else if (button == MouseButtons.Left)
            {
                // when there is no overlapping with a slice or it is a special slice value simply add it
                if (targetValue == null || (selectedItem is SpecialSliceValue && !(targetValue is SpecialSliceValue)))
                {
                    if (selectedItem.Type != SliceValue.SliceType.EXTRA)
                    {
                        SliceValue sliceValueToAdd = new SliceValue(selectedItem);
                        sliceValueToAdd.Position = new Vector3(rotatedGridPosition.X, rotatedGridPosition.Y, 0);
                        currentSliceValues.Add(sliceValueToAdd);
                    }

                    else
                    {
                        SpecialSliceValue sliceValueToAdd = new SpecialSliceValue(selectedItem as SpecialSliceValue);
                        sliceValueToAdd.Position = rotatedGridPosition;

                        float leftestX = Math.Min(sliceValueToAdd.Position.X, sliceValueToAdd.Position.X + sliceValueToAdd.Size.X);
                        float rightestX = Math.Max(sliceValueToAdd.Position.X, sliceValueToAdd.Position.X + sliceValueToAdd.Size.X);
                        float topY = Math.Min(sliceValueToAdd.Position.Y, sliceValueToAdd.Position.Y + sliceValueToAdd.Size.Y);
                        float bottomY = Math.Max(sliceValueToAdd.Position.Y, sliceValueToAdd.Position.Y + sliceValueToAdd.Size.Y);
                        currentSliceValues.RemoveAll(x => x.Position.X >= leftestX && x.Position.X < rightestX && x.Position.Y >= topY && x.Position.Y < bottomY);

                        List<string> specialSliceIDs = new List<string>();
                        foreach(FormValue formValue in FormValues)
                            foreach (GameObjectValue value in formValue.Slices)
                                specialSliceIDs.Add(value.ID);
                        List<string> triggerZoneIDs = new List<string>();
                        foreach (TriggerZoneValue value in MetaDataManager.Instance.TriggerZones)
                            triggerZoneIDs.Add(value.ID);

                        // TODO create prefab class and remove this code from here
                        if (sliceValueToAdd.Special == SpecialSliceValue.SpecialType.SWITCH)
                        {
                            sliceValueToAdd.ID = GetNextValidID("switch_", ref specialSliceIDs);
                            Vector2 triggerZoneSize = new Vector2(1, .5f);
                            TriggerZoneValue triggerZoneValue =
                                new TriggerZoneValue(GetNextValidID("t_s_", ref triggerZoneIDs), new Vector3(Convert.ToInt32(selectedItem.Position.X), Convert.ToInt32(selectedItem.Position.Y) - .5f, selectedItem.Position.Z), triggerZoneSize, true, true, false);
                            MetaDataManager.Instance.AddTriggerZone(triggerZoneValue);
                            Notifier.TriggerZoneValueChanged();
                        }

                        else if (sliceValueToAdd.Special == SpecialSliceValue.SpecialType.CHECKPOINT)
                        {
                            sliceValueToAdd.ID = GetNextValidID("checkpoint_", ref specialSliceIDs);
                            Vector2 triggerZoneSize = new Vector2(3, .5f);
                            TriggerZoneValue triggerZoneValue =
                                new TriggerZoneValue(GetNextValidID("t_c_", ref triggerZoneIDs), new Vector3(Convert.ToInt32(selectedItem.Position.X), Convert.ToInt32(selectedItem.Position.Y) - .5f, selectedItem.Position.Z), triggerZoneSize, false, true, true);
                            triggerZoneValue.Actions.Add(new ActionPlayAnimation(true, false, false, "{\"" + SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ID + "\":\"" + sliceValueToAdd.ID + "\",\"" + SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ANIMATION_CLIP + "\":0}"));
                            triggerZoneValue.Actions.Add(new ActionArriveCheckpoint(true, false, false, "{\"" + SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_NUMBER + "\":" + MetaDataManager.Instance.TriggerZones.Count(x => x.ID.StartsWith("t_c_")) + "}"));
                            MetaDataManager.Instance.AddTriggerZone(triggerZoneValue);
                            Notifier.TriggerZoneValueChanged();
                        }
                        
                        currentSliceValues.Add(sliceValueToAdd);
                    }
                }

                // combine two adjacent triangles to a quad 
                else if ((selectedItem.Type == SliceValue.SliceType.QUAD && targetValue.Type != SliceValue.SliceType.QUAD) ||
                        (selectedItem.Type == SliceValue.SliceType.TRIANGLE_LEFT_TOP && targetValue.Type == SliceValue.SliceType.TRIANGLE_RIGHT_BOTTOM) ||
                        (targetValue.Type == SliceValue.SliceType.TRIANGLE_LEFT_TOP && selectedItem.Type == SliceValue.SliceType.TRIANGLE_RIGHT_BOTTOM) ||
                        (selectedItem.Type == SliceValue.SliceType.TRIANGLE_RIGHT_TOP && targetValue.Type == SliceValue.SliceType.TRIANGLE_LEFT_BOTTOM) ||
                        (targetValue.Type == SliceValue.SliceType.TRIANGLE_RIGHT_TOP && selectedItem.Type == SliceValue.SliceType.TRIANGLE_LEFT_BOTTOM))
                    targetValue.Type = SliceValue.SliceType.QUAD;
            }

            // remove
            else if (button == MouseButtons.Right && targetValue != null)
                currentSliceValues.Remove(targetValue);

            // a slice has been added or removed --> recalculate the center point
            if (oldSlicesCount != currentSliceValues.Count)
            {
                if (currentSliceValues.Count == 0)
                    CurrentFormValue.Position = SerializationConstants.DEFAULT_VALUE_GAME_OBJECT_POSITION;
                else
                    RecalculateCenterPoint(CurrentFormValue);
            }
        }

        private string GetNextValidID(string prefix, ref List<string> ids)
        {
            string idToUse = "";
            int id = 0;
            bool duplicate = true;

            do
            {
                idToUse = prefix + id;
                ++id;
                duplicate = false;

                foreach (string idString in ids)
                    if (idString.StartsWith(idToUse))
                        duplicate = true;
            }
            while (duplicate);

            return idToUse;
        }

        public bool Optimize(int maxSlicesPerForm)
        {
            if (FormValues.Count == 0)
                return false;

            List<FormValue> optimizedValues = new List<FormValue>();

            foreach (FormValue formValue in FormValues)
            {
                if (formValue.Slices.Count == 0)
                    continue;

                List<List<SliceValue>> labeledSliceValues = new List<List<SliceValue>>();
                List<SliceValue> sourceList = formValue.Slices;
                int currentLabel = 0;
                labeledSliceValues.Add(new List<SliceValue>());
                Label(formValue.Slices[0].Position, ref sourceList, labeledSliceValues[currentLabel]);

                for (int i = 1; i < sourceList.Count; ++i)
                {
                    bool alreadyLabeled = false;

                    for(int j = 0; j < labeledSliceValues.Count; ++j)
                        if (labeledSliceValues[j].Contains(formValue.Slices[i]))
                        {
                            alreadyLabeled = true;
                            break;
                        }

                    if(!alreadyLabeled)
                    {
                        ++currentLabel;
                        labeledSliceValues.Add(new List<SliceValue>());
                        Label(formValue.Slices[i].Position, ref sourceList, labeledSliceValues[currentLabel]);
                    }
                }
                
                for (int i = 0; i < labeledSliceValues.Count; ++i)
                {
                    foreach (SliceValue sliceValue in labeledSliceValues[i])
                        if (sliceValue.Breakable)
                            continue;

                    labeledSliceValues[i] = labeledSliceValues[i].OrderBy(s => s.Position.Y).ThenBy(s => s.Position.X).ToList();

                    List<List<SliceValue>> splitSliceValues = new List<List<SliceValue>>();

                    if (labeledSliceValues[i].Count >= maxSlicesPerForm)
                    {
                        while (labeledSliceValues[i].Count >= maxSlicesPerForm)
                        {
                            splitSliceValues.Add(new List<SliceValue>());
                            splitSliceValues.Last().AddRange(labeledSliceValues[i].GetRange(0, maxSlicesPerForm));
                            labeledSliceValues[i].RemoveRange(0, maxSlicesPerForm);
                        }

                        if (labeledSliceValues[i].Count > 0)
                        {
                            splitSliceValues.Add(new List<SliceValue>());
                            splitSliceValues.Last().AddRange(labeledSliceValues[i]);
                            labeledSliceValues[i].Clear();
                        }

                        labeledSliceValues.RemoveAt(i);
                        foreach (List<SliceValue> sliceValues in splitSliceValues)
                            labeledSliceValues.Insert(0, sliceValues);
                    }
                }
                
                for (int i = 0; i < labeledSliceValues.Count; ++i)
                {
                    optimizedValues.Add(new FormValue(formValue.ID + ((labeledSliceValues.Count > 1) ? "_" + i : ""), formValue.Position, formValue.Rotation));
                    optimizedValues.Last().Slices = labeledSliceValues[i];
                }
            }

            FormValues.Clear();
            FormValues = optimizedValues;

            return true;
        }

        private bool Label(Vector3 position, ref List<SliceValue> sourceList, List<SliceValue> targetList)
        {
            foreach (SliceValue sliceValue in sourceList)
                if (sliceValue.Position == position && !targetList.Contains(sliceValue))
                {
                    targetList.Add(sliceValue);
                    Label(sliceValue.Position - new Vector3(1, 0, 0), ref sourceList, targetList);
                    Label(sliceValue.Position + new Vector3(1, 0, 0), ref sourceList, targetList);
                    Label(sliceValue.Position - new Vector3(0, 1, 0), ref sourceList, targetList);
                    Label(sliceValue.Position + new Vector3(0, 1, 0), ref sourceList, targetList);

                    return true;
                }

            return false;
        }
    }
}
