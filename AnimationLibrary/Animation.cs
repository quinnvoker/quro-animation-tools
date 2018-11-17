using Microsoft.Xna.Framework;

namespace QURO.AnimationLibrary
{
    public class Animation
    {
        public string Name { get; set; }
        public bool IsLooping { get; set; }
        public float Delay { get; set; }

        public Rectangle[] Frames { get; set; }

        public bool IsStillImage => Frames.Length <= 1;

        public Animation() { }
    }
}
