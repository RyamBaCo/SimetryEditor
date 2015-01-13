using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Windows.Forms;

namespace SimetryEditor
{
    public class LevelDrawControl : GraphicsDeviceControl
    {
        private DrawManager drawManager;

        protected override void Initialize()
        {
            GlobalValues.Instance.GlobalSpriteBatch = new SpriteBatch(GraphicsDevice);
            GlobalValues.Instance.GlobalContent = new ContentManager(Services, "Content");

            drawManager = new DrawManager();
            // constantly redraw
            Application.Idle += delegate { Invalidate(); };

            Notifier.GridSizeChanged += new NotifyGridSizeChangedHandler(UpdateControlSize);
            Notifier.LevelSizeChanged += new NotifyLevelSizeChangedHandler(UpdateControlSize);
        }

        private void UpdateControlSize()
        {
            Width = Convert.ToInt32(GlobalValues.Instance.LevelSize.X * GlobalValues.Instance.GridSize);
            Height = Convert.ToInt32(GlobalValues.Instance.LevelSize.Y * GlobalValues.Instance.GridSize);

            GlobalValues.Instance.DrawCanvasSize = new System.Drawing.Size(Width, Height);
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.White);
            drawManager.Draw();
        }
    }
}
