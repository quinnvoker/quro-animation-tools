using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QURO.AnimationLibrary;
using QURO;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace AnimationEditor
{
    public partial class Form1 : Form
    {
        private SpriteMapRegion draggedSprite;
        public BindingList<SpriteMapRegion> Sprites { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void loadSpriteSheetButton_Click(object sender, EventArgs e)
        {
            if(loadSpriteSheetDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fileStream = new FileStream(loadSpriteSheetDialog.FileName, FileMode.Open);
                animationPreview.SpriteSheet = Texture2D.FromStream(animationPreview.Editor.graphics, fileStream);
                loadSpriteMapButton.Enabled = true;
            }
        }

        private void loadSpriteMapButton_Click(object sender, EventArgs e)
        {
            if (loadSpriteMapDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                Dictionary<string, SpriteMapRegion> loadedSpriteMap;
                using (XmlReader xmlRead = XmlReader.Create(loadSpriteMapDialog.FileName))
                {
                    loadedSpriteMap = IntermediateSerializer.Deserialize<Dictionary<string, SpriteMapRegion>>(xmlRead, null);
                }

                Sprites = new BindingList<SpriteMapRegion>();
                foreach (KeyValuePair<string, SpriteMapRegion> sprite in loadedSpriteMap)
                {
                    Sprites.Add(sprite.Value);
                }

                spriteListBox.DataSource = Sprites;
                spriteListBox.DisplayMember = "Name";
                spriteListBox.ValueMember = "Bounds";
                Rectangle[] frames = new Rectangle[] { Sprites[0].Bounds, Sprites[1].Bounds, Sprites[2].Bounds };
                animationPreview.CurrentAnimation = new Animation("Test", frames, 1f / 60f, true);
                animationPreview.PreviewSprite = new AnimatedSprite(animationPreview.SpriteSheet, animationPreview.CurrentAnimation);
            }
        }

        private void spriteListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (spriteListBox.SelectedItem == null)
                return;
            spriteListBox.DoDragDrop(spriteListBox.SelectedItem, DragDropEffects.Copy);
            draggedSprite = (SpriteMapRegion)spriteListBox.SelectedItem;
        }
    }
}
