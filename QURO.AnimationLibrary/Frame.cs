using QURO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace QURO.AnimationLibrary
{
    public class Frame
    {
        public SpriteMapRegion Sprite { get; set; }
        public List<SpriteMapRegion> SubSprites { get; set; }
        public List<Vector2> SubSpritePositions { get; set; }

        public float Delay { get; set; }

        public string Name { get { return Sprite.Name; } }
        public Rectangle Bounds { get { return Sprite.Bounds; } }
        public Vector2 Origin { get { return Sprite.Origin; } }


        public Frame() : this(new SpriteMapRegion(), 0, null, null)
        {
        }

        public Frame(SpriteMapRegion sprite, float delay) : this(sprite, delay, null, null)
        {
        }

        public Frame(SpriteMapRegion sprite, float delay, List<SpriteMapRegion> subSprites, List<Vector2> subSpritePositons)
        {
            Sprite = sprite;
            Delay = delay;
            SubSprites = subSprites;
            SubSpritePositions = subSpritePositons;
        }
    }
}
