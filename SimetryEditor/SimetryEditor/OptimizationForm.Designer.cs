namespace SimetryEditor
{
    partial class OptimizationForm
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
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOkay = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Location = new System.Drawing.Point(192, 12);
            this.numericUpDownSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownSize.TabIndex = 0;
            this.numericUpDownSize.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maximum amount of slices per form:";
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
            // OptimizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(290, 80);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOkay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptimizationForm";
            this.Text = "Optimize...";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOkay;
        private System.Windows.Forms.Button buttonCancel;
    }
}