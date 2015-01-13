using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using Simetry.Interface.Serialization;
using Simetry.Interface.Globals;
using Simetry.Interface.Actions;

namespace SimetryEditor
{
    /// <summary>
    /// Draws all data that is not directly part of the level but usable for visual orientation
    /// e.g. selection frame, rotation positions, connections,...
    /// </summary>
    class MetaDataDrawer : ILevelDrawer
    {
        private Texture2D metaDataTexture;
        private Texture2D metaDataCircleTexture;
        private SpriteFont metaDataFont;
        private LevelItemManager.DrawingTexture circleTexture = new LevelItemManager.DrawingTexture(GlobalValues.ASSET_NAME_CIRCLE);

        public MetaDataDrawer()
        {
            metaDataTexture = new Texture2D(GlobalValues.Instance.GlobalSpriteBatch.GraphicsDevice, 1, 1);
            metaDataTexture.SetData<Color>(new Color[] { new Color(255, 255, 255, 50) });
            metaDataFont = GlobalValues.Instance.GlobalContent.Load<SpriteFont>(GlobalValues.ASSET_NAME_FONT);

            metaDataCircleTexture = HelperFunctions.CreateCircleTexture(Convert.ToInt32(GlobalValues.Instance.GridSize / 2 * GlobalValues.Instance.MetaDataDrawSize));
        }

        public void Draw()
        {
            int metaDataRectangleSize = Convert.ToInt32(GlobalValues.Instance.GridSize * GlobalValues.Instance.MetaDataDrawSize);

            #region Draw position (= point of rotation) of current form 
            if (FormsManager.Instance.CurrentFormIndex >= 0)
            {
                Rectangle formPositionRectangle = new Rectangle(
                     Convert.ToInt32(FormsManager.Instance.CurrentFormValue.Position.X * GlobalValues.Instance.GridSize - metaDataRectangleSize / 2),
                     Convert.ToInt32(FormsManager.Instance.CurrentFormValue.Position.Y * GlobalValues.Instance.GridSize - metaDataRectangleSize / 2),
                    metaDataRectangleSize, metaDataRectangleSize);
                GlobalValues.Instance.GlobalSpriteBatch.Draw(metaDataTexture, formPositionRectangle, Color.Green);
            }
            #endregion

            foreach (SliceValue sliceValue in FormsManager.Instance.CurrentFormValue.Slices)
            {
                if (sliceValue.Type == SliceValue.SliceType.EXTRA)
                {
                    SpecialSliceValue specialSliceValue = sliceValue as SpecialSliceValue;

                    // those special slice types don't need additional meta data to be drawn
                    if (specialSliceValue.Special == SpecialSliceValue.SpecialType.SWITCH ||
                        specialSliceValue.Special == SpecialSliceValue.SpecialType.DOOR ||
                        specialSliceValue.Special == SpecialSliceValue.SpecialType.CHECKPOINT ||
                        specialSliceValue.Special == SpecialSliceValue.SpecialType.TREADMILL_LEFT ||
                        specialSliceValue.Special == SpecialSliceValue.SpecialType.TREADMILL_RIGHT)
                        continue;

                    Vector2 startDrawPosition = new Vector2(specialSliceValue.Position.X + FormsManager.Instance.CurrentFormValue.Position.X, specialSliceValue.Position.Y + FormsManager.Instance.CurrentFormValue.Position.Y);
                    
                    if(specialSliceValue.Special == SpecialSliceValue.SpecialType.STAMPER)
                        startDrawPosition += new Vector2(.5f - specialSliceValue.Size.X / 2, 1f);
                    else if (specialSliceValue.Special == SpecialSliceValue.SpecialType.CHECKPOINT)
                        startDrawPosition += new Vector2(.5f - specialSliceValue.Size.X / 2, -specialSliceValue.Size.Y);

                    GlobalValues.Instance.GlobalSpriteBatch.Draw(metaDataTexture, new Rectangle(
                            Convert.ToInt32(startDrawPosition.X * GlobalValues.Instance.GridSize),
                            Convert.ToInt32(startDrawPosition.Y * GlobalValues.Instance.GridSize),
                            Convert.ToInt32(specialSliceValue.Size.X * GlobalValues.Instance.GridSize),
                            Convert.ToInt32(specialSliceValue.Size.Y * GlobalValues.Instance.GridSize)), Color.Brown);
                }
            }

            #region Draw Current Form Value ID as string

            FormValue formValue = FormsManager.Instance.CurrentFormValue;
            if(GlobalValues.Instance.ShowFormTags && formValue.ID.Length > 0)
                GlobalValues.Instance.GlobalSpriteBatch.DrawString(metaDataFont, formValue.ID + (formValue.Position.Z == 0 ? "" : " (" + formValue.Position.Z + ")"), new Vector2(formValue.Position.X, formValue.Position.Y) * GlobalValues.Instance.GridSize, Color.IndianRed);

            if(GlobalValues.Instance.ShowSliceTags)
                foreach(SliceValue sliceValue in formValue.Slices)
                    if(sliceValue.ID.Length > 0)
                        GlobalValues.Instance.GlobalSpriteBatch.DrawString(metaDataFont, sliceValue.ID, new Vector2(formValue.Position.X + sliceValue.Position.X, formValue.Position.Y + sliceValue.Position.Y) * GlobalValues.Instance.GridSize, formValue == FormsManager.Instance.CurrentFormValue ? Color.WhiteSmoke : Color.Black);
            #endregion

            #region Draw Trigger Zones and Game Objects
            foreach (TriggerZoneValue triggerZone in MetaDataManager.Instance.TriggerZones)
            {
                if (!GlobalValues.Instance.ShowAll && triggerZone.Position.Z != GlobalValues.Instance.ZValue)
                    continue;

                GlobalValues.Instance.GlobalSpriteBatch.Draw(metaDataTexture, new Rectangle(
                    Convert.ToInt32(triggerZone.Position.X * GlobalValues.Instance.GridSize),
                    Convert.ToInt32(triggerZone.Position.Y * GlobalValues.Instance.GridSize), 
                    Convert.ToInt32(triggerZone.Size.X * GlobalValues.Instance.GridSize),
                    Convert.ToInt32(triggerZone.Size.Y * GlobalValues.Instance.GridSize)), Color.Yellow);

                GlobalValues.Instance.GlobalSpriteBatch.Draw(metaDataTexture, new Rectangle(
                    Convert.ToInt32(triggerZone.Position.X * GlobalValues.Instance.GridSize - metaDataRectangleSize / 2), 
                    Convert.ToInt32(triggerZone.Position.Y * GlobalValues.Instance.GridSize - metaDataRectangleSize / 2),
                    metaDataRectangleSize, metaDataRectangleSize), Color.Blue);

                GlobalValues.Instance.GlobalSpriteBatch.Draw(metaDataTexture, new Rectangle(
                    Convert.ToInt32((triggerZone.Position.X + triggerZone.Size.X) * GlobalValues.Instance.GridSize - metaDataRectangleSize / 2),
                    Convert.ToInt32((triggerZone.Position.Y + triggerZone.Size.Y) * GlobalValues.Instance.GridSize - metaDataRectangleSize / 2),
                    metaDataRectangleSize, metaDataRectangleSize), Color.Blue);

                if (GlobalValues.Instance.ShowMetadataTags)
                {
                    string triggerZoneMetaData = triggerZone.ID;
                    foreach (BaseAction baseAction in triggerZone.Actions)
                        triggerZoneMetaData += "\n" + baseAction.ActionValue.Name + ":" + baseAction.ActionValue.Parameters;
                    GlobalValues.Instance.GlobalSpriteBatch.DrawString(metaDataFont, triggerZoneMetaData, HelperFunctions.Vector3ToVector2(triggerZone.Position) * GlobalValues.Instance.GridSize, Color.Blue);
                }
            }

            foreach (MetadataGameObjectValue metadataGameObject in MetaDataManager.Instance.MetadataGameObjects)
            {
                if (!GlobalValues.Instance.ShowAll && metadataGameObject.Position.Z != GlobalValues.Instance.ZValue)
                    continue;

                if(metadataGameObject.Type == SerializationConstants.METADATA_TYPE_POSITION)
                    GlobalValues.Instance.GlobalSpriteBatch.Draw(metaDataCircleTexture, HelperFunctions.Vector3ToVector2(metadataGameObject.Position) * GlobalValues.Instance.GridSize - new Vector2(GlobalValues.Instance.GridSize * GlobalValues.Instance.MetaDataDrawSize) / 2, Color.Violet);

                else if (metadataGameObject.Type == SerializationConstants.METADATA_TYPE_POINT_LIGHT)
                {
                    PointLightValue value = (PointLightValue)metadataGameObject;
                    circleTexture.Draw(HelperFunctions.Vector3ToVector2(value.Position) - new Vector2(value.Radius, value.Radius) / 2, new Color(value.Color), Vector2.Zero, 0, new Vector2(value.Radius, value.Radius));
                }

                if (GlobalValues.Instance.ShowMetadataTags)
                    GlobalValues.Instance.GlobalSpriteBatch.DrawString(metaDataFont, metadataGameObject.ID + (metadataGameObject.Position.Z == 0 ? "" : " (" + metadataGameObject.Position.Z + ")"), HelperFunctions.Vector3ToVector2(metadataGameObject.Position) * GlobalValues.Instance.GridSize, Color.Violet);
            }
            #endregion

            #region Draw selection rectangle depending on mode
            if (SelectionManager.Instance.Mode != SelectionManager.SelectionMode.NONE)
            {
                // TODO put these colors in some external settings
                Color selectionColor = Color.White;
                if (SelectionManager.Instance.Mode == SelectionManager.SelectionMode.CREATE)
                    selectionColor = Color.Green;
                else if (SelectionManager.Instance.Mode == SelectionManager.SelectionMode.DELETE)
                    selectionColor = Color.Red;
                else if (SelectionManager.Instance.Mode == SelectionManager.SelectionMode.SELECT)
                    selectionColor = Color.Blue;

                GlobalValues.Instance.GlobalSpriteBatch.Draw(metaDataTexture, SelectionManager.Instance.SelectionRectangle, selectionColor);
            }
            #endregion
        }
    }
}
