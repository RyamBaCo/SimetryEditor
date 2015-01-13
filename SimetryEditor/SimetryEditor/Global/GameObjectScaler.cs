using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simetry.Interface.Globals;
using Simetry.Interface.Serialization;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace SimetryEditor
{
    /// <summary>
    /// implements scale functionality for certain game objects
    /// </summary>
    
    class GameObjectScaler
    {
        #region Singleton Pattern
        private static readonly GameObjectScaler instance = new GameObjectScaler();
        public static GameObjectScaler Instance { get { return instance; } }
        #endregion

        public TriggerZoneValue SelectedGameObject { get; private set; }

        private GameObjectScaler()
        {
            SelectedGameObject = null;

            Notifier.LevelDrawMouseDown += new NotifyLevelDrawMouseDownHandler(MouseDown);
            Notifier.LevelDrawMouseMove += new NotifyLevelDrawMouseMoveHandler(MouseMove);
            Notifier.LevelDrawMouseUpDelayed += new NotifyLevelDrawMouseUpDelayedHandler(MouseUp);
        }

        private void MouseDown(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            if(SelectedGameObject == null)
                foreach (TriggerZoneValue triggerZone in MetaDataManager.Instance.TriggerZones)
                    if(GetGameObjectRectangle(triggerZone.Position, triggerZone.Size).Contains(mousePoint))
                    {
                        SelectedGameObject = triggerZone;
                        break;
                    }
        }

        private Rectangle GetGameObjectRectangle(Vector3 position, Vector2 size)
        {
            int gameObjectRectangleSize = Convert.ToInt32(GlobalValues.Instance.GridSize * GlobalValues.Instance.MetaDataDrawSize);

            return new Rectangle(
                Convert.ToInt32((position.X + size.X) * GlobalValues.Instance.GridSize - gameObjectRectangleSize / 2),
                Convert.ToInt32((position.Y + size.Y) * GlobalValues.Instance.GridSize - gameObjectRectangleSize / 2),
                gameObjectRectangleSize, gameObjectRectangleSize);
        }

        private void MouseMove(MouseEventArgs e)
        {
            if (SelectedGameObject != null)
            {
                Vector2 newSizeChange = new Vector2(SelectedGameObject.Position.X + SelectedGameObject.Size.X, SelectedGameObject.Position.Y + SelectedGameObject.Size.Y) - new Vector2(e.X, e.Y) / GlobalValues.Instance.GridSize;
                Vector2 newSize = new Vector2(
                    Convert.ToInt32(SelectedGameObject.Size.X - newSizeChange.X),
                    Convert.ToInt32(SelectedGameObject.Size.Y - newSizeChange.Y));

                if (newSize.X >= 1 && newSize.Y >= 1)
                    SelectedGameObject.Size = newSize;
            }
        }

        private void MouseUp(MouseEventArgs e)
        {
            SelectedGameObject = null;
        }
    }
}
