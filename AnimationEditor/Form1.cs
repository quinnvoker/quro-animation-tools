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
using QURO.Animation;
using QURO;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace AnimationEditor
{
    public partial class Form1 : Form
    {
        private Texture2D spriteSheet;
        private int frameRate;

        private BindingList<Sprite> sprites;
        private BindingList<Frame> frames;
        private BindingList<Sprite> subSprites;
        private BindingList<Animation> animations;

        private Animation currentAnimation;
        private Frame currentFrame;

        private bool reading;
        private float importDelay = 0;

        public Form1()
        {
            InitializeComponent();
            frameRate = 60;
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

        private void EnableAnimationEditingControls()
        {
            saveAnimationToolStripMenuItem.Enabled = true;
            saveAnimationSetToolStripMenuItem.Enabled = true;

            editToolStripMenuItem.Enabled = true;
            updateAnimationSpritesFromSpriteMapToolStripMenuItem.Enabled = true;

            frameEditorPanel.Enabled = true;
            animationPanel.Enabled = true;
        }

        private void InitiateAnimationList(bool newAnimation = true)
        {
            if (newAnimation)
                animations = new BindingList<Animation>() { new Animation() };
            else
                animations = new BindingList<Animation>();
            animationBox.DataSource = animations;
            animationBox.DisplayMember = "Name";
        }

        private void addSpriteToFrameListButton_Click(object sender, EventArgs e)
        {
            if (spriteListBox.SelectedItem != null)
            {
                AddFrame(new Frame((Sprite)spriteListBox.SelectedItem, importDelay));
            }
        }

        private void AddFrame(Frame frameToAdd)
        {
            int newSelectedIndex;

            if (frames.Count == 1 && frames[0].Bounds == Microsoft.Xna.Framework.Rectangle.Empty)
            {
                frames.Clear();
            }

            if (frameListBox.SelectedItem == null || frameListBox.SelectedIndex == frames.Count - 1)
            {
                frames.Add(frameToAdd);
                frameTrackBar.Maximum = frames.Count - 1;
                newSelectedIndex = frames.Count - 1;
            }
            else
            {
                frames.Insert(frameListBox.SelectedIndex + 1, frameToAdd);
                newSelectedIndex = frameListBox.SelectedIndex + 1;
            }
            UpdateAnimation();
            frameListBox_SetSingleSelection(newSelectedIndex);
        }

        private void UpdateAnimation()
        {
            if(frames?.Count > 0)
            {
                if(currentAnimation == null)
                    currentAnimation = new Animation("unnamed", frames.ToArray(), true);
                else
                {
                    currentAnimation.Name = animationNameBox.Text;
                    currentAnimation.Frames = frames.ToArray();
                    currentAnimation.IsLooping = animationLoopCheckBox.Checked;
                }
                if (animationPreview.PreviewSprite == null)
                    animationPreview.PreviewSprite = new AnimatedSprite(spriteSheet, currentAnimation);
                else
                    animationPreview.PreviewSprite.CurrentAnimation = currentAnimation;
                frameTrackBar.Maximum = currentAnimation.Frames.Count() - 1;
                if(animations.Count < 1)
                {
                    animations.Add(currentAnimation);
                    animationBox.DataSource = animations;
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
            frameTrackBar.Maximum = currentAnimation.Frames.Count() - 1;
            frames = new BindingList<Frame>(currentAnimation.Frames.ToList());
            frameListBox.DataSource = frames;
            frameListBox.DisplayMember = "Name";
            animationNameBox.Text = currentAnimation.Name;
            animationLoopCheckBox.Checked = currentAnimation.IsLooping;
            reading = false;
        }

        private void spriteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (spriteListBox.SelectedItem != null)
            {
                var currentSprite = (Sprite)spriteListBox.SelectedItem;
                Stream texture2DToImageStream = new MemoryStream();
                Texture2DRegionExtractor.GetTexture2DFromRegion(spriteSheet, spriteSheet.GraphicsDevice, currentSprite.Bounds)
                    .SaveAsPng(texture2DToImageStream, currentSprite.Bounds.Width, currentSprite.Bounds.Height);
                spritePreview.Image = Image.FromStream(texture2DToImageStream);
                texture2DToImageStream.Close();
            }
        }

        private void frameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedItem != null)
            {
                currentFrame = (Frame)frameListBox.SelectedItem;
                if (animationPreview.PreviewSprite != null && !animationPreview.Playing)
                {
                    animationPreview.PreviewSprite.CurrentFrameIndex = frameListBox.SelectedIndex;
                    frameTrackBar.Value = frameListBox.SelectedIndex;
                }
                subSpritePanel.Enabled = true;
                if (currentFrame.SubSprites != null)
                    subSprites = new BindingList<Sprite>(currentFrame.SubSprites);
                else
                    subSprites = new BindingList<Sprite>();
                subSpriteListBox.DataSource = subSprites;
                subSpriteListBox.DisplayMember = "Name";
                UpdateFrameInformation();
            }
            else if (frameListBox.SelectedIndices.Count > 1)
            {
                subSpritePanel.Enabled = false;
            }
        }

        private void UpdateFrameInformation()
        {
            delayInputBox.Value = (int)(currentFrame.Delay * frameRate);
        }

        private void delayInputBox_ValueChanged(object sender, EventArgs e)
        {
            foreach(int index in frameListBox.SelectedIndices)
            {
                var currentFrame = frames[index];
                currentFrame.Delay = (float)delayInputBox.Value / frameRate;
            }
        }


        private void loadSpriteSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadSpriteSheetDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fileStream = new FileStream(loadSpriteSheetDialog.FileName, FileMode.Open);
                spriteSheet = Texture2D.FromStream(animationPreview.Editor.graphics, fileStream);
                EnableMapAndAnimationLoadingControls();
                fileStream.Close();
            }
        }

        private void loadSpriteMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSpriteMapFromFile();
        }

        private Dictionary<string, Sprite> LoadSpriteMapFromFile()
        {
            if (loadSpriteMapDialog.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, Sprite> loadedSpriteMap;
                using (XmlReader xmlRead = XmlReader.Create(loadSpriteMapDialog.FileName))
                {
                    loadedSpriteMap = IntermediateSerializer.Deserialize<Dictionary<string, Sprite>>(xmlRead, null);
                }

                sprites = new BindingList<Sprite>();
                foreach (KeyValuePair<string, Sprite> sprite in loadedSpriteMap)
                {
                    sprites.Add(sprite.Value);
                }

                spriteListBox.DataSource = sprites;
                spriteListBox.DisplayMember = "Name";
                spriteListBox.ValueMember = "Bounds";

                if (currentAnimation == null)
                {
                    frames = new BindingList<Frame>();
                    frameListBox.DataSource = frames;
                    frameListBox.DisplayMember = "Name";

                    InitiateAnimationList();
                }

                EnableAnimationEditingControls();
                return loadedSpriteMap;
            }
            return null;
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
            currentAnimation.IsLooping = animationLoopCheckBox.Checked;
        }

        private void playAnimationButton_Click(object sender, EventArgs e)
        {
            if (currentAnimation.Frames.Count() > 0)
            {
                animationPreview.Playing = !animationPreview.Playing;
                if (!animationPreview.Playing)
                {
                    frameTrackBar.Enabled = true;
                }
                else
                {
                    animationPreview.PreviewSprite.CurrentAnimation = currentAnimation;
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
            if (frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedIndex < frames.Count - 1)
            {
                var frameBelow = frames[frameListBox.SelectedIndex + 1];
                frames[frameListBox.SelectedIndex + 1] = currentFrame;
                frames[frameListBox.SelectedIndex] = frameBelow;
                UpdateAnimation();
                frameListBox_SetSingleSelection(frameListBox.SelectedIndex + 1);
            }
        }

        private void moveFrameUpButton_Click(object sender, EventArgs e)
        {
            if (frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedIndex > 0)
            {
                var frameAbove = frames[frameListBox.SelectedIndex - 1];
                frames[frameListBox.SelectedIndex - 1] = currentFrame;
                frames[frameListBox.SelectedIndex] = frameAbove;
                UpdateAnimation();
                frameListBox_SetSingleSelection(frameListBox.SelectedIndex - 1);
            }
        }

        private void removeFrameButton_Click(object sender, EventArgs e)
        {
            if(frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedIndex > -1 && frameListBox.SelectedIndex < frames.Count)
            {
                frames.RemoveAt(frameListBox.SelectedIndex);
                UpdateAnimation();
                if(frames.Count > 0 && frameListBox.SelectedIndex > frames.Count - 1)
                {
                    frameListBox_SetSingleSelection(frames.Count - 1);
                }
            }
        }

        private void animationNameBox_TextChanged(object sender, EventArgs e)
        {
            if (reading)
                return;

            currentAnimation.Name = animationNameBox.Text;
            animations.ResetBindings();
        }

        private void saveAnimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveAnimationDialog.ShowDialog() == DialogResult.OK)
            {
                using (XmlWriter writer = XmlWriter.Create(saveAnimationDialog.FileName))
                {
                    IntermediateSerializer.Serialize(writer, currentAnimation, null);
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
                animations.Add(loadedAnimation);
                animationBox.SelectedIndex = animations.Count - 1;
                currentAnimation = animations[animationBox.SelectedIndex];
                ReadAnimationInfo();
                UpdateAnimation();
            }
        }

        private void animationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentAnimation = animations[animationBox.SelectedIndex];
            ReadAnimationInfo();
            UpdateAnimation();
        }

        private void addAnimationButton_Click(object sender, EventArgs e)
        {
            animations.Add(new Animation());
            animationBox.SelectedIndex = animations.Count - 1;
        }

        private void removeAnimationButton_Click(object sender, EventArgs e)
        {
            if (animationBox.SelectedIndex > -1 && animationBox.SelectedIndex < animations.Count - 1)
            {
                if (animations.Count == 1)
                {
                    currentAnimation = new Animation();
                    animations[animationBox.SelectedIndex] = currentAnimation;
                    ReadAnimationInfo();
                    UpdateAnimation();
                }
                else
                {
                    animations.RemoveAt(animationBox.SelectedIndex);
                    if(animationBox.SelectedIndex > animations.Count - 1)
                    {
                        animationBox.SelectedIndex--;
                    }
                }
            }
        }

        private void importDelayBox_ValueChanged(object sender, EventArgs e)
        {
            importDelay = (float)importDelayBox.Value / frameRate; 
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
            var animSet = new AnimationSet();
            foreach(Animation anim in animations)
            {
                if (animSet.Anims.ContainsKey(anim.Name))
                {
                    string errorMessage = "Duplicate names found! Please ensure all animations have unique names.";
                    string caption = "Save Aborted";
                    MessageBoxButtons saveError = MessageBoxButtons.OK;

                    MessageBox.Show(errorMessage, caption, saveError);
                    return;
                }
                else
                {
                    animSet.Add(anim);
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
                AnimationSet loadedAnimSet;

                using (XmlReader xmlRead = XmlReader.Create(loadAnimationSetDialog.FileName))
                {
                    loadedAnimSet = IntermediateSerializer.Deserialize<AnimationSet>(xmlRead, null);
                }

                if (animationBox.Enabled == false)
                {
                    EnableAnimationEditingControls();
                }
                InitiateAnimationList(newAnimation: false);
                foreach(KeyValuePair<string,Animation> currentEntry in loadedAnimSet.Anims)
                {
                    animations.Add(currentEntry.Value);
                }
                animationBox.SelectedIndex = 0;
                currentAnimation = animations[animationBox.SelectedIndex];
                ReadAnimationInfo();
                UpdateAnimation();
            }
        }

        private void updateAnimationSpritesFromSpriteMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var loadedSpriteMap = LoadSpriteMapFromFile();

            using(XmlReader xmlRead = XmlReader.Create(loadSpriteMapDialog.FileName))
            {
                loadedSpriteMap = IntermediateSerializer.Deserialize<Dictionary<string, Sprite>>(xmlRead, null);
            }

            int updateCounter = 0;

            foreach(Animation anim in animations)
            {
                foreach(Frame frame in anim.Frames)
                {
                    if (loadedSpriteMap.ContainsKey(frame.Name))
                    {
                        frame.Sprite = loadedSpriteMap[frame.Name];
                        updateCounter++;
                    }
                    if (frame.SubSprites != null)
                    {
                        for (int index = 0; index < frame.SubSprites.Count; index++)
                        {
                            var subSprite = frame.SubSprites[index];
                            if (loadedSpriteMap.ContainsKey(subSprite.Name))
                            {
                                frame.SubSprites[index] = loadedSpriteMap[subSprite.Name];
                                updateCounter++;
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Updated " + updateCounter + " sprites!");
        }

        private void subSpriteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadSubSpritePosition();
        }

        private void ReadSubSpritePosition()
        {
            reading = true;
            subSpriteXPosBox.Value = (int)currentFrame.SubSpritePositions[subSpriteListBox.SelectedIndex].X;
            subSpriteYPosBox.Value = (int)currentFrame.SubSpritePositions[subSpriteListBox.SelectedIndex].Y;
            reading = false;
        }

        private void subSpriteXPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (reading || subSpriteListBox.SelectedIndex >= currentFrame.SubSpritePositions.Count)
                return;

            var newPos = currentFrame.SubSpritePositions[subSpriteListBox.SelectedIndex];
            newPos.X = (float)subSpriteXPosBox.Value;
            currentFrame.SubSpritePositions[subSpriteListBox.SelectedIndex] = newPos;
        }

        private void subSpriteYPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (reading || subSpriteListBox.SelectedIndex >= currentFrame.SubSpritePositions.Count)
                return;

            var newPos = currentFrame.SubSpritePositions[subSpriteListBox.SelectedIndex];
            newPos.Y = (float)subSpriteYPosBox.Value;
            currentFrame.SubSpritePositions[subSpriteListBox.SelectedIndex] = newPos;
        }

        private void addSpriteToSubSpritesButton_Click(object sender, EventArgs e)
        {
            var spriteToAdd = sprites[spriteListBox.SelectedIndex];
            if (currentFrame.SubSpritePositions == null)
                currentFrame.SubSpritePositions = new List<Vector2>();
            currentFrame.SubSpritePositions.Add(Vector2.Zero);
            if (currentFrame.SubSprites == null)
                currentFrame.SubSprites = new List<Sprite>();
            currentFrame.SubSprites.Add(spriteToAdd);
            subSprites.Add(spriteToAdd);
        }

        private void addEmptyFrameButton_Click(object sender, EventArgs e)
        {
            AddFrame(new Frame());
        }
    }
}
