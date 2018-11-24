using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using QURO;

namespace QURO.AnimationLibrary
{
    public class AnimatedSprite
    {
        public Texture2D SpriteSheet { get; set; }
        private Animation currentAnimation;
        public Animation CurrentAnimation
        {
            get { return currentAnimation; }
            set
            {
                currentAnimation = value;
                finishedPlaying = false;
                CurrentFrameIndex = 0;
                timer = CurrentFrame.Delay;
            }
        }
        public int CurrentFrameIndex { get; set; }
        public Frame CurrentFrame => CurrentAnimation.Frames[CurrentFrameIndex];

        private float timer;
        private bool finishedPlaying;

        public AnimatedSprite() { }

        public AnimatedSprite(Texture2D spriteSheet, Animation startingAnimation)
        {
            SpriteSheet = spriteSheet;
            CurrentAnimation = startingAnimation;
            timer = CurrentFrame.Delay;
            finishedPlaying = false;
        }

        public void Reset()
        {
            CurrentFrameIndex = 0;
            finishedPlaying = false;
            timer = CurrentFrame.Delay;
        }

        public void Update(GameTime gameTime)
        {
            if (!CurrentAnimation.IsStillImage && !finishedPlaying)
            {
                if (timer <= 0)
                {
                    if (CurrentFrameIndex < CurrentAnimation.Frames.Length - 1)
                    {
                        CurrentFrameIndex++;
                    }
                    else
                    {
                        if (CurrentAnimation.IsLooping)
                        {
                            CurrentFrameIndex = 0;
                        }
                        else
                        {
                            finishedPlaying = true;
                        }
                    }
                    timer = CurrentFrame.Delay;
                }
                else
                {
                    timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color tint)
        {
            spriteBatch.Draw(SpriteSheet, position, CurrentFrame.Bounds, tint);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 spriteOffset, Color tint)
        {
            Rectangle sourceRect = CurrentFrame.Bounds;
            sourceRect.Offset(spriteOffset);

            spriteBatch.Draw(SpriteSheet, position, sourceRect, tint);
        }
    }
}
