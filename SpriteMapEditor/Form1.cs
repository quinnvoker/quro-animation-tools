using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna;
using System.IO;
using QURO;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;


namespace SpriteMapEditor
{
    public partial class Form1 : Form
    {
        private BindingList<SpriteMapRegion> sprites;
        private List<SpriteMapRegion> selectedSprites;

        private bool highlight = false;
        //private SpriteMapRegion currentSprite { get { return sprites[spriteList.SelectedIndices[0]]; } }
        private int zoomLevel = 3;

        private bool loadingSprite = false;
        private bool movingWithMouse = false;
        private bool editingOrigin = false;

        const string TITLE = "QUROGames Sprite Map Editor";
        private string currentSpriteMapFileLocation;
        private string CurrentSpriteMapFileLocation
        {
            get { return currentSpriteMapFileLocation; }
            set
            {
                currentSpriteMapFileLocation = value;
                Text = TITLE + " - " + Path.GetFileName(currentSpriteMapFileLocation);
            }
        }

        Image originPointer_black;
        Image originPointer_white;

        Pen blackPen;
        Pen whitePen;

        DirectBitmap baseMask;
        DirectBitmap highlightMask;

        private Point newPosition;
        private Point oldPosition;

        private int drawingRectangleOffset
        {
            get
            {
                if (zoomLevel > 2)
                    return (zoomLevel - 1) / 2;
                else
                    return 0;
            }
        }

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;

            spriteSheetViewer.Width = 1;
            spriteSheetViewer.Height = 1;

            sprites = new BindingList<SpriteMapRegion> { new SpriteMapRegion() };
            selectedSprites = new List<SpriteMapRegion>();

            spriteList.DataSource = sprites;
            spriteList.DisplayMember = "Name";
            spriteList.ValueMember = "Bounds";

            originPointer_black = Properties.Resources.originPointer_black;
            originPointer_white = Properties.Resources.originPointer_white;

            blackPen = new Pen(Color.Black);
            whitePen = new Pen(Color.White);
            whitePen.DashPattern = new float[] { 4, 4 };

            highlight = highlightCheckBox.Checked;

            LoadSpriteEditorValues();
        }

        private void loadSpriteSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(loadSpriteSheetDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                spriteSheetViewer.Image = Image.FromFile(loadSpriteSheetDialog.FileName);
            }

            InitializeMask();
        }

        private void spriteSheetViewer_Paint(object sender, PaintEventArgs e)
        {
            if (spriteSheetViewer.Image != null)
            {
                spriteSheetViewer.Width = spriteSheetViewer.Image.Width * zoomLevel;
                spriteSheetViewer.Height = spriteSheetViewer.Image.Height * zoomLevel;

                if (highlight)
                {
                    Rectangle highlightBounds = new Rectangle(0,0, highlightMask.Width * zoomLevel, highlightMask.Height * zoomLevel);
                    e.Graphics.DrawImage(highlightMask.Bitmap, highlightBounds);
                }

                foreach (SpriteMapRegion currentSprite in selectedSprites)
                {
                    DrawHighContrastOutline(GetDrawingRect(currentSprite.Bounds), e.Graphics);
                    DrawOriginPoint(currentSprite, e.Graphics);
                }
            }
            base.OnPaint(e);
        }

        private void LoadSpriteEditorValues()
        {
            loadingSprite = true;
            if (spriteList.SelectedIndices.Count > 1)
            {
                spriteNameBox.Text = "";
                spriteXPosBox.Text = "";
                spriteYPosBox.Text = "";
                spriteWidthBox.Text = "";
                spriteHeightBox.Text = "";
                originXPosBox.Text = "";
                originYPosBox.Text = "";

            }
            else if(spriteList.SelectedIndices.Count > 0)
            {
                SpriteMapRegion currentSprite = selectedSprites[0];
                spriteNameBox.Text = currentSprite.Name;
                spriteXPosBox.Value = currentSprite.Bounds.X;
                spriteXPosBox.Text = currentSprite.Bounds.X.ToString();
                spriteYPosBox.Value = currentSprite.Bounds.Y;
                spriteYPosBox.Text = currentSprite.Bounds.Y.ToString();
                spriteWidthBox.Value = currentSprite.Bounds.Width;
                spriteWidthBox.Text = currentSprite.Bounds.Width.ToString();
                spriteHeightBox.Value = currentSprite.Bounds.Height;
                spriteHeightBox.Text = currentSprite.Bounds.Height.ToString();
                originXPosBox.Value = (int)currentSprite.Origin.X;
                originXPosBox.Text = ((int)currentSprite.Origin.X).ToString();
                originYPosBox.Value = (int)currentSprite.Origin.Y;
                originYPosBox.Text = ((int)currentSprite.Origin.Y).ToString();
            }
            loadingSprite = false;
        }

        private Rectangle GetDrawingRect(Microsoft.Xna.Framework.Rectangle baseRect, bool outline = true)
        {
            var drawingRect = new Rectangle(baseRect.X, baseRect.Y, baseRect.Width, baseRect.Height);
            drawingRect.X = drawingRect.X * zoomLevel - (zoomLevel - 1);
            drawingRect.Y = drawingRect.Y * zoomLevel - (zoomLevel - 1);
            drawingRect.X += drawingRectangleOffset;
            drawingRect.Y += drawingRectangleOffset;
            drawingRect.Width *= zoomLevel;
            drawingRect.Height *= zoomLevel;

            drawingRect.Width--;
            drawingRect.Height--;

            return drawingRect;
        }

        private Point GetOriginDrawingPoint(SpriteMapRegion sprite)
        {
            var drawingPoint = new Point(sprite.Bounds.X, sprite.Bounds.Y);
            drawingPoint.X = drawingPoint.X * zoomLevel - (zoomLevel - 1);
            drawingPoint.Y = drawingPoint.Y * zoomLevel - (zoomLevel - 1);
            drawingPoint.X += drawingRectangleOffset;
            drawingPoint.Y += drawingRectangleOffset;
            drawingPoint.X += (int)sprite.Origin.X * zoomLevel;
            drawingPoint.Y += (int)sprite.Origin.Y * zoomLevel;
            return drawingPoint;
        }

        private void DrawOriginPoint(SpriteMapRegion sprite, Graphics graphics)
        {
            if (editingOrigin)
            {
                var spriteSheet = (Bitmap)spriteSheetViewer.Image;
                var colorAtOrigin = spriteSheet.GetPixel((int)(sprite.Bounds.X + sprite.Origin.X),
                    (int)(sprite.Bounds.Y + sprite.Origin.Y));

                var highContrastPointer = originPointer_black;
                if (colorAtOrigin.GetBrightness() < 0.5f)
                {
                    highContrastPointer = originPointer_white;
                }

                var drawPoint = GetOriginDrawingPoint(sprite);
                drawPoint.X -= 5;
                drawPoint.Y -= 5;

                graphics.DrawImage(highContrastPointer, drawPoint);
            }
        }

        private void UpdateHighlightMask()
        {
            if (highlight)
            {
                InitializeMask();
                foreach (SpriteMapRegion currentSprite in selectedSprites)
                {
                    for (int currentY = 0; currentY < currentSprite.Bounds.Height; currentY++)
                    {
                        for (int currentX = 0; currentX < currentSprite.Bounds.Width; currentX++)
                        {
                            highlightMask.SetPixel(currentX + currentSprite.Bounds.X, currentY + currentSprite.Bounds.Y, Color.Transparent);
                        }
                    }
                }
            }
        }

        private void InitializeMask()
        {
            if (baseMask == null)
            {
                Color maskColor = Color.FromArgb(128, 32, 32, 32);

                highlightMask = new DirectBitmap(spriteSheetViewer.Image.Width, spriteSheetViewer.Image.Height);
                for (int currentY = 0; currentY < highlightMask.Height; currentY++)
                {
                    for (int currentX = 0; currentX < highlightMask.Width; currentX++)
                    {
                        highlightMask.SetPixel(currentX, currentY, maskColor);
                    }
                }
                baseMask = new DirectBitmap(highlightMask);
            }
            else
            {
                highlightMask.CopyBitmap(baseMask);
            }
        }

        private void DrawHighContrastOutline(Rectangle rect, Graphics graphics)
        {
            graphics.DrawRectangle(blackPen, rect);
            graphics.DrawRectangle(whitePen, rect);
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            zoomLevel++;
            zoomLabel.Text = "Zoom: " + zoomLevel + "X";
            spriteSheetViewer.Refresh();
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            if (zoomLevel > 1)
            {
                zoomLevel--;
                zoomLabel.Text = "Zoom: " + zoomLevel + "X";
                spriteSheetViewer.Refresh();
            }
        }

        private void spriteViewerPanel_Scroll(object sender, ScrollEventArgs e)
        {
            spriteSheetViewer.Refresh();
        }

        private void spriteXPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            foreach (SpriteMapRegion currentSprite in selectedSprites)
            {
                var newBounds = currentSprite.Bounds;
                newBounds.X = (int)spriteXPosBox.Value;
                currentSprite.Bounds = newBounds;
            }
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void spriteYPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            foreach (SpriteMapRegion currentSprite in selectedSprites)
            {
                var newBounds = currentSprite.Bounds;
                newBounds.Y = (int)spriteYPosBox.Value;
                currentSprite.Bounds = newBounds;
            }
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void spriteWidthBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            foreach (SpriteMapRegion currentSprite in selectedSprites)
            {
                var newBounds = currentSprite.Bounds;
                newBounds.Width = (int)spriteWidthBox.Value;
                currentSprite.Bounds = newBounds;
            }
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void spriteHeightBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            foreach (SpriteMapRegion currentSprite in selectedSprites)
            {
                var newBounds = currentSprite.Bounds;
                newBounds.Height = (int)spriteHeightBox.Value;
                currentSprite.Bounds = newBounds;
            }
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void spriteNameBox_TextChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            selectedSprites[0].Name = spriteNameBox.Text;
            sprites.ResetBindings();
        }

        private void addSpriteButton_Click(object sender, EventArgs e)
        {
            sprites.Add(new SpriteMapRegion(selectedSprites[0].Name, selectedSprites[0].Bounds));
        }

        private void removeSpriteButton_Click(object sender, EventArgs e)
        {
            if (spriteList.SelectedIndex > -1 && spriteList.SelectedIndex < sprites.Count)
                sprites.RemoveAt(spriteList.SelectedIndex);
        }

        private void spriteList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (spriteList.SelectedIndex > -1 && spriteList.SelectedIndex < sprites.Count)
            {
                UpdateSelectedSpriteList();
                LoadSpriteEditorValues();
                UpdateHighlightMask();
                spriteSheetViewer.Refresh();
            }
        }

        private void SingleSpriteFunctions_SetEnabled(bool status)
        {
            moveDownButton.Enabled = status;
            moveUpButton.Enabled = status;
            spriteNameLabel.Enabled = status;
            spriteNameBox.Enabled = status;
            removeSpriteButton.Enabled = status;
            addSpriteButton.Enabled = status;
        }

        private void UpdateSelectedSpriteList()
        {
            selectedSprites.Clear();
            foreach(int currentIndex in spriteList.SelectedIndices)
            {
                selectedSprites.Add(sprites[currentIndex]);
            }
            if (selectedSprites.Count > 1)
                SingleSpriteFunctions_SetEnabled(false);
            else
                SingleSpriteFunctions_SetEnabled(true);
        }

        private Rectangle GetSelectedGroupRectangle()
        {
            Microsoft.Xna.Framework.Rectangle leftMost = selectedSprites[0].Bounds;
            Microsoft.Xna.Framework.Rectangle topMost = selectedSprites[0].Bounds;
            Microsoft.Xna.Framework.Rectangle rightMost = selectedSprites[0].Bounds;
            Microsoft.Xna.Framework.Rectangle bottomMost = selectedSprites[0].Bounds;

            foreach (SpriteMapRegion currentSprite in selectedSprites)
            {
                if (currentSprite.Bounds.X < leftMost.X)
                    leftMost = currentSprite.Bounds;
                if (currentSprite.Bounds.Y < topMost.Y)
                    topMost = currentSprite.Bounds;
                if (currentSprite.Bounds.X + currentSprite.Bounds.Width > rightMost.X + rightMost.Width)
                    rightMost = currentSprite.Bounds;
                if (currentSprite.Bounds.Y + currentSprite.Bounds.Height > bottomMost.Y + bottomMost.Width)
                    bottomMost = currentSprite.Bounds;
            }

            return new Rectangle(leftMost.X, topMost.Y,
                rightMost.X + rightMost.Width - leftMost.X,
                bottomMost.Y + bottomMost.Height - topMost.Y);
        }

        private void saveMapAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exportDict = new Dictionary<string, SpriteMapRegion>();
            foreach (SpriteMapRegion sprite in sprites)
            {
                if (exportDict.ContainsKey(sprite.Name))
                {
                    string errorMessage = "Duplicate names found! Please ensure all sprites have unique names.";
                    string caption = "Save Aborted";
                    MessageBoxButtons saveError = MessageBoxButtons.OK;

                    MessageBox.Show(errorMessage, caption, saveError);
                    return;
                }
                exportDict.Add(sprite.Name, sprite);
            }

            if (saveMapDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentSpriteMapFileLocation = saveMapDialog.FileName;

                using (XmlWriter writer = XmlWriter.Create(CurrentSpriteMapFileLocation))
                {
                    IntermediateSerializer.Serialize(writer, exportDict, null);
                }
            }

            saveSpriteMapToolStripMenuItem.Enabled = true;
        }

        private void saveSpriteMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentSpriteMapFileLocation != null)
            {
                var exportDict = new Dictionary<string, SpriteMapRegion>();
                foreach (SpriteMapRegion sprite in sprites)
                {
                    if (exportDict.ContainsKey(sprite.Name))
                    {
                        string errorMessage = "Duplicate names found! Please ensure all sprites have unique names.";
                        string caption = "Save Aborted";
                        MessageBoxButtons saveError = MessageBoxButtons.OK;

                        MessageBox.Show(errorMessage, caption, saveError);
                        return;
                    }
                    exportDict.Add(sprite.Name, sprite);
                }

                using (XmlWriter writer = XmlWriter.Create(CurrentSpriteMapFileLocation))
                {
                    IntermediateSerializer.Serialize(writer, exportDict, null);
                }
            }
        }

        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(loadMapDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentSpriteMapFileLocation = loadMapDialog.FileName;

                Dictionary<string, SpriteMapRegion> loadedSpriteMap;
                using (XmlReader xmlRead = XmlReader.Create(CurrentSpriteMapFileLocation))
                {
                    loadedSpriteMap = IntermediateSerializer.Deserialize<Dictionary<string, SpriteMapRegion>>(xmlRead, null);
                }

                sprites = new BindingList<SpriteMapRegion>();
                foreach(KeyValuePair<string, SpriteMapRegion> sprite in loadedSpriteMap)
                {
                    sprites.Add(sprite.Value);
                }

                spriteList.DataSource = sprites;
            }
        }

        private void spriteSheetViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if(spriteSheetViewer.Image == null)
                return;
            
            Point mousePosition = new Point(e.X, e.Y);

            bool hovering = false;

            foreach (SpriteMapRegion currentSprite in selectedSprites)
            {
                if (GetDrawingRect(currentSprite.Bounds).Contains(mousePosition))
                {
                    hovering = true;
                    Cursor = Cursors.SizeAll;
                    if (movingWithMouse)
                    {
                        newPosition = mousePosition;
                        newPosition.X /= zoomLevel;
                        newPosition.Y /= zoomLevel;
                        int differenceX = newPosition.X - oldPosition.X;
                        int differenceY = newPosition.Y - oldPosition.Y;

                        var groupRect = GetSelectedGroupRectangle();
                        if (groupRect.X + differenceX < 0 ||
                            groupRect.X + groupRect.Width + differenceX > spriteSheetViewer.Image.Width)
                            differenceX = 0;
                        if (groupRect.Y + differenceY < 0 ||
                            groupRect.Y + groupRect.Height + differenceY > spriteSheetViewer.Image.Height)
                            differenceY = 0;

                        foreach (SpriteMapRegion spriteToMove in selectedSprites)
                        {
                            var newBounds = spriteToMove.Bounds;
                            newBounds.X += differenceX;
                            newBounds.Y += differenceY;

                            newBounds = ClampRectangleToSheet(newBounds);

                            spriteToMove.Bounds = newBounds;
                        }
                        oldPosition = newPosition;
                        UpdateHighlightMask();
                        spriteSheetViewer.Refresh();
                        LoadSpriteEditorValues();
                        break;
                    }
                }
            }
            if(!hovering)
                Cursor = Cursors.Default;
        }

        private Microsoft.Xna.Framework.Rectangle ClampRectangleToSheet(Microsoft.Xna.Framework.Rectangle rect)
        {
            var clampedRect = rect;

            //clamp X value
            if (clampedRect.X < 0)
                clampedRect.X = 0;
            else if (clampedRect.X + clampedRect.Width > spriteSheetViewer.Image.Width)
                clampedRect.X = spriteSheetViewer.Image.Width - clampedRect.Width;
            //clamp Y value
            if (clampedRect.Y < 0)
                clampedRect.Y = 0;
            else if (clampedRect.Y + clampedRect.Height > spriteSheetViewer.Image.Height)
                clampedRect.Y = spriteSheetViewer.Image.Height - clampedRect.Height;

            return clampedRect;
        }

        private void spriteSheetViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (spriteSheetViewer.Image == null)
                return;

            Point mousePosition = new Point(e.X, e.Y);

            foreach (SpriteMapRegion currentSprite in selectedSprites)
            {
                if (GetDrawingRect(currentSprite.Bounds).Contains(mousePosition))
                {
                    movingWithMouse = true;
                    newPosition = mousePosition;
                    newPosition.X /= zoomLevel;
                    newPosition.Y /= zoomLevel;
                    oldPosition = newPosition;
                }
            }
        }

        private void spriteSheetViewer_MouseLeave(object sender, EventArgs e)
        {
            movingWithMouse = false;
            Cursor = Cursors.Default;
        }

        private void spriteSheetViewer_MouseUp(object sender, MouseEventArgs e)
        {
            movingWithMouse = false;
        }

        private void originXPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            foreach (SpriteMapRegion currentSprite in selectedSprites)
            {
                var newOrigin = currentSprite.Origin;
                newOrigin.X = (int)originXPosBox.Value;
                currentSprite.Origin = newOrigin;
            }
            spriteSheetViewer.Refresh();
        }

        private void originYPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            foreach (SpriteMapRegion currentSprite in selectedSprites)
            {
                var newOrigin = currentSprite.Origin;
                newOrigin.Y = (int)originYPosBox.Value;
                currentSprite.Origin = newOrigin;
            }
            spriteSheetViewer.Refresh();
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            if(spriteList.SelectedIndex < sprites.Count - 1)
            {
                var spriteBelow = sprites[spriteList.SelectedIndex + 1];
                sprites[spriteList.SelectedIndex + 1] = selectedSprites[0];
                sprites[spriteList.SelectedIndex] = spriteBelow;
                int newPosition = spriteList.SelectedIndex + 1;
                spriteList.SelectedIndices.Clear();
                spriteList.SelectedIndex = newPosition;
            }
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            if(spriteList.SelectedIndex > 0)
            {
                var spriteAbove = sprites[spriteList.SelectedIndex - 1];
                sprites[spriteList.SelectedIndex - 1] = selectedSprites[0];
                sprites[spriteList.SelectedIndex] = spriteAbove;
                int newPosition = spriteList.SelectedIndex - 1;
                spriteList.SelectedIndices.Clear();
                spriteList.SelectedIndex = newPosition;
            }
        }

        private void editingOriginCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            editingOrigin = editingOriginCheckBox.Checked;

            if (editingOrigin)
            {
                originXPosLabel.Enabled = true;
                originXPosBox.Enabled = true;
                originYPosLabel.Enabled = true;
                originYPosBox.Enabled = true;
            }
            else
            {
                originXPosLabel.Enabled = false;
                originXPosBox.Enabled = false;
                originYPosLabel.Enabled = false;
                originYPosBox.Enabled = false;
            }

            spriteViewerPanel.Refresh();
        }

        private void highlightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            highlight = highlightCheckBox.Checked;
            if (highlight)
            {
                UpdateHighlightMask();
            }
            spriteSheetViewer.Refresh();
        }

        private void outlineTimer_Tick(object sender, EventArgs e)
        {
            if (whitePen.DashOffset < 7)
                whitePen.DashOffset++;
            else
                whitePen.DashOffset = 0;
            spriteSheetViewer.Refresh();
        }
    }
}
