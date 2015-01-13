using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Simetry.Interface.Serialization;
using Simetry.Interface.Globals;

namespace SimetryEditor
{
    class SelectedItemDrawer : ILevelDrawer
    {
        private bool visible;

        private GameObjectValue values = null;

        public SelectedItemDrawer()
        {
            visible = false;

            Notifier.LevelDrawMouseMove += new NotifyLevelDrawMouseMoveHandler(UpdateDrawPosition);
            Notifier.SelectedItemValueChanged += new NotifySelectedItemValueChangedHandler(UpdateValues);
        }

        public void Draw()
        {
            if (!visible)
                return;

            if(values != null && GlobalValues.Instance.CreationMode == GlobalValues.CreationModeType.CREATE_FORMS)
                LevelItemManager.Instance.Draw(values as SliceValue);
        }

        private void UpdateValues(bool visible, GameObjectValue values)
        {
            this.visible = visible;
            this.values = values;

            if(this.values is SliceValue)
                FormsManager.Instance.RegisterSelectedItem(this.values as SliceValue);
        }

        private void UpdateDrawPosition(MouseEventArgs e)
        {
            if (values == null)
                return;

            values.Position = new Vector3(e.X, e.Y, values.Position.Z) / GlobalValues.Instance.GridSize;
        }
    }
}
