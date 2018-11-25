using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Texture2D SpriteSheet { get; set; }
        public int FrameRate { get; set; }

        public BindingList<SpriteMapRegion> Sprites { get; set; }
        public BindingList<Frame> Frames { get; set; }
        public BindingList<Animation> Animations { get; set; }

        public Animation CurrentAnimation { get; set; }
        public Frame CurrentFrame { get; set; }

        private bool reading = false;
        private float importDelay = 0;

        public Form1()
        {
            InitializeComponent();
            FrameRate = 60;
            importDelayBox.Value = 0;
            animationPreview.FrameChanged += animationPreview_FrameChanged;
            animationPreview.AnimationEnded += animationPreview_AnimationEnded;
        }

        private void frameListBox_SetSingleSelection(int index)
        {
            frameListBox.SelectedIndices.Clear();
            frameListBox.SelectedIndex = index;
        }

        private void EnableMapAndAnimationLoadingControls()
        {
            loadSpriteMapToolStripMenuItem.Enabled = true;
            loadAnimationToolStripMenuItem.Enabled = true;
            loadAnimationSetToolStripMenuItem.Enabled = true;
        }

        private void EnableSpriteMapControls()
        {
            spriteListBox.Enabled = true;
            addSpriteToFrameListButton.Enabled = true;
            spritePreview.Enabled = true;
            importDelayBox.Enabled = true;
        }

        private void EnableAnimationEditingControls()
        {
            saveAnimationToolStripMenuItem.Enabled = true;
            saveAnimationSetToolStripMenuItem.Enabled = true;

            frameListBox.Enabled = true;
            moveFrameDownButton.Enabled = true;
            moveFrameUpButton.Enabled = true;
            removeFrameButton.Enabled = true;
            delayInputBox.Enabled = true;

            animationBox.Enabled = true;
            addAnimationButton.Enabled = true;
            removeAnimationButton.Enabled = true;
            removeFrameButton.Enabled = true;
            animationNameBox.Enabled = true;
            animationLoopCheckBox.Enabled = true;
            frameTrackBar.Enabled = true;
            playAnimationButton.Enabled = true;
            animationPreview.Enabled = true;
        }

        private void InitiateAnimationList()
        {
            Animations = new BindingList<Animation>();
            animationBox.DataSource = Animations;
            animationBox.DisplayMember = "Name";
        }

        private void addSpriteToFrameListButton_Click(object sender, EventArgs e)
        {
            if (spriteListBox.SelectedItem != null)
            {
                int newSelectedIndex;

                if (Frames.Count == 1 &&  Frames[0].Bounds == Microsoft.Xna.Framework.Rectangle.Empty)
                {
                    Frames.Clear();
                }

                if (frameListBox.SelectedItem == null || frameListBox.SelectedIndex == Frames.Count - 1)
                {
                    Frames.Add(new Frame((SpriteMapRegion)spriteListBox.SelectedItem, importDelay));
                    frameTrackBar.Maximum = Frames.Count - 1;
                    newSelectedIndex = Frames.Count - 1;
                }
                else
                {
                    Frames.Insert(frameListBox.SelectedIndex + 1, new Frame((SpriteMapRegion)spriteListBox.SelectedItem, 0.25f));
                    newSelectedIndex = frameListBox.SelectedIndex + 1;
                }
                UpdateAnimation();
                frameListBox_SetSingleSelection(newSelectedIndex);
            }
        }

        private void UpdateAnimation()
        {
            if(Frames?.Count > 0)
            {
                if(CurrentAnimation == null)
                    CurrentAnimation = new Animation("unnamed", Frames.ToArray(), true);
                else
                {
                    CurrentAnimation.Name = animationNameBox.Text;
                    CurrentAnimation.Frames = Frames.ToArray();
                    CurrentAnimation.IsLooping = animationLoopCheckBox.Checked;
                }
                if (animationPreview.PreviewSprite == null)
                    animationPreview.PreviewSprite = new AnimatedSprite(SpriteSheet, CurrentAnimation);
                else
                    animationPreview.PreviewSprite.CurrentAnimation = CurrentAnimation;
                frameTrackBar.Maximum = CurrentAnimation.Frames.Count() - 1;
                if(Animations.Count < 1)
                {
                    Animations.Add(CurrentAnimation);
                    animationBox.DataSource = Animations;
                    animationBox.DisplayMember = "Name";
                }
            }
            else
            {
                animationPreview.PreviewSprite = null;
            }
        }

        private void ReadAnimationInfo()
        {
            reading = true;
            frameTrackBar.Maximum = CurrentAnimation.Frames.Count() - 1;
            Frames = new BindingList<Frame>(CurrentAnimation.Frames.ToList());
            frameListBox.DataSource = Frames;
            frameListBox.DisplayMember = "Name";
            animationNameBox.Text = CurrentAnimation.Name;
            animationLoopCheckBox.Checked = CurrentAnimation.IsLooping;
            reading = false;
        }

        private void spriteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (spriteListBox.SelectedItem != null)
            {
                var currentSprite = (SpriteMapRegion)spriteListBox.SelectedItem;
                Stream texture2DToImageStream = new MemoryStream();
                Texture2DRegionExtractor.GetTexture2DFromRegion(SpriteSheet, SpriteSheet.GraphicsDevice, currentSprite.Bounds)
                    .SaveAsPng(texture2DToImageStream, currentSprite.Bounds.Width, currentSprite.Bounds.Height);
                spritePreview.Image = Image.FromStream(texture2DToImageStream);
                texture2DToImageStream.Close();
            }
        }

        private void frameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedItem != null)
            {
                CurrentFrame = (Frame)frameListBox.SelectedItem;
                if (animationPreview.PreviewSprite != null && !animationPreview.Playing)
                {
                    animationPreview.PreviewSprite.CurrentFrameIndex = frameListBox.SelectedIndex;
                    frameTrackBar.Value = frameListBox.SelectedIndex;
                }
                UpdateFrameInformation();
            }
        }

        private void UpdateFrameInformation()
        {
            delayInputBox.Value = (int)(CurrentFrame.Delay * FrameRate);
        }

        private void delayInputBox_ValueChanged(object sender, EventArgs e)
        {
            foreach(int index in frameListBox.SelectedIndices)
            {
                var currentFrame = Frames[index];
                currentFrame.Delay = (float)delayInputBox.Value / FrameRate;
            }
        }


        private void loadSpriteSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadSpriteSheetDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fileStream = new FileStream(loadSpriteSheetDialog.FileName, FileMode.Open);
                SpriteSheet = Texture2D.FromStream(animationPreview.Editor.graphics, fileStream);
                EnableMapAndAnimationLoadingControls();
            }
        }

        private void loadSpriteMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadSpriteMapDialog.ShowDialog() == DialogResult.OK)
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

                if (CurrentAnimation == null)
                {
                    Frames = new BindingList<Frame>();
                    frameListBox.DataSource = Frames;
                    frameListBox.DisplayMember = "Name";
                }

                EnableSpriteMapControls();
                EnableAnimationEditingControls();
            }
        }

        private void animationPreview_FrameChanged(object sender, EventArgs e)
        {
            frameTrackBar.Value = animationPreview.PreviewSprite.CurrentFrameIndex;
        }

        private void animationPreview_AnimationEnded(object sender, EventArgs e)
        {
            animationPreview.Playing = false;
            frameTrackBar.Enabled = true;
        }

        private void animationLoopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CurrentAnimation.IsLooping = animationLoopCheckBox.Checked;
        }

        private void playAnimationButton_Click(object sender, EventArgs e)
        {
            if (CurrentAnimation.Frames.Count() > 0)
            {
                animationPreview.Playing = !animationPreview.Playing;
                if (!animationPreview.Playing)
                {
                    frameTrackBar.Enabled = true;
                }
                else
                {
                    animationPreview.PreviewSprite.CurrentAnimation = CurrentAnimation;
                    frameTrackBar.Enabled = false;
                }
            }
        }

        private void frameTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!animationPreview.Playing)
            {
                animationPreview.PreviewSprite.CurrentFrameIndex = frameTrackBar.Value;
                frameListBox_SetSingleSelection(frameTrackBar.Value);
            }
        }

        private void moveFrameDownButton_Click(object sender, EventArgs e)
        {
            if (frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedIndex < Frames.Count - 1)
            {
                var frameBelow = Frames[frameListBox.SelectedIndex + 1];
                Frames[frameListBox.SelectedIndex + 1] = CurrentFrame;
                Frames[frameListBox.SelectedIndex] = frameBelow;
                UpdateAnimation();
                frameListBox_SetSingleSelection(frameListBox.SelectedIndex + 1);
            }
        }

        private void moveFrameUpButton_Click(object sender, EventArgs e)
        {
            if (frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedIndex > 0)
            {
                var frameAbove = Frames[frameListBox.SelectedIndex - 1];
                Frames[frameListBox.SelectedIndex - 1] = CurrentFrame;
                Frames[frameListBox.SelectedIndex] = frameAbove;
                UpdateAnimation();
                frameListBox_SetSingleSelection(frameListBox.SelectedIndex - 1);
            }
        }

        private void removeFrameButton_Click(object sender, EventArgs e)
        {
            if(frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedIndex > -1 && frameListBox.SelectedIndex < Frames.Count)
            {
                Frames.RemoveAt(frameListBox.SelectedIndex);
                UpdateAnimation();
                if(Frames.Count > 0 && frameListBox.SelectedIndex > Frames.Count - 1)
                {
                    frameListBox_SetSingleSelection(Frames.Count - 1);
                }
            }
        }

        private void animationNameBox_TextChanged(object sender, EventArgs e)
        {
            if (!reading)
            {
                CurrentAnimation.Name = animationNameBox.Text;
                Animations.ResetBindings();
            }
        }

        private void saveAnimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveAnimationDialog.ShowDialog() == DialogResult.OK)
            {
                using (XmlWriter writer = XmlWriter.Create(saveAnimationDialog.FileName))
                {
                    IntermediateSerializer.Serialize(writer, CurrentAnimation, null);
                }
            }
        }

        private void loadAnimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadAnimationDialog.ShowDialog() == DialogResult.OK)
            {
                Animation loadedAnimation;
                using (XmlReader xmlRead = XmlReader.Create(loadAnimationDialog.FileName))
                {
                    loadedAnimation = IntermediateSerializer.Deserialize<Animation>(xmlRead, null);
                }
                if (animationBox.Enabled == false)
                {
                    EnableAnimationEditingControls();
                    InitiateAnimationList();
                }
                Animations.Add(loadedAnimation);
                animationBox.SelectedIndex = Animations.Count - 1;
                CurrentAnimation = Animations[animationBox.SelectedIndex];
                ReadAnimationInfo();
                UpdateAnimation();
            }
        }

        private void animationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentAnimation = Animations[animationBox.SelectedIndex];
            ReadAnimationInfo();
            UpdateAnimation();
        }

        private void addAnimationButton_Click(object sender, EventArgs e)
        {
            Animations.Add(new Animation());
            animationBox.SelectedIndex = Animations.Count - 1;
        }

        private void removeAnimationButton_Click(object sender, EventArgs e)
        {
            if (animationBox.SelectedIndex > -1 && animationBox.SelectedIndex < Animations.Count - 1)
            {
                if (Animations.Count == 1)
                {
                    CurrentAnimation = new Animation();
                    Animations[animationBox.SelectedIndex] = CurrentAnimation;
                    ReadAnimationInfo();
                    UpdateAnimation();
                }
                else
                {
                    Animations.RemoveAt(animationBox.SelectedIndex);
                    if(animationBox.SelectedIndex > Animations.Count - 1)
                    {
                        animationBox.SelectedIndex--;
                    }
                }
            }
        }

        private void importDelayBox_ValueChanged(object sender, EventArgs e)
        {
            importDelay = (float)importDelayBox.Value / FrameRate; 
        }

        private void animationPreview_MouseWheel(object sender, MouseEventArgs e)
        {
            if(Math.Sign(e.Delta) > 0)
            {
                animationPreview.ZoomLevel++;
            }
            else if (animationPreview.ZoomLevel > 1)
            {
                animationPreview.ZoomLevel--;
            }
        }

        private void saveAnimationSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var animSet = new Dictionary<string, Animation>();
            foreach(Animation anim in Animations)
            {
                if (animSet.ContainsKey(anim.Name))
                {
                    string errorMessage = "Duplicate names found! Please ensure all animations have unique names.";
                    string caption = "Save Aborted";
                    MessageBoxButtons saveError = MessageBoxButtons.OK;

                    MessageBox.Show(errorMessage, caption, saveError);
                    return;
                }
                else
                {
                    animSet.Add(anim.Name, anim);
                }
            }

            if (saveAnimationSetDialog.ShowDialog() == DialogResult.OK)
            {
                using (XmlWriter writer = XmlWriter.Create(saveAnimationSetDialog.FileName))
                {
                    IntermediateSerializer.Serialize(writer, animSet, null);
                }
            }
        }

        private void loadAnimationSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadAnimationSetDialog.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, Animation> loadedAnimSet;

                using (XmlReader xmlRead = XmlReader.Create(loadAnimationSetDialog.FileName))
                {
                    loadedAnimSet = IntermediateSerializer.Deserialize<Dictionary<string, Animation>>(xmlRead, null);
                }

                if (animationBox.Enabled == false)
                {
                    EnableAnimationEditingControls();
                }
                InitiateAnimationList();
                foreach(KeyValuePair<string,Animation> currentEntry in loadedAnimSet)
                {
                    Animations.Add(currentEntry.Value);
                }
                animationBox.SelectedIndex = 0;
                CurrentAnimation = Animations[animationBox.SelectedIndex];
                ReadAnimationInfo();
                UpdateAnimation();
            }
        }
    }
}
