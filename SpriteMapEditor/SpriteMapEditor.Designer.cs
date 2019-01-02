namespace SpriteMapEditor
{
    partial class SpriteMapEditor
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
            this.spriteListEditPanel = new System.Windows.Forms.Panel();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.spritesLabel = new System.Windows.Forms.Label();
            this.spriteEditPanel = new System.Windows.Forms.Panel();
            this.originEditPanel = new System.Windows.Forms.Panel();
            this.originPresetLabel = new System.Windows.Forms.Label();
            this.originPresetBox = new System.Windows.Forms.ComboBox();
            this.originXPosLabel = new System.Windows.Forms.Label();
            this.originYPosLabel = new System.Windows.Forms.Label();
            this.originYPosBox = new System.Windows.Forms.NumericUpDown();
            this.originXPosBox = new System.Windows.Forms.NumericUpDown();
            this.editingOriginCheckBox = new System.Windows.Forms.CheckBox();
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
            this.spriteSheetViewer = new global::SpriteMapEditor.PictureBoxWithInterpolationMode();
            this.zoomInButton = new System.Windows.Forms.Button();
            this.zoomOutButton = new System.Windows.Forms.Button();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.importSpriteSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSpriteMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSpriteMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightCheckBox = new System.Windows.Forms.CheckBox();
            this.outlineTimer = new System.Windows.Forms.Timer(this.components);
            this.viewEditPanel = new System.Windows.Forms.Panel();
            this.saveProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.openProjectDialog = new System.Windows.Forms.OpenFileDialog();
            this.spriteListEditPanel.SuspendLayout();
            this.spriteEditPanel.SuspendLayout();
            this.originEditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originYPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originXPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteHeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteYPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteXPosBox)).BeginInit();
            this.spriteViewerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSheetViewer)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.viewEditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // spriteList
            // 
            this.spriteList.AllowDrop = true;
            this.spriteList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteList.FormattingEnabled = true;
            this.spriteList.Location = new System.Drawing.Point(6, 32);
            this.spriteList.MaximumSize = new System.Drawing.Size(185, 4000);
            this.spriteList.MinimumSize = new System.Drawing.Size(4, 4);
            this.spriteList.Name = "spriteList";
            this.spriteList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.spriteList.Size = new System.Drawing.Size(182, 251);
            this.spriteList.TabIndex = 0;
            this.spriteList.SelectedValueChanged += new System.EventHandler(this.spriteList_SelectedValueChanged);
            // 
            // addSpriteButton
            // 
            this.addSpriteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addSpriteButton.Location = new System.Drawing.Point(127, 3);
            this.addSpriteButton.Name = "addSpriteButton";
            this.addSpriteButton.Size = new System.Drawing.Size(27, 23);
            this.addSpriteButton.TabIndex = 2;
            this.addSpriteButton.Text = "+";
            this.addSpriteButton.UseVisualStyleBackColor = true;
            this.addSpriteButton.Click += new System.EventHandler(this.addSpriteButton_Click);
            // 
            // removeSpriteButton
            // 
            this.removeSpriteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeSpriteButton.Location = new System.Drawing.Point(160, 3);
            this.removeSpriteButton.Name = "removeSpriteButton";
            this.removeSpriteButton.Size = new System.Drawing.Size(28, 23);
            this.removeSpriteButton.TabIndex = 3;
            this.removeSpriteButton.Text = "-";
            this.removeSpriteButton.UseVisualStyleBackColor = true;
            this.removeSpriteButton.Click += new System.EventHandler(this.removeSpriteButton_Click);
            // 
            // spriteListEditPanel
            // 
            this.spriteListEditPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteListEditPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.spriteListEditPanel.Controls.Add(this.moveDownButton);
            this.spriteListEditPanel.Controls.Add(this.moveUpButton);
            this.spriteListEditPanel.Controls.Add(this.spritesLabel);
            this.spriteListEditPanel.Controls.Add(this.spriteList);
            this.spriteListEditPanel.Controls.Add(this.addSpriteButton);
            this.spriteListEditPanel.Controls.Add(this.removeSpriteButton);
            this.spriteListEditPanel.Enabled = false;
            this.spriteListEditPanel.Location = new System.Drawing.Point(2, 27);
            this.spriteListEditPanel.Name = "spriteListEditPanel";
            this.spriteListEditPanel.Size = new System.Drawing.Size(191, 321);
            this.spriteListEditPanel.TabIndex = 8;
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownButton.Location = new System.Drawing.Point(41, 289);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(70, 20);
            this.moveDownButton.TabIndex = 5;
            this.moveDownButton.Text = "▼";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpButton.Location = new System.Drawing.Point(117, 289);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(71, 20);
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
            // spriteEditPanel
            // 
            this.spriteEditPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteEditPanel.Controls.Add(this.originEditPanel);
            this.spriteEditPanel.Controls.Add(this.editingOriginCheckBox);
            this.spriteEditPanel.Controls.Add(this.spriteHeightBox);
            this.spriteEditPanel.Controls.Add(this.spriteWidthBox);
            this.spriteEditPanel.Controls.Add(this.spriteYPosBox);
            this.spriteEditPanel.Controls.Add(this.spriteXPosBox);
            this.spriteEditPanel.Controls.Add(this.heightLabel);
            this.spriteEditPanel.Controls.Add(this.widthLabel);
            this.spriteEditPanel.Controls.Add(this.yPosLabel);
            this.spriteEditPanel.Controls.Add(this.xPosLabel);
            this.spriteEditPanel.Controls.Add(this.spriteNameLabel);
            this.spriteEditPanel.Controls.Add(this.spriteSettingsLabel);
            this.spriteEditPanel.Controls.Add(this.spriteNameBox);
            this.spriteEditPanel.Enabled = false;
            this.spriteEditPanel.Location = new System.Drawing.Point(2, 347);
            this.spriteEditPanel.Name = "spriteEditPanel";
            this.spriteEditPanel.Size = new System.Drawing.Size(191, 180);
            this.spriteEditPanel.TabIndex = 9;
            // 
            // originEditPanel
            // 
            this.originEditPanel.Controls.Add(this.originPresetLabel);
            this.originEditPanel.Controls.Add(this.originPresetBox);
            this.originEditPanel.Controls.Add(this.originXPosLabel);
            this.originEditPanel.Controls.Add(this.originYPosLabel);
            this.originEditPanel.Controls.Add(this.originYPosBox);
            this.originEditPanel.Controls.Add(this.originXPosBox);
            this.originEditPanel.Enabled = false;
            this.originEditPanel.Location = new System.Drawing.Point(0, 123);
            this.originEditPanel.Name = "originEditPanel";
            this.originEditPanel.Size = new System.Drawing.Size(191, 54);
            this.originEditPanel.TabIndex = 18;
            // 
            // originPresetLabel
            // 
            this.originPresetLabel.AutoSize = true;
            this.originPresetLabel.Location = new System.Drawing.Point(6, 33);
            this.originPresetLabel.Name = "originPresetLabel";
            this.originPresetLabel.Size = new System.Drawing.Size(70, 13);
            this.originPresetLabel.TabIndex = 25;
            this.originPresetLabel.Text = "Origin Preset:";
            // 
            // originPresetBox
            // 
            this.originPresetBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.originPresetBox.FormattingEnabled = true;
            this.originPresetBox.Location = new System.Drawing.Point(78, 30);
            this.originPresetBox.Name = "originPresetBox";
            this.originPresetBox.Size = new System.Drawing.Size(110, 21);
            this.originPresetBox.TabIndex = 24;
            this.originPresetBox.SelectedIndexChanged += new System.EventHandler(this.originPresetBox_SelectedIndexChanged);
            // 
            // originXPosLabel
            // 
            this.originXPosLabel.AutoSize = true;
            this.originXPosLabel.Location = new System.Drawing.Point(6, 7);
            this.originXPosLabel.Name = "originXPosLabel";
            this.originXPosLabel.Size = new System.Drawing.Size(44, 13);
            this.originXPosLabel.TabIndex = 19;
            this.originXPosLabel.Text = "Origin X";
            // 
            // originYPosLabel
            // 
            this.originYPosLabel.AutoSize = true;
            this.originYPosLabel.Location = new System.Drawing.Point(98, 7);
            this.originYPosLabel.Name = "originYPosLabel";
            this.originYPosLabel.Size = new System.Drawing.Size(44, 13);
            this.originYPosLabel.TabIndex = 20;
            this.originYPosLabel.Text = "Origin Y";
            // 
            // originYPosBox
            // 
            this.originYPosBox.Location = new System.Drawing.Point(143, 4);
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
            this.originXPosBox.Location = new System.Drawing.Point(51, 4);
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
            // editingOriginCheckBox
            // 
            this.editingOriginCheckBox.AutoSize = true;
            this.editingOriginCheckBox.Location = new System.Drawing.Point(9, 103);
            this.editingOriginCheckBox.Name = "editingOriginCheckBox";
            this.editingOriginCheckBox.Size = new System.Drawing.Size(107, 17);
            this.editingOriginCheckBox.TabIndex = 23;
            this.editingOriginCheckBox.Text = "Edit Origin Point?";
            this.editingOriginCheckBox.UseVisualStyleBackColor = true;
            this.editingOriginCheckBox.CheckedChanged += new System.EventHandler(this.editingOriginCheckBox_CheckedChanged);
            // 
            // spriteHeightBox
            // 
            this.spriteHeightBox.Location = new System.Drawing.Point(136, 77);
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
            this.spriteWidthBox.Location = new System.Drawing.Point(44, 77);
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
            this.spriteYPosBox.Location = new System.Drawing.Point(136, 51);
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
            this.spriteXPosBox.Location = new System.Drawing.Point(44, 51);
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
            this.heightLabel.Location = new System.Drawing.Point(98, 80);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(38, 13);
            this.heightLabel.TabIndex = 14;
            this.heightLabel.Text = "Height";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(6, 80);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 12;
            this.widthLabel.Text = "Width";
            // 
            // yPosLabel
            // 
            this.yPosLabel.AutoSize = true;
            this.yPosLabel.Location = new System.Drawing.Point(98, 54);
            this.yPosLabel.Name = "yPosLabel";
            this.yPosLabel.Size = new System.Drawing.Size(38, 13);
            this.yPosLabel.TabIndex = 10;
            this.yPosLabel.Text = "Y Pos.";
            // 
            // xPosLabel
            // 
            this.xPosLabel.AutoSize = true;
            this.xPosLabel.Location = new System.Drawing.Point(6, 54);
            this.xPosLabel.Name = "xPosLabel";
            this.xPosLabel.Size = new System.Drawing.Size(38, 13);
            this.xPosLabel.TabIndex = 8;
            this.xPosLabel.Text = "X Pos.";
            // 
            // spriteNameLabel
            // 
            this.spriteNameLabel.AutoSize = true;
            this.spriteNameLabel.Location = new System.Drawing.Point(6, 25);
            this.spriteNameLabel.Name = "spriteNameLabel";
            this.spriteNameLabel.Size = new System.Drawing.Size(38, 13);
            this.spriteNameLabel.TabIndex = 6;
            this.spriteNameLabel.Text = "Name:";
            // 
            // spriteSettingsLabel
            // 
            this.spriteSettingsLabel.AutoSize = true;
            this.spriteSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spriteSettingsLabel.Location = new System.Drawing.Point(3, 3);
            this.spriteSettingsLabel.Name = "spriteSettingsLabel";
            this.spriteSettingsLabel.Size = new System.Drawing.Size(90, 13);
            this.spriteSettingsLabel.TabIndex = 5;
            this.spriteSettingsLabel.Text = "Sprite Settings";
            // 
            // spriteNameBox
            // 
            this.spriteNameBox.Location = new System.Drawing.Point(44, 22);
            this.spriteNameBox.Name = "spriteNameBox";
            this.spriteNameBox.Size = new System.Drawing.Size(144, 20);
            this.spriteNameBox.TabIndex = 0;
            this.spriteNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.spriteNameBox_KeyPress);
            this.spriteNameBox.Leave += new System.EventHandler(this.spriteNameBox_Leave);
            // 
            // loadSpriteSheetDialog
            // 
            this.loadSpriteSheetDialog.FileName = " ";
            this.loadSpriteSheetDialog.Filter = "PNG files|*.png";
            this.loadSpriteSheetDialog.Title = "Import Sprite Sheet Image";
            // 
            // loadMapDialog
            // 
            this.loadMapDialog.DefaultExt = "smap";
            this.loadMapDialog.FileName = " ";
            this.loadMapDialog.Filter = "QUROGame SpriteMap|*.smap";
            this.loadMapDialog.Title = "Import Sprite Map";
            // 
            // saveMapDialog
            // 
            this.saveMapDialog.DefaultExt = "smap";
            this.saveMapDialog.FileName = " ";
            this.saveMapDialog.Filter = "QUROGame SpriteMap|*.smap";
            this.saveMapDialog.Title = "Export Sprite Map";
            // 
            // spriteViewerPanel
            // 
            this.spriteViewerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spriteViewerPanel.AutoScroll = true;
            this.spriteViewerPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.spriteViewerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.spriteViewerPanel.Controls.Add(this.spriteSheetViewer);
            this.spriteViewerPanel.Enabled = false;
            this.spriteViewerPanel.Location = new System.Drawing.Point(198, 59);
            this.spriteViewerPanel.Name = "spriteViewerPanel";
            this.spriteViewerPanel.Size = new System.Drawing.Size(599, 468);
            this.spriteViewerPanel.TabIndex = 14;
            this.spriteViewerPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.spriteViewerPanel_Scroll);
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
            // zoomInButton
            // 
            this.zoomInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomInButton.Location = new System.Drawing.Point(219, 3);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(27, 23);
            this.zoomInButton.TabIndex = 5;
            this.zoomInButton.Text = "+";
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomOutButton.Location = new System.Drawing.Point(126, 3);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(28, 23);
            this.zoomOutButton.TabIndex = 6;
            this.zoomOutButton.Text = "-";
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            // 
            // zoomLabel
            // 
            this.zoomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.Location = new System.Drawing.Point(160, 8);
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveProjectToolStripMenuItem,
            this.saveProjectAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.importSpriteSheetToolStripMenuItem,
            this.importSpriteMapToolStripMenuItem,
            this.exportSpriteMapToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.newProjectToolStripMenuItem.Text = "New Project...";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.openProjectToolStripMenuItem.Text = "Open Project...";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Enabled = false;
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // saveProjectAsToolStripMenuItem
            // 
            this.saveProjectAsToolStripMenuItem.Enabled = false;
            this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            this.saveProjectAsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.saveProjectAsToolStripMenuItem.Text = "Save Project As...";
            this.saveProjectAsToolStripMenuItem.Click += new System.EventHandler(this.saveProjectAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 6);
            // 
            // importSpriteSheetToolStripMenuItem
            // 
            this.importSpriteSheetToolStripMenuItem.Name = "importSpriteSheetToolStripMenuItem";
            this.importSpriteSheetToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.importSpriteSheetToolStripMenuItem.Text = "Import Sprite Sheet...";
            this.importSpriteSheetToolStripMenuItem.Click += new System.EventHandler(this.importSpriteSheetToolStripMenuItem_Click);
            // 
            // importSpriteMapToolStripMenuItem
            // 
            this.importSpriteMapToolStripMenuItem.Enabled = false;
            this.importSpriteMapToolStripMenuItem.Name = "importSpriteMapToolStripMenuItem";
            this.importSpriteMapToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.importSpriteMapToolStripMenuItem.Text = "Import Sprite Map...";
            this.importSpriteMapToolStripMenuItem.Click += new System.EventHandler(this.importMapToolStripMenuItem_Click);
            // 
            // exportSpriteMapToolStripMenuItem
            // 
            this.exportSpriteMapToolStripMenuItem.Enabled = false;
            this.exportSpriteMapToolStripMenuItem.Name = "exportSpriteMapToolStripMenuItem";
            this.exportSpriteMapToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.exportSpriteMapToolStripMenuItem.Text = "Export Sprite Map...";
            this.exportSpriteMapToolStripMenuItem.Click += new System.EventHandler(this.exportMapToolStripMenuItem_Click);
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
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // highlightCheckBox
            // 
            this.highlightCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.highlightCheckBox.AutoSize = true;
            this.highlightCheckBox.Checked = true;
            this.highlightCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.highlightCheckBox.Location = new System.Drawing.Point(6, 7);
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
            // viewEditPanel
            // 
            this.viewEditPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewEditPanel.Controls.Add(this.zoomLabel);
            this.viewEditPanel.Controls.Add(this.highlightCheckBox);
            this.viewEditPanel.Controls.Add(this.zoomOutButton);
            this.viewEditPanel.Controls.Add(this.zoomInButton);
            this.viewEditPanel.Enabled = false;
            this.viewEditPanel.Location = new System.Drawing.Point(551, 27);
            this.viewEditPanel.Name = "viewEditPanel";
            this.viewEditPanel.Size = new System.Drawing.Size(246, 29);
            this.viewEditPanel.TabIndex = 18;
            // 
            // saveProjectDialog
            // 
            this.saveProjectDialog.DefaultExt = "smappr";
            this.saveProjectDialog.FileName = " ";
            this.saveProjectDialog.Filter = "QUROGames Sprite Map Editor Project|*.smappr";
            this.saveProjectDialog.Title = "Save Project As";
            // 
            // openProjectDialog
            // 
            this.openProjectDialog.DefaultExt = "smappr";
            this.openProjectDialog.FileName = " ";
            this.openProjectDialog.Filter = "QUROGames Sprite Map Editor Project|*.smappr";
            this.openProjectDialog.Title = "Open Project";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.viewEditPanel);
            this.Controls.Add(this.spriteViewerPanel);
            this.Controls.Add(this.spriteEditPanel);
            this.Controls.Add(this.spriteListEditPanel);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(460, 382);
            this.Name = "Form1";
            this.Text = "QUROGames Sprite Map Editor";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.spriteListEditPanel.ResumeLayout(false);
            this.spriteListEditPanel.PerformLayout();
            this.spriteEditPanel.ResumeLayout(false);
            this.spriteEditPanel.PerformLayout();
            this.originEditPanel.ResumeLayout(false);
            this.originEditPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originYPosBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.originXPosBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteHeightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteWidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteYPosBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteXPosBox)).EndInit();
            this.spriteViewerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spriteSheetViewer)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.viewEditPanel.ResumeLayout(false);
            this.viewEditPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox spriteList;
        private System.Windows.Forms.Button addSpriteButton;
        private System.Windows.Forms.Button removeSpriteButton;
        private System.Windows.Forms.Panel spriteListEditPanel;
        private System.Windows.Forms.Label spritesLabel;
        private System.Windows.Forms.Panel spriteEditPanel;
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
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importSpriteMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportSpriteMapToolStripMenuItem;
        private System.Windows.Forms.CheckBox editingOriginCheckBox;
        private System.Windows.Forms.CheckBox highlightCheckBox;
        private System.Windows.Forms.Timer outlineTimer;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.Label originPresetLabel;
        private System.Windows.Forms.ComboBox originPresetBox;
        private System.Windows.Forms.Panel originEditPanel;
        private System.Windows.Forms.Panel viewEditPanel;
        private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveProjectDialog;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openProjectDialog;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem importSpriteSheetToolStripMenuItem;
    }
}

