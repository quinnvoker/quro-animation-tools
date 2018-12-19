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
        private readonly BindingList<Sprite> allSprites;

        private readonly int index;

        private readonly Sprite removedSprite;

        private List<int> preChangeSelection;
        private List<int> postChangeSelection;

        public RemoveSprite(BindingList<Sprite> spriteList, int indexToRemove)
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
            return "Remove Sprite";
        }
    }
}
