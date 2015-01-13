using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace SimetryEditor
{
    /// <summary>
    /// this class deals with the creation of a selection rectangle and storage of the current selection state
    /// </summary>
    class SelectionManager
    {
        #region Singleton Pattern
        private static readonly SelectionManager instance = new SelectionManager();
        public static SelectionManager Instance { get { return instance; } }
        #endregion

        public enum SelectionMode
        {
            CREATE,
            DELETE,
            SELECT,
            NONE
        }

        public SelectionMode Mode { get; private set; }

        // needs to be extracted because we modify the location
        private Rectangle selectionRectangle;
        public Rectangle SelectionRectangle 
        { 
            get { return selectionRectangle; } 
            private set { selectionRectangle = value; } 
        }

        Keys pressedKey;

        private SelectionManager()
        {
            selectionRectangle = Rectangle.Empty;
            Mode = SelectionMode.NONE;

            Notifier.KeyPressed += new NotifyKeyPressedHandler(KeyPressed);
            Notifier.KeyReleased += new NotifyKeyReleasedHandler(KeyReleased);
            Notifier.LevelDrawMouseDown += new NotifyLevelDrawMouseDownHandler(MouseDown);
            Notifier.LevelDrawMouseUpDelayed += new NotifyLevelDrawMouseUpDelayedHandler(MouseUp);
            Notifier.LevelDrawMouseMove += new NotifyLevelDrawMouseMoveHandler(MouseMove);
        }

        private void KeyPressed(Keys keyData)
        {
            pressedKey = keyData;
        }

        private void KeyReleased()
        {
            Mode = SelectionMode.NONE;
            pressedKey = Keys.None;
        }

        private void MouseDown(MouseEventArgs e)
        {
            // TODO extract key bindings into configuration files or something
            if (pressedKey == (Keys.ShiftKey | Keys.Shift))
                Mode = e.Button == MouseButtons.Left ? SelectionMode.CREATE : SelectionMode.DELETE;
            else if (pressedKey == (Keys.ControlKey | Keys.Control))
                Mode = SelectionMode.SELECT;
            else
                Mode = SelectionMode.NONE;

            if (Mode != SelectionMode.NONE)
            {
                selectionRectangle.Location = new Microsoft.Xna.Framework.Point(HelperFunctions.TruncateToGrid(e.Location.X), HelperFunctions.TruncateToGrid(e.Location.Y));
                selectionRectangle.Width = 0;
                selectionRectangle.Height = 0;
            }
        }

        private void MouseUp(MouseEventArgs e)
        {
            KeyReleased();
        }

        private void MouseMove(MouseEventArgs e)
        {
            selectionRectangle.Width = HelperFunctions.TruncateToGrid(e.Location.X - selectionRectangle.Location.X);
            selectionRectangle.Height = HelperFunctions.TruncateToGrid(e.Location.Y - selectionRectangle.Location.Y);
        }
    }
}
