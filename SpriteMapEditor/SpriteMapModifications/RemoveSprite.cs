using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QURO;
using System.ComponentModel;

namespace SpriteMapEditor.SpriteMapModifications
{
    class RemoveSprite : ISpriteMapModification
    {
        private readonly BindingList<SpriteMapRegion> allSprites;

        private readonly int index;

        private readonly SpriteMapRegion removedSprite;

        public RemoveSprite(BindingList<SpriteMapRegion> spriteList, int indexToRemove)
        {
            allSprites = spriteList;
            index = indexToRemove;
            removedSprite = allSprites[index];
        }

        public void Do()
        {
            allSprites.RemoveAt(index);
        }

        public void Undo()
        {
            allSprites.Insert(index, removedSprite);
        }
    }
}
