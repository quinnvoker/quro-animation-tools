using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;


namespace SpriteMapEditor
{
    public partial class Form1 : Form
    {
        private BindingList<Sprite> sprites;

        private bool highlight = false;
        private Sprite currentSprite;
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

            sprites = new BindingList<Sprite> { new Sprite() };

            currentSprite = sprites[0];

            spriteList.DataSource = sprites;
            spriteList.DisplayMember = "Name";
            spriteList.ValueMember = "Bounds";

            LoadSpriteEditorValues();
        }

        private void loadSpriteSheetButton_Click(object sender, EventArgs e)
        {
            if(loadSpriteSheetDialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                spriteSheetViewer.Image = Image.FromFile(loadSpriteSheetDialogue.FileName);
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
            loadingSprite = false;
        }

        private void UpdateSpriteBounds()
        {
            currentSprite.Bounds = new Rectangle((int)spriteXPosBox.Value, (int)spriteYPosBox.Value, (int)spriteWidthBox.Value, (int)spriteHeightBox.Value);
        }

        private Rectangle GetDrawingRect(Rectangle baseRect, bool outline = true)
        {
            var drawingRect = baseRect;
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
            sprites.Add(new Sprite(currentSprite.Name, currentSprite.Bounds));
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
            if (saveMapDialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XmlSerializer mapSerializer = new XmlSerializer(typeof(List<Sprite>));
                TextWriter mapWriter = new StreamWriter(saveMapDialogue.FileName);

                var exportList = sprites.ToList();

                mapSerializer.Serialize(mapWriter, exportList);
                mapWriter.Close();
            }
        }

        private void loadMapButton_Click(object sender, EventArgs e)
        {
            if(loadMapDialogue.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XmlSerializer mapSerializer = new XmlSerializer(typeof(List<Sprite>));
                TextReader mapReader = new StreamReader(loadMapDialogue.FileName);

                sprites = new BindingList<Sprite>((List<Sprite>)mapSerializer.Deserialize(mapReader));
                mapReader.Close();

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

        private void spriteList_MouseDown(object sender, MouseEventArgs e)
        {
            if (rearrangingSprites)
            {
                if (spriteList.SelectedItem == null)
                    return;
                spriteList.DoDragDrop(spriteList.SelectedItem, DragDropEffects.Move);
            }
        }

        private void spriteList_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void spriteList_DragDrop(object sender, DragEventArgs e)
        {
            Point point = spriteList.PointToClient(new Point(e.X, e.Y));
            int index = spriteList.IndexFromPoint(point);
            if (index < 0)
                index = spriteList.Items.Count - 1;
            Sprite data = (Sprite)spriteList.SelectedItem;
            sprites.Remove(data);
            sprites.Insert(index, data);
        }

        private void rearrangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            rearrangingSprites = rearrangeCheckBox.Checked;
            spriteList.AllowDrop = rearrangeCheckBox.Checked;
        }
    }
}
