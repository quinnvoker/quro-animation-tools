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
            spriteBatch.Draw(SpriteSheet, position - CurrentFrame.Origin, CurrentFrame.Bounds, tint);
            if (CurrentFrame.SubSprites != null)
                DrawSubSprites(spriteBatch, position, tint);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Vector2 spriteMapOffset, Color tint, bool offsetSubSprites = false)
        {
            Rectangle sourceRect = CurrentFrame.Bounds;
            sourceRect.Offset(spriteMapOffset);

            spriteBatch.Draw(SpriteSheet, position, sourceRect, tint);
            if (CurrentFrame.SubSprites != null)
                DrawSubSprites(spriteBatch, position, tint, offsetSubSprites? (Vector2?)spriteMapOffset : null);
        }

        public void DrawSubSprites(SpriteBatch spriteBatch, Vector2 position, Color tint, Vector2? spriteMapOffset = null)
        {
            if (CurrentFrame.SubSprites.Count != CurrentFrame.SubSpritePositions.Count)
            {
                System.Console.WriteLine("SubSpriteCount and SubSpritePositionCount are not equal! Skipping subsprites...");
                return;
            }
            for (int index = 0; index < CurrentFrame.SubSprites.Count; index++)
            {
                var subSprite = CurrentFrame.SubSprites[index];

                Rectangle sourceRect = subSprite.Bounds;

                if (spriteMapOffset != null)
                    sourceRect.Offset((Vector2)spriteMapOffset);

                spriteBatch.Draw(SpriteSheet, position - subSprite.Origin + CurrentFrame.SubSpritePositions[index], sourceRect, tint);
            }
        }
    }
}
