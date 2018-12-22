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
        private Texture2D _spriteSheet;
        //property ensures animationPreview holds a copy of whatever spriteSheet the editor is using
        private Texture2D spriteSheet
        {
            get { return _spriteSheet; }
            set
            {
                _spriteSheet = value;
                animationPreview.SpriteSheet = value;
            }
        }
        private int frameRate;

        private BindingList<Sprite> spriteSet;
        private BindingList<Frame> frames;
        private BindingList<Sprite> frameSprites;
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
            animationPreview.SpriteMoved += animationPreview_SpriteMoved;
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
                var spriteToAdd = spriteSet[spriteListBox.SelectedIndex].Clone();
                AddFrame(new Frame(spriteToAdd, importDelay));
            }
        }

        private void AddFrame(Frame frameToAdd)
        {
            int newSelectedIndex;

            //if only frame in animation is uninitiated and input is not empty, clear the list
            if (frameToAdd.Name != "empty" &&
                frames.Count == 1 && 
                frames[0].Sprites.Count == 1 && 
                frames[0].Sprites[0].Name == "empty")
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
                    animationPreview.PreviewSprite = new AnimatedSprite(currentAnimation);
                else
                    animationPreview.PreviewSprite.CurrentAnimation = currentAnimation;
                frameTrackBar.Maximum = currentAnimation.Frames.Count() - 1;
                frameListBox_SetSingleSelection(frameTrackBar.Value);
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
                frameSpritePanel.Enabled = true;
                if (currentFrame.Sprites != null)
                    frameSprites = new BindingList<Sprite>(currentFrame.Sprites);
                else
                    frameSprites = new BindingList<Sprite>();
                frameSpriteListBox.DataSource = frameSprites;
                frameSpriteListBox.DisplayMember = "Name";
                UpdateFrameInformation();
            }
            else if (frameListBox.SelectedIndices.Count > 1)
            {
                frameSpritePanel.Enabled = false;
            }
        }

        private void UpdateFrameInformation()
        {
            reading = true;
            delayInputBox.Value = (int)(currentFrame.Delay * frameRate);
            frameNameBox.Text = currentFrame.Name;
            reading = false;
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

                spriteSet = new BindingList<Sprite>();
                foreach (KeyValuePair<string, Sprite> sprite in loadedSpriteMap)
                {
                    spriteSet.Add(sprite.Value);
                }

                spriteListBox.DataSource = spriteSet;
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
            frameListBox_SetSingleSelection(frameTrackBar.Value);
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
                    frameListBox_SetSingleSelection(frameTrackBar.Value);
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
            if (reading || currentAnimation.Name == animationNameBox.Text)
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
                    if (frame.Sprites != null)
                    {
                        for (int index = 0; index < frame.Sprites.Count; index++)
                        {
                            var sprite = frame.Sprites[index];
                            if (loadedSpriteMap.ContainsKey(sprite.Name))
                            {
                                frame.Sprites[index] = loadedSpriteMap[sprite.Name];
                                updateCounter++;
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Updated " + updateCounter + " sprites!");
        }

        private void frameSpriteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frameSpriteListBox.SelectedIndex > -1 && frameSpriteListBox.SelectedIndex < frameSprites.Count)
            {
                animationPreview.EditSprite = frameSprites[frameSpriteListBox.SelectedIndex];
                ReadSpriteOffset();
            }
        }

        //load selected sprite's position into the sprite position boxes
        private void ReadSpriteOffset()
        {
            reading = true;
            spriteXPosBox.Value = (int)currentFrame.Sprites[frameSpriteListBox.SelectedIndex].Offset.X;
            spriteYPosBox.Value = (int)currentFrame.Sprites[frameSpriteListBox.SelectedIndex].Offset.Y;
            reading = false;
        }

        //update X offset of selected sprite with position entered into spriteXPosBox
        private void spriteXPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (reading || frameSpriteListBox.SelectedIndex >= currentFrame.Sprites.Count)
                return;

            var newPos = currentFrame.Sprites[frameSpriteListBox.SelectedIndex].Offset;
            newPos.X = (float)spriteXPosBox.Value;
            currentFrame.Sprites[frameSpriteListBox.SelectedIndex].Offset = newPos;
        }

        //update Y offset of selected sprite with position entered into spriteYPosBox
        private void spriteYPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (reading || frameSpriteListBox.SelectedIndex >= currentFrame.Sprites.Count)
                return;

            var newPos = currentFrame.Sprites[frameSpriteListBox.SelectedIndex].Offset;
            newPos.Y = (float)spriteYPosBox.Value;
            currentFrame.Sprites[frameSpriteListBox.SelectedIndex].Offset = newPos;
        }

        private void addSpriteToFrameSpritesButton_Click(object sender, EventArgs e)
        {
            var spriteToAdd = spriteSet[spriteListBox.SelectedIndex].Clone();
            if (currentFrame.Sprites == null)
                currentFrame.Sprites = new List<Sprite>();
            currentFrame.Sprites.Add(spriteToAdd);
            frameSprites.ResetBindings();
        }

        private void addEmptyFrameButton_Click(object sender, EventArgs e)
        {
            AddFrame(new Frame());
        }

        private void frameNameBox_TextChanged(object sender, EventArgs e)
        {
            if (reading)
                return;
            currentFrame.Name = frameNameBox.Text;
        }

        private void moveSpriteDownButton_Click(object sender, EventArgs e)
        {
            if (frameSpriteListBox.SelectedIndex < currentFrame.Sprites.Count - 1)
            {
                var index = frameSpriteListBox.SelectedIndex;

                var currentSprite = frameSprites[index];
                var spriteBelow = frameSprites[index + 1];
                frameSprites[index + 1] = currentSprite;
                frameSprites[index] = spriteBelow;
                UpdateAnimation();
                frameSpriteListBox.SelectedIndex = index + 1;
            }
        }

        private void moveSpriteUpButton_Click(object sender, EventArgs e)
        {
            if (frameSpriteListBox.SelectedIndex > 0)
            {
                var index = frameSpriteListBox.SelectedIndex;

                var currentSprite = frameSprites[index];
                var spriteAbove = frameSprites[index - 1];
                frameSprites[index - 1] = currentSprite;
                frameSprites[index] = spriteAbove;
                UpdateAnimation();
                frameSpriteListBox.SelectedIndex = index - 1;
            }
        }

        private void removeSpriteButton_Click(object sender, EventArgs e)
        {
            if (frameSpriteListBox.SelectedIndex > -1 && frameSpriteListBox.SelectedIndex < frameSprites.Count)
            {
                frameSprites.RemoveAt(frameSpriteListBox.SelectedIndex);
                UpdateAnimation();
            }
        }

        private void animationPreview_SpriteMoved(object sender, EventArgs e)
        {
            ReadSpriteOffset();
        }

        private void duplicateFrameButton_Click(object sender, EventArgs e)
        {
            AddFrame(currentFrame.Clone());
        }

        private void replaceSpriteButton_Click(object sender, EventArgs e)
        {
            var spr = frameSprites[frameSpriteListBox.SelectedIndex];
            var replacement = spriteSet[spriteListBox.SelectedIndex];

            spr.Bounds = replacement.Bounds;
            spr.Origin = replacement.Origin;
            spr.Name = replacement.Name;
            UpdateAnimation();
        }
    }
}
