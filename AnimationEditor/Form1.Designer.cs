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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.loadSpriteSheetDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadSpriteMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.spriteMapListBox = new System.Windows.Forms.ListBox();
            this.frameListBox = new System.Windows.Forms.ListBox();
            this.frameTrackBar = new System.Windows.Forms.TrackBar();
            this.delayInputBox = new System.Windows.Forms.NumericUpDown();
            this.animationBox = new System.Windows.Forms.ComboBox();
            this.animationNameBox = new System.Windows.Forms.TextBox();
            this.playAnimationButton = new System.Windows.Forms.Button();
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
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.updateAnimationSpritesFromSpriteMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animationLoopCheckBox = new System.Windows.Forms.CheckBox();
            this.saveAnimationDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveAnimationSetDialog = new System.Windows.Forms.SaveFileDialog();
            this.loadAnimationDialog = new System.Windows.Forms.OpenFileDialog();
            this.frameEditorPanel = new System.Windows.Forms.Panel();
            this.frameNameBox = new System.Windows.Forms.TextBox();
            this.frameSpritePanel = new System.Windows.Forms.Panel();
            this.spritePosPanel = new System.Windows.Forms.Panel();
            this.frameSpritePositionLabel = new System.Windows.Forms.Label();
            this.spriteYPosLabel = new System.Windows.Forms.Label();
            this.spriteXPosLabel = new System.Windows.Forms.Label();
            this.spriteYPosBox = new System.Windows.Forms.NumericUpDown();
            this.spriteXPosBox = new System.Windows.Forms.NumericUpDown();
            this.frameSpriteListBox = new System.Windows.Forms.ListBox();
            this.frameSpriteListLabel = new System.Windows.Forms.Label();
            this.replaceSpriteButton = new System.Windows.Forms.Button();
            this.importDelayLabel = new System.Windows.Forms.Label();
            this.importValuesLabel = new System.Windows.Forms.Label();
            this.importDelayBox = new System.Windows.Forms.NumericUpDown();
            this.frameNameLabel = new System.Windows.Forms.Label();
            this.delayLabel = new System.Windows.Forms.Label();
            this.frameInfoLabel = new System.Windows.Forms.Label();
            this.frameBoxLabel = new System.Windows.Forms.Label();
            this.spriteBoxLabel = new System.Windows.Forms.Label();
            this.animationPanel = new System.Windows.Forms.Panel();
            this.animationNameLabel = new System.Windows.Forms.Label();
            this.animationLabel = new System.Windows.Forms.Label();
            this.animationPreview = new AnimationEditor.AnimationPreview();
            this.loadAnimationSetDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.addAnimationButton = new System.Windows.Forms.Button();
            this.removeAnimationButton = new System.Windows.Forms.Button();
            this.removeSpriteButton = new System.Windows.Forms.Button();
            this.moveSpriteUpButton = new System.Windows.Forms.Button();
            this.moveSpriteDownButton = new System.Windows.Forms.Button();
            this.addSpriteToFrameSpritesButton = new System.Windows.Forms.Button();
            this.addSpriteToFrameListButton = new System.Windows.Forms.Button();
            this.spritePreview = new System.Windows.Forms.PictureBox();
            this.moveFrameDownButton = new System.Windows.Forms.Button();
            this.moveFrameUpButton = new System.Windows.Forms.Button();
            this.duplicateFrameButton = new System.Windows.Forms.Button();
            this.addEmptyFrameButton = new System.Windows.Forms.Button();
            this.removeFrameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayInputBox)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.frameEditorPanel.SuspendLayout();
            this.frameSpritePanel.SuspendLayout();
            this.spritePosPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteYPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteXPosBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDelayBox)).BeginInit();
            this.animationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritePreview)).BeginInit();
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
            // spriteMapListBox
            // 
            this.spriteMapListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteMapListBox.BackColor = System.Drawing.SystemColors.Window;
            this.spriteMapListBox.FormattingEnabled = true;
            this.spriteMapListBox.Location = new System.Drawing.Point(6, 64);
            this.spriteMapListBox.Name = "spriteMapListBox";
            this.spriteMapListBox.Size = new System.Drawing.Size(119, 290);
            this.spriteMapListBox.TabIndex = 3;
            this.toolTip.SetToolTip(this.spriteMapListBox, "Available Sprites from loaded SpriteMap");
            this.spriteMapListBox.SelectedIndexChanged += new System.EventHandler(this.spriteListBox_SelectedIndexChanged);
            // 
            // frameListBox
            // 
            this.frameListBox.AllowDrop = true;
            this.frameListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.frameListBox.BackColor = System.Drawing.SystemColors.Window;
            this.frameListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.frameListBox.FormattingEnabled = true;
            this.frameListBox.Location = new System.Drawing.Point(164, 41);
            this.frameListBox.Name = "frameListBox";
            this.frameListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.frameListBox.Size = new System.Drawing.Size(120, 134);
            this.frameListBox.TabIndex = 4;
            this.toolTip.SetToolTip(this.frameListBox, "Frames in Current Animation");
            this.frameListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.frameListBox_DrawItem);
            this.frameListBox.SelectedIndexChanged += new System.EventHandler(this.frameListBox_SelectedIndexChanged);
            // 
            // frameTrackBar
            // 
            this.frameTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.frameTrackBar.Location = new System.Drawing.Point(2, 337);
            this.frameTrackBar.Name = "frameTrackBar";
            this.frameTrackBar.Size = new System.Drawing.Size(468, 45);
            this.frameTrackBar.TabIndex = 7;
            this.frameTrackBar.Scroll += new System.EventHandler(this.frameTrackBar_Scroll);
            // 
            // delayInputBox
            // 
            this.delayInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delayInputBox.Location = new System.Drawing.Point(201, 225);
            this.delayInputBox.Name = "delayInputBox";
            this.delayInputBox.Size = new System.Drawing.Size(83, 20);
            this.delayInputBox.TabIndex = 8;
            this.toolTip.SetToolTip(this.delayInputBox, "Delay of selected Frames\r\nDelay determines how many additional \"game frames\" the " +
        "current Frame will be shown for\r\nAssumes the game runs at 60fps");
            this.delayInputBox.ValueChanged += new System.EventHandler(this.delayInputBox_ValueChanged);
            // 
            // animationBox
            // 
            this.animationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.animationBox.FormattingEnabled = true;
            this.animationBox.Location = new System.Drawing.Point(71, 0);
            this.animationBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.animationBox.Name = "animationBox";
            this.animationBox.Size = new System.Drawing.Size(121, 21);
            this.animationBox.TabIndex = 9;
            this.toolTip.SetToolTip(this.animationBox, "Currently viewed Animation");
            this.animationBox.SelectedIndexChanged += new System.EventHandler(this.animationBox_SelectedIndexChanged);
            // 
            // animationNameBox
            // 
            this.animationNameBox.Location = new System.Drawing.Point(313, 0);
            this.animationNameBox.Name = "animationNameBox";
            this.animationNameBox.Size = new System.Drawing.Size(100, 20);
            this.animationNameBox.TabIndex = 10;
            this.toolTip.SetToolTip(this.animationNameBox, "Name of current Animation");
            this.animationNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.animationNameBox_KeyPress);
            this.animationNameBox.Leave += new System.EventHandler(this.animationNameBox_Leave);
            // 
            // playAnimationButton
            // 
            this.playAnimationButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playAnimationButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAnimationButton.Image = global::AnimationEditor.Properties.Resources.play;
            this.playAnimationButton.Location = new System.Drawing.Point(199, 369);
            this.playAnimationButton.Name = "playAnimationButton";
            this.playAnimationButton.Size = new System.Drawing.Size(75, 23);
            this.playAnimationButton.TabIndex = 11;
            this.toolTip.SetToolTip(this.playAnimationButton, "Play/Pause Animation");
            this.playAnimationButton.UseVisualStyleBackColor = true;
            this.playAnimationButton.Click += new System.EventHandler(this.playAnimationButton_Click);
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
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.updateAnimationSpritesFromSpriteMapToolStripMenuItem});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.undoToolStripMenuItem.Text = "Undo...";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(304, 22);
            this.redoToolStripMenuItem.Text = "Redo...";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(301, 6);
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
            this.animationLoopCheckBox.Location = new System.Drawing.Point(418, 2);
            this.animationLoopCheckBox.Name = "animationLoopCheckBox";
            this.animationLoopCheckBox.Size = new System.Drawing.Size(50, 17);
            this.animationLoopCheckBox.TabIndex = 16;
            this.animationLoopCheckBox.Text = "Loop";
            this.toolTip.SetToolTip(this.animationLoopCheckBox, "Does this Animation Loop?");
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
            // frameEditorPanel
            // 
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
            this.frameEditorPanel.Controls.Add(this.spriteMapListBox);
            this.frameEditorPanel.Controls.Add(this.addSpriteToFrameListButton);
            this.frameEditorPanel.Controls.Add(this.spritePreview);
            this.frameEditorPanel.Controls.Add(this.moveFrameDownButton);
            this.frameEditorPanel.Controls.Add(this.delayInputBox);
            this.frameEditorPanel.Controls.Add(this.moveFrameUpButton);
            this.frameEditorPanel.Controls.Add(this.duplicateFrameButton);
            this.frameEditorPanel.Controls.Add(this.addEmptyFrameButton);
            this.frameEditorPanel.Controls.Add(this.removeFrameButton);
            this.frameEditorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.frameEditorPanel.Enabled = false;
            this.frameEditorPanel.Location = new System.Drawing.Point(0, 24);
            this.frameEditorPanel.Name = "frameEditorPanel";
            this.frameEditorPanel.Size = new System.Drawing.Size(290, 401);
            this.frameEditorPanel.TabIndex = 19;
            // 
            // frameNameBox
            // 
            this.frameNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameNameBox.Location = new System.Drawing.Point(201, 199);
            this.frameNameBox.Name = "frameNameBox";
            this.frameNameBox.Size = new System.Drawing.Size(83, 20);
            this.frameNameBox.TabIndex = 25;
            this.toolTip.SetToolTip(this.frameNameBox, "Name of selected Sprite(s)");
            this.frameNameBox.TextChanged += new System.EventHandler(this.frameNameBox_TextChanged);
            this.frameNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frameNameBox_KeyPress);
            this.frameNameBox.Leave += new System.EventHandler(this.frameNameBox_Leave);
            // 
            // frameSpritePanel
            // 
            this.frameSpritePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameSpritePanel.Controls.Add(this.spritePosPanel);
            this.frameSpritePanel.Controls.Add(this.removeSpriteButton);
            this.frameSpritePanel.Controls.Add(this.moveSpriteUpButton);
            this.frameSpritePanel.Controls.Add(this.moveSpriteDownButton);
            this.frameSpritePanel.Controls.Add(this.frameSpriteListBox);
            this.frameSpritePanel.Controls.Add(this.frameSpriteListLabel);
            this.frameSpritePanel.Controls.Add(this.replaceSpriteButton);
            this.frameSpritePanel.Controls.Add(this.addSpriteToFrameSpritesButton);
            this.frameSpritePanel.Location = new System.Drawing.Point(130, 246);
            this.frameSpritePanel.Name = "frameSpritePanel";
            this.frameSpritePanel.Size = new System.Drawing.Size(161, 155);
            this.frameSpritePanel.TabIndex = 24;
            // 
            // spritePosPanel
            // 
            this.spritePosPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.spritePosPanel.Controls.Add(this.frameSpritePositionLabel);
            this.spritePosPanel.Controls.Add(this.spriteYPosLabel);
            this.spritePosPanel.Controls.Add(this.spriteXPosLabel);
            this.spritePosPanel.Controls.Add(this.spriteYPosBox);
            this.spritePosPanel.Controls.Add(this.spriteXPosBox);
            this.spritePosPanel.Location = new System.Drawing.Point(32, 110);
            this.spritePosPanel.Name = "spritePosPanel";
            this.spritePosPanel.Size = new System.Drawing.Size(128, 44);
            this.spritePosPanel.TabIndex = 27;
            // 
            // frameSpritePositionLabel
            // 
            this.frameSpritePositionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameSpritePositionLabel.AutoSize = true;
            this.frameSpritePositionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameSpritePositionLabel.Location = new System.Drawing.Point(1, 1);
            this.frameSpritePositionLabel.Name = "frameSpritePositionLabel";
            this.frameSpritePositionLabel.Size = new System.Drawing.Size(86, 13);
            this.frameSpritePositionLabel.TabIndex = 23;
            this.frameSpritePositionLabel.Text = "Sprite Positon";
            // 
            // spriteYPosLabel
            // 
            this.spriteYPosLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteYPosLabel.AutoSize = true;
            this.spriteYPosLabel.Location = new System.Drawing.Point(62, 21);
            this.spriteYPosLabel.Name = "spriteYPosLabel";
            this.spriteYPosLabel.Size = new System.Drawing.Size(14, 13);
            this.spriteYPosLabel.TabIndex = 18;
            this.spriteYPosLabel.Text = "Y";
            // 
            // spriteXPosLabel
            // 
            this.spriteXPosLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteXPosLabel.AutoSize = true;
            this.spriteXPosLabel.Location = new System.Drawing.Point(1, 21);
            this.spriteXPosLabel.Name = "spriteXPosLabel";
            this.spriteXPosLabel.Size = new System.Drawing.Size(14, 13);
            this.spriteXPosLabel.TabIndex = 18;
            this.spriteXPosLabel.Text = "X";
            // 
            // spriteYPosBox
            // 
            this.spriteYPosBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteYPosBox.Location = new System.Drawing.Point(77, 19);
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
            this.toolTip.SetToolTip(this.spriteYPosBox, "Y Offset of selected Sprite in current Frame");
            this.spriteYPosBox.ValueChanged += new System.EventHandler(this.spriteYPosBox_ValueChanged);
            // 
            // spriteXPosBox
            // 
            this.spriteXPosBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spriteXPosBox.Location = new System.Drawing.Point(16, 19);
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
            this.toolTip.SetToolTip(this.spriteXPosBox, "X Offset of selected Sprite in current Frame");
            this.spriteXPosBox.ValueChanged += new System.EventHandler(this.spriteXPosBox_ValueChanged);
            // 
            // frameSpriteListBox
            // 
            this.frameSpriteListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameSpriteListBox.FormattingEnabled = true;
            this.frameSpriteListBox.Location = new System.Drawing.Point(34, 26);
            this.frameSpriteListBox.Name = "frameSpriteListBox";
            this.frameSpriteListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.frameSpriteListBox.Size = new System.Drawing.Size(120, 82);
            this.frameSpriteListBox.TabIndex = 22;
            this.toolTip.SetToolTip(this.frameSpriteListBox, "Sprites shown in Current Frame");
            this.frameSpriteListBox.SelectedIndexChanged += new System.EventHandler(this.frameSpriteListBox_SelectedIndexChanged);
            // 
            // frameSpriteListLabel
            // 
            this.frameSpriteListLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameSpriteListLabel.AutoSize = true;
            this.frameSpriteListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameSpriteListLabel.Location = new System.Drawing.Point(33, 10);
            this.frameSpriteListLabel.Name = "frameSpriteListLabel";
            this.frameSpriteListLabel.Size = new System.Drawing.Size(46, 13);
            this.frameSpriteListLabel.TabIndex = 16;
            this.frameSpriteListLabel.Text = "Sprites";
            // 
            // replaceSpriteButton
            // 
            this.replaceSpriteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.replaceSpriteButton.Enabled = false;
            this.replaceSpriteButton.Image = global::AnimationEditor.Properties.Resources.replace;
            this.replaceSpriteButton.Location = new System.Drawing.Point(1, 49);
            this.replaceSpriteButton.Name = "replaceSpriteButton";
            this.replaceSpriteButton.Size = new System.Drawing.Size(27, 23);
            this.replaceSpriteButton.TabIndex = 5;
            this.replaceSpriteButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.replaceSpriteButton, "Replace selected Sprite in Frame with selected Sprite from SpriteMap");
            this.replaceSpriteButton.UseVisualStyleBackColor = true;
            this.replaceSpriteButton.Click += new System.EventHandler(this.replaceSpriteButton_Click);
            // 
            // importDelayLabel
            // 
            this.importDelayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importDelayLabel.AutoSize = true;
            this.importDelayLabel.Location = new System.Drawing.Point(4, 376);
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
            this.importValuesLabel.Location = new System.Drawing.Point(4, 357);
            this.importValuesLabel.Name = "importValuesLabel";
            this.importValuesLabel.Size = new System.Drawing.Size(84, 13);
            this.importValuesLabel.TabIndex = 20;
            this.importValuesLabel.Text = "Import Values";
            // 
            // importDelayBox
            // 
            this.importDelayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importDelayBox.Location = new System.Drawing.Point(41, 374);
            this.importDelayBox.Name = "importDelayBox";
            this.importDelayBox.Size = new System.Drawing.Size(83, 20);
            this.importDelayBox.TabIndex = 19;
            this.toolTip.SetToolTip(this.importDelayBox, "Default delay for new Frames\r\nDelay determines how many additional \"game frames\" " +
        "the current frame will be shown for\r\nAssumes the game runs at 60fps");
            this.importDelayBox.ValueChanged += new System.EventHandler(this.importDelayBox_ValueChanged);
            // 
            // frameNameLabel
            // 
            this.frameNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameNameLabel.AutoSize = true;
            this.frameNameLabel.Location = new System.Drawing.Point(163, 202);
            this.frameNameLabel.Name = "frameNameLabel";
            this.frameNameLabel.Size = new System.Drawing.Size(35, 13);
            this.frameNameLabel.TabIndex = 18;
            this.frameNameLabel.Text = "Name";
            // 
            // delayLabel
            // 
            this.delayLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(163, 227);
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
            this.frameInfoLabel.Location = new System.Drawing.Point(163, 183);
            this.frameInfoLabel.Name = "frameInfoLabel";
            this.frameInfoLabel.Size = new System.Drawing.Size(112, 13);
            this.frameInfoLabel.TabIndex = 17;
            this.frameInfoLabel.Text = "Current Frame Info";
            // 
            // frameBoxLabel
            // 
            this.frameBoxLabel.AutoSize = true;
            this.frameBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameBoxLabel.Location = new System.Drawing.Point(161, 3);
            this.frameBoxLabel.Name = "frameBoxLabel";
            this.frameBoxLabel.Size = new System.Drawing.Size(65, 13);
            this.frameBoxLabel.TabIndex = 16;
            this.frameBoxLabel.Text = "Frame List";
            // 
            // spriteBoxLabel
            // 
            this.spriteBoxLabel.AutoSize = true;
            this.spriteBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spriteBoxLabel.Location = new System.Drawing.Point(4, 3);
            this.spriteBoxLabel.Name = "spriteBoxLabel";
            this.spriteBoxLabel.Size = new System.Drawing.Size(64, 13);
            this.spriteBoxLabel.TabIndex = 15;
            this.spriteBoxLabel.Text = "SpriteMap";
            // 
            // animationPanel
            // 
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
            this.animationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animationPanel.Enabled = false;
            this.animationPanel.Location = new System.Drawing.Point(290, 24);
            this.animationPanel.Name = "animationPanel";
            this.animationPanel.Size = new System.Drawing.Size(474, 401);
            this.animationPanel.TabIndex = 20;
            // 
            // animationNameLabel
            // 
            this.animationNameLabel.AutoSize = true;
            this.animationNameLabel.Location = new System.Drawing.Point(272, 3);
            this.animationNameLabel.Name = "animationNameLabel";
            this.animationNameLabel.Size = new System.Drawing.Size(35, 13);
            this.animationNameLabel.TabIndex = 23;
            this.animationNameLabel.Text = "Name";
            // 
            // animationLabel
            // 
            this.animationLabel.AutoSize = true;
            this.animationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.animationLabel.Location = new System.Drawing.Point(3, 3);
            this.animationLabel.Name = "animationLabel";
            this.animationLabel.Size = new System.Drawing.Size(62, 13);
            this.animationLabel.TabIndex = 22;
            this.animationLabel.Text = "Animation";
            // 
            // animationPreview
            // 
            this.animationPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animationPreview.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.animationPreview.EditSprites = null;
            this.animationPreview.GridSpacing = 0;
            this.animationPreview.Location = new System.Drawing.Point(2, 26);
            this.animationPreview.Name = "animationPreview";
            this.animationPreview.PixelGridDisplayLevel = 0;
            this.animationPreview.Playing = false;
            this.animationPreview.PreviewSprite = null;
            this.animationPreview.Size = new System.Drawing.Size(466, 304);
            this.animationPreview.SpriteSheet = null;
            this.animationPreview.TabIndex = 0;
            this.animationPreview.Text = "animationPreview1";
            this.animationPreview.ZoomLevel = 0F;
            this.animationPreview.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.animationPreview_MouseWheel);
            // 
            // loadAnimationSetDialog
            // 
            this.loadAnimationSetDialog.DefaultExt = "animset";
            this.loadAnimationSetDialog.FileName = "openFileDialog1";
            this.loadAnimationSetDialog.Filter = "QUROGames AnimationSet|*.animSet";
            // 
            // addAnimationButton
            // 
            this.addAnimationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAnimationButton.Image = ((System.Drawing.Image)(resources.GetObject("addAnimationButton.Image")));
            this.addAnimationButton.Location = new System.Drawing.Point(193, -1);
            this.addAnimationButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.addAnimationButton.Name = "addAnimationButton";
            this.addAnimationButton.Size = new System.Drawing.Size(27, 23);
            this.addAnimationButton.TabIndex = 18;
            this.toolTip.SetToolTip(this.addAnimationButton, "Add new Animation");
            this.addAnimationButton.UseVisualStyleBackColor = true;
            this.addAnimationButton.Click += new System.EventHandler(this.addAnimationButton_Click);
            // 
            // removeAnimationButton
            // 
            this.removeAnimationButton.Image = ((System.Drawing.Image)(resources.GetObject("removeAnimationButton.Image")));
            this.removeAnimationButton.Location = new System.Drawing.Point(220, -1);
            this.removeAnimationButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.removeAnimationButton.Name = "removeAnimationButton";
            this.removeAnimationButton.Size = new System.Drawing.Size(27, 23);
            this.removeAnimationButton.TabIndex = 17;
            this.toolTip.SetToolTip(this.removeAnimationButton, "Delete current Animation");
            this.removeAnimationButton.UseVisualStyleBackColor = true;
            this.removeAnimationButton.Click += new System.EventHandler(this.removeAnimationButton_Click);
            // 
            // removeSpriteButton
            // 
            this.removeSpriteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeSpriteButton.Image = ((System.Drawing.Image)(resources.GetObject("removeSpriteButton.Image")));
            this.removeSpriteButton.Location = new System.Drawing.Point(132, 3);
            this.removeSpriteButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.removeSpriteButton.Name = "removeSpriteButton";
            this.removeSpriteButton.Size = new System.Drawing.Size(23, 23);
            this.removeSpriteButton.TabIndex = 26;
            this.toolTip.SetToolTip(this.removeSpriteButton, "Delete Sprite");
            this.removeSpriteButton.UseVisualStyleBackColor = true;
            this.removeSpriteButton.Click += new System.EventHandler(this.removeSpriteButton_Click);
            // 
            // moveSpriteUpButton
            // 
            this.moveSpriteUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveSpriteUpButton.Image = ((System.Drawing.Image)(resources.GetObject("moveSpriteUpButton.Image")));
            this.moveSpriteUpButton.Location = new System.Drawing.Point(109, 3);
            this.moveSpriteUpButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.moveSpriteUpButton.Name = "moveSpriteUpButton";
            this.moveSpriteUpButton.Size = new System.Drawing.Size(23, 23);
            this.moveSpriteUpButton.TabIndex = 26;
            this.toolTip.SetToolTip(this.moveSpriteUpButton, "Move Sprite Up");
            this.moveSpriteUpButton.UseVisualStyleBackColor = true;
            this.moveSpriteUpButton.Click += new System.EventHandler(this.moveSpriteUpButton_Click);
            // 
            // moveSpriteDownButton
            // 
            this.moveSpriteDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.moveSpriteDownButton.Image = global::AnimationEditor.Properties.Resources.movedown;
            this.moveSpriteDownButton.Location = new System.Drawing.Point(86, 3);
            this.moveSpriteDownButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.moveSpriteDownButton.Name = "moveSpriteDownButton";
            this.moveSpriteDownButton.Size = new System.Drawing.Size(23, 23);
            this.moveSpriteDownButton.TabIndex = 26;
            this.toolTip.SetToolTip(this.moveSpriteDownButton, "Move Sprite Down");
            this.moveSpriteDownButton.UseVisualStyleBackColor = true;
            this.moveSpriteDownButton.Click += new System.EventHandler(this.moveSpriteDownButton_Click);
            // 
            // addSpriteToFrameSpritesButton
            // 
            this.addSpriteToFrameSpritesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addSpriteToFrameSpritesButton.Enabled = false;
            this.addSpriteToFrameSpritesButton.Image = ((System.Drawing.Image)(resources.GetObject("addSpriteToFrameSpritesButton.Image")));
            this.addSpriteToFrameSpritesButton.Location = new System.Drawing.Point(1, 26);
            this.addSpriteToFrameSpritesButton.Name = "addSpriteToFrameSpritesButton";
            this.addSpriteToFrameSpritesButton.Size = new System.Drawing.Size(27, 23);
            this.addSpriteToFrameSpritesButton.TabIndex = 5;
            this.toolTip.SetToolTip(this.addSpriteToFrameSpritesButton, "Add selected Sprite from SpriteMap to Current Frame\'s Sprites");
            this.addSpriteToFrameSpritesButton.UseVisualStyleBackColor = true;
            this.addSpriteToFrameSpritesButton.Click += new System.EventHandler(this.addSpriteToFrameSpritesButton_Click);
            // 
            // addSpriteToFrameListButton
            // 
            this.addSpriteToFrameListButton.Enabled = false;
            this.addSpriteToFrameListButton.Image = ((System.Drawing.Image)(resources.GetObject("addSpriteToFrameListButton.Image")));
            this.addSpriteToFrameListButton.Location = new System.Drawing.Point(131, 61);
            this.addSpriteToFrameListButton.Name = "addSpriteToFrameListButton";
            this.addSpriteToFrameListButton.Size = new System.Drawing.Size(27, 23);
            this.addSpriteToFrameListButton.TabIndex = 5;
            this.toolTip.SetToolTip(this.addSpriteToFrameListButton, "Add selected Sprite from SpriteMap as new Frame");
            this.addSpriteToFrameListButton.UseVisualStyleBackColor = true;
            this.addSpriteToFrameListButton.Click += new System.EventHandler(this.addSpriteToFrameListButton_Click);
            // 
            // spritePreview
            // 
            this.spritePreview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.spritePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.spritePreview.Location = new System.Drawing.Point(6, 19);
            this.spritePreview.Name = "spritePreview";
            this.spritePreview.Size = new System.Drawing.Size(119, 46);
            this.spritePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.spritePreview.TabIndex = 6;
            this.spritePreview.TabStop = false;
            // 
            // moveFrameDownButton
            // 
            this.moveFrameDownButton.Image = global::AnimationEditor.Properties.Resources.movedown;
            this.moveFrameDownButton.Location = new System.Drawing.Point(216, 18);
            this.moveFrameDownButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.moveFrameDownButton.Name = "moveFrameDownButton";
            this.moveFrameDownButton.Size = new System.Drawing.Size(23, 23);
            this.moveFrameDownButton.TabIndex = 14;
            this.toolTip.SetToolTip(this.moveFrameDownButton, "Move Frame Down");
            this.moveFrameDownButton.UseVisualStyleBackColor = true;
            this.moveFrameDownButton.Click += new System.EventHandler(this.moveFrameDownButton_Click);
            // 
            // moveFrameUpButton
            // 
            this.moveFrameUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveFrameUpButton.Image = ((System.Drawing.Image)(resources.GetObject("moveFrameUpButton.Image")));
            this.moveFrameUpButton.Location = new System.Drawing.Point(239, 18);
            this.moveFrameUpButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.moveFrameUpButton.Name = "moveFrameUpButton";
            this.moveFrameUpButton.Size = new System.Drawing.Size(23, 23);
            this.moveFrameUpButton.TabIndex = 13;
            this.toolTip.SetToolTip(this.moveFrameUpButton, "Move Frame Up");
            this.moveFrameUpButton.UseVisualStyleBackColor = true;
            this.moveFrameUpButton.Click += new System.EventHandler(this.moveFrameUpButton_Click);
            // 
            // duplicateFrameButton
            // 
            this.duplicateFrameButton.Image = ((System.Drawing.Image)(resources.GetObject("duplicateFrameButton.Image")));
            this.duplicateFrameButton.Location = new System.Drawing.Point(193, 18);
            this.duplicateFrameButton.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.duplicateFrameButton.Name = "duplicateFrameButton";
            this.duplicateFrameButton.Size = new System.Drawing.Size(23, 23);
            this.duplicateFrameButton.TabIndex = 12;
            this.toolTip.SetToolTip(this.duplicateFrameButton, "Duplicate Frame");
            this.duplicateFrameButton.UseVisualStyleBackColor = true;
            this.duplicateFrameButton.Click += new System.EventHandler(this.duplicateFrameButton_Click);
            // 
            // addEmptyFrameButton
            // 
            this.addEmptyFrameButton.Image = ((System.Drawing.Image)(resources.GetObject("addEmptyFrameButton.Image")));
            this.addEmptyFrameButton.Location = new System.Drawing.Point(170, 18);
            this.addEmptyFrameButton.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.addEmptyFrameButton.Name = "addEmptyFrameButton";
            this.addEmptyFrameButton.Size = new System.Drawing.Size(23, 23);
            this.addEmptyFrameButton.TabIndex = 12;
            this.toolTip.SetToolTip(this.addEmptyFrameButton, "Add Empty Frame");
            this.addEmptyFrameButton.UseVisualStyleBackColor = true;
            this.addEmptyFrameButton.Click += new System.EventHandler(this.addEmptyFrameButton_Click);
            // 
            // removeFrameButton
            // 
            this.removeFrameButton.Image = ((System.Drawing.Image)(resources.GetObject("removeFrameButton.Image")));
            this.removeFrameButton.Location = new System.Drawing.Point(262, 18);
            this.removeFrameButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.removeFrameButton.Name = "removeFrameButton";
            this.removeFrameButton.Size = new System.Drawing.Size(23, 23);
            this.removeFrameButton.TabIndex = 12;
            this.toolTip.SetToolTip(this.removeFrameButton, "Delete Frame");
            this.removeFrameButton.UseVisualStyleBackColor = true;
            this.removeFrameButton.Click += new System.EventHandler(this.removeFrameButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(764, 425);
            this.Controls.Add(this.animationPanel);
            this.Controls.Add(this.frameEditorPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(780, 464);
            this.Name = "Form1";
            this.Text = "QUROGames Animation Studio";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayInputBox)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.frameEditorPanel.ResumeLayout(false);
            this.frameEditorPanel.PerformLayout();
            this.frameSpritePanel.ResumeLayout(false);
            this.frameSpritePanel.PerformLayout();
            this.spritePosPanel.ResumeLayout(false);
            this.spritePosPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteYPosBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spriteXPosBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.importDelayBox)).EndInit();
            this.animationPanel.ResumeLayout(false);
            this.animationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spritePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AnimationPreview animationPreview;
        private System.Windows.Forms.OpenFileDialog loadSpriteSheetDialog;
        private System.Windows.Forms.OpenFileDialog loadSpriteMapDialog;
        private System.Windows.Forms.ListBox spriteMapListBox;
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
        private System.Windows.Forms.Button duplicateFrameButton;
        private System.Windows.Forms.Button replaceSpriteButton;
        private System.Windows.Forms.Panel spritePosPanel;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}

