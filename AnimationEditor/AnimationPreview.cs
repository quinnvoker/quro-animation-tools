using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using QURO;
using QURO.Animation;

namespace AnimationEditor
{
    class AnimationPreview : UpdateWindow
    {
        public Texture2D SpriteSheet { get; set; }
        public AnimatedSprite PreviewSprite { get; set; }
        public float ZoomLevel { get; set; }
        public Vector3 CameraLocation { get; set; }

        public List<Sprite> EditSprites { get; set; }

        public int PixelGridDisplayLevel { get; set; }
        public int GridSpacing { get; set; }
        public Color OriginGridLineColor { get; set; }
        public Color FullGridLineColor { get; set; }
        public Color HalfGridLineColor { get; set; }
        public Color PixelGridLineColor { get; set; }

        private Texture2D gridLine;
        private bool hovering;
        private bool dragging;
        private bool panning;
        private MouseState mState;
        private MouseState mState_old;

        private Vector2 totalDragDist;

        private Vector2 centerPoint
        {
            get { return  new Vector2((Editor.graphics.PresentationParameters.BackBufferWidth / 2), (Editor.graphics.PresentationParameters.BackBufferHeight / 2)); }
        }

        private EventHandler onFrameChanged;
        public event EventHandler FrameChanged
        {
            add
            {
                onFrameChanged += value;
            }
            remove
            {
                onFrameChanged -= value;
            }
        }

        private EventHandler onSpriteDragUpdate;
        public event EventHandler SpriteDragUpdate
        {
            add
            {
                onSpriteDragUpdate += value;
            }
            remove
            {
                onSpriteDragUpdate -= value;
            }
        }

        private EventHandler onSpriteDragCompleted;
        public event EventHandler SpriteDragCompleted
        {
            add
            {
                onSpriteDragCompleted += value;
            }
            remove
            {
                onSpriteDragCompleted -= value;
            }
        }

        private EventHandler onAnimationEnded;
        public event EventHandler AnimationEnded
        {
            add
            {
                onAnimationEnded += value;
            }
            remove
            {
                onAnimationEnded -= value;
            }
        }

        public bool Playing { get; set; }

        protected override void Initialize()
        {
            base.Initialize();
            gridLine = new Texture2D(Editor.graphics, 1, 1);
            gridLine.SetData(new Color[] { Color.White });
            GridSpacing = 16;
            PixelGridDisplayLevel = 5;
            OriginGridLineColor = new Color(204, 204, 204);
            FullGridLineColor = new Color(145, 135, 120);
            HalfGridLineColor = new Color(120, 117, 115);
            PixelGridLineColor = new Color(113, 110, 108);
            CameraLocation = new Vector3();
            ZoomLevel = 1;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MouseControl();

            if (Playing && PreviewSprite != null)
            {
                if (!PreviewSprite.CurrentAnimation.IsLooping && PreviewSprite.CurrentFrameIndex == PreviewSprite.CurrentAnimation.Frames.Count() - 1)
                {
                    OnAnimationEnded(new EventArgs());
                }
                else
                {
                    PreviewSprite.Update(gameTime);
                    OnFrameChanged(new EventArgs());
                }
            }
        }

        private void MouseControl()
        {
            mState = Mouse.GetState();

            //fix for when detecting the mouse being within Bounds made an uninteractable section appear at the top of screen and allowed interaction below bottom
            Rectangle frame = new Rectangle(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
            frame.Y = 0;

            if (frame.Contains(mState.X, mState.Y))
            {
                HandleDragging();
                HandlePanning();
            }
            else
            {
                if (hovering)
                    Cursor = System.Windows.Forms.Cursors.Default;
                hovering = false;
                dragging = false;
            }

            mState_old = mState;
        }

        private void HandleDragging()
        {
            if (EditSprites != null && EditSprites.Count > 0)
            {
                bool hoverFound = false;
                foreach (Sprite spr in EditSprites)
                {
                    /*create draggable rect spriteRect at 0,0
                     *rect is scaled by Zoomlevel to match sprite's onscreen size
                     *rect is then offset to match sprite's offset & origin(multiplied by the zoomlevel)
                     *rect is then offset by the camera's location(multiplied by zoomlevel) and the onscreen centerpoint
                     *this results in a rect that matches the sprite's onscreen position regardless of pan or zoom
                     */
                    Rectangle sprRect = new Rectangle(0, 0, (int)(spr.Bounds.Width * ZoomLevel), (int)(spr.Bounds.Height * ZoomLevel));
                    sprRect.Offset((spr.Offset - spr.Origin) * ZoomLevel + new Vector2(CameraLocation.X, CameraLocation.Y) * ZoomLevel + centerPoint);
                    if (sprRect.Contains(mState.Position))
                    {
                        hoverFound = true;
                        break;
                    }
                }

                if (hoverFound)
                {
                    if (!hovering)
                    {
                        Cursor = System.Windows.Forms.Cursors.SizeAll;
                        hovering = true;
                    }
                }
                else
                {
                    if (hovering && !dragging)
                    {
                        Cursor = System.Windows.Forms.Cursors.Default;
                        hovering = false;
                    }
                }

                if (mState.LeftButton == ButtonState.Pressed && mState.RightButton != ButtonState.Pressed && mState_old.LeftButton != ButtonState.Pressed)
                {
                    dragging = hovering;
                    if (dragging)
                    {
                        totalDragDist = Vector2.Zero;
                    }
                }

                if (mState.LeftButton != ButtonState.Pressed)
                {
                    if(dragging && totalDragDist != Vector2.Zero)
                    {
                        OnSpriteDragCompleted(new Modifications.SpriteDragArgs(totalDragDist));

                    }
                    dragging = false;
                }

                if (dragging)
                {
                    var mousePosScaled = (mState.Position.ToVector2() / ZoomLevel).ToPoint();
                    var mousePosOldScaled = (mState_old.Position.ToVector2() / ZoomLevel).ToPoint();

                    Vector2 distMoved = new Vector2(mousePosScaled.X - mousePosOldScaled.X, mousePosScaled.Y - mousePosOldScaled.Y);

                    if (distMoved != Vector2.Zero)
                    {
                        totalDragDist += distMoved;
                        foreach(Sprite spr in EditSprites)
                        {
                            spr.Offset += distMoved;
                        }
                        OnSpriteDragUpdate(new EventArgs());
                    }
                }
            }
        }

        private void HandlePanning()
        {
            if (Enabled)
            {
                if (mState.RightButton == ButtonState.Pressed && mState.LeftButton != ButtonState.Pressed && mState_old.RightButton != ButtonState.Pressed)
                    panning = true;

                if (mState.RightButton != ButtonState.Pressed)
                {
                    //if the camera has been panned, lock the camera position to integers to prevent ugly misaligned sprites
                    if (panning)
                        CameraLocation = new Vector3((int)CameraLocation.X, (int)CameraLocation.Y, (int)CameraLocation.Z);
                    panning = false;
                }

                if (panning)
                {
                    Vector3 distMoved = new Vector3(mState.X - mState_old.X, mState.Y - mState_old.Y, 0);

                    if (distMoved != Vector3.Zero)
                    {
                        CameraLocation += distMoved / ZoomLevel;
                    }
                }
            }
        }

        protected virtual void OnSpriteDragCompleted(EventArgs e)
        { 
            onSpriteDragCompleted?.Invoke(this, e);
        }

        protected virtual void OnSpriteDragUpdate(EventArgs e)
        {
            onSpriteDragUpdate?.Invoke(this, e);
        }

        protected virtual void OnFrameChanged(EventArgs e)
        {
            onFrameChanged?.Invoke(this, e);
        }

        protected virtual void OnAnimationEnded(EventArgs e)
        {
            onAnimationEnded?.Invoke(this, e);
        }

        protected override void Draw()
        {
            base.Draw();
            //camera matrix moves translates world space in relation to camera position
            Matrix cameraMatrix = Matrix.CreateTranslation(CameraLocation);
            //zoom matrix scales up everything in world space
            Matrix zoomMatrix = Matrix.CreateScale(ZoomLevel);
            //center matrix repositions camera within zoomed space
            Matrix centerMatrix = Matrix.CreateTranslation(new Vector3(centerPoint, 0));
            Matrix transformMatrix = cameraMatrix * zoomMatrix * centerMatrix;

            Editor.graphics.Clear(Color.DimGray);

            Editor.spriteBatch.Begin();
            DrawGrid();
            Editor.spriteBatch.End();

            if (ZoomLevel >= 1)
                Editor.spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: transformMatrix);
            else
                Editor.spriteBatch.Begin(transformMatrix: transformMatrix);
            PreviewSprite?.Draw(Editor.spriteBatch, SpriteSheet, Vector2.Zero, Color.White);

            Editor.spriteBatch.End();

        }

        private void DrawGrid()
        {
            
            List<int>[] verticalLines = new List<int>[] { new List<int>(), new List<int>(), new List<int>(), new List<int>() };
            List<int>[] horizontalLines = new List<int>[] { new List<int>(), new List<int>(), new List<int>(), new List<int>() };

            /*
             * Scans each horizontal pixel in viewspace
             * If pixel lines up with a gridmarked position in worldspace, add that position to the verticalLines list, in appropriate category for grid type
             */
            int increment = 1;
            for (int x = 0; x < Editor.graphics.PresentationParameters.BackBufferWidth; x += increment)
            {
                int xPosInWorldSpace = x - (int)((CameraLocation.X * ZoomLevel) + centerPoint.X);
                if (xPosInWorldSpace == 0)
                {
                    verticalLines[3].Add(x);
                }
                else if (xPosInWorldSpace % (GridSpacing * ZoomLevel) == 0)
                {
                    verticalLines[2].Add(x);
                }
                else if (xPosInWorldSpace % (GridSpacing / 2 * ZoomLevel) == 0)
                {
                    verticalLines[1].Add(x);
                    if(increment == 1 && ZoomLevel < PixelGridDisplayLevel)
                        increment = (int)(GridSpacing / 2 * ZoomLevel);
                }
                else if (ZoomLevel >= PixelGridDisplayLevel && xPosInWorldSpace % ZoomLevel == 0)
                {
                    verticalLines[0].Add(x);
                    if (increment == 1)
                        increment = (int)ZoomLevel;
                }
            }

            //Same as above, but scans vertically for horizontal lines
            increment = 1;
            for (int y = 0; y < Editor.graphics.PresentationParameters.BackBufferHeight; y += increment)
            {
                int yPosInWorldSpace = y - (int)((CameraLocation.Y * ZoomLevel) + centerPoint.Y);
                if (yPosInWorldSpace == 0)
                {
                    horizontalLines[3].Add(y);
                }
                else if (yPosInWorldSpace % (GridSpacing * ZoomLevel) == 0)
                {
                    horizontalLines[2].Add(y);
                }
                else if (yPosInWorldSpace % (GridSpacing / 2 * ZoomLevel) == 0)
                {
                    horizontalLines[1].Add(y);
                    if (increment == 1 && ZoomLevel < PixelGridDisplayLevel)
                        increment = (int)(GridSpacing / 2 * ZoomLevel);
                }
                else if (ZoomLevel >= PixelGridDisplayLevel && yPosInWorldSpace % ZoomLevel == 0)
                {
                    horizontalLines[0].Add(y);
                    if (increment == 1)
                        increment = (int)ZoomLevel;
                }
            }

            //draw collected gridlines in order from low to high priority (pixelGridLine -> originGridLine)
            Color drawColor = PixelGridLineColor;
            for(int index = 0; index < 4; index++)
            {
                switch (index)
                {
                    case 1:
                        drawColor = HalfGridLineColor;
                        break;
                    case 2:
                        drawColor = FullGridLineColor;
                        break;
                    case 3:
                        drawColor = OriginGridLineColor;
                        break;
                }

                foreach(int x in verticalLines[index])
                {
                    DrawVerticalGridLine(x, drawColor);
                }
                foreach(int y in horizontalLines[index])
                {
                    DrawHorizontalGridLine(y, drawColor);
                }
            }
        }

        private void DrawHorizontalGridLine(int y, Color color)
        {
            Editor.spriteBatch.Draw(gridLine, new Rectangle(0, y, Editor.graphics.PresentationParameters.BackBufferWidth, 1), color);
        }
        private void DrawVerticalGridLine(int x, Color color)
        {
            Editor.spriteBatch.Draw(gridLine, new Rectangle(x, 0, 1, Editor.graphics.PresentationParameters.BackBufferHeight), color);
        }
    }
}
