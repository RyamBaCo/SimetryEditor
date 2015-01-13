namespace SimetryEditor
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelLevelScroll = new System.Windows.Forms.Panel();
            this.levelDrawControl = new SimetryEditor.LevelDrawControl();
            this.labelGridSize = new System.Windows.Forms.Label();
            this.groupBoxDimensions = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownLevelSizeHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLevelSizeWidth = new System.Windows.Forms.NumericUpDown();
            this.labelLevelSize = new System.Windows.Forms.Label();
            this.trackBarGridSize = new System.Windows.Forms.TrackBar();
            this.imageListLevelElements = new System.Windows.Forms.ImageList(this.components);
            this.objectListViewElements = new BrightIdeasSoftware.ObjectListView();
            this.elementsColumnType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.elementsColumnBreakable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.elementsColumnLethal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.elementsColumnHeavy = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.elementsColumnSlippery = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.comboBoxForms = new System.Windows.Forms.ComboBox();
            this.groupBoxCurrentForm = new System.Windows.Forms.GroupBox();
            this.objectListViewSpecialSlices = new BrightIdeasSoftware.ObjectListView();
            this.specialSlicesColumnID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.specialSlicesColumnWidth = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.specialSlicesColumnHeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.specialSlicesParameters = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.buttonRemoveForm = new System.Windows.Forms.Button();
            this.buttonAddForm = new System.Windows.Forms.Button();
            this.objectListViewSlices = new BrightIdeasSoftware.ObjectListView();
            this.slicesColumnID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.slicesColumnBreakable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.slicesColumnLethal = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.slicesColumnHeavy = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.slicesColumnSlippery = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownRotation = new System.Windows.Forms.NumericUpDown();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogLevel = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogLevel = new System.Windows.Forms.OpenFileDialog();
            this.tabControlCreation = new System.Windows.Forms.TabControl();
            this.tabPageForms = new System.Windows.Forms.TabPage();
            this.tabPageTriggerZones = new System.Windows.Forms.TabPage();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.buttonRemoveAction = new System.Windows.Forms.Button();
            this.buttonAddAction = new System.Windows.Forms.Button();
            this.comboBoxActions = new System.Windows.Forms.ComboBox();
            this.objectListViewActions = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnActionName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnActionExecuteOnEnter = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnActionExecuteOnExit = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnActionExecuteOnKey = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnActionParameters = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.objectListViewTriggerZones = new BrightIdeasSoftware.ObjectListView();
            this.triggerZoneColumnID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.triggerZoneTriggerByAll = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.triggerZoneExecuteOnce = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.triggerZoneExecuteParallel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.triggerZoneColumnWidth = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.triggerZoneColumnHeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabPageMetadata = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxPointLightShadows = new System.Windows.Forms.CheckBox();
            this.numericUpDownPointLightAttenuation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPointLightIntensity = new System.Windows.Forms.NumericUpDown();
            this.panelPointLightColor = new System.Windows.Forms.Panel();
            this.numericUpDownPointLightRadius = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownPointLightResolution = new System.Windows.Forms.NumericUpDown();
            this.buttonAddEditPointLight = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxPointLightPosition = new System.Windows.Forms.TextBox();
            this.groupBoxBackground = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownBackgroundAnimationDelay = new System.Windows.Forms.NumericUpDown();
            this.buttonAddEditBackground = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBackgroundRepeatGap = new System.Windows.Forms.TextBox();
            this.textBoxBackgroundRepeat = new System.Windows.Forms.TextBox();
            this.textBoxBackgroundScale = new System.Windows.Forms.TextBox();
            this.textBoxBackgroundRotation = new System.Windows.Forms.TextBox();
            this.textBoxBackgroundPosition = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxBackgroundNames = new System.Windows.Forms.ComboBox();
            this.objectListViewMetadataObjects = new BrightIdeasSoftware.ObjectListView();
            this.olvMetadataGameObjectID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMetadataGameObjectType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnMetadataGameObjectParameters = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.checkBoxShowTagForms = new System.Windows.Forms.CheckBox();
            this.checkBoxShowTagSlices = new System.Windows.Forms.CheckBox();
            this.checkBoxShowTagMetadata = new System.Windows.Forms.CheckBox();
            this.checkBoxShowTagObjects = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTipEditor = new System.Windows.Forms.ToolTip(this.components);
            this.numericUpDownCurrentZValue = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxShowAll = new System.Windows.Forms.CheckBox();
            this.checkBoxDrawBackground = new System.Windows.Forms.CheckBox();
            this.labelCurrentPosition = new System.Windows.Forms.Label();
            this.colorDialogLight = new System.Windows.Forms.ColorDialog();
            this.panelLevelScroll.SuspendLayout();
            this.groupBoxDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevelSizeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevelSizeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGridSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewElements)).BeginInit();
            this.groupBoxCurrentForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewSpecialSlices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewSlices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotation)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.tabControlCreation.SuspendLayout();
            this.tabPageForms.SuspendLayout();
            this.tabPageTriggerZones.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewTriggerZones)).BeginInit();
            this.tabPageMetadata.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointLightAttenuation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointLightIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointLightRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointLightResolution)).BeginInit();
            this.groupBoxBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBackgroundAnimationDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewMetadataObjects)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrentZValue)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLevelScroll
            // 
            this.panelLevelScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLevelScroll.AutoScroll = true;
            this.panelLevelScroll.Controls.Add(this.levelDrawControl);
            this.panelLevelScroll.Location = new System.Drawing.Point(12, 27);
            this.panelLevelScroll.Name = "panelLevelScroll";
            this.panelLevelScroll.Size = new System.Drawing.Size(539, 564);
            this.panelLevelScroll.TabIndex = 1;
            // 
            // levelDrawControl
            // 
            this.levelDrawControl.Location = new System.Drawing.Point(3, 3);
            this.levelDrawControl.Name = "levelDrawControl";
            this.levelDrawControl.Size = new System.Drawing.Size(283, 272);
            this.levelDrawControl.TabIndex = 0;
            this.levelDrawControl.Text = "levelDrawControl";
            this.levelDrawControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.levelDrawControl_MouseDown);
            this.levelDrawControl.MouseEnter += new System.EventHandler(this.levelDrawControl_MouseEnter);
            this.levelDrawControl.MouseLeave += new System.EventHandler(this.levelDrawControl_MouseLeave);
            this.levelDrawControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.levelDrawControl_MouseMove);
            this.levelDrawControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.levelDrawControl_MouseUp);
            // 
            // labelGridSize
            // 
            this.labelGridSize.AutoSize = true;
            this.labelGridSize.Location = new System.Drawing.Point(4, 20);
            this.labelGridSize.Name = "labelGridSize";
            this.labelGridSize.Size = new System.Drawing.Size(55, 26);
            this.labelGridSize.TabIndex = 3;
            this.labelGridSize.Text = "Zoom\r\n(Grid Size)\r\n";
            // 
            // groupBoxDimensions
            // 
            this.groupBoxDimensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDimensions.Controls.Add(this.labelGridSize);
            this.groupBoxDimensions.Controls.Add(this.label1);
            this.groupBoxDimensions.Controls.Add(this.numericUpDownLevelSizeHeight);
            this.groupBoxDimensions.Controls.Add(this.numericUpDownLevelSizeWidth);
            this.groupBoxDimensions.Controls.Add(this.labelLevelSize);
            this.groupBoxDimensions.Controls.Add(this.trackBarGridSize);
            this.groupBoxDimensions.Location = new System.Drawing.Point(553, 26);
            this.groupBoxDimensions.Name = "groupBoxDimensions";
            this.groupBoxDimensions.Size = new System.Drawing.Size(206, 88);
            this.groupBoxDimensions.TabIndex = 4;
            this.groupBoxDimensions.TabStop = false;
            this.groupBoxDimensions.Text = "Dimensions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "x";
            // 
            // numericUpDownLevelSizeHeight
            // 
            this.numericUpDownLevelSizeHeight.Location = new System.Drawing.Point(144, 56);
            this.numericUpDownLevelSizeHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownLevelSizeHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLevelSizeHeight.Name = "numericUpDownLevelSizeHeight";
            this.numericUpDownLevelSizeHeight.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownLevelSizeHeight.TabIndex = 6;
            this.numericUpDownLevelSizeHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLevelSizeHeight.ValueChanged += new System.EventHandler(this.numericUpDownLevelSizeHeightWidth_ValueChanged);
            // 
            // numericUpDownLevelSizeWidth
            // 
            this.numericUpDownLevelSizeWidth.Location = new System.Drawing.Point(64, 56);
            this.numericUpDownLevelSizeWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownLevelSizeWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLevelSizeWidth.Name = "numericUpDownLevelSizeWidth";
            this.numericUpDownLevelSizeWidth.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownLevelSizeWidth.TabIndex = 5;
            this.numericUpDownLevelSizeWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLevelSizeWidth.ValueChanged += new System.EventHandler(this.numericUpDownLevelSizeHeightWidth_ValueChanged);
            // 
            // labelLevelSize
            // 
            this.labelLevelSize.AutoSize = true;
            this.labelLevelSize.Location = new System.Drawing.Point(6, 59);
            this.labelLevelSize.Name = "labelLevelSize";
            this.labelLevelSize.Size = new System.Drawing.Size(56, 13);
            this.labelLevelSize.TabIndex = 4;
            this.labelLevelSize.Text = "Level Size";
            // 
            // trackBarGridSize
            // 
            this.trackBarGridSize.Location = new System.Drawing.Point(50, 17);
            this.trackBarGridSize.Maximum = 100;
            this.trackBarGridSize.Minimum = 1;
            this.trackBarGridSize.Name = "trackBarGridSize";
            this.trackBarGridSize.Size = new System.Drawing.Size(155, 45);
            this.trackBarGridSize.TabIndex = 5;
            this.trackBarGridSize.Value = 1;
            // 
            // imageListLevelElements
            // 
            this.imageListLevelElements.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLevelElements.ImageStream")));
            this.imageListLevelElements.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLevelElements.Images.SetKeyName(0, "Quad");
            this.imageListLevelElements.Images.SetKeyName(1, "Triangle 1");
            this.imageListLevelElements.Images.SetKeyName(2, "Triangle 2");
            this.imageListLevelElements.Images.SetKeyName(3, "Triangle 3");
            this.imageListLevelElements.Images.SetKeyName(4, "Triangle 4");
            this.imageListLevelElements.Images.SetKeyName(5, "Checkpoint");
            this.imageListLevelElements.Images.SetKeyName(6, "Stamper");
            this.imageListLevelElements.Images.SetKeyName(7, "Switch");
            this.imageListLevelElements.Images.SetKeyName(8, "Door");
            this.imageListLevelElements.Images.SetKeyName(9, "Treadmill Left");
            this.imageListLevelElements.Images.SetKeyName(10, "Treadmill Right");
            this.imageListLevelElements.Images.SetKeyName(11, "Scale");
            // 
            // objectListViewElements
            // 
            this.objectListViewElements.AllColumns.Add(this.elementsColumnType);
            this.objectListViewElements.AllColumns.Add(this.elementsColumnBreakable);
            this.objectListViewElements.AllColumns.Add(this.elementsColumnLethal);
            this.objectListViewElements.AllColumns.Add(this.elementsColumnHeavy);
            this.objectListViewElements.AllColumns.Add(this.elementsColumnSlippery);
            this.objectListViewElements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListViewElements.BackColor = System.Drawing.SystemColors.Window;
            this.objectListViewElements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.elementsColumnType,
            this.elementsColumnBreakable,
            this.elementsColumnLethal,
            this.elementsColumnHeavy,
            this.elementsColumnSlippery});
            this.objectListViewElements.FullRowSelect = true;
            this.objectListViewElements.HeaderUsesThemes = false;
            this.objectListViewElements.HeaderWordWrap = true;
            this.objectListViewElements.HideSelection = false;
            this.objectListViewElements.LargeImageList = this.imageListLevelElements;
            this.objectListViewElements.Location = new System.Drawing.Point(6, 6);
            this.objectListViewElements.MultiSelect = false;
            this.objectListViewElements.Name = "objectListViewElements";
            this.objectListViewElements.OwnerDraw = true;
            this.objectListViewElements.ShowGroups = false;
            this.objectListViewElements.ShowImagesOnSubItems = true;
            this.objectListViewElements.Size = new System.Drawing.Size(267, 118);
            this.objectListViewElements.SmallImageList = this.imageListLevelElements;
            this.objectListViewElements.TabIndex = 6;
            this.objectListViewElements.UseCompatibleStateImageBehavior = false;
            this.objectListViewElements.UseSubItemCheckBoxes = true;
            this.objectListViewElements.View = System.Windows.Forms.View.Details;
            this.objectListViewElements.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.objectListViewElements_SubItemChecking);
            // 
            // elementsColumnType
            // 
            this.elementsColumnType.AspectName = "Type";
            this.elementsColumnType.Text = "Type";
            this.elementsColumnType.Width = 158;
            // 
            // elementsColumnBreakable
            // 
            this.elementsColumnBreakable.AspectName = "Breakable";
            this.elementsColumnBreakable.CheckBoxes = true;
            this.elementsColumnBreakable.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.elementsColumnBreakable.MaximumWidth = 22;
            this.elementsColumnBreakable.MinimumWidth = 22;
            this.elementsColumnBreakable.Text = "B";
            this.elementsColumnBreakable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.elementsColumnBreakable.ToolTipText = "Breakable?";
            this.elementsColumnBreakable.Width = 22;
            // 
            // elementsColumnLethal
            // 
            this.elementsColumnLethal.AspectName = "Lethal";
            this.elementsColumnLethal.CheckBoxes = true;
            this.elementsColumnLethal.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.elementsColumnLethal.MaximumWidth = 22;
            this.elementsColumnLethal.MinimumWidth = 22;
            this.elementsColumnLethal.Text = "L";
            this.elementsColumnLethal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.elementsColumnLethal.ToolTipText = "Lethal?";
            this.elementsColumnLethal.Width = 22;
            // 
            // elementsColumnHeavy
            // 
            this.elementsColumnHeavy.AspectName = "Heavy";
            this.elementsColumnHeavy.AspectToStringFormat = " ";
            this.elementsColumnHeavy.CheckBoxes = true;
            this.elementsColumnHeavy.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.elementsColumnHeavy.MaximumWidth = 22;
            this.elementsColumnHeavy.MinimumWidth = 22;
            this.elementsColumnHeavy.Text = "H";
            this.elementsColumnHeavy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.elementsColumnHeavy.ToolTipText = "Heavy?";
            this.elementsColumnHeavy.Width = 22;
            // 
            // elementsColumnSlippery
            // 
            this.elementsColumnSlippery.AspectName = "Slippery";
            this.elementsColumnSlippery.CheckBoxes = true;
            this.elementsColumnSlippery.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.elementsColumnSlippery.MaximumWidth = 22;
            this.elementsColumnSlippery.MinimumWidth = 22;
            this.elementsColumnSlippery.Text = "S";
            this.elementsColumnSlippery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.elementsColumnSlippery.ToolTipText = "Slippery?";
            this.elementsColumnSlippery.Width = 22;
            // 
            // comboBoxForms
            // 
            this.comboBoxForms.FormattingEnabled = true;
            this.comboBoxForms.Location = new System.Drawing.Point(26, 19);
            this.comboBoxForms.Name = "comboBoxForms";
            this.comboBoxForms.Size = new System.Drawing.Size(97, 21);
            this.comboBoxForms.TabIndex = 7;
            this.comboBoxForms.SelectedIndexChanged += new System.EventHandler(this.comboBoxForms_SelectedIndexChanged);
            this.comboBoxForms.TextUpdate += new System.EventHandler(this.comboBoxForms_TextUpdate);
            // 
            // groupBoxCurrentForm
            // 
            this.groupBoxCurrentForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCurrentForm.Controls.Add(this.objectListViewSpecialSlices);
            this.groupBoxCurrentForm.Controls.Add(this.buttonRemoveForm);
            this.groupBoxCurrentForm.Controls.Add(this.buttonAddForm);
            this.groupBoxCurrentForm.Controls.Add(this.objectListViewSlices);
            this.groupBoxCurrentForm.Controls.Add(this.label5);
            this.groupBoxCurrentForm.Controls.Add(this.label2);
            this.groupBoxCurrentForm.Controls.Add(this.numericUpDownRotation);
            this.groupBoxCurrentForm.Controls.Add(this.comboBoxForms);
            this.groupBoxCurrentForm.Location = new System.Drawing.Point(6, 130);
            this.groupBoxCurrentForm.Name = "groupBoxCurrentForm";
            this.groupBoxCurrentForm.Size = new System.Drawing.Size(267, 310);
            this.groupBoxCurrentForm.TabIndex = 8;
            this.groupBoxCurrentForm.TabStop = false;
            this.groupBoxCurrentForm.Text = "Current Form";
            // 
            // objectListViewSpecialSlices
            // 
            this.objectListViewSpecialSlices.AllColumns.Add(this.specialSlicesColumnID);
            this.objectListViewSpecialSlices.AllColumns.Add(this.specialSlicesColumnWidth);
            this.objectListViewSpecialSlices.AllColumns.Add(this.specialSlicesColumnHeight);
            this.objectListViewSpecialSlices.AllColumns.Add(this.specialSlicesParameters);
            this.objectListViewSpecialSlices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListViewSpecialSlices.BackColor = System.Drawing.SystemColors.Window;
            this.objectListViewSpecialSlices.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.objectListViewSpecialSlices.CellEditEnterChangesRows = true;
            this.objectListViewSpecialSlices.CellEditTabChangesRows = true;
            this.objectListViewSpecialSlices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.specialSlicesColumnID,
            this.specialSlicesColumnWidth,
            this.specialSlicesColumnHeight,
            this.specialSlicesParameters});
            this.objectListViewSpecialSlices.FullRowSelect = true;
            this.objectListViewSpecialSlices.HeaderUsesThemes = false;
            this.objectListViewSpecialSlices.HeaderWordWrap = true;
            this.objectListViewSpecialSlices.HideSelection = false;
            this.objectListViewSpecialSlices.LargeImageList = this.imageListLevelElements;
            this.objectListViewSpecialSlices.Location = new System.Drawing.Point(9, 241);
            this.objectListViewSpecialSlices.Name = "objectListViewSpecialSlices";
            this.objectListViewSpecialSlices.OwnerDraw = true;
            this.objectListViewSpecialSlices.ShowGroups = false;
            this.objectListViewSpecialSlices.ShowImagesOnSubItems = true;
            this.objectListViewSpecialSlices.Size = new System.Drawing.Size(253, 63);
            this.objectListViewSpecialSlices.SmallImageList = this.imageListLevelElements;
            this.objectListViewSpecialSlices.TabIndex = 18;
            this.objectListViewSpecialSlices.UseCompatibleStateImageBehavior = false;
            this.objectListViewSpecialSlices.UseSubItemCheckBoxes = true;
            this.objectListViewSpecialSlices.View = System.Windows.Forms.View.Details;
            this.objectListViewSpecialSlices.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.objectListViewSpecialSlices_CellEditFinishing);
            // 
            // specialSlicesColumnID
            // 
            this.specialSlicesColumnID.AspectName = "ID";
            this.specialSlicesColumnID.Text = "ID";
            this.specialSlicesColumnID.Width = 80;
            // 
            // specialSlicesColumnWidth
            // 
            this.specialSlicesColumnWidth.AspectName = "Size.X";
            this.specialSlicesColumnWidth.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.specialSlicesColumnWidth.Text = "Width";
            this.specialSlicesColumnWidth.Width = 44;
            // 
            // specialSlicesColumnHeight
            // 
            this.specialSlicesColumnHeight.AspectName = "Size.Y";
            this.specialSlicesColumnHeight.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.specialSlicesColumnHeight.Text = "Height";
            this.specialSlicesColumnHeight.Width = 44;
            // 
            // specialSlicesParameters
            // 
            this.specialSlicesParameters.AspectName = "Parameters";
            this.specialSlicesParameters.Text = "Parameters";
            this.specialSlicesParameters.Width = 80;
            // 
            // buttonRemoveForm
            // 
            this.buttonRemoveForm.Enabled = false;
            this.buttonRemoveForm.Location = new System.Drawing.Point(145, 18);
            this.buttonRemoveForm.Name = "buttonRemoveForm";
            this.buttonRemoveForm.Size = new System.Drawing.Size(15, 23);
            this.buttonRemoveForm.TabIndex = 17;
            this.buttonRemoveForm.Text = "-";
            this.buttonRemoveForm.UseVisualStyleBackColor = true;
            this.buttonRemoveForm.Click += new System.EventHandler(this.buttonRemoveForm_Click);
            // 
            // buttonAddForm
            // 
            this.buttonAddForm.Location = new System.Drawing.Point(128, 18);
            this.buttonAddForm.Name = "buttonAddForm";
            this.buttonAddForm.Size = new System.Drawing.Size(15, 23);
            this.buttonAddForm.TabIndex = 16;
            this.buttonAddForm.Text = "+";
            this.buttonAddForm.UseVisualStyleBackColor = true;
            this.buttonAddForm.Click += new System.EventHandler(this.buttonAddForm_Click);
            // 
            // objectListViewSlices
            // 
            this.objectListViewSlices.AllColumns.Add(this.slicesColumnID);
            this.objectListViewSlices.AllColumns.Add(this.slicesColumnBreakable);
            this.objectListViewSlices.AllColumns.Add(this.slicesColumnLethal);
            this.objectListViewSlices.AllColumns.Add(this.slicesColumnHeavy);
            this.objectListViewSlices.AllColumns.Add(this.slicesColumnSlippery);
            this.objectListViewSlices.BackColor = System.Drawing.SystemColors.Window;
            this.objectListViewSlices.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.objectListViewSlices.CellEditEnterChangesRows = true;
            this.objectListViewSlices.CellEditTabChangesRows = true;
            this.objectListViewSlices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.slicesColumnID,
            this.slicesColumnBreakable,
            this.slicesColumnLethal,
            this.slicesColumnHeavy,
            this.slicesColumnSlippery});
            this.objectListViewSlices.FullRowSelect = true;
            this.objectListViewSlices.HeaderUsesThemes = false;
            this.objectListViewSlices.HeaderWordWrap = true;
            this.objectListViewSlices.HideSelection = false;
            this.objectListViewSlices.LargeImageList = this.imageListLevelElements;
            this.objectListViewSlices.Location = new System.Drawing.Point(9, 46);
            this.objectListViewSlices.Name = "objectListViewSlices";
            this.objectListViewSlices.OwnerDraw = true;
            this.objectListViewSlices.ShowGroups = false;
            this.objectListViewSlices.ShowImagesOnSubItems = true;
            this.objectListViewSlices.Size = new System.Drawing.Size(253, 189);
            this.objectListViewSlices.SmallImageList = this.imageListLevelElements;
            this.objectListViewSlices.TabIndex = 9;
            this.objectListViewSlices.UseCompatibleStateImageBehavior = false;
            this.objectListViewSlices.UseSubItemCheckBoxes = true;
            this.objectListViewSlices.View = System.Windows.Forms.View.Details;
            this.objectListViewSlices.SubItemChecking += new System.EventHandler<BrightIdeasSoftware.SubItemCheckingEventArgs>(this.objectListViewSlices_SubItemChecking);
            this.objectListViewSlices.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.objectListViewSlices_ItemsChanged);
            this.objectListViewSlices.SelectedIndexChanged += new System.EventHandler(this.objectListViewSlices_SelectedIndexChanged);
            // 
            // slicesColumnID
            // 
            this.slicesColumnID.AspectName = "ID";
            this.slicesColumnID.Text = "ID";
            this.slicesColumnID.Width = 138;
            // 
            // slicesColumnBreakable
            // 
            this.slicesColumnBreakable.AspectName = "Breakable";
            this.slicesColumnBreakable.CheckBoxes = true;
            this.slicesColumnBreakable.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slicesColumnBreakable.MaximumWidth = 22;
            this.slicesColumnBreakable.MinimumWidth = 22;
            this.slicesColumnBreakable.Text = "B";
            this.slicesColumnBreakable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slicesColumnBreakable.ToolTipText = "Breakable?";
            this.slicesColumnBreakable.Width = 22;
            // 
            // slicesColumnLethal
            // 
            this.slicesColumnLethal.AspectName = "Lethal";
            this.slicesColumnLethal.CheckBoxes = true;
            this.slicesColumnLethal.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slicesColumnLethal.MaximumWidth = 22;
            this.slicesColumnLethal.MinimumWidth = 22;
            this.slicesColumnLethal.Text = "L";
            this.slicesColumnLethal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slicesColumnLethal.ToolTipText = "Lethal?";
            this.slicesColumnLethal.Width = 22;
            // 
            // slicesColumnHeavy
            // 
            this.slicesColumnHeavy.AspectName = "Heavy";
            this.slicesColumnHeavy.AspectToStringFormat = " ";
            this.slicesColumnHeavy.CheckBoxes = true;
            this.slicesColumnHeavy.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slicesColumnHeavy.MaximumWidth = 22;
            this.slicesColumnHeavy.MinimumWidth = 22;
            this.slicesColumnHeavy.Text = "H";
            this.slicesColumnHeavy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slicesColumnHeavy.ToolTipText = "Heavy?";
            this.slicesColumnHeavy.Width = 22;
            // 
            // slicesColumnSlippery
            // 
            this.slicesColumnSlippery.AspectName = "Slippery";
            this.slicesColumnSlippery.CheckBoxes = true;
            this.slicesColumnSlippery.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slicesColumnSlippery.MaximumWidth = 22;
            this.slicesColumnSlippery.MinimumWidth = 22;
            this.slicesColumnSlippery.Text = "S";
            this.slicesColumnSlippery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.slicesColumnSlippery.ToolTipText = "Slippery?";
            this.slicesColumnSlippery.Width = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Rotation";
            // 
            // numericUpDownRotation
            // 
            this.numericUpDownRotation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRotation.Location = new System.Drawing.Point(214, 20);
            this.numericUpDownRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRotation.Name = "numericUpDownRotation";
            this.numericUpDownRotation.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownRotation.TabIndex = 8;
            this.numericUpDownRotation.ValueChanged += new System.EventHandler(this.numericUpDownRotation_ValueChanged);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(846, 24);
            this.menuStripMain.TabIndex = 9;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.optimizeToolStripMenuItem,
            this.shiftToolStripMenuItem});
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.levelToolStripMenuItem.Text = "Level";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // optimizeToolStripMenuItem
            // 
            this.optimizeToolStripMenuItem.Name = "optimizeToolStripMenuItem";
            this.optimizeToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.optimizeToolStripMenuItem.Text = "Optimize...";
            this.optimizeToolStripMenuItem.Click += new System.EventHandler(this.optimizeToolStripMenuItem_Click);
            // 
            // shiftToolStripMenuItem
            // 
            this.shiftToolStripMenuItem.Name = "shiftToolStripMenuItem";
            this.shiftToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.shiftToolStripMenuItem.Text = "Shift...";
            this.shiftToolStripMenuItem.Click += new System.EventHandler(this.shiftToolStripMenuItem_Click);
            // 
            // saveFileDialogLevel
            // 
            this.saveFileDialogLevel.Filter = "JSON|*.json";
            // 
            // openFileDialogLevel
            // 
            this.openFileDialogLevel.Filter = "JSON|*.json";
            // 
            // tabControlCreation
            // 
            this.tabControlCreation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlCreation.Controls.Add(this.tabPageForms);
            this.tabControlCreation.Controls.Add(this.tabPageTriggerZones);
            this.tabControlCreation.Controls.Add(this.tabPageMetadata);
            this.tabControlCreation.Location = new System.Drawing.Point(553, 120);
            this.tabControlCreation.Name = "tabControlCreation";
            this.tabControlCreation.SelectedIndex = 0;
            this.tabControlCreation.Size = new System.Drawing.Size(287, 471);
            this.tabControlCreation.TabIndex = 10;
            this.tabControlCreation.SelectedIndexChanged += new System.EventHandler(this.tabControlCreation_SelectedIndexChanged);
            // 
            // tabPageForms
            // 
            this.tabPageForms.Controls.Add(this.groupBoxCurrentForm);
            this.tabPageForms.Controls.Add(this.objectListViewElements);
            this.tabPageForms.Location = new System.Drawing.Point(4, 22);
            this.tabPageForms.Name = "tabPageForms";
            this.tabPageForms.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageForms.Size = new System.Drawing.Size(279, 445);
            this.tabPageForms.TabIndex = 0;
            this.tabPageForms.Text = "Forms / Slices";
            this.tabPageForms.UseVisualStyleBackColor = true;
            // 
            // tabPageTriggerZones
            // 
            this.tabPageTriggerZones.Controls.Add(this.groupBoxActions);
            this.tabPageTriggerZones.Controls.Add(this.objectListViewTriggerZones);
            this.tabPageTriggerZones.Location = new System.Drawing.Point(4, 22);
            this.tabPageTriggerZones.Name = "tabPageTriggerZones";
            this.tabPageTriggerZones.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTriggerZones.Size = new System.Drawing.Size(279, 445);
            this.tabPageTriggerZones.TabIndex = 1;
            this.tabPageTriggerZones.Text = "Trigger Zones";
            this.tabPageTriggerZones.UseVisualStyleBackColor = true;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxActions.Controls.Add(this.buttonRemoveAction);
            this.groupBoxActions.Controls.Add(this.buttonAddAction);
            this.groupBoxActions.Controls.Add(this.comboBoxActions);
            this.groupBoxActions.Controls.Add(this.objectListViewActions);
            this.groupBoxActions.Enabled = false;
            this.groupBoxActions.Location = new System.Drawing.Point(5, 253);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(263, 186);
            this.groupBoxActions.TabIndex = 14;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            this.toolTipEditor.SetToolTip(this.groupBoxActions, "LALALALALLAAL");
            // 
            // buttonRemoveAction
            // 
            this.buttonRemoveAction.Enabled = false;
            this.buttonRemoveAction.Location = new System.Drawing.Point(242, 18);
            this.buttonRemoveAction.Name = "buttonRemoveAction";
            this.buttonRemoveAction.Size = new System.Drawing.Size(15, 23);
            this.buttonRemoveAction.TabIndex = 18;
            this.buttonRemoveAction.Text = "-";
            this.buttonRemoveAction.UseVisualStyleBackColor = true;
            this.buttonRemoveAction.Click += new System.EventHandler(this.buttonRemoveAction_Click);
            // 
            // buttonAddAction
            // 
            this.buttonAddAction.Location = new System.Drawing.Point(225, 18);
            this.buttonAddAction.Name = "buttonAddAction";
            this.buttonAddAction.Size = new System.Drawing.Size(15, 23);
            this.buttonAddAction.TabIndex = 17;
            this.buttonAddAction.Text = "+";
            this.buttonAddAction.UseVisualStyleBackColor = true;
            this.buttonAddAction.Click += new System.EventHandler(this.buttonAddAction_Click);
            // 
            // comboBoxActions
            // 
            this.comboBoxActions.DisplayMember = "Name";
            this.comboBoxActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxActions.FormattingEnabled = true;
            this.comboBoxActions.Location = new System.Drawing.Point(6, 19);
            this.comboBoxActions.Name = "comboBoxActions";
            this.comboBoxActions.Size = new System.Drawing.Size(213, 21);
            this.comboBoxActions.TabIndex = 13;
            // 
            // objectListViewActions
            // 
            this.objectListViewActions.AllColumns.Add(this.olvColumnActionName);
            this.objectListViewActions.AllColumns.Add(this.olvColumnActionExecuteOnEnter);
            this.objectListViewActions.AllColumns.Add(this.olvColumnActionExecuteOnExit);
            this.objectListViewActions.AllColumns.Add(this.olvColumnActionExecuteOnKey);
            this.objectListViewActions.AllColumns.Add(this.olvColumnActionParameters);
            this.objectListViewActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListViewActions.BackColor = System.Drawing.SystemColors.Window;
            this.objectListViewActions.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.objectListViewActions.CellEditEnterChangesRows = true;
            this.objectListViewActions.CellEditTabChangesRows = true;
            this.objectListViewActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnActionName,
            this.olvColumnActionExecuteOnEnter,
            this.olvColumnActionExecuteOnExit,
            this.olvColumnActionExecuteOnKey,
            this.olvColumnActionParameters});
            this.objectListViewActions.FullRowSelect = true;
            this.objectListViewActions.HeaderUsesThemes = false;
            this.objectListViewActions.HeaderWordWrap = true;
            this.objectListViewActions.HideSelection = false;
            this.objectListViewActions.Location = new System.Drawing.Point(6, 46);
            this.objectListViewActions.MultiSelect = false;
            this.objectListViewActions.Name = "objectListViewActions";
            this.objectListViewActions.OwnerDraw = true;
            this.objectListViewActions.ShowGroups = false;
            this.objectListViewActions.ShowImagesOnSubItems = true;
            this.objectListViewActions.Size = new System.Drawing.Size(251, 134);
            this.objectListViewActions.TabIndex = 12;
            this.objectListViewActions.UseCompatibleStateImageBehavior = false;
            this.objectListViewActions.UseSubItemCheckBoxes = true;
            this.objectListViewActions.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnActionName
            // 
            this.olvColumnActionName.AspectName = "ActionValue.Name";
            this.olvColumnActionName.IsEditable = false;
            this.olvColumnActionName.Text = "Name";
            this.olvColumnActionName.Width = 40;
            // 
            // olvColumnActionExecuteOnEnter
            // 
            this.olvColumnActionExecuteOnEnter.AspectName = "ExecuteOnEnter";
            this.olvColumnActionExecuteOnEnter.CheckBoxes = true;
            this.olvColumnActionExecuteOnEnter.MaximumWidth = 22;
            this.olvColumnActionExecuteOnEnter.MinimumWidth = 22;
            this.olvColumnActionExecuteOnEnter.Text = "E";
            this.olvColumnActionExecuteOnEnter.ToolTipText = "Execute On Enter?";
            this.olvColumnActionExecuteOnEnter.Width = 22;
            // 
            // olvColumnActionExecuteOnExit
            // 
            this.olvColumnActionExecuteOnExit.AspectName = "ExecuteOnExit";
            this.olvColumnActionExecuteOnExit.CheckBoxes = true;
            this.olvColumnActionExecuteOnExit.MaximumWidth = 22;
            this.olvColumnActionExecuteOnExit.MinimumWidth = 22;
            this.olvColumnActionExecuteOnExit.Text = "X";
            this.olvColumnActionExecuteOnExit.ToolTipText = "Execute on Exit?";
            this.olvColumnActionExecuteOnExit.Width = 22;
            // 
            // olvColumnActionExecuteOnKey
            // 
            this.olvColumnActionExecuteOnKey.AspectName = "ExecuteOnKey";
            this.olvColumnActionExecuteOnKey.CheckBoxes = true;
            this.olvColumnActionExecuteOnKey.MaximumWidth = 22;
            this.olvColumnActionExecuteOnKey.MinimumWidth = 22;
            this.olvColumnActionExecuteOnKey.Text = "K";
            this.olvColumnActionExecuteOnKey.ToolTipText = "Execute on Key?";
            this.olvColumnActionExecuteOnKey.Width = 22;
            // 
            // olvColumnActionParameters
            // 
            this.olvColumnActionParameters.AspectName = "ActionValue.Parameters";
            this.olvColumnActionParameters.Text = "Parameters";
            this.olvColumnActionParameters.Width = 120;
            // 
            // objectListViewTriggerZones
            // 
            this.objectListViewTriggerZones.AllColumns.Add(this.triggerZoneColumnID);
            this.objectListViewTriggerZones.AllColumns.Add(this.triggerZoneTriggerByAll);
            this.objectListViewTriggerZones.AllColumns.Add(this.triggerZoneExecuteOnce);
            this.objectListViewTriggerZones.AllColumns.Add(this.triggerZoneExecuteParallel);
            this.objectListViewTriggerZones.AllColumns.Add(this.triggerZoneColumnWidth);
            this.objectListViewTriggerZones.AllColumns.Add(this.triggerZoneColumnHeight);
            this.objectListViewTriggerZones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListViewTriggerZones.BackColor = System.Drawing.SystemColors.Window;
            this.objectListViewTriggerZones.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.objectListViewTriggerZones.CellEditEnterChangesRows = true;
            this.objectListViewTriggerZones.CellEditTabChangesRows = true;
            this.objectListViewTriggerZones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.triggerZoneColumnID,
            this.triggerZoneTriggerByAll,
            this.triggerZoneExecuteOnce,
            this.triggerZoneExecuteParallel,
            this.triggerZoneColumnWidth,
            this.triggerZoneColumnHeight});
            this.objectListViewTriggerZones.FullRowSelect = true;
            this.objectListViewTriggerZones.HeaderUsesThemes = false;
            this.objectListViewTriggerZones.HeaderWordWrap = true;
            this.objectListViewTriggerZones.HideSelection = false;
            this.objectListViewTriggerZones.Location = new System.Drawing.Point(6, 6);
            this.objectListViewTriggerZones.Name = "objectListViewTriggerZones";
            this.objectListViewTriggerZones.OwnerDraw = true;
            this.objectListViewTriggerZones.ShowGroups = false;
            this.objectListViewTriggerZones.ShowImagesOnSubItems = true;
            this.objectListViewTriggerZones.Size = new System.Drawing.Size(262, 241);
            this.objectListViewTriggerZones.TabIndex = 11;
            this.objectListViewTriggerZones.UseCompatibleStateImageBehavior = false;
            this.objectListViewTriggerZones.UseSubItemCheckBoxes = true;
            this.objectListViewTriggerZones.View = System.Windows.Forms.View.Details;
            this.objectListViewTriggerZones.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.objectListViewTriggerZones_CellEditFinishing);
            this.objectListViewTriggerZones.SelectedIndexChanged += new System.EventHandler(this.objectListViewTriggerZones_SelectedIndexChanged);
            // 
            // triggerZoneColumnID
            // 
            this.triggerZoneColumnID.AspectName = "ID";
            this.triggerZoneColumnID.Text = "Trigger Zones";
            this.triggerZoneColumnID.Width = 82;
            // 
            // triggerZoneTriggerByAll
            // 
            this.triggerZoneTriggerByAll.AspectName = "TriggerByAll";
            this.triggerZoneTriggerByAll.CheckBoxes = true;
            this.triggerZoneTriggerByAll.MaximumWidth = 22;
            this.triggerZoneTriggerByAll.MinimumWidth = 22;
            this.triggerZoneTriggerByAll.Text = "A";
            this.triggerZoneTriggerByAll.ToolTipText = "Trigger By All?";
            this.triggerZoneTriggerByAll.Width = 22;
            // 
            // triggerZoneExecuteOnce
            // 
            this.triggerZoneExecuteOnce.AspectName = "ExecuteOnce";
            this.triggerZoneExecuteOnce.CheckBoxes = true;
            this.triggerZoneExecuteOnce.MaximumWidth = 22;
            this.triggerZoneExecuteOnce.MinimumWidth = 22;
            this.triggerZoneExecuteOnce.Text = "O";
            this.triggerZoneExecuteOnce.ToolTipText = "Execute Once?";
            this.triggerZoneExecuteOnce.Width = 22;
            // 
            // triggerZoneExecuteParallel
            // 
            this.triggerZoneExecuteParallel.AspectName = "ExecuteParallel";
            this.triggerZoneExecuteParallel.CheckBoxes = true;
            this.triggerZoneExecuteParallel.MaximumWidth = 22;
            this.triggerZoneExecuteParallel.MinimumWidth = 22;
            this.triggerZoneExecuteParallel.Text = "P";
            this.triggerZoneExecuteParallel.ToolTipText = "Execute Parallel?";
            this.triggerZoneExecuteParallel.Width = 22;
            // 
            // triggerZoneColumnWidth
            // 
            this.triggerZoneColumnWidth.AspectName = "Size.X";
            this.triggerZoneColumnWidth.Text = "Width";
            // 
            // triggerZoneColumnHeight
            // 
            this.triggerZoneColumnHeight.AspectName = "Size.Y";
            this.triggerZoneColumnHeight.Text = "Height";
            // 
            // tabPageMetadata
            // 
            this.tabPageMetadata.Controls.Add(this.groupBox2);
            this.tabPageMetadata.Controls.Add(this.groupBoxBackground);
            this.tabPageMetadata.Controls.Add(this.objectListViewMetadataObjects);
            this.tabPageMetadata.Location = new System.Drawing.Point(4, 22);
            this.tabPageMetadata.Name = "tabPageMetadata";
            this.tabPageMetadata.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMetadata.Size = new System.Drawing.Size(279, 445);
            this.tabPageMetadata.TabIndex = 2;
            this.tabPageMetadata.Text = "Metadata";
            this.tabPageMetadata.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxPointLightShadows);
            this.groupBox2.Controls.Add(this.numericUpDownPointLightAttenuation);
            this.groupBox2.Controls.Add(this.numericUpDownPointLightIntensity);
            this.groupBox2.Controls.Add(this.panelPointLightColor);
            this.groupBox2.Controls.Add(this.numericUpDownPointLightRadius);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.numericUpDownPointLightResolution);
            this.groupBox2.Controls.Add(this.buttonAddEditPointLight);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.textBoxPointLightPosition);
            this.groupBox2.Location = new System.Drawing.Point(8, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 128);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Point Light";
            // 
            // checkBoxPointLightShadows
            // 
            this.checkBoxPointLightShadows.AutoSize = true;
            this.checkBoxPointLightShadows.Location = new System.Drawing.Point(180, 73);
            this.checkBoxPointLightShadows.Name = "checkBoxPointLightShadows";
            this.checkBoxPointLightShadows.Size = new System.Drawing.Size(70, 17);
            this.checkBoxPointLightShadows.TabIndex = 19;
            this.checkBoxPointLightShadows.Text = "Shadows";
            this.checkBoxPointLightShadows.UseVisualStyleBackColor = true;
            // 
            // numericUpDownPointLightAttenuation
            // 
            this.numericUpDownPointLightAttenuation.DecimalPlaces = 2;
            this.numericUpDownPointLightAttenuation.Location = new System.Drawing.Point(73, 70);
            this.numericUpDownPointLightAttenuation.Name = "numericUpDownPointLightAttenuation";
            this.numericUpDownPointLightAttenuation.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPointLightAttenuation.TabIndex = 18;
            this.numericUpDownPointLightAttenuation.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDownPointLightIntensity
            // 
            this.numericUpDownPointLightIntensity.DecimalPlaces = 2;
            this.numericUpDownPointLightIntensity.Location = new System.Drawing.Point(190, 45);
            this.numericUpDownPointLightIntensity.Name = "numericUpDownPointLightIntensity";
            this.numericUpDownPointLightIntensity.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPointLightIntensity.TabIndex = 17;
            this.numericUpDownPointLightIntensity.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // panelPointLightColor
            // 
            this.panelPointLightColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPointLightColor.Location = new System.Drawing.Point(73, 44);
            this.panelPointLightColor.Name = "panelPointLightColor";
            this.panelPointLightColor.Size = new System.Drawing.Size(63, 20);
            this.panelPointLightColor.TabIndex = 16;
            this.panelPointLightColor.Click += new System.EventHandler(this.panelPointLightColor_Click);
            // 
            // numericUpDownPointLightRadius
            // 
            this.numericUpDownPointLightRadius.DecimalPlaces = 2;
            this.numericUpDownPointLightRadius.Location = new System.Drawing.Point(190, 20);
            this.numericUpDownPointLightRadius.Name = "numericUpDownPointLightRadius";
            this.numericUpDownPointLightRadius.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPointLightRadius.TabIndex = 15;
            this.numericUpDownPointLightRadius.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Resolution:";
            // 
            // numericUpDownPointLightResolution
            // 
            this.numericUpDownPointLightResolution.Location = new System.Drawing.Point(73, 96);
            this.numericUpDownPointLightResolution.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericUpDownPointLightResolution.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownPointLightResolution.Name = "numericUpDownPointLightResolution";
            this.numericUpDownPointLightResolution.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownPointLightResolution.TabIndex = 13;
            this.numericUpDownPointLightResolution.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // buttonAddEditPointLight
            // 
            this.buttonAddEditPointLight.Location = new System.Drawing.Point(206, 97);
            this.buttonAddEditPointLight.Name = "buttonAddEditPointLight";
            this.buttonAddEditPointLight.Size = new System.Drawing.Size(48, 23);
            this.buttonAddEditPointLight.TabIndex = 12;
            this.buttonAddEditPointLight.Text = "Add";
            this.buttonAddEditPointLight.UseVisualStyleBackColor = true;
            this.buttonAddEditPointLight.Click += new System.EventHandler(this.buttonAddPointLight_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Attenuation:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(139, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Intensity:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(34, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Color:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(144, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Radius:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Position:";
            // 
            // textBoxPointLightPosition
            // 
            this.textBoxPointLightPosition.Location = new System.Drawing.Point(73, 18);
            this.textBoxPointLightPosition.Name = "textBoxPointLightPosition";
            this.textBoxPointLightPosition.Size = new System.Drawing.Size(63, 20);
            this.textBoxPointLightPosition.TabIndex = 2;
            this.textBoxPointLightPosition.Text = "[0,0,0]";
            // 
            // groupBoxBackground
            // 
            this.groupBoxBackground.Controls.Add(this.label11);
            this.groupBoxBackground.Controls.Add(this.numericUpDownBackgroundAnimationDelay);
            this.groupBoxBackground.Controls.Add(this.buttonAddEditBackground);
            this.groupBoxBackground.Controls.Add(this.label10);
            this.groupBoxBackground.Controls.Add(this.label9);
            this.groupBoxBackground.Controls.Add(this.label8);
            this.groupBoxBackground.Controls.Add(this.label7);
            this.groupBoxBackground.Controls.Add(this.label6);
            this.groupBoxBackground.Controls.Add(this.textBoxBackgroundRepeatGap);
            this.groupBoxBackground.Controls.Add(this.textBoxBackgroundRepeat);
            this.groupBoxBackground.Controls.Add(this.textBoxBackgroundScale);
            this.groupBoxBackground.Controls.Add(this.textBoxBackgroundRotation);
            this.groupBoxBackground.Controls.Add(this.textBoxBackgroundPosition);
            this.groupBoxBackground.Controls.Add(this.label4);
            this.groupBoxBackground.Controls.Add(this.comboBoxBackgroundNames);
            this.groupBoxBackground.Location = new System.Drawing.Point(8, 6);
            this.groupBoxBackground.Name = "groupBoxBackground";
            this.groupBoxBackground.Size = new System.Drawing.Size(260, 128);
            this.groupBoxBackground.TabIndex = 12;
            this.groupBoxBackground.TabStop = false;
            this.groupBoxBackground.Text = "Background";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(150, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Delay:";
            // 
            // numericUpDownBackgroundAnimationDelay
            // 
            this.numericUpDownBackgroundAnimationDelay.Location = new System.Drawing.Point(190, 70);
            this.numericUpDownBackgroundAnimationDelay.Name = "numericUpDownBackgroundAnimationDelay";
            this.numericUpDownBackgroundAnimationDelay.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownBackgroundAnimationDelay.TabIndex = 13;
            // 
            // buttonAddEditBackground
            // 
            this.buttonAddEditBackground.Location = new System.Drawing.Point(206, 97);
            this.buttonAddEditBackground.Name = "buttonAddEditBackground";
            this.buttonAddEditBackground.Size = new System.Drawing.Size(48, 23);
            this.buttonAddEditBackground.TabIndex = 12;
            this.buttonAddEditBackground.Text = "Add";
            this.buttonAddEditBackground.UseVisualStyleBackColor = true;
            this.buttonAddEditBackground.Click += new System.EventHandler(this.buttonAddEditBackground_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Repeat Gap:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(143, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Repeat:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Scale:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(137, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Rotation:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Position:";
            // 
            // textBoxBackgroundRepeatGap
            // 
            this.textBoxBackgroundRepeatGap.Location = new System.Drawing.Point(73, 70);
            this.textBoxBackgroundRepeatGap.Name = "textBoxBackgroundRepeatGap";
            this.textBoxBackgroundRepeatGap.Size = new System.Drawing.Size(63, 20);
            this.textBoxBackgroundRepeatGap.TabIndex = 6;
            this.textBoxBackgroundRepeatGap.Text = "[0,0,0,0]";
            // 
            // textBoxBackgroundRepeat
            // 
            this.textBoxBackgroundRepeat.Location = new System.Drawing.Point(190, 44);
            this.textBoxBackgroundRepeat.Name = "textBoxBackgroundRepeat";
            this.textBoxBackgroundRepeat.Size = new System.Drawing.Size(63, 20);
            this.textBoxBackgroundRepeat.TabIndex = 5;
            this.textBoxBackgroundRepeat.Text = "[1,1]";
            // 
            // textBoxBackgroundScale
            // 
            this.textBoxBackgroundScale.Location = new System.Drawing.Point(73, 44);
            this.textBoxBackgroundScale.Name = "textBoxBackgroundScale";
            this.textBoxBackgroundScale.Size = new System.Drawing.Size(63, 20);
            this.textBoxBackgroundScale.TabIndex = 4;
            this.textBoxBackgroundScale.Text = "[1,1,1]";
            // 
            // textBoxBackgroundRotation
            // 
            this.textBoxBackgroundRotation.Location = new System.Drawing.Point(190, 18);
            this.textBoxBackgroundRotation.Name = "textBoxBackgroundRotation";
            this.textBoxBackgroundRotation.Size = new System.Drawing.Size(63, 20);
            this.textBoxBackgroundRotation.TabIndex = 3;
            this.textBoxBackgroundRotation.Text = "[0,180,180]";
            // 
            // textBoxBackgroundPosition
            // 
            this.textBoxBackgroundPosition.Location = new System.Drawing.Point(73, 18);
            this.textBoxBackgroundPosition.Name = "textBoxBackgroundPosition";
            this.textBoxBackgroundPosition.Size = new System.Drawing.Size(63, 20);
            this.textBoxBackgroundPosition.TabIndex = 2;
            this.textBoxBackgroundPosition.Text = "[0,0,10]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Asset:";
            // 
            // comboBoxBackgroundNames
            // 
            this.comboBoxBackgroundNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBackgroundNames.FormattingEnabled = true;
            this.comboBoxBackgroundNames.Location = new System.Drawing.Point(48, 98);
            this.comboBoxBackgroundNames.Name = "comboBoxBackgroundNames";
            this.comboBoxBackgroundNames.Size = new System.Drawing.Size(151, 21);
            this.comboBoxBackgroundNames.TabIndex = 0;
            // 
            // objectListViewMetadataObjects
            // 
            this.objectListViewMetadataObjects.AllColumns.Add(this.olvMetadataGameObjectID);
            this.objectListViewMetadataObjects.AllColumns.Add(this.olvColumnMetadataGameObjectType);
            this.objectListViewMetadataObjects.AllColumns.Add(this.olvColumnMetadataGameObjectParameters);
            this.objectListViewMetadataObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.objectListViewMetadataObjects.BackColor = System.Drawing.SystemColors.Window;
            this.objectListViewMetadataObjects.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.objectListViewMetadataObjects.CellEditEnterChangesRows = true;
            this.objectListViewMetadataObjects.CellEditTabChangesRows = true;
            this.objectListViewMetadataObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvMetadataGameObjectID,
            this.olvColumnMetadataGameObjectType,
            this.olvColumnMetadataGameObjectParameters});
            this.objectListViewMetadataObjects.FullRowSelect = true;
            this.objectListViewMetadataObjects.HeaderUsesThemes = false;
            this.objectListViewMetadataObjects.HeaderWordWrap = true;
            this.objectListViewMetadataObjects.HideSelection = false;
            this.objectListViewMetadataObjects.Location = new System.Drawing.Point(6, 278);
            this.objectListViewMetadataObjects.Name = "objectListViewMetadataObjects";
            this.objectListViewMetadataObjects.OwnerDraw = true;
            this.objectListViewMetadataObjects.ShowGroups = false;
            this.objectListViewMetadataObjects.ShowImagesOnSubItems = true;
            this.objectListViewMetadataObjects.Size = new System.Drawing.Size(262, 161);
            this.objectListViewMetadataObjects.TabIndex = 11;
            this.objectListViewMetadataObjects.UseCompatibleStateImageBehavior = false;
            this.objectListViewMetadataObjects.UseSubItemCheckBoxes = true;
            this.objectListViewMetadataObjects.View = System.Windows.Forms.View.Details;
            this.objectListViewMetadataObjects.SelectedIndexChanged += new System.EventHandler(this.objectListViewMetadataObjects_SelectedIndexChanged);
            // 
            // olvMetadataGameObjectID
            // 
            this.olvMetadataGameObjectID.AspectName = "ID";
            this.olvMetadataGameObjectID.Text = "ID";
            this.olvMetadataGameObjectID.Width = 80;
            this.olvMetadataGameObjectID.WordWrap = true;
            // 
            // olvColumnMetadataGameObjectType
            // 
            this.olvColumnMetadataGameObjectType.AspectName = "Type";
            this.olvColumnMetadataGameObjectType.IsEditable = false;
            this.olvColumnMetadataGameObjectType.Text = "Type";
            // 
            // olvColumnMetadataGameObjectParameters
            // 
            this.olvColumnMetadataGameObjectParameters.AspectName = "Parameters";
            this.olvColumnMetadataGameObjectParameters.Text = "Parameters";
            this.olvColumnMetadataGameObjectParameters.Width = 113;
            // 
            // checkBoxShowTagForms
            // 
            this.checkBoxShowTagForms.AutoSize = true;
            this.checkBoxShowTagForms.Checked = true;
            this.checkBoxShowTagForms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowTagForms.Location = new System.Drawing.Point(6, 16);
            this.checkBoxShowTagForms.Name = "checkBoxShowTagForms";
            this.checkBoxShowTagForms.Size = new System.Drawing.Size(54, 17);
            this.checkBoxShowTagForms.TabIndex = 8;
            this.checkBoxShowTagForms.Text = "Forms";
            this.checkBoxShowTagForms.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowTagSlices
            // 
            this.checkBoxShowTagSlices.AutoSize = true;
            this.checkBoxShowTagSlices.Checked = true;
            this.checkBoxShowTagSlices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowTagSlices.Location = new System.Drawing.Point(6, 32);
            this.checkBoxShowTagSlices.Name = "checkBoxShowTagSlices";
            this.checkBoxShowTagSlices.Size = new System.Drawing.Size(54, 17);
            this.checkBoxShowTagSlices.TabIndex = 10;
            this.checkBoxShowTagSlices.Text = "Slices";
            this.checkBoxShowTagSlices.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowTagMetadata
            // 
            this.checkBoxShowTagMetadata.AutoSize = true;
            this.checkBoxShowTagMetadata.Checked = true;
            this.checkBoxShowTagMetadata.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowTagMetadata.Location = new System.Drawing.Point(6, 49);
            this.checkBoxShowTagMetadata.Name = "checkBoxShowTagMetadata";
            this.checkBoxShowTagMetadata.Size = new System.Drawing.Size(71, 17);
            this.checkBoxShowTagMetadata.TabIndex = 11;
            this.checkBoxShowTagMetadata.Text = "Metadata";
            this.checkBoxShowTagMetadata.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowTagObjects
            // 
            this.checkBoxShowTagObjects.AutoSize = true;
            this.checkBoxShowTagObjects.Checked = true;
            this.checkBoxShowTagObjects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowTagObjects.Location = new System.Drawing.Point(6, 66);
            this.checkBoxShowTagObjects.Name = "checkBoxShowTagObjects";
            this.checkBoxShowTagObjects.Size = new System.Drawing.Size(62, 17);
            this.checkBoxShowTagObjects.TabIndex = 12;
            this.checkBoxShowTagObjects.Text = "Objects";
            this.checkBoxShowTagObjects.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBoxShowTagObjects);
            this.groupBox1.Controls.Add(this.checkBoxShowTagForms);
            this.groupBox1.Controls.Add(this.checkBoxShowTagMetadata);
            this.groupBox1.Controls.Add(this.checkBoxShowTagSlices);
            this.groupBox1.Location = new System.Drawing.Point(765, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(75, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Show IDs";
            // 
            // numericUpDownCurrentZValue
            // 
            this.numericUpDownCurrentZValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownCurrentZValue.Location = new System.Drawing.Point(771, 3);
            this.numericUpDownCurrentZValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownCurrentZValue.Name = "numericUpDownCurrentZValue";
            this.numericUpDownCurrentZValue.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownCurrentZValue.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(721, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Z Value";
            // 
            // checkBoxShowAll
            // 
            this.checkBoxShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowAll.AutoSize = true;
            this.checkBoxShowAll.Checked = true;
            this.checkBoxShowAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowAll.Location = new System.Drawing.Point(648, 5);
            this.checkBoxShowAll.Name = "checkBoxShowAll";
            this.checkBoxShowAll.Size = new System.Drawing.Size(67, 17);
            this.checkBoxShowAll.TabIndex = 12;
            this.checkBoxShowAll.Text = "Show All";
            this.checkBoxShowAll.UseVisualStyleBackColor = true;
            // 
            // checkBoxDrawBackground
            // 
            this.checkBoxDrawBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDrawBackground.AutoSize = true;
            this.checkBoxDrawBackground.Location = new System.Drawing.Point(529, 5);
            this.checkBoxDrawBackground.Name = "checkBoxDrawBackground";
            this.checkBoxDrawBackground.Size = new System.Drawing.Size(112, 17);
            this.checkBoxDrawBackground.TabIndex = 13;
            this.checkBoxDrawBackground.Text = "Draw Background";
            this.checkBoxDrawBackground.UseVisualStyleBackColor = true;
            // 
            // labelCurrentPosition
            // 
            this.labelCurrentPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentPosition.AutoSize = true;
            this.labelCurrentPosition.Location = new System.Drawing.Point(456, 6);
            this.labelCurrentPosition.Name = "labelCurrentPosition";
            this.labelCurrentPosition.Size = new System.Drawing.Size(48, 13);
            this.labelCurrentPosition.TabIndex = 14;
            this.labelCurrentPosition.Text = "X: 0 Y: 0";
            // 
            // colorDialogLight
            // 
            this.colorDialogLight.AnyColor = true;
            this.colorDialogLight.Color = System.Drawing.Color.White;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 603);
            this.Controls.Add(this.labelCurrentPosition);
            this.Controls.Add(this.checkBoxDrawBackground);
            this.Controls.Add(this.checkBoxShowAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownCurrentZValue);
            this.Controls.Add(this.groupBoxDimensions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControlCreation);
            this.Controls.Add(this.panelLevelScroll);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.Text = "Simetry Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelLevelScroll.ResumeLayout(false);
            this.groupBoxDimensions.ResumeLayout(false);
            this.groupBoxDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevelSizeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevelSizeWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGridSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewElements)).EndInit();
            this.groupBoxCurrentForm.ResumeLayout(false);
            this.groupBoxCurrentForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewSpecialSlices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewSlices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotation)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabControlCreation.ResumeLayout(false);
            this.tabPageForms.ResumeLayout(false);
            this.tabPageTriggerZones.ResumeLayout(false);
            this.groupBoxActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewTriggerZones)).EndInit();
            this.tabPageMetadata.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointLightAttenuation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointLightIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointLightRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPointLightResolution)).EndInit();
            this.groupBoxBackground.ResumeLayout(false);
            this.groupBoxBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBackgroundAnimationDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectListViewMetadataObjects)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCurrentZValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SimetryEditor.LevelDrawControl levelDrawControl;
        private System.Windows.Forms.Panel panelLevelScroll;
        private System.Windows.Forms.Label labelGridSize;
        private System.Windows.Forms.GroupBox groupBoxDimensions;
        private System.Windows.Forms.NumericUpDown numericUpDownLevelSizeHeight;
        private System.Windows.Forms.Label labelLevelSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarGridSize;
        private System.Windows.Forms.ImageList imageListLevelElements;
        private BrightIdeasSoftware.ObjectListView objectListViewElements;
        private BrightIdeasSoftware.OLVColumn elementsColumnType;
        private BrightIdeasSoftware.OLVColumn elementsColumnBreakable;
        private BrightIdeasSoftware.OLVColumn elementsColumnLethal;
        private BrightIdeasSoftware.OLVColumn elementsColumnHeavy;
        private System.Windows.Forms.ComboBox comboBoxForms;
        private System.Windows.Forms.GroupBox groupBoxCurrentForm;
        private System.Windows.Forms.NumericUpDown numericUpDownRotation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private BrightIdeasSoftware.ObjectListView objectListViewSlices;
        private BrightIdeasSoftware.OLVColumn slicesColumnID;
        private BrightIdeasSoftware.OLVColumn slicesColumnBreakable;
        private BrightIdeasSoftware.OLVColumn slicesColumnLethal;
        private BrightIdeasSoftware.OLVColumn slicesColumnHeavy;
        private System.Windows.Forms.Button buttonRemoveForm;
        private System.Windows.Forms.Button buttonAddForm;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogLevel;
        private System.Windows.Forms.OpenFileDialog openFileDialogLevel;
        private System.Windows.Forms.TabControl tabControlCreation;
        private System.Windows.Forms.TabPage tabPageForms;
        private System.Windows.Forms.TabPage tabPageTriggerZones;
        private System.Windows.Forms.NumericUpDown numericUpDownLevelSizeWidth;
        private System.Windows.Forms.CheckBox checkBoxShowTagForms;
        private System.Windows.Forms.CheckBox checkBoxShowTagSlices;
        private System.Windows.Forms.CheckBox checkBoxShowTagMetadata;
        private System.Windows.Forms.CheckBox checkBoxShowTagObjects;
        private System.Windows.Forms.GroupBox groupBox1;
        private BrightIdeasSoftware.ObjectListView objectListViewTriggerZones;
        private BrightIdeasSoftware.OLVColumn triggerZoneColumnID;
        private BrightIdeasSoftware.OLVColumn triggerZoneExecuteOnce;
        private BrightIdeasSoftware.OLVColumn triggerZoneExecuteParallel;
        private BrightIdeasSoftware.ObjectListView objectListViewActions;
        private BrightIdeasSoftware.OLVColumn olvColumnActionName;
        private BrightIdeasSoftware.OLVColumn olvColumnActionExecuteOnEnter;
        private BrightIdeasSoftware.OLVColumn olvColumnActionExecuteOnExit;
        private BrightIdeasSoftware.OLVColumn olvColumnActionExecuteOnKey;
        private System.Windows.Forms.ComboBox comboBoxActions;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button buttonAddAction;
        private BrightIdeasSoftware.OLVColumn olvColumnActionParameters;
        private System.Windows.Forms.Button buttonRemoveAction;
        private BrightIdeasSoftware.ObjectListView objectListViewSpecialSlices;
        private BrightIdeasSoftware.OLVColumn specialSlicesColumnID;
        private BrightIdeasSoftware.OLVColumn specialSlicesColumnWidth;
        private BrightIdeasSoftware.OLVColumn specialSlicesColumnHeight;
        private BrightIdeasSoftware.OLVColumn specialSlicesParameters;
        private BrightIdeasSoftware.OLVColumn triggerZoneColumnWidth;
        private BrightIdeasSoftware.OLVColumn triggerZoneColumnHeight;
        private BrightIdeasSoftware.OLVColumn triggerZoneTriggerByAll;
        private BrightIdeasSoftware.OLVColumn elementsColumnSlippery;
        private BrightIdeasSoftware.OLVColumn slicesColumnSlippery;
        private System.Windows.Forms.ToolStripMenuItem optimizeToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipEditor;
        private System.Windows.Forms.NumericUpDown numericUpDownCurrentZValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxShowAll;
        private System.Windows.Forms.TabPage tabPageMetadata;
        private BrightIdeasSoftware.ObjectListView objectListViewMetadataObjects;
        private BrightIdeasSoftware.OLVColumn olvMetadataGameObjectID;
        private System.Windows.Forms.GroupBox groupBoxBackground;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxBackgroundNames;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBackgroundRepeatGap;
        private System.Windows.Forms.TextBox textBoxBackgroundRepeat;
        private System.Windows.Forms.TextBox textBoxBackgroundScale;
        private System.Windows.Forms.TextBox textBoxBackgroundRotation;
        private System.Windows.Forms.TextBox textBoxBackgroundPosition;
        private System.Windows.Forms.Button buttonAddEditBackground;
        private BrightIdeasSoftware.OLVColumn olvColumnMetadataGameObjectType;
        private BrightIdeasSoftware.OLVColumn olvColumnMetadataGameObjectParameters;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownBackgroundAnimationDelay;
        private System.Windows.Forms.CheckBox checkBoxDrawBackground;
        private System.Windows.Forms.ToolStripMenuItem shiftToolStripMenuItem;
        private System.Windows.Forms.Label labelCurrentPosition;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelPointLightColor;
        private System.Windows.Forms.NumericUpDown numericUpDownPointLightRadius;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownPointLightResolution;
        private System.Windows.Forms.Button buttonAddEditPointLight;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxPointLightPosition;
        private System.Windows.Forms.ColorDialog colorDialogLight;
        private System.Windows.Forms.CheckBox checkBoxPointLightShadows;
        private System.Windows.Forms.NumericUpDown numericUpDownPointLightAttenuation;
        private System.Windows.Forms.NumericUpDown numericUpDownPointLightIntensity;
    }
}

