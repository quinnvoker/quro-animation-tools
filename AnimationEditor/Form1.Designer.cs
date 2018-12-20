namespace AnimationEditor
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
            this.loadSpriteSheetDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadSpriteMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.spriteListBox = new System.Windows.Forms.ListBox();
            this.frameListBox = new System.Windows.Forms.ListBox();
            this.addSpriteToFrameListButton = new System.Windows.Forms.Button();
            this.spritePreview = new System.Windows.Forms.PictureBox();
            this.frameTrackBar = new System.Windows.Forms.TrackBar();
            this.delayInputBox = new System.Windows.Forms.NumericUpDown();
            this.animationBox = new System.Windows.Forms.ComboBox();
            this.animationNameBox = new System.Windows.Forms.TextBox();
            this.playAnimationButton = new System.Windows.Forms.Button();
            this.removeFrameButton = new System.Windows.Forms.Button();
            this.moveFrameUpButton = new System.Windows.Forms.Button();
            this.moveFrameDownButton = new System.Windows.Forms.Button();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSpriteSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSpriteMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.loadAnimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAnimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.loadAnimationSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAnimationSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAnimationSpritesFromSpriteMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationLoopCheckBox = new System.Windows.Forms.CheckBox();
            this.saveAnimationDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveAnimationSetDialog = new System.Windows.Forms.SaveFileDialog();
            this.loadAnimationDialog = new System.Windows.Forms.OpenFileDialog();
            this.addAnimationButton = new System.Windows.Forms.Button();
            this.removeAnimationButton = new System.Windows.Forms.Button();
            this.frameEditorPanel = new System.Windows.Forms.Panel();
            this.frameSpritePanel = new System.Windows.Forms.Panel();
            this.frameSpritePositionLabel = new System.Windows.Forms.Label();
            this.frameSpriteListBox = new System.Windows.Forms.ListBox();
            this.spriteYPosLabel = new System.Windows.Forms.Label();
            this.spriteXPosLabel = new System.Windows.Forms.Label();
            this.frameSpriteListLabel = new System.Windows.Forms.Label();
            this.addSpriteToFrameSpritesButton = new System.Windows.Forms.Button();
            this.spriteYPosBox = new System.Windows.Forms.NumericUpDown();
            this.spriteXPosBox = new System.Windows.Forms.NumericUpDown();
            this.importDelayLabel = new System.Windows.Forms.Label();
            this.importValuesLabel = new System.Windows.Forms.Label();
            this.importDelayBox = new System.Windows.Forms.NumericUpDown();
            this.delayLabel = new System.Windows.Forms.Label();
            this.frameInfoLabel = new System.Windows.Forms.Label();
            this.frameBoxLabel = new System.Windows.Forms.Label();
            this.spriteBoxLabel = new System.Windows.Forms.Label();
            this.addEmptyFrameButton = new System.Windows.Forms.Button();
            this.animationPanel = new System.Windows.Forms.Panel();
            this.animationNameLabel = new System.Windows.Forms.Label();
            this.animationLabel = new System.Windows.Forms.Label();
            this.loadAnimationSetDialog = new System.Windows.Forms.OpenFileDialog();
            this.frameNameBox = new System.Windows.Forms.TextBox();
            this.frameNameLabel = new System.Windows.Forms.Label();
            this.moveSpriteDownButton = new System.Windows.Forms.Button();
            this.moveSpriteUpButton = new System.Windows.Forms.Button();
            this.removeSpriteButton = new System.Windows.Forms.Button();
            this.animationPreview = new AnimationEditor.AnimationPreview();
            ((System.ComponentModel.ISupportInitialize)(this.spritePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayInputBox)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.frameEditorPanel.SuspendLayout();
            this.frameSpritePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteYPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteXPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDelayBox)).BeginInit();
            this.animationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadSpriteSheetDialog
            // 
            this.loadSpriteSheetDialog.DefaultExt = "png";
            this.loadSpriteSheetDialog.FileName = "openFileDialog1";
            this.loadSpriteSheetDialog.Filter = "PNG files|*png";
            // 
            // loadSpriteMapDialog
            // 
            this.loadSpriteMapDialog.DefaultExt = "smap";
            this.loadSpriteMapDialog.FileName = "openFileDialog1";
            this.loadSpriteMapDialog.Filter = "QUROGames SpriteMap|*smap";
            // 
            // spriteListBox
            // 
            this.spriteListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteListBox.BackColor = System.Drawing.SystemColors.Window;
            this.spriteListBox.FormattingEnabled = true;
            this.spriteListBox.Location = new System.Drawing.Point(5, 62);
            this.spriteListBox.Name = "spriteListBox";
            this.spriteListBox.Size = new System.Drawing.Size(119, 277);
            this.spriteListBox.TabIndex = 3;
            this.spriteListBox.SelectedIndexChanged += new System.EventHandler(this.spriteListBox_SelectedIndexChanged);
            // 
            // frameListBox
            // 
            this.frameListBox.AllowDrop = true;
            this.frameListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.frameListBox.BackColor = System.Drawing.SystemColors.Window;
            this.frameListBox.FormattingEnabled = true;
            this.frameListBox.Location = new System.Drawing.Point(163, 41);
            this.frameListBox.Name = "frameListBox";
            this.frameListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.frameListBox.Size = new System.Drawing.Size(120, 160);
            this.frameListBox.TabIndex = 4;
            this.frameListBox.SelectedIndexChanged += new System.EventHandler(this.frameListBox_SelectedIndexChanged);
            // 
            // addSpriteToFrameListButton
            // 
            this.addSpriteToFrameListButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addSpriteToFrameListButton.Location = new System.Drawing.Point(130, 130);
            this.addSpriteToFrameListButton.Name = "addSpriteToFrameListButton";
            this.addSpriteToFrameListButton.Size = new System.Drawing.Size(27, 23);
            this.addSpriteToFrameListButton.TabIndex = 5;
            this.addSpriteToFrameListButton.Text = "→";
            this.addSpriteToFrameListButton.UseVisualStyleBackColor = true;
            this.addSpriteToFrameListButton.Click += new System.EventHandler(this.addSpriteToFrameListButton_Click);
            // 
            // spritePreview
            // 
            this.spritePreview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.spritePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.spritePreview.Location = new System.Drawing.Point(5, 19);
            this.spritePreview.Name = "spritePreview";
            this.spritePreview.Size = new System.Drawing.Size(119, 43);
            this.spritePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.spritePreview.TabIndex = 6;
            this.spritePreview.TabStop = false;
            // 
            // frameTrackBar
            // 
            this.frameTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frameTrackBar.Location = new System.Drawing.Point(3, 339);
            this.frameTrackBar.Name = "frameTrackBar";
            this.frameTrackBar.Size = new System.Drawing.Size(467, 45);
            this.frameTrackBar.TabIndex = 7;
            this.frameTrackBar.Scroll += new System.EventHandler(this.frameTrackBar_Scroll);
            // 
            // delayInputBox
            // 
            this.delayInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delayInputBox.Location = new System.Drawing.Point(200, 254);
            this.delayInputBox.Name = "delayInputBox";
            this.delayInputBox.Size = new System.Drawing.Size(83, 20);
            this.delayInputBox.TabIndex = 8;
            this.delayInputBox.ValueChanged += new System.EventHandler(this.delayInputBox_ValueChanged);
            // 
            // animationBox
            // 
            this.animationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.animationBox.FormattingEnabled = true;
            this.animationBox.Location = new System.Drawing.Point(72, 0);
            this.animationBox.Name = "animationBox";
            this.animationBox.Size = new System.Drawing.Size(121, 21);
            this.animationBox.TabIndex = 9;
            this.animationBox.SelectedIndexChanged += new System.EventHandler(this.animationBox_SelectedIndexChanged);
            // 
            // animationNameBox
            // 
            this.animationNameBox.Location = new System.Drawing.Point(314, 0);
            this.animationNameBox.Name = "animationNameBox";
            this.animationNameBox.Size = new System.Drawing.Size(100, 20);
            this.animationNameBox.TabIndex = 10;
            this.animationNameBox.TextChanged += new System.EventHandler(this.animationNameBox_TextChanged);
            // 
            // playAnimationButton
            // 
            this.playAnimationButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playAnimationButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAnimationButton.Location = new System.Drawing.Point(200, 371);
            this.playAnimationButton.Name = "playAnimationButton";
            this.playAnimationButton.Size = new System.Drawing.Size(75, 23);
            this.playAnimationButton.TabIndex = 11;
            this.playAnimationButton.Text = "| | / ►";
            this.playAnimationButton.UseVisualStyleBackColor = true;
            this.playAnimationButton.Click += new System.EventHandler(this.playAnimationButton_Click);
            // 
            // removeFrameButton
            // 
            this.removeFrameButton.Location = new System.Drawing.Point(257, 18);
            this.removeFrameButton.Name = "removeFrameButton";
            this.removeFrameButton.Size = new System.Drawing.Size(27, 23);
            this.removeFrameButton.TabIndex = 12;
            this.removeFrameButton.Text = "X";
            this.removeFrameButton.UseVisualStyleBackColor = true;
            this.removeFrameButton.Click += new System.EventHandler(this.removeFrameButton_Click);
            // 
            // moveFrameUpButton
            // 
            this.moveFrameUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveFrameUpButton.Location = new System.Drawing.Point(226, 18);
            this.moveFrameUpButton.Name = "moveFrameUpButton";
            this.moveFrameUpButton.Size = new System.Drawing.Size(27, 23);
            this.moveFrameUpButton.TabIndex = 13;
            this.moveFrameUpButton.Text = "↑";
            this.moveFrameUpButton.UseVisualStyleBackColor = true;
            this.moveFrameUpButton.Click += new System.EventHandler(this.moveFrameUpButton_Click);
            // 
            // moveFrameDownButton
            // 
            this.moveFrameDownButton.Location = new System.Drawing.Point(194, 18);
            this.moveFrameDownButton.Name = "moveFrameDownButton";
            this.moveFrameDownButton.Size = new System.Drawing.Size(27, 23);
            this.moveFrameDownButton.TabIndex = 14;
            this.moveFrameDownButton.Text = "↓";
            this.moveFrameDownButton.UseVisualStyleBackColor = true;
            this.moveFrameDownButton.Click += new System.EventHandler(this.moveFrameDownButton_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(764, 24);
            this.mainMenuStrip.TabIndex = 15;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSpriteSheetToolStripMenuItem,
            this.loadSpriteMapToolStripMenuItem,
            this.toolStripMenuItem3,
            this.loadAnimationToolStripMenuItem,
            this.saveAnimationToolStripMenuItem,
            this.toolStripMenuItem2,
            this.loadAnimationSetToolStripMenuItem,
            this.saveAnimationSetToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadSpriteSheetToolStripMenuItem
            // 
            this.loadSpriteSheetToolStripMenuItem.Name = "loadSpriteSheetToolStripMenuItem";
            this.loadSpriteSheetToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.loadSpriteSheetToolStripMenuItem.Text = "Load Sprite Sheet...";
            this.loadSpriteSheetToolStripMenuItem.Click += new System.EventHandler(this.loadSpriteSheetToolStripMenuItem_Click);
            // 
            // loadSpriteMapToolStripMenuItem
            // 
            this.loadSpriteMapToolStripMenuItem.Enabled = false;
            this.loadSpriteMapToolStripMenuItem.Name = "loadSpriteMapToolStripMenuItem";
            this.loadSpriteMapToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.loadSpriteMapToolStripMenuItem.Text = "Load Sprite Map...";
            this.loadSpriteMapToolStripMenuItem.Click += new System.EventHandler(this.loadSpriteMapToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(184, 6);
            // 
            // loadAnimationToolStripMenuItem
            // 
            this.loadAnimationToolStripMenuItem.Enabled = false;
            this.loadAnimationToolStripMenuItem.Name = "loadAnimationToolStripMenuItem";
            this.loadAnimationToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.loadAnimationToolStripMenuItem.Text = "Load Animation...";
            this.loadAnimationToolStripMenuItem.Click += new System.EventHandler(this.loadAnimationToolStripMenuItem_Click);
            // 
            // saveAnimationToolStripMenuItem
            // 
            this.saveAnimationToolStripMenuItem.Enabled = false;
            this.saveAnimationToolStripMenuItem.Name = "saveAnimationToolStripMenuItem";
            this.saveAnimationToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveAnimationToolStripMenuItem.Text = "Save Animation...";
            this.saveAnimationToolStripMenuItem.Click += new System.EventHandler(this.saveAnimationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(184, 6);
            // 
            // loadAnimationSetToolStripMenuItem
            // 
            this.loadAnimationSetToolStripMenuItem.Enabled = false;
            this.loadAnimationSetToolStripMenuItem.Name = "loadAnimationSetToolStripMenuItem";
            this.loadAnimationSetToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.loadAnimationSetToolStripMenuItem.Text = "Load Animation Set...";
            this.loadAnimationSetToolStripMenuItem.Click += new System.EventHandler(this.loadAnimationSetToolStripMenuItem_Click);
            // 
            // saveAnimationSetToolStripMenuItem
            // 
            this.saveAnimationSetToolStripMenuItem.Enabled = false;
            this.saveAnimationSetToolStripMenuItem.Name = "saveAnimationSetToolStripMenuItem";
            this.saveAnimationSetToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveAnimationSetToolStripMenuItem.Text = "Save Animation Set...";
            this.saveAnimationSetToolStripMenuItem.Click += new System.EventHandler(this.saveAnimationSetToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateAnimationSpritesFromSpriteMapToolStripMenuItem});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // updateAnimationSpritesFromSpriteMapToolStripMenuItem
            // 
            this.updateAnimationSpritesFromSpriteMapToolStripMenuItem.Enabled = false;
            this.updateAnimationSpritesFromSpriteMapToolStripMenuItem.Name = "updateAnimationSpritesFromSpriteMapToolStripMenuItem";
            this.updateAnimationSpritesFromSpriteMapToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.updateAnimationSpritesFromSpriteMapToolStripMenuItem.Text = "Update Animation Sprites from SpriteMap...";
            this.updateAnimationSpritesFromSpriteMapToolStripMenuItem.Click += new System.EventHandler(this.updateAnimationSpritesFromSpriteMapToolStripMenuItem_Click);
            // 
            // animationLoopCheckBox
            // 
            this.animationLoopCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.animationLoopCheckBox.AutoSize = true;
            this.animationLoopCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.animationLoopCheckBox.Location = new System.Drawing.Point(420, 2);
            this.animationLoopCheckBox.Name = "animationLoopCheckBox";
            this.animationLoopCheckBox.Size = new System.Drawing.Size(50, 17);
            this.animationLoopCheckBox.TabIndex = 16;
            this.animationLoopCheckBox.Text = "Loop";
            this.animationLoopCheckBox.UseVisualStyleBackColor = true;
            this.animationLoopCheckBox.CheckedChanged += new System.EventHandler(this.animationLoopCheckBox_CheckedChanged);
            // 
            // saveAnimationDialog
            // 
            this.saveAnimationDialog.DefaultExt = "anim";
            this.saveAnimationDialog.Filter = "QUROGames Animation|*.anim";
            // 
            // saveAnimationSetDialog
            // 
            this.saveAnimationSetDialog.DefaultExt = "animset";
            this.saveAnimationSetDialog.Filter = "QUROGames AnimationSet|*.animSet";
            // 
            // loadAnimationDialog
            // 
            this.loadAnimationDialog.DefaultExt = "anim";
            this.loadAnimationDialog.FileName = "openFileDialog1";
            this.loadAnimationDialog.Filter = "QUROGames Animation|*.anim";
            // 
            // addAnimationButton
            // 
            this.addAnimationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAnimationButton.Location = new System.Drawing.Point(200, -1);
            this.addAnimationButton.Name = "addAnimationButton";
            this.addAnimationButton.Size = new System.Drawing.Size(27, 23);
            this.addAnimationButton.TabIndex = 18;
            this.addAnimationButton.Text = "+";
            this.addAnimationButton.UseVisualStyleBackColor = true;
            this.addAnimationButton.Click += new System.EventHandler(this.addAnimationButton_Click);
            // 
            // removeAnimationButton
            // 
            this.removeAnimationButton.Location = new System.Drawing.Point(233, -1);
            this.removeAnimationButton.Name = "removeAnimationButton";
            this.removeAnimationButton.Size = new System.Drawing.Size(27, 23);
            this.removeAnimationButton.TabIndex = 17;
            this.removeAnimationButton.Text = "-";
            this.removeAnimationButton.UseVisualStyleBackColor = true;
            this.removeAnimationButton.Click += new System.EventHandler(this.removeAnimationButton_Click);
            // 
            // frameEditorPanel
            // 
            this.frameEditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.frameEditorPanel.Controls.Add(this.frameNameBox);
            this.frameEditorPanel.Controls.Add(this.frameSpritePanel);
            this.frameEditorPanel.Controls.Add(this.importDelayLabel);
            this.frameEditorPanel.Controls.Add(this.importValuesLabel);
            this.frameEditorPanel.Controls.Add(this.importDelayBox);
            this.frameEditorPanel.Controls.Add(this.frameNameLabel);
            this.frameEditorPanel.Controls.Add(this.delayLabel);
            this.frameEditorPanel.Controls.Add(this.frameInfoLabel);
            this.frameEditorPanel.Controls.Add(this.frameBoxLabel);
            this.frameEditorPanel.Controls.Add(this.spriteBoxLabel);
            this.frameEditorPanel.Controls.Add(this.frameListBox);
            this.frameEditorPanel.Controls.Add(this.spriteListBox);
            this.frameEditorPanel.Controls.Add(this.addSpriteToFrameListButton);
            this.frameEditorPanel.Controls.Add(this.spritePreview);
            this.frameEditorPanel.Controls.Add(this.moveFrameDownButton);
            this.frameEditorPanel.Controls.Add(this.delayInputBox);
            this.frameEditorPanel.Controls.Add(this.moveFrameUpButton);
            this.frameEditorPanel.Controls.Add(this.addEmptyFrameButton);
            this.frameEditorPanel.Controls.Add(this.removeFrameButton);
            this.frameEditorPanel.Enabled = false;
            this.frameEditorPanel.Location = new System.Drawing.Point(0, 27);
            this.frameEditorPanel.Name = "frameEditorPanel";
            this.frameEditorPanel.Size = new System.Drawing.Size(290, 403);
            this.frameEditorPanel.TabIndex = 19;
            // 
            // frameSpritePanel
            // 
            this.frameSpritePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameSpritePanel.Controls.Add(this.removeSpriteButton);
            this.frameSpritePanel.Controls.Add(this.moveSpriteUpButton);
            this.frameSpritePanel.Controls.Add(this.moveSpriteDownButton);
            this.frameSpritePanel.Controls.Add(this.frameSpritePositionLabel);
            this.frameSpritePanel.Controls.Add(this.frameSpriteListBox);
            this.frameSpritePanel.Controls.Add(this.spriteYPosLabel);
            this.frameSpritePanel.Controls.Add(this.spriteXPosLabel);
            this.frameSpritePanel.Controls.Add(this.frameSpriteListLabel);
            this.frameSpritePanel.Controls.Add(this.addSpriteToFrameSpritesButton);
            this.frameSpritePanel.Controls.Add(this.spriteYPosBox);
            this.frameSpritePanel.Controls.Add(this.spriteXPosBox);
            this.frameSpritePanel.Location = new System.Drawing.Point(129, 277);
            this.frameSpritePanel.Name = "frameSpritePanel";
            this.frameSpritePanel.Size = new System.Drawing.Size(161, 126);
            this.frameSpritePanel.TabIndex = 24;
            // 
            // frameSpritePositionLabel
            // 
            this.frameSpritePositionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameSpritePositionLabel.AutoSize = true;
            this.frameSpritePositionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameSpritePositionLabel.Location = new System.Drawing.Point(33, 82);
            this.frameSpritePositionLabel.Name = "frameSpritePositionLabel";
            this.frameSpritePositionLabel.Size = new System.Drawing.Size(86, 13);
            this.frameSpritePositionLabel.TabIndex = 23;
            this.frameSpritePositionLabel.Text = "Sprite Positon";
            // 
            // frameSpriteListBox
            // 
            this.frameSpriteListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameSpriteListBox.FormattingEnabled = true;
            this.frameSpriteListBox.Location = new System.Drawing.Point(34, 23);
            this.frameSpriteListBox.Name = "frameSpriteListBox";
            this.frameSpriteListBox.Size = new System.Drawing.Size(120, 56);
            this.frameSpriteListBox.TabIndex = 22;
            this.frameSpriteListBox.SelectedIndexChanged += new System.EventHandler(this.frameSpriteListBox_SelectedIndexChanged);
            // 
            // spriteYPosLabel
            // 
            this.spriteYPosLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteYPosLabel.AutoSize = true;
            this.spriteYPosLabel.Location = new System.Drawing.Point(94, 102);
            this.spriteYPosLabel.Name = "spriteYPosLabel";
            this.spriteYPosLabel.Size = new System.Drawing.Size(14, 13);
            this.spriteYPosLabel.TabIndex = 18;
            this.spriteYPosLabel.Text = "Y";
            // 
            // spriteXPosLabel
            // 
            this.spriteXPosLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteXPosLabel.AutoSize = true;
            this.spriteXPosLabel.Location = new System.Drawing.Point(33, 102);
            this.spriteXPosLabel.Name = "spriteXPosLabel";
            this.spriteXPosLabel.Size = new System.Drawing.Size(14, 13);
            this.spriteXPosLabel.TabIndex = 18;
            this.spriteXPosLabel.Text = "X";
            // 
            // frameSpriteListLabel
            // 
            this.frameSpriteListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameSpriteListLabel.AutoSize = true;
            this.frameSpriteListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameSpriteListLabel.Location = new System.Drawing.Point(33, 7);
            this.frameSpriteListLabel.Name = "frameSpriteListLabel";
            this.frameSpriteListLabel.Size = new System.Drawing.Size(46, 13);
            this.frameSpriteListLabel.TabIndex = 16;
            this.frameSpriteListLabel.Text = "Sprites";
            // 
            // addSpriteToFrameSpritesButton
            // 
            this.addSpriteToFrameSpritesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addSpriteToFrameSpritesButton.Location = new System.Drawing.Point(1, 36);
            this.addSpriteToFrameSpritesButton.Name = "addSpriteToFrameSpritesButton";
            this.addSpriteToFrameSpritesButton.Size = new System.Drawing.Size(27, 23);
            this.addSpriteToFrameSpritesButton.TabIndex = 5;
            this.addSpriteToFrameSpritesButton.Text = "→";
            this.addSpriteToFrameSpritesButton.UseVisualStyleBackColor = true;
            this.addSpriteToFrameSpritesButton.Click += new System.EventHandler(this.addSpriteToFrameSpritesButton_Click);
            // 
            // spriteYPosBox
            // 
            this.spriteYPosBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteYPosBox.Location = new System.Drawing.Point(109, 100);
            this.spriteYPosBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spriteYPosBox.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.spriteYPosBox.Name = "spriteYPosBox";
            this.spriteYPosBox.Size = new System.Drawing.Size(43, 20);
            this.spriteYPosBox.TabIndex = 8;
            this.spriteYPosBox.ValueChanged += new System.EventHandler(this.spriteYPosBox_ValueChanged);
            // 
            // spriteXPosBox
            // 
            this.spriteXPosBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteXPosBox.Location = new System.Drawing.Point(48, 100);
            this.spriteXPosBox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spriteXPosBox.Minimum = new decimal(new int[] {
            2147483647,
            0,
            0,
            -2147483648});
            this.spriteXPosBox.Name = "spriteXPosBox";
            this.spriteXPosBox.Size = new System.Drawing.Size(43, 20);
            this.spriteXPosBox.TabIndex = 8;
            this.spriteXPosBox.ValueChanged += new System.EventHandler(this.spriteXPosBox_ValueChanged);
            // 
            // importDelayLabel
            // 
            this.importDelayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importDelayLabel.AutoSize = true;
            this.importDelayLabel.Location = new System.Drawing.Point(3, 378);
            this.importDelayLabel.Name = "importDelayLabel";
            this.importDelayLabel.Size = new System.Drawing.Size(34, 13);
            this.importDelayLabel.TabIndex = 21;
            this.importDelayLabel.Text = "Delay";
            // 
            // importValuesLabel
            // 
            this.importValuesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importValuesLabel.AutoSize = true;
            this.importValuesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importValuesLabel.Location = new System.Drawing.Point(3, 355);
            this.importValuesLabel.Name = "importValuesLabel";
            this.importValuesLabel.Size = new System.Drawing.Size(84, 13);
            this.importValuesLabel.TabIndex = 20;
            this.importValuesLabel.Text = "Import Values";
            // 
            // importDelayBox
            // 
            this.importDelayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importDelayBox.Location = new System.Drawing.Point(40, 376);
            this.importDelayBox.Name = "importDelayBox";
            this.importDelayBox.Size = new System.Drawing.Size(83, 20);
            this.importDelayBox.TabIndex = 19;
            this.importDelayBox.ValueChanged += new System.EventHandler(this.importDelayBox_ValueChanged);
            // 
            // delayLabel
            // 
            this.delayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(162, 256);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(34, 13);
            this.delayLabel.TabIndex = 18;
            this.delayLabel.Text = "Delay";
            // 
            // frameInfoLabel
            // 
            this.frameInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameInfoLabel.AutoSize = true;
            this.frameInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameInfoLabel.Location = new System.Drawing.Point(162, 212);
            this.frameInfoLabel.Name = "frameInfoLabel";
            this.frameInfoLabel.Size = new System.Drawing.Size(112, 13);
            this.frameInfoLabel.TabIndex = 17;
            this.frameInfoLabel.Text = "Current Frame Info";
            // 
            // frameBoxLabel
            // 
            this.frameBoxLabel.AutoSize = true;
            this.frameBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameBoxLabel.Location = new System.Drawing.Point(160, 3);
            this.frameBoxLabel.Name = "frameBoxLabel";
            this.frameBoxLabel.Size = new System.Drawing.Size(65, 13);
            this.frameBoxLabel.TabIndex = 16;
            this.frameBoxLabel.Text = "Frame List";
            // 
            // spriteBoxLabel
            // 
            this.spriteBoxLabel.AutoSize = true;
            this.spriteBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spriteBoxLabel.Location = new System.Drawing.Point(3, 3);
            this.spriteBoxLabel.Name = "spriteBoxLabel";
            this.spriteBoxLabel.Size = new System.Drawing.Size(97, 13);
            this.spriteBoxLabel.TabIndex = 15;
            this.spriteBoxLabel.Text = "Sprite Selection";
            // 
            // addEmptyFrameButton
            // 
            this.addEmptyFrameButton.Location = new System.Drawing.Point(162, 18);
            this.addEmptyFrameButton.Name = "addEmptyFrameButton";
            this.addEmptyFrameButton.Size = new System.Drawing.Size(27, 23);
            this.addEmptyFrameButton.TabIndex = 12;
            this.addEmptyFrameButton.Text = "+";
            this.addEmptyFrameButton.UseVisualStyleBackColor = true;
            this.addEmptyFrameButton.Click += new System.EventHandler(this.addEmptyFrameButton_Click);
            // 
            // animationPanel
            // 
            this.animationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationPanel.Controls.Add(this.animationNameLabel);
            this.animationPanel.Controls.Add(this.animationLabel);
            this.animationPanel.Controls.Add(this.playAnimationButton);
            this.animationPanel.Controls.Add(this.animationPreview);
            this.animationPanel.Controls.Add(this.frameTrackBar);
            this.animationPanel.Controls.Add(this.addAnimationButton);
            this.animationPanel.Controls.Add(this.animationBox);
            this.animationPanel.Controls.Add(this.removeAnimationButton);
            this.animationPanel.Controls.Add(this.animationNameBox);
            this.animationPanel.Controls.Add(this.animationLoopCheckBox);
            this.animationPanel.Enabled = false;
            this.animationPanel.Location = new System.Drawing.Point(289, 27);
            this.animationPanel.Name = "animationPanel";
            this.animationPanel.Size = new System.Drawing.Size(475, 403);
            this.animationPanel.TabIndex = 20;
            // 
            // animationNameLabel
            // 
            this.animationNameLabel.AutoSize = true;
            this.animationNameLabel.Location = new System.Drawing.Point(273, 3);
            this.animationNameLabel.Name = "animationNameLabel";
            this.animationNameLabel.Size = new System.Drawing.Size(35, 13);
            this.animationNameLabel.TabIndex = 23;
            this.animationNameLabel.Text = "Name";
            // 
            // animationLabel
            // 
            this.animationLabel.AutoSize = true;
            this.animationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animationLabel.Location = new System.Drawing.Point(4, 3);
            this.animationLabel.Name = "animationLabel";
            this.animationLabel.Size = new System.Drawing.Size(62, 13);
            this.animationLabel.TabIndex = 22;
            this.animationLabel.Text = "Animation";
            // 
            // loadAnimationSetDialog
            // 
            this.loadAnimationSetDialog.DefaultExt = "animset";
            this.loadAnimationSetDialog.FileName = "openFileDialog1";
            this.loadAnimationSetDialog.Filter = "QUROGames AnimationSet|*.animSet";
            // 
            // frameNameBox
            // 
            this.frameNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameNameBox.Location = new System.Drawing.Point(200, 228);
            this.frameNameBox.Name = "frameNameBox";
            this.frameNameBox.Size = new System.Drawing.Size(83, 20);
            this.frameNameBox.TabIndex = 25;
            // 
            // frameNameLabel
            // 
            this.frameNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameNameLabel.AutoSize = true;
            this.frameNameLabel.Location = new System.Drawing.Point(162, 231);
            this.frameNameLabel.Name = "frameNameLabel";
            this.frameNameLabel.Size = new System.Drawing.Size(35, 13);
            this.frameNameLabel.TabIndex = 18;
            this.frameNameLabel.Text = "Name";
            // 
            // moveSpriteDownButton
            // 
            this.moveSpriteDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveSpriteDownButton.Location = new System.Drawing.Point(86, 0);
            this.moveSpriteDownButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.moveSpriteDownButton.Name = "moveSpriteDownButton";
            this.moveSpriteDownButton.Size = new System.Drawing.Size(23, 23);
            this.moveSpriteDownButton.TabIndex = 26;
            this.moveSpriteDownButton.Text = "↓";
            this.moveSpriteDownButton.UseVisualStyleBackColor = true;
            this.moveSpriteDownButton.Click += new System.EventHandler(this.moveSpriteDownButton_Click);
            // 
            // moveSpriteUpButton
            // 
            this.moveSpriteUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveSpriteUpButton.Location = new System.Drawing.Point(109, 0);
            this.moveSpriteUpButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.moveSpriteUpButton.Name = "moveSpriteUpButton";
            this.moveSpriteUpButton.Size = new System.Drawing.Size(23, 23);
            this.moveSpriteUpButton.TabIndex = 26;
            this.moveSpriteUpButton.Text = "↑";
            this.moveSpriteUpButton.UseVisualStyleBackColor = true;
            this.moveSpriteUpButton.Click += new System.EventHandler(this.moveSpriteUpButton_Click);
            // 
            // removeSpriteButton
            // 
            this.removeSpriteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeSpriteButton.Location = new System.Drawing.Point(132, 0);
            this.removeSpriteButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.removeSpriteButton.Name = "removeSpriteButton";
            this.removeSpriteButton.Size = new System.Drawing.Size(23, 23);
            this.removeSpriteButton.TabIndex = 26;
            this.removeSpriteButton.Text = "X";
            this.removeSpriteButton.UseVisualStyleBackColor = true;
            this.removeSpriteButton.Click += new System.EventHandler(this.removeSpriteButton_Click);
            // 
            // animationPreview
            // 
            this.animationPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationPreview.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.animationPreview.Location = new System.Drawing.Point(3, 26);
            this.animationPreview.Name = "animationPreview";
            this.animationPreview.Playing = false;
            this.animationPreview.PreviewSprite = null;
            this.animationPreview.Size = new System.Drawing.Size(467, 306);
            this.animationPreview.SpriteSheet = null;
            this.animationPreview.TabIndex = 0;
            this.animationPreview.Text = "animationPreview1";
            this.animationPreview.ZoomLevel = 0F;
            this.animationPreview.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.animationPreview_MouseWheel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(764, 430);
            this.Controls.Add(this.animationPanel);
            this.Controls.Add(this.frameEditorPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.MinimumSize = new System.Drawing.Size(780, 345);
            this.Name = "Form1";
            this.Text = "QUROGames Animation Studio";
            ((System.ComponentModel.ISupportInitialize)(this.spritePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayInputBox)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.frameEditorPanel.ResumeLayout(false);
            this.frameEditorPanel.PerformLayout();
            this.frameSpritePanel.ResumeLayout(false);
            this.frameSpritePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteYPosBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteXPosBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDelayBox)).EndInit();
            this.animationPanel.ResumeLayout(false);
            this.animationPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AnimationPreview animationPreview;
        private System.Windows.Forms.OpenFileDialog loadSpriteSheetDialog;
        private System.Windows.Forms.OpenFileDialog loadSpriteMapDialog;
        private System.Windows.Forms.ListBox spriteListBox;
        private System.Windows.Forms.ListBox frameListBox;
        private System.Windows.Forms.Button addSpriteToFrameListButton;
        private System.Windows.Forms.PictureBox spritePreview;
        private System.Windows.Forms.TrackBar frameTrackBar;
        private System.Windows.Forms.NumericUpDown delayInputBox;
        private System.Windows.Forms.ComboBox animationBox;
        private System.Windows.Forms.TextBox animationNameBox;
        private System.Windows.Forms.Button playAnimationButton;
        private System.Windows.Forms.Button removeFrameButton;
        private System.Windows.Forms.Button moveFrameUpButton;
        private System.Windows.Forms.Button moveFrameDownButton;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSpriteSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSpriteMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadAnimationSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAnimationSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem loadAnimationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAnimationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.CheckBox animationLoopCheckBox;
        private System.Windows.Forms.SaveFileDialog saveAnimationDialog;
        private System.Windows.Forms.SaveFileDialog saveAnimationSetDialog;
        private System.Windows.Forms.OpenFileDialog loadAnimationDialog;
        private System.Windows.Forms.Button addAnimationButton;
        private System.Windows.Forms.Button removeAnimationButton;
        private System.Windows.Forms.Panel frameEditorPanel;
        private System.Windows.Forms.Label frameBoxLabel;
        private System.Windows.Forms.Label spriteBoxLabel;
        private System.Windows.Forms.Label importDelayLabel;
        private System.Windows.Forms.Label importValuesLabel;
        private System.Windows.Forms.NumericUpDown importDelayBox;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Label frameInfoLabel;
        private System.Windows.Forms.Panel animationPanel;
        private System.Windows.Forms.Label animationLabel;
        private System.Windows.Forms.Label animationNameLabel;
        private System.Windows.Forms.OpenFileDialog loadAnimationSetDialog;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateAnimationSpritesFromSpriteMapToolStripMenuItem;
        private System.Windows.Forms.ListBox frameSpriteListBox;
        private System.Windows.Forms.Label spriteYPosLabel;
        private System.Windows.Forms.Label spriteXPosLabel;
        private System.Windows.Forms.Label frameSpriteListLabel;
        private System.Windows.Forms.Button addSpriteToFrameSpritesButton;
        private System.Windows.Forms.NumericUpDown spriteYPosBox;
        private System.Windows.Forms.NumericUpDown spriteXPosBox;
        private System.Windows.Forms.Panel frameSpritePanel;
        private System.Windows.Forms.Label frameSpritePositionLabel;
        private System.Windows.Forms.Button addEmptyFrameButton;
        private System.Windows.Forms.TextBox frameNameBox;
        private System.Windows.Forms.Label frameNameLabel;
        private System.Windows.Forms.Button removeSpriteButton;
        private System.Windows.Forms.Button moveSpriteUpButton;
        private System.Windows.Forms.Button moveSpriteDownButton;
    }
}

