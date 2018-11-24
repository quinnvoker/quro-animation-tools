using QURO;
using Microsoft.Xna.Framework;

namespace QURO.AnimationLibrary
{
    public class Frame : SpriteMapRegion
    {
        public float Delay { get; set; }

        public Frame()
        {
            Name = "unnamed";
            Bounds = new Rectangle(0, 0, 8, 8);
            Origin = Vector2.Zero;
            Delay = 0;
        }

        public Frame(SpriteMapRegion sprite, float delay)
        {
            Name = sprite.Name;
            Bounds = sprite.Bounds;
            Origin = sprite.Origin;
            Delay = delay;
        }

        public Frame(string name, Rectangle bounds, float delay, Vector2 origin)
        {
            Name = name;
            Bounds = bounds;
            Origin = origin;
            Delay = delay;
        }

        public Frame(Rectangle bounds, float delay, Vector2 origin)
        {
            Name = "unnamed";
            Bounds = bounds;
            Origin = origin;
            Delay = delay;
        }

        public Frame(Rectangle bounds, float delay)
        {
            Name = "unnamed";
            Bounds = bounds;
            Origin = Vector2.Zero;
            Delay = delay;
        }
    }
}
