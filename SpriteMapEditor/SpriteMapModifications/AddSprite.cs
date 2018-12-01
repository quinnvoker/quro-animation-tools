using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QURO;

namespace SpriteMapEditor.SpriteMapModifications
{
    class AddSprite : ISpriteMapModification
    {
        private readonly BindingList<SpriteMapRegion> allSprites;

        private readonly SpriteMapRegion selectedSprite;

        public AddSprite(BindingList<SpriteMapRegion> spriteList, SpriteMapRegion selected = null)
        {
            allSprites = spriteList;
            selectedSprite = selected;
        }

        public void Do()
        {
            if (selectedSprite != null)
                allSprites.Add(new SpriteMapRegion(selectedSprite.Name, selectedSprite.Bounds, selectedSprite.Origin));
            else
                allSprites.Add(new SpriteMapRegion());
        }

        public void Undo()
        {
            allSprites.RemoveAt(allSprites.Count - 1);
        }
    }
}
