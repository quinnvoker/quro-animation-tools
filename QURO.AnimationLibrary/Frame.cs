using QURO;
using Microsoft.Xna.Framework;

namespace QURO.AnimationLibrary
{
    public class Frame
    {
        public SpriteMapRegion Sprite { get; set; }
        public float Delay { get; set; }

        public string Name { get { return Sprite.Name; } }
        public Rectangle Bounds { get { return Sprite.Bounds; } }
        public Vector2 Origin { get { return Sprite.Origin; } }

        public Frame() : this(new SpriteMapRegion(), 0)
        {
        }

        public Frame(SpriteMapRegion sprite, float delay)
        {
            Sprite = sprite;
            Delay = delay;
        }
    }
}
