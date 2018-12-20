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

        public Sprite EditSprite { get; set; }

        public int GridSpacing { get; set; }

        private Texture2D gridLine;
        private bool hovering;
        private bool dragging;
        private MouseState mState;
        private MouseState mState_old;

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

        private EventHandler onSpriteMoved;
        public event EventHandler SpriteMoved
        {
            add
            {
                onSpriteMoved += value;
            }
            remove
            {
                onSpriteMoved -= value;
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
            GridSpacing = 8;
            ZoomLevel = 1;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

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
            else if(PreviewSprite != null)
            {
                MouseControl();
            }
        }

        private void MouseControl()
        {
            mState = Mouse.GetState();
            if(EditSprite != null)
            {
                Rectangle spriteRect = new Rectangle((int)(centerPoint.X), (int)(centerPoint.Y), (int)(EditSprite.Bounds.Width * ZoomLevel), (int)(EditSprite.Bounds.Height * ZoomLevel));
                spriteRect.Offset((EditSprite.Offset - EditSprite.Origin) * ZoomLevel);

                if (Bounds.Contains(mState.X, mState.Y))
                {
                    if (spriteRect.Contains(mState.Position))
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

                    if (mState.LeftButton == ButtonState.Pressed && mState_old.LeftButton != ButtonState.Pressed)
                        dragging = hovering;
                    else if (mState.LeftButton != ButtonState.Pressed)
                        dragging = false;

                    if (dragging)
                    {
                        var mousePosScaled = (mState.Position.ToVector2() / ZoomLevel).ToPoint();
                        var mousePosOldScaled = (mState_old.Position.ToVector2() / ZoomLevel).ToPoint();

                        Vector2 distMoved = new Vector2(mousePosScaled.X - mousePosOldScaled.X, mousePosScaled.Y - mousePosOldScaled.Y);

                        if (distMoved != Vector2.Zero)
                        {
                            EditSprite.Offset += distMoved;
                            OnSpriteMoved(new EventArgs());
                        }
                    }
                }
                else
                {
                    if (hovering)
                        Cursor = System.Windows.Forms.Cursors.Default;
                    hovering = false;
                    dragging = false;
                }
            }
            mState_old = mState;
        }

        protected virtual void OnSpriteMoved(EventArgs e)
        {
            onSpriteMoved?.Invoke(this, e);
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
            Matrix scaleMatrix = Matrix.CreateScale(ZoomLevel);
            Matrix translationMatrix = Matrix.CreateTranslation(new Vector3(centerPoint, 0));

            Editor.graphics.Clear(Color.DimGray);

            Editor.spriteBatch.Begin(transformMatrix:translationMatrix);
            DrawGrid();
            Editor.spriteBatch.End();

            if (ZoomLevel >= 1)
                Editor.spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: scaleMatrix * translationMatrix);
            else
                Editor.spriteBatch.Begin(transformMatrix: scaleMatrix);
            PreviewSprite?.Draw(Editor.spriteBatch, SpriteSheet, Vector2.Zero, Color.White);
            Editor.spriteBatch.End();
        }

        private void DrawGrid()
        {
            int horizontalIterations = (int)(Editor.graphics.PresentationParameters.BackBufferHeight / GridSpacing / 2);
            int verticalIterations = (int)(Editor.graphics.PresentationParameters.BackBufferWidth / GridSpacing / 2);

            int offset = GridSpacing * (int)ZoomLevel;
            Color currentDrawColor = new Color(115, 113, 110);

            for (int index = 0; index <= horizontalIterations || index <= verticalIterations; index++)
            {
                DrawHorizontalGridLine(offset, currentDrawColor);
                DrawHorizontalGridLine(-offset, currentDrawColor);
                DrawVerticalGridLine(offset, currentDrawColor);
                DrawVerticalGridLine(-offset, currentDrawColor);
                offset += GridSpacing * (int)ZoomLevel;
            }

            currentDrawColor = new Color(155, 145, 130);

            offset = 0;

            for (int index = 0; index <= horizontalIterations || index <= verticalIterations; index += 2)
            {
                DrawHorizontalGridLine(offset, currentDrawColor);
                DrawHorizontalGridLine(-offset, currentDrawColor);
                DrawVerticalGridLine(offset, currentDrawColor);
                DrawVerticalGridLine(-offset, currentDrawColor);
                offset += GridSpacing * (int)ZoomLevel * 2;
            }

            currentDrawColor = new Color(204, 204, 204);
            DrawHorizontalGridLine(0, currentDrawColor);
            DrawVerticalGridLine(0, currentDrawColor);
        }

        private void DrawHorizontalGridLine(int y, Color color)
        {
            Editor.spriteBatch.Draw(gridLine, new Rectangle(0 - (int)centerPoint.X, y, Editor.graphics.PresentationParameters.BackBufferWidth, 1), color);
        }
        private void DrawVerticalGridLine(int x, Color color)
        {
            Editor.spriteBatch.Draw(gridLine, new Rectangle(x, 0 - (int)centerPoint.Y, 1, Editor.graphics.PresentationParameters.BackBufferHeight), color);
        }
    }
}
