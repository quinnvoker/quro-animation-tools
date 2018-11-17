using MonoGame.Extended.TextureAtlases;

namespace QURO.AnimationLibrary
{
    public class Animation
    {
        public string Name { get; set; }
        public bool IsLooping { get; set; }
        public float Delay { get; set; }

        public TextureRegion2D[] Frames { get; set; }

        public bool IsStillImage => Frames.Length <= 1;

        public Animation() { }

        public Animation(string name, TextureAtlas textureAtlas, string[] frameNames, float delaySetting = 0.2f, bool willLoop = false)
        {
            Name = name;

            Frames = new TextureRegion2D[frameNames.Length];

            for (int index = 0; index < frameNames.Length; index++)
            {
                Frames[index] = textureAtlas.GetRegion(frameNames[index]);
            }
            IsLooping = willLoop;
            Delay = delaySetting;
        }
    }
}
