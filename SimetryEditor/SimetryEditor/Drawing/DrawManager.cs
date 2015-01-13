using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimetryEditor
{
    /// <summary>
    /// Instantiates all needed drawer classes and calls their drawing function
    /// Therefore defines the drawing order
    /// </summary>
    class DrawManager : ILevelDrawer
    {
        private BackgroundDrawer backgroundDrawer;
        private RasterDrawer rasterDrawer;
        private SelectedItemDrawer selectedItemDrawer;
        private FormsDrawer formsDrawer;
        private MetaDataDrawer metaDataDrawer;

        public DrawManager()
        {
            backgroundDrawer = new BackgroundDrawer();
            rasterDrawer = new RasterDrawer();
            formsDrawer = new FormsDrawer();
            selectedItemDrawer = new SelectedItemDrawer();
            metaDataDrawer = new MetaDataDrawer();
        }

        public void Draw()
        {
            GlobalValues.Instance.GlobalSpriteBatch.Begin();
            backgroundDrawer.Draw();
            rasterDrawer.Draw();
            formsDrawer.Draw();
            selectedItemDrawer.Draw();
            metaDataDrawer.Draw();
            GlobalValues.Instance.GlobalSpriteBatch.End();
        }
    }
}
