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
using AnimationEditor.Modifications;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

/*
 * Editor for creating animations for use with the QURO.Animation library
 * Coded in C# as a first Windows application project for me, from mid-November 2018 to January 1st, 2019
 * Was created alongside the SpriteMapEditor app, this one being much more advanced in design
 * Had a lot of fun with this one. Probably had the hardest time with the grid drawing in AnimationPreview!
 * It was a great experience, but I'm excited to see what comes next. Especially trying WPF.
 * After making a couple of games using this I hope to return to QURO.Animation and give it a few enhancements!
 * Maybe something like adding sprite scaling and rotation, 
 * and restructuring animations to use moving objects translated between frames, to save resources and make tweening a possibility
 * And then of course rewriting this editor but in WPF...haha! See you then!
 * -Quinn
 * PS. Sorry for not properly documenting half of what I did when I made this. Hope it's not too hard to unravel later.
*/
namespace AnimationEditor
{
    public partial class AnimationEditor : Form
    {
        private History undoHistory;

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

        private BindingList<Sprite> spriteMap;
        private BindingList<Frame> frames;
        private BindingList<Sprite> frameSprites;
        private BindingList<Animation> animations;

        private Animation currentAnimation;
        private Frame currentFrame;

        private bool frameNameBoxEdited;
        private bool tracking;
        private bool reading;
        private float importDelay = 0;

        public AnimationEditor()
        {
            InitializeComponent();
            undoHistory = new History();
            undoHistory.HistoryUpdated += OnUndoHistoryUpdated;
            frameRate = 60;
            importDelayBox.Value = 0;
            animationPreview.FrameChanged += animationPreview_FrameChanged;
            animationPreview.AnimationEnded += animationPreview_AnimationEnded;
            animationPreview.SpriteDragUpdate += animationPreview_SpriteDragUpdate;
            animationPreview.SpriteDragCompleted += animationPreview_SpriteDragComplete;
        }

        private void DoModification(IModification mod)
        {
            ModHelper.DoModificationWithSelectionTracking(mod, animationBox, frameListBox, frameSpriteListBox);
            undoHistory.Add(mod);
        }

        private void animationPreview_SpriteDragComplete(object sender, EventArgs e)
        {
            var args = e as SpriteDragArgs;
            var mod = new MoveSprite(frameSprites, frameSpriteListBox, args.DragDistance);
            mod.Undo();
            DoModification(mod);
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
            if (spriteMapListBox.SelectedItem != null)
            {
                var spriteToAdd = spriteMap[spriteMapListBox.SelectedIndex].Clone();
                AddFrame(new Frame(spriteToAdd, importDelay));
            }
        }

        private void AddFrame(Frame frameToAdd)
        {
            DoModification(new AddFrame(frames, frameListBox, frameToAdd));
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if(frames?.Count > 0)
            {
                //update currentAnimation's data
                if(currentAnimation == null)
                    currentAnimation = new Animation("unnamed", frames.ToArray(), true);
                else
                {
                    currentAnimation.Name = animationNameBox.Text;
                    currentAnimation.Frames = frames.ToArray();
                    currentAnimation.IsLooping = animationLoopCheckBox.Checked;
                }
                //ensure frameTrackBar length matches current animation
                frameTrackBar.Maximum = currentAnimation.Frames.Count() - 1;
                //send currentAnimation to animationPreview
                if (animationPreview.PreviewSprite == null)
                    animationPreview.PreviewSprite = new AnimatedSprite(currentAnimation);
                else
                    animationPreview.PreviewSprite.CurrentAnimation = currentAnimation;
                //restore currently viewed frame
                if (frameListBox.SelectedIndices.Count < 2)
                    frameListBox_SetSingleSelection(frameTrackBar.Value);
                else
                    frameListBox.SelectedIndex = frameTrackBar.Value;
                //if animations list is empty, send created currentAnimation to it
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

        private void UpdateEnabledControls()
        {
            bool singleFrameSelected = frameListBox.SelectedIndices.Count < 2;
            bool singleSpriteSelected = frameSpriteListBox.SelectedIndices.Count < 2;

            //update per-frame controls
            frameSpritePanel.Enabled = singleFrameSelected;
            moveFrameDownButton.Enabled = singleFrameSelected;
            moveFrameUpButton.Enabled = singleFrameSelected;
            removeFrameButton.Enabled = singleFrameSelected;
            duplicateFrameButton.Enabled = singleFrameSelected;

            //update per-sprite controls
            spritePosPanel.Enabled = singleSpriteSelected;
            replaceSpriteButton.Enabled = singleSpriteSelected && spriteMap != null;
            moveSpriteDownButton.Enabled = singleSpriteSelected;
            moveSpriteUpButton.Enabled = singleSpriteSelected;
            removeSpriteButton.Enabled = singleSpriteSelected;

            reading = true;
            if (!singleSpriteSelected)
            {
                spriteXPosBox.Text = "";
                spriteYPosBox.Text = "";
            }
            else
            {
                spriteXPosBox.Text = spriteXPosBox.Value.ToString();
                spriteYPosBox.Text = spriteYPosBox.Value.ToString();
            }
            reading = false;
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
            if (spriteMapListBox.SelectedItem != null)
            {
                var currentSprite = (Sprite)spriteMapListBox.SelectedItem;
                Stream texture2DToImageStream = new MemoryStream();
                Texture2DRegionExtractor.GetTexture2DFromRegion(spriteSheet, spriteSheet.GraphicsDevice, currentSprite.Bounds)
                    .SaveAsPng(texture2DToImageStream, currentSprite.Bounds.Width, currentSprite.Bounds.Height);
                spritePreview.Image = Image.FromStream(texture2DToImageStream);
                texture2DToImageStream.Close();
            }
        }

        private void frameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!tracking)
                UpdateEnabledControls();
            if (frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedItem != null)
            {
                //create copy of current frameSprite selection
                List<int> oldFrameSpriteSelection = new List<int>();
                foreach (int index in frameSpriteListBox.SelectedIndices)
                {
                    oldFrameSpriteSelection.Add(index);
                }

                //update currentFrame to match selection
                currentFrame = (Frame)frameListBox.SelectedItem;
                //update preview and frameTrackBar frame positions
                if (animationPreview.PreviewSprite != null && !animationPreview.Playing)
                {
                    animationPreview.PreviewSprite.CurrentFrameIndex = frameListBox.SelectedIndex;
                    frameTrackBar.Maximum = frames.Count - 1;
                    frameTrackBar.Value = frameListBox.SelectedIndex;
                }

                //update frameSpriteListBox with the current frame's sprites
                if (currentFrame.Sprites != null)
                    frameSprites = new BindingList<Sprite>(currentFrame.Sprites);
                else
                    frameSprites = new BindingList<Sprite>();
                frameSpriteListBox.DataSource = frameSprites;
                frameSpriteListBox.DisplayMember = "Name";

                //restore old frameSprite selection
                frameSpriteListBox.SelectedIndices.Clear();
                foreach(int index in oldFrameSpriteSelection)
                {
                    if(index < frameSprites.Count)
                    {
                        frameSpriteListBox.SelectedIndex = index;
                    }
                }

                //ensure at least one sprite is selected
                if (frameSprites.Count > 0 && frameSpriteListBox.SelectedIndices.Count < 1)
                    frameSpriteListBox.SelectedIndex = 0;

                //update forms fields to match selected frame's informations
                UpdateFrameInformation();
            }
            else if (frameListBox.SelectedIndices.Count > 1)
            {
                //disable preview sprite drag+drop functionality
                if (animationPreview.EditSprites != null)
                    animationPreview.EditSprites.Clear();
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
            if (reading || tracking)
                return;
            DoModification(new ChangeFrameDelay(frames, frameListBox, (float)delayInputBox.Value / frameRate));
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

                spriteMap = new BindingList<Sprite>();
                foreach (KeyValuePair<string, Sprite> sprite in loadedSpriteMap)
                {
                    spriteMap.Add(sprite.Value);
                }

                spriteMapListBox.DataSource = spriteMap;
                spriteMapListBox.DisplayMember = "Name";
                spriteMapListBox.ValueMember = "Bounds";

                //enable spriteMap-required controls
                addSpriteToFrameListButton.Enabled = true;
                addSpriteToFrameSpritesButton.Enabled = true;
                replaceSpriteButton.Enabled = true;

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
            playAnimationButton.Image = Properties.Resources.play;
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
                    playAnimationButton.Image = Properties.Resources.play;
                }
                else
                {
                    animationPreview.PreviewSprite.CurrentAnimation = currentAnimation;
                    frameTrackBar.Enabled = false;
                    playAnimationButton.Image = Properties.Resources.pause;
                }
            }
        }

        private void frameTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!animationPreview.Playing)
            {
                tracking = true;
                animationPreview.PreviewSprite.CurrentFrameIndex = frameTrackBar.Value;
                frameListBox_SetSingleSelection(frameTrackBar.Value);
                tracking = false;
            }
        }

        private void moveFrameDownButton_Click(object sender, EventArgs e)
        {
            if (frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedIndex < frames.Count - 1)
            {
                MoveFrame(frames, frameListBox, 1);
            }
        }

        private void moveFrameUpButton_Click(object sender, EventArgs e)
        {
            if (frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedIndex > 0)
            {
                MoveFrame(frames, frameListBox, -1);
            }
        }

        private void MoveFrame(BindingList<Frame> frameList, ListBox frameBox, int dir)
        {
            DoModification(new ReorderFrame(frameList, frameBox, dir));
            UpdateAnimation();
        }

        private void removeFrameButton_Click(object sender, EventArgs e)
        {
            if(frameListBox.SelectedIndices.Count == 1 && frameListBox.SelectedIndex > -1 && frameListBox.SelectedIndex < frames.Count)
            {
                DoModification(new RemoveFrame(frames, frameListBox, frameListBox.SelectedIndex));
                UpdateAnimation();
            }
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
                AddAnimation(loadedAnimation);
                currentAnimation = animations[animationBox.SelectedIndex];
                ReadAnimationInfo();
                UpdateAnimation();
            }
        }

        private void AddAnimation(Animation anim)
        {
            DoModification(new AddAnimation(animations, animationBox, anim));
        }

        private void animationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentAnimation = animations[animationBox.SelectedIndex];
            ReadAnimationInfo();
            UpdateAnimation();
        }

        private void addAnimationButton_Click(object sender, EventArgs e)
        {
            AddAnimation(new Animation());
        }

        private void removeAnimationButton_Click(object sender, EventArgs e)
        {
            if (animationBox.SelectedIndex > -1 && animationBox.SelectedIndex < animations.Count)
            {
                DoModification(new RemoveAnimation(animations, animationBox, animationBox.SelectedIndex));
                ReadAnimationInfo();
                UpdateAnimation();
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
                undoHistory = new History();
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
            if(!tracking)
                UpdateEnabledControls();
            if (frameSpriteListBox.SelectedIndex > -1 && frameSpriteListBox.SelectedIndex < frameSprites.Count)
            {
                //check if animationPreview has initialized EditSprites; do so if not, and if so, clear it
                if (animationPreview.EditSprites == null)
                    animationPreview.EditSprites = new List<Sprite>();
                else
                    animationPreview.EditSprites.Clear();
                //add selected sprites to EditSprites list
                foreach(int index in frameSpriteListBox.SelectedIndices)
                {
                    if(index < frameSprites.Count)
                        animationPreview.EditSprites.Add(frameSprites[index]);
                }
                if (frameSpriteListBox.SelectedIndices.Count == 1)
                {
                    ReadSpriteOffset();
                }
            }
        }

        //load selected sprite's position into the sprite position boxes
        private void ReadSpriteOffset()
        {
            reading = true;
            spriteXPosBox.Value = (int)frameSprites[frameSpriteListBox.SelectedIndex].Offset.X;
            spriteYPosBox.Value = (int)frameSprites[frameSpriteListBox.SelectedIndex].Offset.Y;
            reading = false;
        }

        //update X offset of selected sprite with position entered into spriteXPosBox
        private void spriteXPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (reading || frameSpriteListBox.SelectedIndex >= currentFrame.Sprites.Count)
                return;

            SetSpritePosition();
            currentFrame.Sprites = frameSprites.ToList();
            /*
            var newPos = currentFrame.Sprites[frameSpriteListBox.SelectedIndex].Offset;
            newPos.X = (float)spriteXPosBox.Value;
            currentFrame.Sprites[frameSpriteListBox.SelectedIndex].Offset = newPos;
            */
        }

        //update Y offset of selected sprite with position entered into spriteYPosBox
        private void spriteYPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (reading || frameSpriteListBox.SelectedIndex >= currentFrame.Sprites.Count)
                return;

            SetSpritePosition();
            currentFrame.Sprites = frameSprites.ToList();
            /*
            var newPos = currentFrame.Sprites[frameSpriteListBox.SelectedIndex].Offset;
            newPos.Y = (float)spriteYPosBox.Value;
            currentFrame.Sprites[frameSpriteListBox.SelectedIndex].Offset = newPos;
            */
        }

        private void SetSpritePosition()
        {
            DoModification(new SetSpritePosition(frameSprites, frameSpriteListBox, new Vector2((float)spriteXPosBox.Value, (float)spriteYPosBox.Value)));
        }

        private void addSpriteToFrameSpritesButton_Click(object sender, EventArgs e)
        {
            var spriteToAdd = spriteMap[spriteMapListBox.SelectedIndex].Clone();

            DoModification(new AddSprite(frameSprites, frameSpriteListBox, currentFrame, spriteToAdd));
        }

        private void addEmptyFrameButton_Click(object sender, EventArgs e)
        {
            AddFrame(new Frame());
        }

        private void RenameFrames()
        {
            bool changed = false;

            foreach(int index in frameListBox.SelectedIndices)
            {
                if (frames[index].Name != frameNameBox.Text)
                {
                    changed = true;
                    break;
                }
            }

            if (changed)
            {
                DoModification(new RenameFrame(frames, frameListBox, frameNameBox.Text));
            }
        }

        private void moveSpriteDownButton_Click(object sender, EventArgs e)
        {
            if (frameSpriteListBox.SelectedIndex < currentFrame.Sprites.Count - 1)
            {
                MoveSprite(frameSprites, frameSpriteListBox, 1);
            }
        }

        private void moveSpriteUpButton_Click(object sender, EventArgs e)
        {
            if (frameSpriteListBox.SelectedIndex > 0)
            {
                MoveSprite(frameSprites, frameSpriteListBox, -1);
            }
        }

        private void MoveSprite(BindingList<Sprite> spriteList, ListBox spriteBox, int dir)
        {
            DoModification(new ReorderSprite(spriteList, spriteBox, dir));
            UpdateAnimation();
        }

        private void removeSpriteButton_Click(object sender, EventArgs e)
        {
            if (frameSpriteListBox.SelectedIndex > -1 && frameSpriteListBox.SelectedIndex < frameSprites.Count)
            {
                DoModification(new RemoveSprite(frameSprites, frameSpriteListBox, frameSpriteListBox.SelectedIndex));
                UpdateAnimation();
            }
        }

        private void animationPreview_SpriteDragUpdate(object sender, EventArgs e)
        {
            if(frameSpriteListBox.SelectedIndices.Count == 1)
                ReadSpriteOffset();
        }

        private void duplicateFrameButton_Click(object sender, EventArgs e)
        {
            AddFrame(currentFrame.Clone());
        }

        private void replaceSpriteButton_Click(object sender, EventArgs e)
        {
            DoModification(new ReplaceSprite(frameSprites, frameSpriteListBox.SelectedIndex, spriteMap[spriteMapListBox.SelectedIndex]));
            UpdateAnimation();
        }

        private void Undo()
        {
            undoHistory.Undo(animationBox, frameListBox, frameSpriteListBox);
            UpdateAnimation();
        }

        private void Redo()
        {
            undoHistory.Redo(animationBox, frameListBox, frameSpriteListBox);
            UpdateAnimation();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void UpdateAnimationName()
        {
            DoModification(new RenameAnimation(animations, animationBox.SelectedIndex, animationNameBox.Text));
        }

        private void animationNameBox_Leave(object sender, EventArgs e)
        {
            if (animations[animationBox.SelectedIndex].Name != animationNameBox.Text)
            {
                UpdateAnimationName();
            }
        }

        private void animationNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && animations[animationBox.SelectedIndex].Name != animationNameBox.Text)
            {
                UpdateAnimationName();
            }
        }

        private void frameNameBox_Leave(object sender, EventArgs e)
        {
            if (frameNameBoxEdited)
                RenameFrames();
            frameNameBoxEdited = false;
        }

        private void frameNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && frameNameBoxEdited)
                RenameFrames();
            frameNameBoxEdited = false;
        }

        private void frameNameBox_TextChanged(object sender, EventArgs e)
        {
            if(!reading && !tracking)
            {
                frameNameBoxEdited = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.Z)
                {
                    
                    Undo();
                }
                else if (e.KeyCode == Keys.Y)
                {
                    Redo();
                }
            }
        }

        private void OnUndoHistoryUpdated(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = undoHistory.CanUndo;
            undoToolStripMenuItem.Text = undoHistory.NextUndoString();
            redoToolStripMenuItem.Enabled = undoHistory.CanRedo;
            redoToolStripMenuItem.Text = undoHistory.NextRedoString();
        }

        private void frameListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush nameBrush = Brushes.Black;
            Brush indexBrush = Brushes.Gray;

            if (e.BackColor.GetBrightness() < 0.5)
                nameBrush = Brushes.White;

            System.Drawing.Rectangle indexRect = e.Bounds;
            System.Drawing.Rectangle nameRect = e.Bounds;
            indexRect.Width = 26;
            nameRect.X += 24;
            nameRect.Width -= 24;

            string indexString = "";
            for(int index = 3 - e.Index.ToString().Length; index > 0; index--)
            {
                indexString += "0";
            }
            indexString += e.Index;
            indexString += ":";

            e.Graphics.FillRectangle(Brushes.White, indexRect);
            e.Graphics.FillRectangle(new SolidBrush(e.BackColor), nameRect);
            e.Graphics.DrawString(indexString,
                e.Font, indexBrush, indexRect, StringFormat.GenericDefault);

            e.Graphics.DrawString(frames[e.Index].Name,
                e.Font, nameBrush, nameRect, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
    }
}
