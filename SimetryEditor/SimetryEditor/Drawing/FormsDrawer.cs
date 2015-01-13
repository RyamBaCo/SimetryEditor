using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Simetry.Interface.Serialization;

namespace SimetryEditor
{
    class FormsDrawer : ILevelDrawer
    {
        public void Draw()
        {
            for (int formIndex = 0; formIndex < FormsManager.Instance.FormValues.Count; ++formIndex)
            {
                FormValue formValue = FormsManager.Instance.FormValues[formIndex];

                if (!GlobalValues.Instance.ShowAll && formValue.Position.Z != GlobalValues.Instance.ZValue)
                    continue;

                for (int i = 0; i < formValue.Slices.Count; ++i)
                {
                    int alpha = 255;
                    if (FormsManager.Instance.CurrentFormIndex != formIndex)
                        alpha = 40;
                    else if (FormsManager.Instance.SelectedSlices.Contains(i))
                        alpha = 150;

                    LevelItemManager.Instance.Draw(formValue.Slices[i], new Vector2(formValue.Position.X, formValue.Position.Y), formValue.Rotation, alpha);
                }
            }
        }
    }
}
