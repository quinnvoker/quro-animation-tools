using Microsoft.Xna.Framework;

namespace QURO.AnimationLibrary
{
    public class Animation
    {
        public string Name { get; set; }
        public bool IsLooping { get; set; }

        public Frame[] Frames { get; set; }

        public bool IsStillImage => Frames.Length <= 1;

        public Animation() : this("unnamed", new Frame[] { new Frame() }, false)
        {
        }

        public Animation(string name, Frame[] frames, bool loop)
        {
            Name = name;
            Frames = frames;
            IsLooping = loop;
        }
    }
}
