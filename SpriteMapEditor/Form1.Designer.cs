﻿namespace SpriteMapEditor
{
    partial class Form1
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
            this.spriteList = new System.Windows.Forms.ListBox();
            this.addSpriteButton = new System.Windows.Forms.Button();
            this.removeSpriteButton = new System.Windows.Forms.Button();
            this.spriteListPanel = new System.Windows.Forms.Panel();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.spritesLabel = new System.Windows.Forms.Label();
            this.spritePanel = new System.Windows.Forms.Panel();
            this.editingOriginCheckBox = new System.Windows.Forms.CheckBox();
            this.originYPosBox = new System.Windows.Forms.NumericUpDown();
            this.originXPosBox = new System.Windows.Forms.NumericUpDown();
            this.originYPosLabel = new System.Windows.Forms.Label();
            this.originXPosLabel = new System.Windows.Forms.Label();
            this.spriteHeightBox = new System.Windows.Forms.NumericUpDown();
            this.spriteWidthBox = new System.Windows.Forms.NumericUpDown();
            this.spriteYPosBox = new System.Windows.Forms.NumericUpDown();
            this.spriteXPosBox = new System.Windows.Forms.NumericUpDown();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.yPosLabel = new System.Windows.Forms.Label();
            this.xPosLabel = new System.Windows.Forms.Label();
            this.spriteNameLabel = new System.Windows.Forms.Label();
            this.spriteSettingsLabel = new System.Windows.Forms.Label();
            this.spriteNameBox = new System.Windows.Forms.TextBox();
            this.loadSpriteSheetDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.spriteViewerPanel = new System.Windows.Forms.Panel();
            this.zoomInButton = new System.Windows.Forms.Button();
            this.zoomOutButton = new System.Windows.Forms.Button();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSpriteSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSpriteMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveSpriteMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSpriteMapAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightCheckBox = new System.Windows.Forms.CheckBox();
            this.outlineTimer = new System.Windows.Forms.Timer(this.components);
            this.spriteSheetViewer = new SpriteMapEditor.PictureBoxWithInterpolationMode();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteListPanel.SuspendLayout();
            this.spritePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originYPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originXPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteHeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteYPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteXPosBox)).BeginInit();
            this.spriteViewerPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSheetViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // spriteList
            // 
            this.spriteList.AllowDrop = true;
            this.spriteList.FormattingEnabled = true;
            this.spriteList.Location = new System.Drawing.Point(3, 32);
            this.spriteList.Name = "spriteList";
            this.spriteList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.spriteList.Size = new System.Drawing.Size(183, 199);
            this.spriteList.TabIndex = 0;
            this.spriteList.SelectedValueChanged += new System.EventHandler(this.spriteList_SelectedValueChanged);
            // 
            // addSpriteButton
            // 
            this.addSpriteButton.Location = new System.Drawing.Point(126, 3);
            this.addSpriteButton.Name = "addSpriteButton";
            this.addSpriteButton.Size = new System.Drawing.Size(27, 23);
            this.addSpriteButton.TabIndex = 2;
            this.addSpriteButton.Text = "+";
            this.addSpriteButton.UseVisualStyleBackColor = true;
            this.addSpriteButton.Click += new System.EventHandler(this.addSpriteButton_Click);
            // 
            // removeSpriteButton
            // 
            this.removeSpriteButton.Location = new System.Drawing.Point(159, 3);
            this.removeSpriteButton.Name = "removeSpriteButton";
            this.removeSpriteButton.Size = new System.Drawing.Size(28, 23);
            this.removeSpriteButton.TabIndex = 3;
            this.removeSpriteButton.Text = "-";
            this.removeSpriteButton.UseVisualStyleBackColor = true;
            this.removeSpriteButton.Click += new System.EventHandler(this.removeSpriteButton_Click);
            // 
            // spriteListPanel
            // 
            this.spriteListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spriteListPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.spriteListPanel.Controls.Add(this.moveDownButton);
            this.spriteListPanel.Controls.Add(this.moveUpButton);
            this.spriteListPanel.Controls.Add(this.spritesLabel);
            this.spriteListPanel.Controls.Add(this.spriteList);
            this.spriteListPanel.Controls.Add(this.addSpriteButton);
            this.spriteListPanel.Controls.Add(this.removeSpriteButton);
            this.spriteListPanel.Location = new System.Drawing.Point(2, 27);
            this.spriteListPanel.Name = "spriteListPanel";
            this.spriteListPanel.Size = new System.Drawing.Size(190, 258);
            this.spriteListPanel.TabIndex = 8;
            // 
            // moveDownButton
            // 
            this.moveDownButton.Location = new System.Drawing.Point(39, 233);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(70, 18);
            this.moveDownButton.TabIndex = 5;
            this.moveDownButton.Text = "▼";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Location = new System.Drawing.Point(115, 233);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(71, 18);
            this.moveUpButton.TabIndex = 6;
            this.moveUpButton.Text = "▲";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // spritesLabel
            // 
            this.spritesLabel.AutoSize = true;
            this.spritesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spritesLabel.Location = new System.Drawing.Point(3, 8);
            this.spritesLabel.Name = "spritesLabel";
            this.spritesLabel.Size = new System.Drawing.Size(46, 13);
            this.spritesLabel.TabIndex = 4;
            this.spritesLabel.Text = "Sprites";
            // 
            // spritePanel
            // 
            this.spritePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spritePanel.Controls.Add(this.editingOriginCheckBox);
            this.spritePanel.Controls.Add(this.originYPosBox);
            this.spritePanel.Controls.Add(this.originXPosBox);
            this.spritePanel.Controls.Add(this.originYPosLabel);
            this.spritePanel.Controls.Add(this.originXPosLabel);
            this.spritePanel.Controls.Add(this.spriteHeightBox);
            this.spritePanel.Controls.Add(this.spriteWidthBox);
            this.spritePanel.Controls.Add(this.spriteYPosBox);
            this.spritePanel.Controls.Add(this.spriteXPosBox);
            this.spritePanel.Controls.Add(this.heightLabel);
            this.spritePanel.Controls.Add(this.widthLabel);
            this.spritePanel.Controls.Add(this.yPosLabel);
            this.spritePanel.Controls.Add(this.xPosLabel);
            this.spritePanel.Controls.Add(this.spriteNameLabel);
            this.spritePanel.Controls.Add(this.spriteSettingsLabel);
            this.spritePanel.Controls.Add(this.spriteNameBox);
            this.spritePanel.Location = new System.Drawing.Point(2, 291);
            this.spritePanel.Name = "spritePanel";
            this.spritePanel.Size = new System.Drawing.Size(190, 172);
            this.spritePanel.TabIndex = 9;
            // 
            // editingOriginCheckBox
            // 
            this.editingOriginCheckBox.AutoSize = true;
            this.editingOriginCheckBox.Location = new System.Drawing.Point(9, 108);
            this.editingOriginCheckBox.Name = "editingOriginCheckBox";
            this.editingOriginCheckBox.Size = new System.Drawing.Size(107, 17);
            this.editingOriginCheckBox.TabIndex = 23;
            this.editingOriginCheckBox.Text = "Edit Origin Point?";
            this.editingOriginCheckBox.UseVisualStyleBackColor = true;
            this.editingOriginCheckBox.CheckedChanged += new System.EventHandler(this.editingOriginCheckBox_CheckedChanged);
            // 
            // originYPosBox
            // 
            this.originYPosBox.Enabled = false;
            this.originYPosBox.Location = new System.Drawing.Point(143, 131);
            this.originYPosBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.originYPosBox.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.originYPosBox.Name = "originYPosBox";
            this.originYPosBox.Size = new System.Drawing.Size(45, 20);
            this.originYPosBox.TabIndex = 22;
            this.originYPosBox.ValueChanged += new System.EventHandler(this.originYPosBox_ValueChanged);
            // 
            // originXPosBox
            // 
            this.originXPosBox.Enabled = false;
            this.originXPosBox.Location = new System.Drawing.Point(51, 131);
            this.originXPosBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.originXPosBox.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.originXPosBox.Name = "originXPosBox";
            this.originXPosBox.Size = new System.Drawing.Size(45, 20);
            this.originXPosBox.TabIndex = 21;
            this.originXPosBox.ValueChanged += new System.EventHandler(this.originXPosBox_ValueChanged);
            // 
            // originYPosLabel
            // 
            this.originYPosLabel.AutoSize = true;
            this.originYPosLabel.Enabled = false;
            this.originYPosLabel.Location = new System.Drawing.Point(98, 134);
            this.originYPosLabel.Name = "originYPosLabel";
            this.originYPosLabel.Size = new System.Drawing.Size(44, 13);
            this.originYPosLabel.TabIndex = 20;
            this.originYPosLabel.Text = "Origin Y";
            // 
            // originXPosLabel
            // 
            this.originXPosLabel.AutoSize = true;
            this.originXPosLabel.Enabled = false;
            this.originXPosLabel.Location = new System.Drawing.Point(6, 134);
            this.originXPosLabel.Name = "originXPosLabel";
            this.originXPosLabel.Size = new System.Drawing.Size(44, 13);
            this.originXPosLabel.TabIndex = 19;
            this.originXPosLabel.Text = "Origin X";
            // 
            // spriteHeightBox
            // 
            this.spriteHeightBox.Location = new System.Drawing.Point(136, 82);
            this.spriteHeightBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spriteHeightBox.Name = "spriteHeightBox";
            this.spriteHeightBox.Size = new System.Drawing.Size(52, 20);
            this.spriteHeightBox.TabIndex = 18;
            this.spriteHeightBox.ValueChanged += new System.EventHandler(this.spriteHeightBox_ValueChanged);
            // 
            // spriteWidthBox
            // 
            this.spriteWidthBox.Location = new System.Drawing.Point(44, 82);
            this.spriteWidthBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spriteWidthBox.Name = "spriteWidthBox";
            this.spriteWidthBox.Size = new System.Drawing.Size(52, 20);
            this.spriteWidthBox.TabIndex = 17;
            this.spriteWidthBox.ValueChanged += new System.EventHandler(this.spriteWidthBox_ValueChanged);
            // 
            // spriteYPosBox
            // 
            this.spriteYPosBox.Location = new System.Drawing.Point(136, 56);
            this.spriteYPosBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spriteYPosBox.Name = "spriteYPosBox";
            this.spriteYPosBox.Size = new System.Drawing.Size(52, 20);
            this.spriteYPosBox.TabIndex = 16;
            this.spriteYPosBox.ValueChanged += new System.EventHandler(this.spriteYPosBox_ValueChanged);
            // 
            // spriteXPosBox
            // 
            this.spriteXPosBox.Location = new System.Drawing.Point(44, 56);
            this.spriteXPosBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spriteXPosBox.Name = "spriteXPosBox";
            this.spriteXPosBox.Size = new System.Drawing.Size(52, 20);
            this.spriteXPosBox.TabIndex = 15;
            this.spriteXPosBox.ValueChanged += new System.EventHandler(this.spriteXPosBox_ValueChanged);
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(98, 85);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(38, 13);
            this.heightLabel.TabIndex = 14;
            this.heightLabel.Text = "Height";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(6, 85);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 12;
            this.widthLabel.Text = "Width";
            // 
            // yPosLabel
            // 
            this.yPosLabel.AutoSize = true;
            this.yPosLabel.Location = new System.Drawing.Point(98, 59);
            this.yPosLabel.Name = "yPosLabel";
            this.yPosLabel.Size = new System.Drawing.Size(35, 13);
            this.yPosLabel.TabIndex = 10;
            this.yPosLabel.Text = "Y Pos";
            // 
            // xPosLabel
            // 
            this.xPosLabel.AutoSize = true;
            this.xPosLabel.Location = new System.Drawing.Point(6, 59);
            this.xPosLabel.Name = "xPosLabel";
            this.xPosLabel.Size = new System.Drawing.Size(38, 13);
            this.xPosLabel.TabIndex = 8;
            this.xPosLabel.Text = "X Pos.";
            // 
            // spriteNameLabel
            // 
            this.spriteNameLabel.AutoSize = true;
            this.spriteNameLabel.Location = new System.Drawing.Point(6, 30);
            this.spriteNameLabel.Name = "spriteNameLabel";
            this.spriteNameLabel.Size = new System.Drawing.Size(38, 13);
            this.spriteNameLabel.TabIndex = 6;
            this.spriteNameLabel.Text = "Name:";
            // 
            // spriteSettingsLabel
            // 
            this.spriteSettingsLabel.AutoSize = true;
            this.spriteSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spriteSettingsLabel.Location = new System.Drawing.Point(3, 8);
            this.spriteSettingsLabel.Name = "spriteSettingsLabel";
            this.spriteSettingsLabel.Size = new System.Drawing.Size(90, 13);
            this.spriteSettingsLabel.TabIndex = 5;
            this.spriteSettingsLabel.Text = "Sprite Settings";
            // 
            // spriteNameBox
            // 
            this.spriteNameBox.Location = new System.Drawing.Point(44, 27);
            this.spriteNameBox.Name = "spriteNameBox";
            this.spriteNameBox.Size = new System.Drawing.Size(144, 20);
            this.spriteNameBox.TabIndex = 0;
            this.spriteNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.spriteNameBox_KeyPress);
            this.spriteNameBox.Leave += new System.EventHandler(this.spriteNameBox_Leave);
            // 
            // loadSpriteSheetDialog
            // 
            this.loadSpriteSheetDialog.FileName = "openFileDialog1";
            this.loadSpriteSheetDialog.Filter = "PNG files|*.png";
            // 
            // loadMapDialog
            // 
            this.loadMapDialog.DefaultExt = "smap";
            this.loadMapDialog.FileName = "openFileDialog1";
            this.loadMapDialog.Filter = "QUROGame SpriteMap|*.smap";
            // 
            // saveMapDialog
            // 
            this.saveMapDialog.DefaultExt = "smap";
            this.saveMapDialog.Filter = "QUROGame SpriteMap|*.smap";
            // 
            // spriteViewerPanel
            // 
            this.spriteViewerPanel.AutoScroll = true;
            this.spriteViewerPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.spriteViewerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.spriteViewerPanel.Controls.Add(this.spriteSheetViewer);
            this.spriteViewerPanel.Location = new System.Drawing.Point(198, 59);
            this.spriteViewerPanel.Name = "spriteViewerPanel";
            this.spriteViewerPanel.Size = new System.Drawing.Size(488, 404);
            this.spriteViewerPanel.TabIndex = 14;
            this.spriteViewerPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.spriteViewerPanel_Scroll);
            // 
            // zoomInButton
            // 
            this.zoomInButton.Location = new System.Drawing.Point(659, 30);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(27, 23);
            this.zoomInButton.TabIndex = 5;
            this.zoomInButton.Text = "+";
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Location = new System.Drawing.Point(566, 30);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(28, 23);
            this.zoomOutButton.TabIndex = 6;
            this.zoomOutButton.Text = "-";
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomLabel
            // 
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.Location = new System.Drawing.Point(600, 35);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(53, 13);
            this.zoomLabel.TabIndex = 15;
            this.zoomLabel.Text = "Zoom: 3X";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(691, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSpriteSheetToolStripMenuItem,
            this.loadSpriteMapToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveSpriteMapToolStripMenuItem,
            this.saveSpriteMapAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadSpriteSheetToolStripMenuItem
            // 
            this.loadSpriteSheetToolStripMenuItem.Name = "loadSpriteSheetToolStripMenuItem";
            this.loadSpriteSheetToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.loadSpriteSheetToolStripMenuItem.Text = "Load Sprite Sheet...";
            this.loadSpriteSheetToolStripMenuItem.Click += new System.EventHandler(this.loadSpriteSheetToolStripMenuItem_Click);
            // 
            // loadSpriteMapToolStripMenuItem
            // 
            this.loadSpriteMapToolStripMenuItem.Enabled = false;
            this.loadSpriteMapToolStripMenuItem.Name = "loadSpriteMapToolStripMenuItem";
            this.loadSpriteMapToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.loadSpriteMapToolStripMenuItem.Text = "Load Sprite Map...";
            this.loadSpriteMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 6);
            // 
            // saveSpriteMapToolStripMenuItem
            // 
            this.saveSpriteMapToolStripMenuItem.Enabled = false;
            this.saveSpriteMapToolStripMenuItem.Name = "saveSpriteMapToolStripMenuItem";
            this.saveSpriteMapToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveSpriteMapToolStripMenuItem.Text = "Save Sprite Map";
            this.saveSpriteMapToolStripMenuItem.Click += new System.EventHandler(this.saveSpriteMapToolStripMenuItem_Click);
            // 
            // saveSpriteMapAsToolStripMenuItem
            // 
            this.saveSpriteMapAsToolStripMenuItem.Enabled = false;
            this.saveSpriteMapAsToolStripMenuItem.Name = "saveSpriteMapAsToolStripMenuItem";
            this.saveSpriteMapAsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveSpriteMapAsToolStripMenuItem.Text = "Save Sprite Map As...";
            this.saveSpriteMapAsToolStripMenuItem.Click += new System.EventHandler(this.saveMapAsToolStripMenuItem_Click);
            // 
            // highlightCheckBox
            // 
            this.highlightCheckBox.AutoSize = true;
            this.highlightCheckBox.Checked = true;
            this.highlightCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.highlightCheckBox.Location = new System.Drawing.Point(446, 34);
            this.highlightCheckBox.Name = "highlightCheckBox";
            this.highlightCheckBox.Size = new System.Drawing.Size(114, 17);
            this.highlightCheckBox.TabIndex = 17;
            this.highlightCheckBox.Text = "Highlight Selection";
            this.highlightCheckBox.UseVisualStyleBackColor = true;
            this.highlightCheckBox.CheckedChanged += new System.EventHandler(this.highlightCheckBox_CheckedChanged);
            // 
            // outlineTimer
            // 
            this.outlineTimer.Enabled = true;
            this.outlineTimer.Interval = 66;
            this.outlineTimer.Tick += new System.EventHandler(this.outlineTimer_Tick);
            // 
            // spriteSheetViewer
            // 
            this.spriteSheetViewer.BackgroundImage = global::SpriteMapEditor.Properties.Resources.transparentUI;
            this.spriteSheetViewer.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.spriteSheetViewer.Location = new System.Drawing.Point(0, 0);
            this.spriteSheetViewer.Margin = new System.Windows.Forms.Padding(0);
            this.spriteSheetViewer.Name = "spriteSheetViewer";
            this.spriteSheetViewer.Size = new System.Drawing.Size(147, 143);
            this.spriteSheetViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.spriteSheetViewer.TabIndex = 13;
            this.spriteSheetViewer.TabStop = false;
            this.spriteSheetViewer.Paint += new System.Windows.Forms.PaintEventHandler(this.spriteSheetViewer_Paint);
            this.spriteSheetViewer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spriteSheetViewer_MouseDown);
            this.spriteSheetViewer.MouseLeave += new System.EventHandler(this.spriteSheetViewer_MouseLeave);
            this.spriteSheetViewer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spriteSheetViewer_MouseMove);
            this.spriteSheetViewer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spriteSheetViewer_MouseUp);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(691, 465);
            this.Controls.Add(this.highlightCheckBox);
            this.Controls.Add(this.zoomLabel);
            this.Controls.Add(this.zoomInButton);
            this.Controls.Add(this.spriteViewerPanel);
            this.Controls.Add(this.zoomOutButton);
            this.Controls.Add(this.spritePanel);
            this.Controls.Add(this.spriteListPanel);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "QUROGames Sprite Map Editor";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.spriteListPanel.ResumeLayout(false);
            this.spriteListPanel.PerformLayout();
            this.spritePanel.ResumeLayout(false);
            this.spritePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originYPosBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originXPosBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteHeightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteYPosBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteXPosBox)).EndInit();
            this.spriteViewerPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSheetViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox spriteList;
        private System.Windows.Forms.Button addSpriteButton;
        private System.Windows.Forms.Button removeSpriteButton;
        private System.Windows.Forms.Panel spriteListPanel;
        private System.Windows.Forms.Label spritesLabel;
        private System.Windows.Forms.Panel spritePanel;
        private System.Windows.Forms.Label spriteSettingsLabel;
        private System.Windows.Forms.TextBox spriteNameBox;
        private System.Windows.Forms.Label spriteNameLabel;
        private System.Windows.Forms.Label xPosLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label yPosLabel;
        private System.Windows.Forms.OpenFileDialog loadSpriteSheetDialog;
        private System.Windows.Forms.OpenFileDialog loadMapDialog;
        private System.Windows.Forms.SaveFileDialog saveMapDialog;
        private PictureBoxWithInterpolationMode spriteSheetViewer;
        private System.Windows.Forms.Panel spriteViewerPanel;
        private System.Windows.Forms.Button zoomInButton;
        private System.Windows.Forms.Button zoomOutButton;
        private System.Windows.Forms.NumericUpDown spriteHeightBox;
        private System.Windows.Forms.NumericUpDown spriteWidthBox;
        private System.Windows.Forms.NumericUpDown spriteYPosBox;
        private System.Windows.Forms.NumericUpDown spriteXPosBox;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.NumericUpDown originYPosBox;
        private System.Windows.Forms.NumericUpDown originXPosBox;
        private System.Windows.Forms.Label originYPosLabel;
        private System.Windows.Forms.Label originXPosLabel;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSpriteSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSpriteMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveSpriteMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSpriteMapAsToolStripMenuItem;
        private System.Windows.Forms.CheckBox editingOriginCheckBox;
        private System.Windows.Forms.CheckBox highlightCheckBox;
        private System.Windows.Forms.Timer outlineTimer;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    }
}

