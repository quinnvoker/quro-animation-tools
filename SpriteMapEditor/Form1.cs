using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
using SpriteMapEditor.SpriteMapModifications;


namespace SpriteMapEditor
{
    public partial class Form1 : Form
    {
        private History undoHistory;

        private BindingList<Sprite> sprites;
        private List<Sprite> selectedSprites;

        private bool highlight = false;
        private int zoomLevel = 3;

        private bool loadingSprite = false;
        private bool movingWithMouse = false;
        private bool editingOrigin = false;

        const string TITLE = "QUROGames Sprite Map Editor";
        private string _currentSpriteMapFileLocation;
        private string CurrentSpriteMapFileLocation
        {
            get { return _currentSpriteMapFileLocation; }
            set
            {
                _currentSpriteMapFileLocation = value;
                loadMapDialog.FileName = _currentSpriteMapFileLocation;
                saveMapDialog.FileName = _currentSpriteMapFileLocation;
            }
        }
        private string _currentSpriteSheetFileLocation;
        private string CurrentSpriteSheetFileLocation
        {
            get { return _currentSpriteSheetFileLocation; }
            set
            {
                _currentSpriteSheetFileLocation = value;
                loadSpriteSheetDialog.FileName = _currentSpriteSheetFileLocation;
            }
        }
        private string _currentProjectFileLocation;
        private string CurrentProjectFileLocation
        {
            get { return _currentProjectFileLocation; }
            set
            {
                _currentProjectFileLocation = value;
                Text = TITLE + " - " + Path.GetFileName(_currentProjectFileLocation);
                openProjectDialog.FileName = _currentProjectFileLocation;
                saveProjectDialog.FileName = _currentProjectFileLocation;
            }
        }

        Image originPointer_black;
        Image originPointer_white;

        Image spriteSheet;

        Pen blackPen;
        Pen whitePen;

        DirectBitmap baseMask;
        DirectBitmap highlightMask;

        private Point newPosition;
        private Point oldPosition;

        private List<Microsoft.Xna.Framework.Rectangle> preDragBounds;

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;

            undoHistory = new History();

            originPresetBox.DataSource = Enum.GetValues(typeof(OriginPreset));

            spriteSheetViewer.Width = 1;
            spriteSheetViewer.Height = 1;

            sprites = new BindingList<Sprite> { new Sprite() };
            selectedSprites = new List<Sprite>();

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

        private void newProjectMenuItem_Click(object sender, EventArgs e)
        {
            undoHistory = new History();

            CurrentProjectFileLocation = null;
            CurrentSpriteMapFileLocation = null;
            CurrentSpriteSheetFileLocation = null;

            sprites = new BindingList<Sprite>() { new Sprite() };
            LoadSpriteSheet();
            if (spriteSheet == null)
                return;
            spriteList.DataSource = sprites;
        }

        private void LoadSpriteSheet()
        {
            if (loadSpriteSheetDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentSpriteSheetFileLocation = loadSpriteSheetDialog.FileName;

                spriteSheet = Image.FromFile(CurrentSpriteSheetFileLocation);
                spriteSheetViewer.Image = spriteSheet;
                if (spriteSheet == null)
                    return;
                importSpriteSheetToolStripMenuItem.Text = "Replace Sprite Sheet...";
                InitializeMask();
                EnableEditing();
            }
        }

        private void LoadSpriteMap()
        {
            if (loadMapDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentSpriteMapFileLocation = loadMapDialog.FileName;

                Dictionary<string, Sprite> loadedSpriteMap;
                using (XmlReader xmlRead = XmlReader.Create(CurrentSpriteMapFileLocation))
                {
                    loadedSpriteMap = IntermediateSerializer.Deserialize<Dictionary<string, Sprite>>(xmlRead, null);
                }

                sprites = new BindingList<Sprite>();
                foreach (KeyValuePair<string, Sprite> sprite in loadedSpriteMap)
                {
                    sprites.Add(sprite.Value);
                }

                spriteList.DataSource = sprites;
            }
        }

        private void SaveProject()
        {
            if (CurrentProjectFileLocation != null)
            {
                SpriteMapProject project = new SpriteMapProject(CurrentSpriteSheetFileLocation, sprites.ToList());

                using (XmlWriter writer = XmlWriter.Create(CurrentProjectFileLocation))
                {
                    IntermediateSerializer.Serialize(writer, project, null);
                }
            }
        }

        private void LoadProject()
        {
            undoHistory = new History();

            SpriteMapProject loadedProject;

            using (XmlReader xmlRead = XmlReader.Create(CurrentProjectFileLocation))
            {
                loadedProject = IntermediateSerializer.Deserialize<SpriteMapProject>(xmlRead, null);
            }

            if (File.Exists(loadedProject.SpriteSheetFileLocation))
            {
                CurrentSpriteSheetFileLocation = loadedProject.SpriteSheetFileLocation;
                spriteSheet = Image.FromFile(loadedProject.SpriteSheetFileLocation);
                spriteSheetViewer.Image = spriteSheet;
                InitializeMask();
                EnableEditing();
            }
            else
            {
                MessageBox.Show("Image referenced by project not found!\nPlease locate a new Sprite Sheet image...");
                LoadSpriteSheet();
            }
            if (spriteSheet == null)
                return;

            importSpriteSheetToolStripMenuItem.Text = "Replace Sprite Sheet...";

            sprites = new BindingList<Sprite>(loadedProject.SpriteMap);
            spriteList.DataSource = sprites;

            saveProjectToolStripMenuItem.Enabled = true;
        }

        private void EnableEditing()
        {
            importSpriteMapToolStripMenuItem.Enabled = true;
            exportSpriteMapToolStripMenuItem.Enabled = true;
            saveProjectAsToolStripMenuItem.Enabled = true;
            spriteListEditPanel.Enabled = true;
            spriteEditPanel.Enabled = true;
            viewEditPanel.Enabled = true;
            spriteViewerPanel.Enabled = true;
        }

        private void spriteSheetViewer_Paint(object sender, PaintEventArgs e)
        {
            if (spriteSheet != null)
            {
                spriteSheetViewer.Width = spriteSheet.Width * zoomLevel;
                spriteSheetViewer.Height = spriteSheet.Height * zoomLevel;

                if (highlight)
                {
                    Rectangle highlightBounds = new Rectangle(0,0, highlightMask.Width * zoomLevel, highlightMask.Height * zoomLevel);
                    e.Graphics.DrawImage(highlightMask.Bitmap, highlightBounds);
                }

                foreach (Sprite currentSprite in selectedSprites)
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
                Sprite currentSprite = selectedSprites[0];
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
            originPresetBox.SelectedIndex = 0;
            loadingSprite = false;
        }

        private Rectangle GetDrawingRect(Microsoft.Xna.Framework.Rectangle baseRect, bool outline = true)
        {
            var drawingRect = new Rectangle(baseRect.X, baseRect.Y, baseRect.Width, baseRect.Height);
            drawingRect.X = drawingRect.X * zoomLevel + 1;
            drawingRect.Y = drawingRect.Y * zoomLevel + 1;
            drawingRect.Width *= zoomLevel;
            drawingRect.Height *= zoomLevel;

            drawingRect.Width--;
            drawingRect.Height--;

            return drawingRect;
        }

        private Point GetOriginDrawingPoint(Sprite sprite)
        {
            var drawingPoint = new Point(sprite.Bounds.X, sprite.Bounds.Y);
            drawingPoint.X = drawingPoint.X * zoomLevel;
            drawingPoint.Y = drawingPoint.Y * zoomLevel;
            drawingPoint.X += (int)sprite.Origin.X * zoomLevel;
            drawingPoint.Y += (int)sprite.Origin.Y * zoomLevel;
            return drawingPoint;
        }

        private void DrawOriginPoint(Sprite sprite, Graphics graphics)
        {
            if (editingOrigin)
            {
                var spriteSheetBitmap = (Bitmap)spriteSheet;
                var colorAtOrigin = spriteSheetBitmap.GetPixel((int)(sprite.Bounds.X + sprite.Origin.X),
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
                foreach (Sprite currentSprite in selectedSprites)
                {
                    var highlightRect = currentSprite.Bounds;

                    //make sure highlight mask update doesn't attempt to write to pixels that are out of bounds
                    var oobX = highlightRect.X + highlightRect.Width - spriteSheet.Width;
                    var oobY = highlightRect.Y + highlightRect.Height - spriteSheet.Height;
                    if (oobX > 0)
                        highlightRect.Width -= oobX;
                    if (oobY > 0)
                        highlightRect.Height -= oobY;

                    for (int currentY = 0; currentY < highlightRect.Height; currentY++)
                    {
                        for (int currentX = 0; currentX < highlightRect.Width; currentX++)
                        {
                            highlightMask.SetPixel(currentX + highlightRect.X, currentY + highlightRect.Y, Color.Transparent);
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

                highlightMask = new DirectBitmap(spriteSheet.Width, spriteSheet.Height);
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
                highlightMask.Dispose();
                highlightMask = new DirectBitmap(baseMask);
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
            var modification = new ModifyBounds(selectedSprites, x: (int)spriteXPosBox.Value);
            ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
            undoHistory.Add(modification);
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void spriteYPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            var modification = new ModifyBounds(selectedSprites, y: (int)spriteYPosBox.Value);
            ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
            undoHistory.Add(modification);
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void spriteWidthBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            var modification = new ModifyBounds(selectedSprites, width: (int)spriteWidthBox.Value);
            ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
            undoHistory.Add(modification);
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void spriteHeightBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            var modification = new ModifyBounds(selectedSprites, height: (int)spriteHeightBox.Value);
            ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
            undoHistory.Add(modification);
            UpdateHighlightMask();
            spriteSheetViewer.Refresh();
        }

        private void addSpriteButton_Click(object sender, EventArgs e)
        {
            var modification = new AddSprite(sprites, selectedSprites[0]);
            ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
            undoHistory.Add(modification);
        }

        private void removeSpriteButton_Click(object sender, EventArgs e)
        {
            int indexToRemove = spriteList.SelectedIndex;
            if (indexToRemove == sprites.Count - 1)
            {
                spriteList.SelectedIndices.Clear();
                spriteList.SelectedIndex = indexToRemove - 1;
            }

            if (indexToRemove > -1 && indexToRemove < sprites.Count)
            {
                var modification = new RemoveSprite(sprites, indexToRemove);
                ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
                undoHistory.Add(modification);
            }
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

            foreach (Sprite currentSprite in selectedSprites)
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

        private void exportMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exportDict = new Dictionary<string, Sprite>();
            foreach (Sprite sprite in sprites)
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
        }

        private void importMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSpriteMap();
        }

        private void spriteSheetViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if(spriteSheet == null)
                return;
            
            Point mousePosition = new Point(e.X, e.Y);

            bool hovering = false;

            foreach (Sprite currentSprite in selectedSprites)
            {
                if (GetDrawingRect(currentSprite.Bounds).Contains(mousePosition))
                {
                    hovering = true;
                    Cursor = Cursors.SizeAll;
                }
            }

            if (movingWithMouse)
            {
                newPosition = mousePosition;
                newPosition.X /= zoomLevel;
                newPosition.Y /= zoomLevel;
                int differenceX = newPosition.X - oldPosition.X;
                int differenceY = newPosition.Y - oldPosition.Y;

                var groupRect = GetSelectedGroupRectangle();
                if (groupRect.X + differenceX < 0 ||
                    groupRect.X + groupRect.Width + differenceX > spriteSheet.Width)
                    differenceX = 0;
                if (groupRect.Y + differenceY < 0 ||
                    groupRect.Y + groupRect.Height + differenceY > spriteSheet.Height)
                    differenceY = 0;

                foreach (Sprite spriteToMove in selectedSprites)
                {
                    var newBounds = spriteToMove.Bounds;
                    newBounds.X += differenceX;
                    newBounds.Y += differenceY;
                    spriteToMove.Bounds = newBounds;
                }
                oldPosition = newPosition;
                UpdateHighlightMask();
                spriteSheetViewer.Refresh();
                LoadSpriteEditorValues();
            }

            if (!hovering)
                Cursor = Cursors.Default;
        }

        private void spriteSheetViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (spriteSheet == null)
                return;

            Point mousePosition = new Point(e.X, e.Y);

            foreach (Sprite currentSprite in selectedSprites)
            {
                if (GetDrawingRect(currentSprite.Bounds).Contains(mousePosition))
                {
                    movingWithMouse = true;
                    preDragBounds = new List<Microsoft.Xna.Framework.Rectangle>();
                    foreach (Sprite sprite in selectedSprites)
                    {
                        preDragBounds.Add(sprite.Bounds);
                    }
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
            if (movingWithMouse)
            {
                movingWithMouse = false;
                var totalDragX = selectedSprites[0].Bounds.X - preDragBounds[0].X;
                var totalDragY = selectedSprites[0].Bounds.Y - preDragBounds[0].Y;
                if (totalDragX != 0 || totalDragY != 0)
                {
                    var modification = new MoveBounds(selectedSprites, totalDragX, totalDragY, preDragBounds);
                    modification.Undo();
                    ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
                    undoHistory.Add(modification);
                }
            }
        }

        private void originXPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            var modification = new ModifyOrigin(selectedSprites, x: (int)originXPosBox.Value);
            ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
            undoHistory.Add(modification);
            spriteSheetViewer.Refresh();
        }

        private void originYPosBox_ValueChanged(object sender, EventArgs e)
        {
            if (loadingSprite)
                return;
            var modification = new ModifyOrigin(selectedSprites, y: (int)originYPosBox.Value);
            ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
            undoHistory.Add(modification);
            spriteSheetViewer.Refresh();
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            if(spriteList.SelectedIndex < sprites.Count - 1)
            {
                var modification = new MoveSpriteListEntry(sprites, spriteList.SelectedIndex, 1);
                ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
                undoHistory.Add(modification);
                int newPosition = spriteList.SelectedIndex + 1;
                spriteList.SelectedIndices.Clear();
                spriteList.SelectedIndex = newPosition;
            }
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            if(spriteList.SelectedIndex > 0)
            {
                var modification = new MoveSpriteListEntry(sprites, spriteList.SelectedIndex, -1);
                ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
                undoHistory.Add(modification);
                int newPosition = spriteList.SelectedIndex - 1;
                spriteList.SelectedIndices.Clear();
                spriteList.SelectedIndex = newPosition;
            }
        }

        private void editingOriginCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            editingOrigin = editingOriginCheckBox.Checked;

            originEditPanel.Enabled = editingOrigin;

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

        private void UpdateSpriteName()
        {
            var modification = new RenameSprite(selectedSprites[0], spriteNameBox.Text);
            ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
            undoHistory.Add(modification);
            sprites.ResetBindings();
        }

        private void spriteNameBox_Leave(object sender, EventArgs e)
        {
            if (selectedSprites[0].Name != spriteNameBox.Text)
            {
                UpdateSpriteName();
            }
        }

        private void spriteNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && selectedSprites[0].Name != spriteNameBox.Text)
            {
                UpdateSpriteName();
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (selectedSprites[0].Name != spriteNameBox.Text)
            {
                UpdateSpriteName();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.Z)
                {
                    //Console.WriteLine("Undo Keypress");
                    undoHistory.Undo(spriteList);
                }
                else if (e.KeyCode == Keys.Y)
                {
                    //Console.WriteLine("Redo Keypress");
                    undoHistory.Redo(spriteList);
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoHistory.Undo(spriteList);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoHistory.Redo(spriteList);
        }

        private void originPresetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((OriginPreset)originPresetBox.SelectedIndex == OriginPreset.None)
                return;
            var modification = new ApplyOriginPreset(selectedSprites, 
                (OriginPreset)originPresetBox.SelectedIndex);
            ModHelper.DoModificationWithSelectionTracking(modification, spriteList);
            undoHistory.Add(modification);
            spriteSheetViewer.Refresh();
        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveProjectDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CurrentProjectFileLocation = saveProjectDialog.FileName;

                SaveProject();
            }

            saveProjectToolStripMenuItem.Enabled = true;
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openProjectDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentProjectFileLocation = openProjectDialog.FileName;

                LoadProject();
            }
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void importSpriteSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSpriteSheet();
        }
    }
}
