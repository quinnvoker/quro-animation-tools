using Microsoft.Xna.Framework;

namespace QURO.AnimationLibrary
{
    public class Frame
    {
        public Rectangle SourceRect { get; set; }
        public float Delay { get; set; }

        public Frame() { }

        public Frame(Rectangle sourceRectangle, float delay)
        {
            SourceRect = sourceRectangle;
            Delay = delay;
        }
    }
}
