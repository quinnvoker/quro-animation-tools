using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QURO;
using System.ComponentModel;

namespace SpriteMapEditor.SpriteMapModifications
{
    class MoveSpriteListEntry : ISpriteMapModification
    {
        private readonly BindingList<SpriteMapRegion> allSprites;

        private readonly int selectedIndex;
        private readonly int dir;

        public MoveSpriteListEntry(BindingList<SpriteMapRegion> spriteList, int selection, int direction)
        {
            allSprites = spriteList;
            selectedIndex = selection;
            dir = Math.Sign(direction);
        }

        public void Do()
        {
            var movingSprite = allSprites[selectedIndex];
            allSprites.RemoveAt(selectedIndex);
            allSprites.Insert(selectedIndex + dir, movingSprite);
        }

        public void Undo()
        {
            var movingSprite = allSprites[selectedIndex + dir];
            allSprites.RemoveAt(selectedIndex + dir);
            allSprites.Insert(selectedIndex, movingSprite);
        }
    }
}
