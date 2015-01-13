namespace SimetryEditor
{
    partial class ShiftForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownShiftX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOkay = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.numericUpDownShiftY = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftY)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownShiftX
            // 
            this.numericUpDownShiftX.Location = new System.Drawing.Point(55, 12);
            this.numericUpDownShiftX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownShiftX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownShiftX.Name = "numericUpDownShiftX";
            this.numericUpDownShiftX.Size = new System.Drawing.Size(48, 20);
            this.numericUpDownShiftX.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shift to";
            // 
            // buttonOkay
            // 
            this.buttonOkay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOkay.Location = new System.Drawing.Point(12, 46);
            this.buttonOkay.Name = "buttonOkay";
            this.buttonOkay.Size = new System.Drawing.Size(75, 23);
            this.buttonOkay.TabIndex = 2;
            this.buttonOkay.Text = "OK";
            this.buttonOkay.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(93, 46);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // numericUpDownShiftY
            // 
            this.numericUpDownShiftY.Location = new System.Drawing.Point(120, 12);
            this.numericUpDownShiftY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownShiftY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownShiftY.Name = "numericUpDownShiftY";
            this.numericUpDownShiftY.Size = new System.Drawing.Size(48, 20);
            this.numericUpDownShiftY.TabIndex = 4;
            // 
            // ShiftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(184, 80);
            this.Controls.Add(this.numericUpDownShiftY);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOkay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownShiftX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShiftForm";
            this.Text = "Shift...";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownShiftX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOkay;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NumericUpDown numericUpDownShiftY;
    }
}