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
            this.animationLoopCheckBox = new System.Windows.Forms.CheckBox();
            this.saveAnimationDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveAnimationSetDialog = new System.Windows.Forms.SaveFileDialog();
            this.loadAnimationDialog = new System.Windows.Forms.OpenFileDialog();
            this.addAnimationButton = new System.Windows.Forms.Button();
            this.removeAnimationButton = new System.Windows.Forms.Button();
            this.frameEditorPanel = new System.Windows.Forms.Panel();
            this.importDelayLabel = new System.Windows.Forms.Label();
            this.importValuesLabel = new System.Windows.Forms.Label();
            this.importDelayBox = new System.Windows.Forms.NumericUpDown();
            this.delayLabel = new System.Windows.Forms.Label();
            this.frameInfoLabel = new System.Windows.Forms.Label();
            this.frameBoxLabel = new System.Windows.Forms.Label();
            this.spriteBoxLabel = new System.Windows.Forms.Label();
            this.animationPanel = new System.Windows.Forms.Panel();
            this.animationNameLabel = new System.Windows.Forms.Label();
            this.animationLabel = new System.Windows.Forms.Label();
            this.animationPreview = new AnimationEditor.AnimationPreview();
            this.loadAnimationSetDialog = new System.Windows.Forms.OpenFileDialog();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAnimationSpritesFromSpriteMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.spritePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayInputBox)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.frameEditorPanel.SuspendLayout();
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
            this.spriteListBox.BackColor = System.Drawing.SystemColors.Window;
            this.spriteListBox.Enabled = false;
            this.spriteListBox.FormattingEnabled = true;
            this.spriteListBox.Location = new System.Drawing.Point(5, 62);
            this.spriteListBox.Name = "spriteListBox";
            this.spriteListBox.Size = new System.Drawing.Size(119, 303);
            this.spriteListBox.TabIndex = 3;
            this.spriteListBox.SelectedIndexChanged += new System.EventHandler(this.spriteListBox_SelectedIndexChanged);
            // 
            // frameListBox
            // 
            this.frameListBox.AllowDrop = true;
            this.frameListBox.BackColor = System.Drawing.SystemColors.Window;
            this.frameListBox.Enabled = false;
            this.frameListBox.FormattingEnabled = true;
            this.frameListBox.Location = new System.Drawing.Point(163, 62);
            this.frameListBox.Name = "frameListBox";
            this.frameListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.frameListBox.Size = new System.Drawing.Size(120, 303);
            this.frameListBox.TabIndex = 4;
            this.frameListBox.SelectedIndexChanged += new System.EventHandler(this.frameListBox_SelectedIndexChanged);
            // 
            // addSpriteToFrameListButton
            // 
            this.addSpriteToFrameListButton.Enabled = false;
            this.addSpriteToFrameListButton.Location = new System.Drawing.Point(130, 212);
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
            this.spritePreview.Enabled = false;
            this.spritePreview.Location = new System.Drawing.Point(5, 19);
            this.spritePreview.Name = "spritePreview";
            this.spritePreview.Size = new System.Drawing.Size(119, 43);
            this.spritePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.spritePreview.TabIndex = 6;
            this.spritePreview.TabStop = false;
            // 
            // frameTrackBar
            // 
            this.frameTrackBar.Enabled = false;
            this.frameTrackBar.Location = new System.Drawing.Point(3, 359);
            this.frameTrackBar.Name = "frameTrackBar";
            this.frameTrackBar.Size = new System.Drawing.Size(466, 45);
            this.frameTrackBar.TabIndex = 7;
            this.frameTrackBar.Scroll += new System.EventHandler(this.frameTrackBar_Scroll);
            // 
            // delayInputBox
            // 
            this.delayInputBox.Enabled = false;
            this.delayInputBox.Location = new System.Drawing.Point(198, 393);
            this.delayInputBox.Name = "delayInputBox";
            this.delayInputBox.Size = new System.Drawing.Size(83, 20);
            this.delayInputBox.TabIndex = 8;
            this.delayInputBox.ValueChanged += new System.EventHandler(this.delayInputBox_ValueChanged);
            // 
            // animationBox
            // 
            this.animationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.animationBox.Enabled = false;
            this.animationBox.FormattingEnabled = true;
            this.animationBox.Location = new System.Drawing.Point(71, 0);
            this.animationBox.Name = "animationBox";
            this.animationBox.Size = new System.Drawing.Size(121, 21);
            this.animationBox.TabIndex = 9;
            this.animationBox.SelectedIndexChanged += new System.EventHandler(this.animationBox_SelectedIndexChanged);
            // 
            // animationNameBox
            // 
            this.animationNameBox.Enabled = false;
            this.animationNameBox.Location = new System.Drawing.Point(313, 0);
            this.animationNameBox.Name = "animationNameBox";
            this.animationNameBox.Size = new System.Drawing.Size(100, 20);
            this.animationNameBox.TabIndex = 10;
            this.animationNameBox.TextChanged += new System.EventHandler(this.animationNameBox_TextChanged);
            // 
            // playAnimationButton
            // 
            this.playAnimationButton.Enabled = false;
            this.playAnimationButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playAnimationButton.Location = new System.Drawing.Point(200, 391);
            this.playAnimationButton.Name = "playAnimationButton";
            this.playAnimationButton.Size = new System.Drawing.Size(75, 23);
            this.playAnimationButton.TabIndex = 11;
            this.playAnimationButton.Text = "| | / ►";
            this.playAnimationButton.UseVisualStyleBackColor = true;
            this.playAnimationButton.Click += new System.EventHandler(this.playAnimationButton_Click);
            // 
            // removeFrameButton
            // 
            this.removeFrameButton.Enabled = false;
            this.removeFrameButton.Location = new System.Drawing.Point(256, 26);
            this.removeFrameButton.Name = "removeFrameButton";
            this.removeFrameButton.Size = new System.Drawing.Size(27, 23);
            this.removeFrameButton.TabIndex = 12;
            this.removeFrameButton.Text = "X";
            this.removeFrameButton.UseVisualStyleBackColor = true;
            this.removeFrameButton.Click += new System.EventHandler(this.removeFrameButton_Click);
            // 
            // moveFrameUpButton
            // 
            this.moveFrameUpButton.Enabled = false;
            this.moveFrameUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveFrameUpButton.Location = new System.Drawing.Point(223, 26);
            this.moveFrameUpButton.Name = "moveFrameUpButton";
            this.moveFrameUpButton.Size = new System.Drawing.Size(27, 23);
            this.moveFrameUpButton.TabIndex = 13;
            this.moveFrameUpButton.Text = "↑";
            this.moveFrameUpButton.UseVisualStyleBackColor = true;
            this.moveFrameUpButton.Click += new System.EventHandler(this.moveFrameUpButton_Click);
            // 
            // moveFrameDownButton
            // 
            this.moveFrameDownButton.Enabled = false;
            this.moveFrameDownButton.Location = new System.Drawing.Point(190, 26);
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
            this.mainMenuStrip.Size = new System.Drawing.Size(763, 24);
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
            // animationLoopCheckBox
            // 
            this.animationLoopCheckBox.AutoSize = true;
            this.animationLoopCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.animationLoopCheckBox.Enabled = false;
            this.animationLoopCheckBox.Location = new System.Drawing.Point(419, 2);
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
            this.addAnimationButton.Enabled = false;
            this.addAnimationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAnimationButton.Location = new System.Drawing.Point(199, -1);
            this.addAnimationButton.Name = "addAnimationButton";
            this.addAnimationButton.Size = new System.Drawing.Size(27, 23);
            this.addAnimationButton.TabIndex = 18;
            this.addAnimationButton.Text = "+";
            this.addAnimationButton.UseVisualStyleBackColor = true;
            this.addAnimationButton.Click += new System.EventHandler(this.addAnimationButton_Click);
            // 
            // removeAnimationButton
            // 
            this.removeAnimationButton.Enabled = false;
            this.removeAnimationButton.Location = new System.Drawing.Point(232, -1);
            this.removeAnimationButton.Name = "removeAnimationButton";
            this.removeAnimationButton.Size = new System.Drawing.Size(27, 23);
            this.removeAnimationButton.TabIndex = 17;
            this.removeAnimationButton.Text = "-";
            this.removeAnimationButton.UseVisualStyleBackColor = true;
            this.removeAnimationButton.Click += new System.EventHandler(this.removeAnimationButton_Click);
            // 
            // frameEditorPanel
            // 
            this.frameEditorPanel.Controls.Add(this.importDelayLabel);
            this.frameEditorPanel.Controls.Add(this.importValuesLabel);
            this.frameEditorPanel.Controls.Add(this.importDelayBox);
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
            this.frameEditorPanel.Controls.Add(this.removeFrameButton);
            this.frameEditorPanel.Location = new System.Drawing.Point(0, 27);
            this.frameEditorPanel.Name = "frameEditorPanel";
            this.frameEditorPanel.Size = new System.Drawing.Size(290, 423);
            this.frameEditorPanel.TabIndex = 19;
            // 
            // importDelayLabel
            // 
            this.importDelayLabel.AutoSize = true;
            this.importDelayLabel.Location = new System.Drawing.Point(4, 395);
            this.importDelayLabel.Name = "importDelayLabel";
            this.importDelayLabel.Size = new System.Drawing.Size(34, 13);
            this.importDelayLabel.TabIndex = 21;
            this.importDelayLabel.Text = "Delay";
            // 
            // importValuesLabel
            // 
            this.importValuesLabel.AutoSize = true;
            this.importValuesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importValuesLabel.Location = new System.Drawing.Point(4, 372);
            this.importValuesLabel.Name = "importValuesLabel";
            this.importValuesLabel.Size = new System.Drawing.Size(84, 13);
            this.importValuesLabel.TabIndex = 20;
            this.importValuesLabel.Text = "Import Values";
            // 
            // importDelayBox
            // 
            this.importDelayBox.Enabled = false;
            this.importDelayBox.Location = new System.Drawing.Point(41, 393);
            this.importDelayBox.Name = "importDelayBox";
            this.importDelayBox.Size = new System.Drawing.Size(83, 20);
            this.importDelayBox.TabIndex = 19;
            this.importDelayBox.ValueChanged += new System.EventHandler(this.importDelayBox_ValueChanged);
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(160, 395);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(34, 13);
            this.delayLabel.TabIndex = 18;
            this.delayLabel.Text = "Delay";
            // 
            // frameInfoLabel
            // 
            this.frameInfoLabel.AutoSize = true;
            this.frameInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameInfoLabel.Location = new System.Drawing.Point(160, 372);
            this.frameInfoLabel.Name = "frameInfoLabel";
            this.frameInfoLabel.Size = new System.Drawing.Size(121, 13);
            this.frameInfoLabel.TabIndex = 17;
            this.frameInfoLabel.Text = "Selected Frame Info";
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
            this.animationPanel.Location = new System.Drawing.Point(289, 27);
            this.animationPanel.Name = "animationPanel";
            this.animationPanel.Size = new System.Drawing.Size(474, 423);
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
            this.animationPreview.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.animationPreview.Enabled = false;
            this.animationPreview.Location = new System.Drawing.Point(3, 26);
            this.animationPreview.Name = "animationPreview";
            this.animationPreview.Playing = false;
            this.animationPreview.PreviewSprite = null;
            this.animationPreview.Size = new System.Drawing.Size(466, 326);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(763, 450);
            this.Controls.Add(this.animationPanel);
            this.Controls.Add(this.frameEditorPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "QUROGames Animation Studio";
            ((System.ComponentModel.ISupportInitialize)(this.spritePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayInputBox)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.frameEditorPanel.ResumeLayout(false);
            this.frameEditorPanel.PerformLayout();
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
    }
}

