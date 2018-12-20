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
        private bool hovering;
        private bool dragging;
        private MouseState mState;
        private MouseState mState_old;

        private Vector2 centerPoint
        {
            get { return  new Vector2((Editor.graphics.PresentationParameters.BackBufferWidth / 2) / ZoomLevel, (Editor.graphics.PresentationParameters.BackBufferHeight / 2) / ZoomLevel); }
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
                Rectangle spriteRect = new Rectangle((int)(centerPoint.X * ZoomLevel), (int)(centerPoint.Y * ZoomLevel), (int)(EditSprite.Bounds.Width * ZoomLevel), (int)(EditSprite.Bounds.Height * ZoomLevel));
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

            Editor.graphics.Clear(Color.DimGray);

            if (ZoomLevel >= 1)
                Editor.spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: scaleMatrix);
            else
                Editor.spriteBatch.Begin(transformMatrix: scaleMatrix);
            PreviewSprite?.Draw(Editor.spriteBatch, SpriteSheet, centerPoint, Color.White);
            Editor.spriteBatch.End();
        }
    }
}
