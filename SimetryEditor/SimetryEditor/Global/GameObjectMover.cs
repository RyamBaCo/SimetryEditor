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
    /// implements drag-and-drop functionality for certain game objects
    /// </summary>
    
    class GameObjectMover
    {
        #region Singleton Pattern
        private static readonly GameObjectMover instance = new GameObjectMover();
        public static GameObjectMover Instance { get { return instance; } }
        #endregion

        public GameObjectValue SelectedGameObject { get; private set; }

        private GameObjectMover()
        {
            SelectedGameObject = null;

            Notifier.LevelDrawMouseDown += new NotifyLevelDrawMouseDownHandler(MouseDown);
            Notifier.LevelDrawMouseMove += new NotifyLevelDrawMouseMoveHandler(MouseMove);
            Notifier.LevelDrawMouseUpDelayed += new NotifyLevelDrawMouseUpDelayedHandler(MouseUp);
        }

        private void MouseDown(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            if (GetGameObjectRectangle(FormsManager.Instance.CurrentFormValue.Position).Contains(mousePoint))
                SelectedGameObject = FormsManager.Instance.CurrentFormValue;
            if(SelectedGameObject == null)
            {
                foreach (GameObjectValue gameObject in MetaDataManager.Instance.MetadataGameObjects)
                    if (GetGameObjectRectangle(gameObject.Position).Contains(mousePoint))
                    {
                        SelectedGameObject = gameObject;
                        break;
                    }
            }
            if(SelectedGameObject == null)
                foreach (TriggerZoneValue triggerZone in MetaDataManager.Instance.TriggerZones)
                    if(GetGameObjectRectangle(triggerZone.Position).Contains(mousePoint))
                    {
                        SelectedGameObject = triggerZone;
                        break;
                    }
        }

        private Rectangle GetGameObjectRectangle(Vector3 position)
        {
            int gameObjectRectangleSize = Convert.ToInt32(GlobalValues.Instance.GridSize * GlobalValues.Instance.MetaDataDrawSize);

            return new Rectangle(
                Convert.ToInt32(position.X * GlobalValues.Instance.GridSize - gameObjectRectangleSize / 2),
                Convert.ToInt32(position.Y * GlobalValues.Instance.GridSize - gameObjectRectangleSize / 2),
                gameObjectRectangleSize, gameObjectRectangleSize);
        }

        private void MouseMove(MouseEventArgs e)
        {
            if (SelectedGameObject != null)
            {
                Vector2 mouseToGrid = new Vector2(e.X, e.Y) / GlobalValues.Instance.GridSize;
                SelectedGameObject.Position -= 
                    new Vector3(
                        Convert.ToInt32(SelectedGameObject.Position.X - mouseToGrid.X), 
                        Convert.ToInt32(SelectedGameObject.Position.Y - mouseToGrid.Y), 0);
            }
        }

        private void MouseUp(MouseEventArgs e)
        {
            SelectedGameObject = null;
        }
    }
}
