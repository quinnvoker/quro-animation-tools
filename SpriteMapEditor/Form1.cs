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

        private bool highlight = false;
        private SpriteMapRegion currentSprite { get { return sprites[spriteList.SelectedIndices[0]]; } }
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

            spriteList.DataSource = sprites;
            spriteList.DisplayMember = "Name";
            spriteList.ValueMember = "Bounds";

            originPointer_black = Properties.Resources.originPointer_black;
            originPointer_white = Properties.Resources.originPointer_white;

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
                    //SurroundWithTranslucentRects(GetDrawingRect(currentSprite.Bounds, false), Color.Gray, e.Graphics);
                    //e.Graphics.DrawImage(highlightMask.Bitmap, Point.Empty);
                    Rectangle highlightBounds = new Rectangle(0,0, highlightMask.Width * zoomLevel, highlightMask.Height * zoomLevel);
                    e.Graphics.DrawImage(highlightMask.Bitmap, highlightBounds);
                }
                    
                DrawHighContrastOutline(GetDrawingRect(currentSprite.Bounds), e.Graphics);

                //origin drawing code
                if (editingOrigin)
                {
                    var spriteSheet = (Bitmap)spriteSheetViewer.Image;
                    var colorAtOrigin = spriteSheet.GetPixel((int)(currentSprite.Bounds.X + currentSprite.Origin.X), 
                        (int)(currentSprite.Bounds.Y + currentSprite.Origin.Y));

                    var highContrastPointer = originPointer_black;
                    if (colorAtOrigin.GetBrightness() < 0.5f)
                    {
                        highContrastPointer = originPointer_white;
                    }

                    var drawPoint = GetOriginDrawingPoint(currentSprite);
                    drawPoint.X -= 5;
                    drawPoint.Y -= 5;

                    e.Graphics.DrawImage(highContrastPointer, drawPoint);
                }
            }
            base.OnPaint(e);
        }

        private void LoadSpriteEditorValues()
        {
            loadingSprite = true;
            spriteNameBox.Text = currentSprite.Name;
            spriteXPosBox.Value = currentSprite.Bounds.X;
            spriteYPosBox.Value = currentSprite.Bounds.Y;
            spriteWidthBox.Value = currentSprite.Bounds.Width;
            spriteHeightBox.Value = currentSprite.Bounds.Height;
            originXPosBox.Value = (int)currentSprite.Origin.X;
            originYPosBox.Value = (int)currentSprite.Origin.Y;
            loadingSprite = false;
        }

        private void UpdateSpriteBounds()
        {
            currentSprite.Bounds = new Microsoft.Xna.Framework.Rectangle((int)spriteXPosBox.Value, (int)spriteYPosBox.Value, (int)spriteWidthBox.Value, (int)spriteHeightBox.Value);
        }

        private void UpdateSpriteOrigin()
        {
            currentSprite.Origin = new Microsoft.Xna.Framework.Vector2((int)originXPosBox.Value, (int)originYPosBox.Value);
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

        private void UpdateHighlightMask()
        {
            if (highlight)
            {
                InitializeMask();
                for (int currentY = 0; currentY < currentSprite.Bounds.Height; currentY++)
                {
                    for (int currentX = 0; currentX < currentSprite.Bounds.Width; currentX++)
                    {
                        highlightMask.SetPixel(currentX + currentSprite.Bounds.X, currentY + currentSprite.Bounds.Y, Color.Transparent);
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
            using (Pen blackPen = new Pen(Color.Black))
            {
                graphics.DrawRectangle(blackPen, rect);
            }
            using (Pen whitePen = new Pen(Color.White))
            {
                whitePen.DashPattern = new float[] { 4, 4 };
                graphics.DrawRectangle(whitePen, rect);
            }
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
            UpdateSpriteBounds();
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void spriteYPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            UpdateSpriteBounds();
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void spriteWidthBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            UpdateSpriteBounds();
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void spriteHeightBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            UpdateSpriteBounds();
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void spriteNameBox_TextChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            currentSprite.Name = spriteNameBox.Text;
            sprites.ResetBindings();
        }

        private void addSpriteButton_Click(object sender, EventArgs e)
        {
            sprites.Add(new SpriteMapRegion(currentSprite.Name, currentSprite.Bounds));
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
                //currentSprite = sprites[spriteList.SelectedIndex];
                LoadSpriteEditorValues();
                UpdateHighlightMask();
                spriteSheetViewer.Refresh();
            }
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

            if (GetDrawingRect(currentSprite.Bounds).Contains(mousePosition))
            {
                Cursor = Cursors.SizeAll;
                if (movingWithMouse)
                {
                    newPosition = mousePosition;
                    newPosition.X /= zoomLevel;
                    newPosition.Y /= zoomLevel;
                    int differenceX = newPosition.X - oldPosition.X;
                    int differenceY = newPosition.Y - oldPosition.Y;
                    var newBounds = currentSprite.Bounds;
                    newBounds.X += differenceX;
                    newBounds.Y += differenceY;

                    newBounds = ClampRectangleToSheet(newBounds);

                    currentSprite.Bounds = newBounds;
                    oldPosition = newPosition;
                    UpdateHighlightMask();
                    spriteSheetViewer.Refresh();
                    LoadSpriteEditorValues();
                }
            }
            else
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

            if (GetDrawingRect(currentSprite.Bounds).Contains(mousePosition))
            {
                movingWithMouse = true;
                newPosition = mousePosition;
                newPosition.X /= zoomLevel;
                newPosition.Y /= zoomLevel;
                oldPosition = newPosition;
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
            UpdateSpriteOrigin();
            spriteSheetViewer.Refresh();
        }

        private void originYPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            UpdateSpriteOrigin();
            spriteSheetViewer.Refresh();
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            if(spriteList.SelectedIndex < sprites.Count - 1)
            {
                var spriteBelow = sprites[spriteList.SelectedIndex + 1];
                sprites[spriteList.SelectedIndex + 1] = currentSprite;
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
                sprites[spriteList.SelectedIndex - 1] = currentSprite;
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
    }
}
