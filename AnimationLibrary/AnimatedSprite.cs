using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.TextureAtlases;

namespace QURO.AnimationLibrary
{
    public class AnimatedSprite
    {
        public TextureAtlas CurrentTextureAtlas { get; set; }
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
        public TextureRegion2D CurrentFrame => CurrentAnimation.Frames[CurrentFrameIndex];

        private float timer;

        public AnimatedSprite() { }

        public AnimatedSprite(TextureAtlas textureAtlas, Animation startingAnimation)
        {
            CurrentTextureAtlas = textureAtlas;
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
            spriteBatch.Draw(CurrentTextureAtlas.Texture, position, CurrentFrame.Bounds, tint);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 spriteOffset, Color tint)
        {
            Rectangle sourceRect = CurrentFrame.Bounds;
            sourceRect.Offset(spriteOffset);

            spriteBatch.Draw(CurrentTextureAtlas.Texture, position, sourceRect, tint);
        }
    }
}
