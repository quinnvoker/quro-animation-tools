using System.Collections.Generic;

namespace QURO.AnimationLibrary
{
    public class AnimationSet
    {
        public Dictionary<string, Animation> Anims;

        public AnimationSet()
        {
            Anims = new Dictionary<string, Animation>();
        }

        public void Add(Animation anim)
        {
            Anims.Add(anim.Name, anim);
        }

        public void Remove(Animation anim)
        {
            Anims.Remove(anim.Name);
        }

        public void Remove(string animName)
        {
            Anims.Remove(animName);
        }
    }
}
