using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
                CurrentFrameIndex = 0;
            }
        }
        public int CurrentFrameIndex { get; set; }
        public Rectangle CurrentFrame => CurrentAnimation.Frames[CurrentFrameIndex];

        private float timer;

        public AnimatedSprite() { }

        public AnimatedSprite(Texture2D spriteSheet, Animation startingAnimation)
        {
            SpriteSheet = spriteSheet;
            CurrentAnimation = startingAnimation;
            timer = CurrentAnimation.Delay;
        }

        public void Reset()
        {
            CurrentFrameIndex = 0;
            timer = CurrentAnimation.Delay;
        }

        public void Update(GameTime gameTime)
        {
            if (!CurrentAnimation.IsStillImage)
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
                    }
                    timer = CurrentAnimation.Delay;
                }
                else
                {
                    timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color tint)
        {
            spriteBatch.Draw(SpriteSheet, position, CurrentFrame, tint);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 spriteOffset, Color tint)
        {
            Rectangle sourceRect = CurrentFrame;
            sourceRect.Offset(spriteOffset);

            spriteBatch.Draw(SpriteSheet, position, sourceRect, tint);
        }
    }
}
