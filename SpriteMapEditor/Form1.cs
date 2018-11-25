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
        private SpriteMapRegion currentSprite;
        private int zoomLevel = 3;

        private bool loadingSprite = false;
        private bool movingWithMouse = false;
        private bool rearrangingSprites = false;

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

            currentSprite = sprites[0];

            spriteList.DataSource = sprites;
            spriteList.DisplayMember = "Name";
            spriteList.ValueMember = "Bounds";

            LoadSpriteEditorValues();
        }

        private void loadSpriteSheetButton_Click(object sender, EventArgs e)
        {
            if(loadSpriteSheetDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                spriteSheetViewer.Image = Image.FromFile(loadSpriteSheetDialog.FileName);
            }
        }

        private void spriteSheetViewer_Paint(object sender, PaintEventArgs e)
        {
            if (spriteSheetViewer.Image != null)
            {
                spriteSheetViewer.Width = spriteSheetViewer.Image.Width * zoomLevel;
                spriteSheetViewer.Height = spriteSheetViewer.Image.Height * zoomLevel;

                if (highlight)
                    SurroundWithTranslucentRects(GetDrawingRect(currentSprite.Bounds, false), Color.Gray, e.Graphics);
                DrawHighContrastOutline(GetDrawingRect(currentSprite.Bounds), e.Graphics);
                /*
                 * Origin display code, uncomment when ready to implement
                 * 
                using (Brush magentaBrush = new SolidBrush(Color.Magenta))
                {
                    e.Graphics.FillRectangle(magentaBrush, GetOriginDrawingRect(currentSprite));
                }
                */
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

            if (outline)
            {
                drawingRect.X--;
                drawingRect.Y--;
                drawingRect.Width++;
                drawingRect.Height++;
            }

            return drawingRect;
        }

        private Rectangle GetOriginDrawingRect(SpriteMapRegion sprite)
        {
            var drawingRect = new Rectangle(sprite.Bounds.X, sprite.Bounds.Y, 2, 2);
            drawingRect.X = drawingRect.X * zoomLevel - (zoomLevel - 1);
            drawingRect.Y = drawingRect.Y * zoomLevel - (zoomLevel - 1);
            drawingRect.X += drawingRectangleOffset;
            drawingRect.Y += drawingRectangleOffset;
            drawingRect.X += (int)sprite.Origin.X * zoomLevel;
            drawingRect.Y += (int)sprite.Origin.Y * zoomLevel;
            return drawingRect;
        }

        private void SurroundWithTranslucentRects(Rectangle rect, Color color, Graphics graphics)
        {
            Rectangle topBorder = new Rectangle(0, 0, spriteSheetViewer.Width, rect.Y);
            Rectangle leftBorder = new Rectangle(0, rect.Y, rect.X, rect.Height);
            Rectangle rightBorder = new Rectangle(rect.X + rect.Width, rect.Y, spriteSheetViewer.Width - rect.X + rect.Width, rect.Height);
            Rectangle bottomBorder = new Rectangle(0, rect.Y + rect.Height, spriteSheetViewer.Width, spriteSheetViewer.Height - rect.Y + rect.Height);
            FillTranslucentRects(new Rectangle[] { topBorder, leftBorder, rightBorder, bottomBorder }, color, graphics);
        }

        private void FillTranslucentRect(Rectangle rect, Color color, Graphics graphics)
        {
            using (Brush whiteBrush = new SolidBrush(Color.FromArgb(128, color)))
            {
                graphics.FillRectangle(whiteBrush, rect);
            }
        }

        private void FillTranslucentRects(Rectangle[] rects, Color color, Graphics graphics)
        {
            using (Brush whiteBrush = new SolidBrush(Color.FromArgb(128, color)))
            {
                graphics.FillRectangles(whiteBrush, rects);
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

        private void highlightButton_Click(object sender, EventArgs e)
        {
            highlight = !highlight;
            if (highlight)
                fillButton.Text = "No Highlight";
            else
                fillButton.Text = "Highlight";
            spriteSheetViewer.Refresh();
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
            spriteSheetViewer.Refresh();
        }

        private void spriteYPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            UpdateSpriteBounds();
            spriteSheetViewer.Refresh();
        }

        private void spriteWidthBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            UpdateSpriteBounds();
            spriteSheetViewer.Refresh();
        }

        private void spriteHeightBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            UpdateSpriteBounds();
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
                currentSprite = sprites[spriteList.SelectedIndex];
                LoadSpriteEditorValues();
                spriteSheetViewer.Refresh();
            }
        }

        private void saveMapButton_Click(object sender, EventArgs e)
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
                using (XmlWriter writer = XmlWriter.Create(saveMapDialog.FileName))
                {
                    IntermediateSerializer.Serialize(writer, exportDict, null);
                }
            }
        }

        private void loadMapButton_Click(object sender, EventArgs e)
        {
            if(loadMapDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Dictionary<string, SpriteMapRegion> loadedSpriteMap;
                using (XmlReader xmlRead = XmlReader.Create(loadMapDialog.FileName))
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
                    Console.WriteLine(differenceX + ", " + differenceY);
                    var newBounds = currentSprite.Bounds;
                    newBounds.X += differenceX;
                    newBounds.Y += differenceY;

                    currentSprite.Bounds = newBounds;
                    oldPosition = newPosition;
                    spriteSheetViewer.Refresh();
                    LoadSpriteEditorValues();
                }
            }
            else
                Cursor = Cursors.Default;
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
                spriteList.SelectedIndex++;
            }
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            if(spriteList.SelectedIndex > 0)
            {
                var spriteAbove = sprites[spriteList.SelectedIndex - 1];
                sprites[spriteList.SelectedIndex - 1] = currentSprite;
                sprites[spriteList.SelectedIndex] = spriteAbove;
                spriteList.SelectedIndex--;
            }
        }
    }
}
