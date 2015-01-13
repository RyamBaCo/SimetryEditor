using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simetry.Interface.Serialization;
using Simetry.Interface.Globals;

namespace SimetryEditor
{
    class BackgroundDrawer : ILevelDrawer
    {
        private Texture2D backgroundTexture;
        private SpriteFont backgroundFont;
        private Color[] randomColors;

        public BackgroundDrawer()
        {
            backgroundTexture = new Texture2D(GlobalValues.Instance.GlobalSpriteBatch.GraphicsDevice, 1, 1);
            backgroundTexture.SetData<Color>( new Color[] { Color.White } );
            backgroundFont = GlobalValues.Instance.GlobalContent.Load<SpriteFont>(GlobalValues.ASSET_NAME_FONT);

            Random random = new Random();
            randomColors = new Color[100];
            for (int i = 0; i < 100; ++i)
                randomColors[i] = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        public void Draw()
        {
            if (!GlobalValues.Instance.DrawBackground)
                return;

            List<BackgroundValue> convertedBackgroundData = MetaDataManager.Instance.MetadataGameObjects.FindAll(m => m is BackgroundValue).Cast<BackgroundValue>().OrderByDescending(b => new Vector2(GetBackgroundRectangle(b).Width, GetBackgroundRectangle(b).Height).LengthSquared()).ToList();

            for(int i = 0; i < convertedBackgroundData.Count; ++i)
            {
                Rectangle currentBackgroundRectangle = GetBackgroundRectangle(convertedBackgroundData[i]);

                Color drawColor = randomColors[i % 100];
                GlobalValues.Instance.GlobalSpriteBatch.Draw(backgroundTexture, currentBackgroundRectangle, drawColor);

                Vector2 fontSize = backgroundFont.MeasureString(convertedBackgroundData[i].AssetName);
                Color fontColor = new Color(255 - drawColor.R, 255 - drawColor.G, 255 - drawColor.B, 20);

                for (int x = currentBackgroundRectangle.Left + (int)(fontSize.X * .5f); x < currentBackgroundRectangle.Right - fontSize.X; x += (int)fontSize.X * 2)
                    for (int y = currentBackgroundRectangle.Top + (int)(fontSize.Y * .5f); y < currentBackgroundRectangle.Bottom - fontSize.Y; y += (int)fontSize.Y * 2)
                        GlobalValues.Instance.GlobalSpriteBatch.DrawString(backgroundFont, convertedBackgroundData[i].AssetName, new Vector2(x, y), fontColor);
            }
        }

        private Rectangle GetBackgroundRectangle(BackgroundValue backgroundValue)
        {
            Vector2 sizeToUse = new Vector2(
                (SerializationConstants.BackgroundAssetNames[backgroundValue.AssetName].X + backgroundValue.RepeatGap.X) * backgroundValue.Repeat.X,
                (SerializationConstants.BackgroundAssetNames[backgroundValue.AssetName].Y + backgroundValue.RepeatGap.Y) * backgroundValue.Repeat.Y);

            return new Rectangle(Math.Max(0, (int)(backgroundValue.Position.X - sizeToUse.X / 2)) * GlobalValues.Instance.GridSize, Math.Max(0, (int)(backgroundValue.Position.Y - sizeToUse.Y)) * GlobalValues.Instance.GridSize,
                        (int)(sizeToUse.X) * GlobalValues.Instance.GridSize,
                        (int)(sizeToUse.Y) * GlobalValues.Instance.GridSize);
        }
    }
}
