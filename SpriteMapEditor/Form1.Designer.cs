namespace SpriteMapEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.spriteList = new System.Windows.Forms.ListBox();
            this.addSpriteButton = new System.Windows.Forms.Button();
            this.removeSpriteButton = new System.Windows.Forms.Button();
            this.loadSpriteSheetButton = new System.Windows.Forms.Button();
            this.loadMapButton = new System.Windows.Forms.Button();
            this.saveMapButton = new System.Windows.Forms.Button();
            this.filePanel = new System.Windows.Forms.Panel();
            this.spriteListPanel = new System.Windows.Forms.Panel();
            this.spritesLabel = new System.Windows.Forms.Label();
            this.spritePanel = new System.Windows.Forms.Panel();
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
            this.label2 = new System.Windows.Forms.Label();
            this.spriteSettingsLabel = new System.Windows.Forms.Label();
            this.spriteNameBox = new System.Windows.Forms.TextBox();
            this.loadSpriteSheetDialogue = new System.Windows.Forms.OpenFileDialog();
            this.loadMapDialogue = new System.Windows.Forms.OpenFileDialog();
            this.saveMapDialogue = new System.Windows.Forms.SaveFileDialog();
            this.fillButton = new System.Windows.Forms.Button();
            this.spriteViewerPanel = new System.Windows.Forms.Panel();
            this.spriteSheetViewer = new SpriteMapEditor.PictureBoxWithInterpolationMode();
            this.zoomInButton = new System.Windows.Forms.Button();
            this.zoomOutButton = new System.Windows.Forms.Button();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.filePanel.SuspendLayout();
            this.spriteListPanel.SuspendLayout();
            this.spritePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originYPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.originXPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteHeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteWidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteYPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteXPosBox)).BeginInit();
            this.spriteViewerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSheetViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // spriteList
            // 
            this.spriteList.AllowDrop = true;
            this.spriteList.FormattingEnabled = true;
            this.spriteList.Location = new System.Drawing.Point(3, 32);
            this.spriteList.Name = "spriteList";
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
            // loadSpriteSheetButton
            // 
            this.loadSpriteSheetButton.Location = new System.Drawing.Point(3, 3);
            this.loadSpriteSheetButton.Name = "loadSpriteSheetButton";
            this.loadSpriteSheetButton.Size = new System.Drawing.Size(185, 23);
            this.loadSpriteSheetButton.TabIndex = 4;
            this.loadSpriteSheetButton.Text = "Load Sprite Sheet...";
            this.loadSpriteSheetButton.UseVisualStyleBackColor = true;
            this.loadSpriteSheetButton.Click += new System.EventHandler(this.loadSpriteSheetButton_Click);
            // 
            // loadMapButton
            // 
            this.loadMapButton.Location = new System.Drawing.Point(3, 32);
            this.loadMapButton.Name = "loadMapButton";
            this.loadMapButton.Size = new System.Drawing.Size(92, 23);
            this.loadMapButton.TabIndex = 5;
            this.loadMapButton.Text = "Load Map...";
            this.loadMapButton.UseVisualStyleBackColor = true;
            this.loadMapButton.Click += new System.EventHandler(this.loadMapButton_Click);
            // 
            // saveMapButton
            // 
            this.saveMapButton.Location = new System.Drawing.Point(96, 32);
            this.saveMapButton.Name = "saveMapButton";
            this.saveMapButton.Size = new System.Drawing.Size(92, 23);
            this.saveMapButton.TabIndex = 6;
            this.saveMapButton.Text = "Save Map As...";
            this.saveMapButton.UseVisualStyleBackColor = true;
            this.saveMapButton.Click += new System.EventHandler(this.saveMapButton_Click);
            // 
            // filePanel
            // 
            this.filePanel.Controls.Add(this.loadSpriteSheetButton);
            this.filePanel.Controls.Add(this.saveMapButton);
            this.filePanel.Controls.Add(this.loadMapButton);
            this.filePanel.Location = new System.Drawing.Point(2, 2);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(190, 62);
            this.filePanel.TabIndex = 7;
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
            this.spriteListPanel.Location = new System.Drawing.Point(2, 63);
            this.spriteListPanel.Name = "spriteListPanel";
            this.spriteListPanel.Size = new System.Drawing.Size(190, 254);
            this.spriteListPanel.TabIndex = 8;
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
            this.spritePanel.Controls.Add(this.label2);
            this.spritePanel.Controls.Add(this.spriteSettingsLabel);
            this.spritePanel.Controls.Add(this.spriteNameBox);
            this.spritePanel.Location = new System.Drawing.Point(2, 323);
            this.spritePanel.Name = "spritePanel";
            this.spritePanel.Size = new System.Drawing.Size(190, 140);
            this.spritePanel.TabIndex = 9;
            // 
            // originYPosBox
            // 
            this.originYPosBox.Enabled = false;
            this.originYPosBox.Location = new System.Drawing.Point(143, 108);
            this.originYPosBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.originYPosBox.Name = "originYPosBox";
            this.originYPosBox.Size = new System.Drawing.Size(45, 20);
            this.originYPosBox.TabIndex = 22;
            this.originYPosBox.ValueChanged += new System.EventHandler(this.originYPosBox_ValueChanged);
            // 
            // originXPosBox
            // 
            this.originXPosBox.Enabled = false;
            this.originXPosBox.Location = new System.Drawing.Point(51, 108);
            this.originXPosBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.originXPosBox.Name = "originXPosBox";
            this.originXPosBox.Size = new System.Drawing.Size(45, 20);
            this.originXPosBox.TabIndex = 21;
            this.originXPosBox.ValueChanged += new System.EventHandler(this.originXPosBox_ValueChanged);
            // 
            // originYPosLabel
            // 
            this.originYPosLabel.AutoSize = true;
            this.originYPosLabel.Enabled = false;
            this.originYPosLabel.Location = new System.Drawing.Point(98, 111);
            this.originYPosLabel.Name = "originYPosLabel";
            this.originYPosLabel.Size = new System.Drawing.Size(44, 13);
            this.originYPosLabel.TabIndex = 20;
            this.originYPosLabel.Text = "Origin Y";
            // 
            // originXPosLabel
            // 
            this.originXPosLabel.AutoSize = true;
            this.originXPosLabel.Enabled = false;
            this.originXPosLabel.Location = new System.Drawing.Point(6, 111);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name:";
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
            this.spriteNameBox.TextChanged += new System.EventHandler(this.spriteNameBox_TextChanged);
            // 
            // loadSpriteSheetDialogue
            // 
            this.loadSpriteSheetDialogue.FileName = "openFileDialog1";
            this.loadSpriteSheetDialogue.Filter = "PNG files|*.png";
            // 
            // loadMapDialogue
            // 
            this.loadMapDialogue.FileName = "openFileDialog1";
            this.loadMapDialogue.Filter = "Xml files|*.xml";
            // 
            // saveMapDialogue
            // 
            this.saveMapDialogue.DefaultExt = "xml";
            this.saveMapDialogue.Filter = "Xml files|*.xml";
            // 
            // fillButton
            // 
            this.fillButton.Location = new System.Drawing.Point(454, 5);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(86, 23);
            this.fillButton.TabIndex = 12;
            this.fillButton.Text = "Highight";
            this.fillButton.UseVisualStyleBackColor = true;
            this.fillButton.Click += new System.EventHandler(this.highlightButton_Click);
            // 
            // spriteViewerPanel
            // 
            this.spriteViewerPanel.AutoScroll = true;
            this.spriteViewerPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.spriteViewerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.spriteViewerPanel.Controls.Add(this.spriteSheetViewer);
            this.spriteViewerPanel.Location = new System.Drawing.Point(199, 34);
            this.spriteViewerPanel.Name = "spriteViewerPanel";
            this.spriteViewerPanel.Size = new System.Drawing.Size(488, 429);
            this.spriteViewerPanel.TabIndex = 14;
            this.spriteViewerPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.spriteViewerPanel_Scroll);
            // 
            // spriteSheetViewer
            // 
            this.spriteSheetViewer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("spriteSheetViewer.BackgroundImage")));
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
            this.zoomInButton.Location = new System.Drawing.Point(652, 5);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(27, 23);
            this.zoomInButton.TabIndex = 5;
            this.zoomInButton.Text = "+";
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Location = new System.Drawing.Point(559, 5);
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
            this.zoomLabel.Location = new System.Drawing.Point(593, 10);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(53, 13);
            this.zoomLabel.TabIndex = 15;
            this.zoomLabel.Text = "Zoom: 3X";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(691, 465);
            this.Controls.Add(this.zoomLabel);
            this.Controls.Add(this.zoomInButton);
            this.Controls.Add(this.spriteViewerPanel);
            this.Controls.Add(this.zoomOutButton);
            this.Controls.Add(this.fillButton);
            this.Controls.Add(this.spritePanel);
            this.Controls.Add(this.spriteListPanel);
            this.Controls.Add(this.filePanel);
            this.Name = "Form1";
            this.Text = "QUROGames Sprite Map Editor";
            this.filePanel.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.spriteSheetViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox spriteList;
        private System.Windows.Forms.Button addSpriteButton;
        private System.Windows.Forms.Button removeSpriteButton;
        private System.Windows.Forms.Button loadSpriteSheetButton;
        private System.Windows.Forms.Button loadMapButton;
        private System.Windows.Forms.Button saveMapButton;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Panel spriteListPanel;
        private System.Windows.Forms.Label spritesLabel;
        private System.Windows.Forms.Panel spritePanel;
        private System.Windows.Forms.Label spriteSettingsLabel;
        private System.Windows.Forms.TextBox spriteNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label xPosLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label yPosLabel;
        private System.Windows.Forms.OpenFileDialog loadSpriteSheetDialogue;
        private System.Windows.Forms.OpenFileDialog loadMapDialogue;
        private System.Windows.Forms.SaveFileDialog saveMapDialogue;
        private System.Windows.Forms.Button fillButton;
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
    }
}

