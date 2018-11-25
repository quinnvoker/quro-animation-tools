using Microsoft.Xna.Framework;

namespace QURO.AnimationLibrary
{
    public class Animation
    {
        public string Name { get; set; }
        public bool IsLooping { get; set; }

        public Frame[] Frames { get; set; }

        public bool IsStillImage => Frames.Length <= 1;

        public Animation()
        {
            Name = "unnamed";
            Frames = new Frame[] { new Frame() };
            IsLooping = false;
        }

        public Animation(string name, Frame[] frames, bool loop)
        {
            Name = name;
            Frames = frames;
            IsLooping = loop;
        }

        public Animation(string name, Rectangle[] sourceRects, float delay, bool loop)
        {
            Name = name;

            Frames = new Frame[sourceRects.Length];
            for(int index = 0; index < sourceRects.Length; index++)
            {
                Frames[index] = new Frame(sourceRects[index], delay);
            }

            IsLooping = loop;
        }
    }
}
