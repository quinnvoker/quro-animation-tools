using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using QURO.Animation;

namespace AnimationEditor
{
    class AnimationPreview : UpdateWindow
    {
        public AnimatedSprite PreviewSprite { get; set; }
        public float ZoomLevel { get; set; }

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
            PreviewSprite?.Draw(Editor.spriteBatch, new Vector2((Editor.graphics.PresentationParameters.BackBufferWidth / 2) / ZoomLevel, (Editor.graphics.PresentationParameters.BackBufferHeight / 2) / ZoomLevel), Color.White);
            Editor.spriteBatch.End();
        }
    }
}
