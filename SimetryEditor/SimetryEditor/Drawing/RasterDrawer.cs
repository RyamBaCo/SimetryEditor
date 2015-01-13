using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimetryEditor
{
    class RasterDrawer : ILevelDrawer
    {
        private Texture2D gridTexture;

        public RasterDrawer()
        {
            gridTexture = new Texture2D(GlobalValues.Instance.GlobalSpriteBatch.GraphicsDevice, 1, 1);
            gridTexture.SetData<Color>( new Color[] { Color.White } );
        }

        public void Draw()
        {
            for (int y = 0; y <= GlobalValues.Instance.LevelSize.X; ++y)
                HelperFunctions.DrawLine(gridTexture, Color.LightGray, 1, new Vector2(y * GlobalValues.Instance.GridSize, 0), new Vector2(y * GlobalValues.Instance.GridSize, GlobalValues.Instance.DrawCanvasSize.Height));

            for (int x = 0; x <= GlobalValues.Instance.LevelSize.Y; ++x)
                HelperFunctions.DrawLine(gridTexture, Color.LightGray, 1, new Vector2(0, x * GlobalValues.Instance.GridSize), new Vector2(GlobalValues.Instance.DrawCanvasSize.Width, x * GlobalValues.Instance.GridSize));
        }
    }
}
