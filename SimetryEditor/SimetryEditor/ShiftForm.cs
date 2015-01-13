using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace SimetryEditor
{
    public partial class ShiftForm : Form
    {
        public Vector3 Offset { get { return new Vector3((float)numericUpDownShiftX.Value, (float)numericUpDownShiftY.Value, 0); } }

        public ShiftForm()
        {
            InitializeComponent();
        }
    }
}
