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
            this.loadSpriteSheetButton = new System.Windows.Forms.Button();
            this.loadSpriteSheetDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadSpriteMapButton = new System.Windows.Forms.Button();
            this.loadSpriteMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.spritesListBox = new System.Windows.Forms.ListBox();
            this.animationPreview = new AnimationEditor.AnimationPreview();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // loadSpriteSheetButton
            // 
            this.loadSpriteSheetButton.Location = new System.Drawing.Point(28, 36);
            this.loadSpriteSheetButton.Name = "loadSpriteSheetButton";
            this.loadSpriteSheetButton.Size = new System.Drawing.Size(119, 23);
            this.loadSpriteSheetButton.TabIndex = 1;
            this.loadSpriteSheetButton.Text = "Load Sprite Sheet...";
            this.loadSpriteSheetButton.UseVisualStyleBackColor = true;
            this.loadSpriteSheetButton.Click += new System.EventHandler(this.loadSpriteSheetButton_Click);
            // 
            // loadSpriteSheetDialog
            // 
            this.loadSpriteSheetDialog.DefaultExt = "png";
            this.loadSpriteSheetDialog.FileName = "openFileDialog1";
            this.loadSpriteSheetDialog.Filter = "PNG files|*png";
            // 
            // loadSpriteMapButton
            // 
            this.loadSpriteMapButton.Enabled = false;
            this.loadSpriteMapButton.Location = new System.Drawing.Point(28, 65);
            this.loadSpriteMapButton.Name = "loadSpriteMapButton";
            this.loadSpriteMapButton.Size = new System.Drawing.Size(119, 23);
            this.loadSpriteMapButton.TabIndex = 2;
            this.loadSpriteMapButton.Text = "Load Sprite Map...";
            this.loadSpriteMapButton.UseVisualStyleBackColor = true;
            this.loadSpriteMapButton.Click += new System.EventHandler(this.loadSpriteMapButton_Click);
            // 
            // loadSpriteMapDialog
            // 
            this.loadSpriteMapDialog.DefaultExt = "xml";
            this.loadSpriteMapDialog.FileName = "openFileDialog1";
            this.loadSpriteMapDialog.Filter = "Xml Files|*.xml";
            // 
            // spritesListBox
            // 
            this.spritesListBox.FormattingEnabled = true;
            this.spritesListBox.Location = new System.Drawing.Point(28, 104);
            this.spritesListBox.Name = "spritesListBox";
            this.spritesListBox.Size = new System.Drawing.Size(119, 264);
            this.spritesListBox.TabIndex = 3;
            // 
            // animationPreview
            // 
            this.animationPreview.CurrentAnimation = null;
            this.animationPreview.Location = new System.Drawing.Point(351, 73);
            this.animationPreview.Name = "animationPreview";
            this.animationPreview.PreviewSprite = null;
            this.animationPreview.Size = new System.Drawing.Size(253, 198);
            this.animationPreview.SpriteSheet = null;
            this.animationPreview.TabIndex = 0;
            this.animationPreview.Text = "animationPreview1";
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(166, 104);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 264);
            this.listBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.spritesListBox);
            this.Controls.Add(this.loadSpriteMapButton);
            this.Controls.Add(this.loadSpriteSheetButton);
            this.Controls.Add(this.animationPreview);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private AnimationPreview animationPreview;
        private System.Windows.Forms.Button loadSpriteSheetButton;
        private System.Windows.Forms.OpenFileDialog loadSpriteSheetDialog;
        private System.Windows.Forms.Button loadSpriteMapButton;
        private System.Windows.Forms.OpenFileDialog loadSpriteMapDialog;
        private System.Windows.Forms.ListBox spritesListBox;
        private System.Windows.Forms.ListBox listBox1;
    }
}

