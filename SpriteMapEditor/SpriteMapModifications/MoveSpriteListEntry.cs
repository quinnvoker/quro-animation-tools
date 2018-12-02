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

        private List<int> preChangeSelection;
        private List<int> postChangeSelection;

        public MoveSpriteListEntry(BindingList<SpriteMapRegion> spriteList, int selection, int direction)
        {
            allSprites = spriteList;
            selectedIndex = selection;
            dir = Math.Sign(direction);
        }

        public void Do()
        {
            var movingSprite = allSprites[selectedIndex];
            allSprites[selectedIndex] = allSprites[selectedIndex + dir];
            allSprites[selectedIndex + dir] = movingSprite;
        }

        public void Undo()
        {
            var movingSprite = allSprites[selectedIndex + dir];
            allSprites[selectedIndex + dir] = allSprites[selectedIndex];
            allSprites[selectedIndex] = movingSprite;
        }

        public List<int> GetPreChangeSelection()
        {
            return preChangeSelection;
        }
        public void SetPreChangeSelection(List<int> currentSelection)
        {
            preChangeSelection = currentSelection;
        }
        public List<int> GetPostChangeSelection()
        {
            return postChangeSelection;
        }
        public void SetPostChangeSelection(List<int> currentSelection)
        {
            postChangeSelection = currentSelection;
        }

        public override string ToString()
        {
            return "Move Sprite List Entry";
        }
    }
}
