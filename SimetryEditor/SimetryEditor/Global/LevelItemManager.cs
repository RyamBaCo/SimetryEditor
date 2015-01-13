using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Simetry.Interface.Serialization;

namespace SimetryEditor
{
    /// <summary>
    /// this class deals with the drawing logic behind all level items
    /// </summary>
    class LevelItemManager
    {
        public class DrawingTexture
        {
            public string AssetName { get; private set; }
            // defines the size on which the texture should be stretched
            public Vector2 GridSize { get; private set; }
            public Texture2D Texture { get; private set; }

            public DrawingTexture(string assetName) : this(assetName, new Vector2(1, 1)) { }

            public DrawingTexture(string assetName, Vector2 gridSize)
            {
                GridSize = gridSize;
                AssetName = assetName;
                Texture = LoadTexture(AssetName);
            }

            public void Draw(Vector2 gridPosition)
            {
                Draw(gridPosition, Color.White);
            }

            public void Draw(Vector2 gridPosition, Color color)
            {
                Draw(gridPosition, color, Vector2.Zero, 0);
            }

            public void Draw(Vector2 gridPosition, Color color, Vector2 formGridPosition, int rotation, Vector2 gridSizeToDraw)
            {
                float radianRotation = MathHelper.ToRadians(rotation);
                Vector2 gridPositionToDraw = gridPosition;
              
                if (gridSizeToDraw.X < 0)
                {
                    gridSizeToDraw.X = Math.Abs(gridSizeToDraw.X);
                    gridPositionToDraw.X -= gridSizeToDraw.X - 1;
                }

                if (gridSizeToDraw.Y < 0)
                {
                    gridSizeToDraw.Y = Math.Abs(gridSizeToDraw.Y);
                    gridPositionToDraw.Y -= gridSizeToDraw.Y - 1;
                }

                GlobalValues.Instance.GlobalSpriteBatch.Draw(
                    Texture,
                    new Rectangle(
                        Convert.ToInt32((gridPositionToDraw.X * Math.Cos(radianRotation) - gridPositionToDraw.Y * Math.Sin(radianRotation) + formGridPosition.X) * GlobalValues.Instance.GridSize),
                        Convert.ToInt32((gridPositionToDraw.X * Math.Sin(radianRotation) + gridPositionToDraw.Y * Math.Cos(radianRotation) + formGridPosition.Y) * GlobalValues.Instance.GridSize),
                        Convert.ToInt32(GlobalValues.Instance.GridSize * gridSizeToDraw.X),
                        Convert.ToInt32(GlobalValues.Instance.GridSize * gridSizeToDraw.Y)),
                    null, color,
                    radianRotation, Vector2.Zero, SpriteEffects.None, 0);
            }

            public void Draw(Vector2 gridPosition, Color color, Vector2 formGridPosition, int rotation)
            {
                Draw(gridPosition, color, formGridPosition, rotation, GridSize);
            }

            private Texture2D LoadTexture(string name)
            {
                return GlobalValues.Instance.GlobalContent.Load<Texture2D>(name);
            }
        }

        private enum SliceProperty
        {
            BREAKABLE,
            HEAVY,
            SLIPPERY
        }

        private static readonly LevelItemManager instance = new LevelItemManager();
        public static LevelItemManager Instance { get { return instance; } }

        private Dictionary<SliceValue.SliceType, DrawingTexture> sliceTextureDictionary = new Dictionary<SliceValue.SliceType, DrawingTexture>();
        private Dictionary<SpecialSliceValue.SpecialType, DrawingTexture> specialSliceTextureDictionary = new Dictionary<SpecialSliceValue.SpecialType, DrawingTexture>();
        private Dictionary<SliceProperty, DrawingTexture> slicePropertiesTextureDictionary = new Dictionary<SliceProperty, DrawingTexture>();

        private LevelItemManager()
        {
            sliceTextureDictionary.Add(SliceValue.SliceType.QUAD, new DrawingTexture(GlobalValues.ASSET_NAME_QUAD));
            sliceTextureDictionary.Add(SliceValue.SliceType.TRIANGLE_RIGHT_TOP, new DrawingTexture(GlobalValues.ASSET_NAME_TRIANGLE_1));
            sliceTextureDictionary.Add(SliceValue.SliceType.TRIANGLE_LEFT_TOP, new DrawingTexture(GlobalValues.ASSET_NAME_TRIANGLE_2));
            sliceTextureDictionary.Add(SliceValue.SliceType.TRIANGLE_RIGHT_BOTTOM, new DrawingTexture(GlobalValues.ASSET_NAME_TRIANGLE_3));
            sliceTextureDictionary.Add(SliceValue.SliceType.TRIANGLE_LEFT_BOTTOM, new DrawingTexture(GlobalValues.ASSET_NAME_TRIANGLE_4));

            specialSliceTextureDictionary.Add(SpecialSliceValue.SpecialType.CHECKPOINT, new DrawingTexture(GlobalValues.ASSET_NAME_CHECKPOINT, new Vector2(3, 2)));
            specialSliceTextureDictionary.Add(SpecialSliceValue.SpecialType.STAMPER, new DrawingTexture(GlobalValues.ASSET_NAME_STAMPER, new Vector2(1, 2)));
            specialSliceTextureDictionary.Add(SpecialSliceValue.SpecialType.SWITCH, new DrawingTexture(GlobalValues.ASSET_NAME_SWITCH, new Vector2(1, -2)));
            specialSliceTextureDictionary.Add(SpecialSliceValue.SpecialType.DOOR, new DrawingTexture(GlobalValues.ASSET_NAME_DOOR, new Vector2(4, 7)));
            specialSliceTextureDictionary.Add(SpecialSliceValue.SpecialType.TREADMILL_RIGHT, new DrawingTexture(GlobalValues.ASSET_NAME_TREADMILL_RIGHT, new Vector2(3, 1)));
            specialSliceTextureDictionary.Add(SpecialSliceValue.SpecialType.TREADMILL_LEFT, new DrawingTexture(GlobalValues.ASSET_NAME_TREADMILL_LEFT, new Vector2(3, 1)));
            specialSliceTextureDictionary.Add(SpecialSliceValue.SpecialType.SCALE, new DrawingTexture(GlobalValues.ASSET_NAME_SCALE, new Vector2(8, 2)));

            slicePropertiesTextureDictionary.Add(SliceProperty.BREAKABLE, new DrawingTexture(GlobalValues.ASSET_NAME_BREAKABLE));
            slicePropertiesTextureDictionary.Add(SliceProperty.HEAVY, new DrawingTexture(GlobalValues.ASSET_NAME_HEAVY));
            slicePropertiesTextureDictionary.Add(SliceProperty.SLIPPERY, new DrawingTexture(GlobalValues.ASSET_NAME_SLIPPERY));
        }

        // used for images in objectlistview
        public string GetAssetNameForSliceType(SliceValue sliceValue)
        {
            SliceValue.SliceType type = sliceValue.Type;

            if (type != SliceValue.SliceType.EXTRA)
            {
                if (!sliceTextureDictionary.ContainsKey(type))
                {
                    HelperFunctions.ShowErrorMessage("LevelItemManager::GetAssetNameForSliceType: " + HelperFunctions.MessageTexts.GetNoEntryInSliceDictionaryError(type));
                    return null;
                }

                return sliceTextureDictionary[type].AssetName;
            }

            SpecialSliceValue.SpecialType special = (sliceValue as SpecialSliceValue).Special;

            if (!specialSliceTextureDictionary.ContainsKey(special))
            {
                HelperFunctions.ShowErrorMessage("LevelItemManager::GetAssetNameForSliceType: " + HelperFunctions.MessageTexts.GetNoEntryInSpecialSliceDictionaryError(special));
                return null;
            }

            return specialSliceTextureDictionary[special].AssetName;
        }

        // called by formsmanager
        public Vector2 GetGridSizeForSpecialSliceType(SpecialSliceValue.SpecialType special)
        {
            if (!specialSliceTextureDictionary.ContainsKey(special))
            {
                HelperFunctions.ShowErrorMessage("LevelItemManager::GetGridSizeForSpecialSliceType: " + HelperFunctions.MessageTexts.GetNoEntryInSpecialSliceDictionaryError(special));
                return Vector2.Zero;
            }

            return specialSliceTextureDictionary[special].GridSize;
        }

        public bool Draw(SliceValue sliceValue)
        {
            return Draw(sliceValue, Vector2.Zero, 0, 255);
        }

        public bool Draw(SliceValue sliceValue, Vector2 formGridPosition, int rotation, int alpha)
        {
            DrawingTexture sliceTexture;
            Color colorToDraw;

            if (sliceValue.Type != SliceValue.SliceType.EXTRA)
            {
                if (!sliceTextureDictionary.ContainsKey(sliceValue.Type))
                {
                    HelperFunctions.ShowErrorMessage("LevelItemManager::Draw: " + HelperFunctions.MessageTexts.GetNoEntryInSliceDictionaryError(sliceValue.Type));
                    return false;
                }
                sliceTexture = sliceTextureDictionary[sliceValue.Type];
                colorToDraw = sliceValue.Lethal ? new Color(255, 0, 0, alpha) : new Color(0, 0, 0, alpha);
                sliceTexture.Draw(HelperFunctions.Vector3ToVector2(sliceValue.Position), colorToDraw, formGridPosition, rotation);
            }
            else
            {
                SpecialSliceValue specialSliceValue = sliceValue as SpecialSliceValue;

                if (!specialSliceTextureDictionary.ContainsKey(specialSliceValue.Special))
                {
                    HelperFunctions.ShowErrorMessage("LevelItemManager::Draw: " + HelperFunctions.MessageTexts.GetNoEntryInSpecialSliceDictionaryError(specialSliceValue.Special));
                    return false;
                }
                sliceTexture = specialSliceTextureDictionary[specialSliceValue.Special];

                Vector2 sizeToUse = specialSliceValue.Size;
                Vector2 positionToDraw = formGridPosition;

                if (specialSliceValue.Special == SpecialSliceValue.SpecialType.SCALE)
                    sizeToUse = new Vector2(specialSliceValue.Size.X, 2);
                else if (specialSliceValue.Special == SpecialSliceValue.SpecialType.STAMPER)
                    positionToDraw += new Vector2(-specialSliceValue.Size.X / 2, 1);

                sliceTexture.Draw(HelperFunctions.Vector3ToVector2(specialSliceValue.Position), new Color(255, 255, 255, alpha), positionToDraw, rotation, sizeToUse);
            }

            if (sliceValue.Breakable)
                slicePropertiesTextureDictionary[SliceProperty.BREAKABLE].Draw(HelperFunctions.Vector3ToVector2(sliceValue.Position), Color.White, formGridPosition, rotation);
            if (sliceValue.Heavy)
                slicePropertiesTextureDictionary[SliceProperty.HEAVY].Draw(HelperFunctions.Vector3ToVector2(sliceValue.Position), Color.White, formGridPosition, rotation);
            if (sliceValue.Slippery)
                slicePropertiesTextureDictionary[SliceProperty.SLIPPERY].Draw(HelperFunctions.Vector3ToVector2(sliceValue.Position), Color.White, formGridPosition, rotation);
            return true;
        }
    }
}
