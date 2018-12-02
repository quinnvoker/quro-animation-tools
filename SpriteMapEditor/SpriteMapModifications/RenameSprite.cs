using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QURO;

namespace SpriteMapEditor.SpriteMapModifications
{
    class RenameSprite : ISpriteMapModification
    {
        private readonly SpriteMapRegion sprite;

        private readonly string newName;
        private readonly string oldName;

        private List<int> preChangeSelection;
        private List<int> postChangeSelection;

        public RenameSprite(SpriteMapRegion spriteToRename, string name)
        {
            sprite = spriteToRename;
            newName = name;
            oldName = sprite.Name;
        }

        public void Do()
        {
            sprite.Name = newName;
        }

        public void Undo()
        {
            sprite.Name = oldName;
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
            return "Rename Sprite";
        }
    }
}
