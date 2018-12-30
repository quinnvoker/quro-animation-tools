using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QURO;
using QURO.Animation;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace AnimationEditor.Modifications
{
    class ReplaceSprite : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Sprite> sprites;
        private int index;
        private Sprite original;
        private Sprite replacement;

        public ReplaceSprite(BindingList<Sprite> spriteList, int origIndex, Sprite newSprite)
        {
            sprites = spriteList;
            index = origIndex;
            original = sprites[index].Clone();
            replacement = newSprite;
        }

        public void Do()
        {
            sprites[index].Name = replacement.Name;
            sprites[index].Bounds = replacement.Bounds;
            sprites[index].Origin = replacement.Origin;
        }

        public void Undo()
        {
            sprites[index].Name = original.Name;
            sprites[index].Bounds = original.Bounds;
            sprites[index].Origin = original.Origin;
        }

        public SelectionState GetPreChangeSelection()
        {
            return preChangeSelection;
        }
        public void SetPreChangeSelection(SelectionState currentSelection)
        {
            preChangeSelection = currentSelection;
        }
        public SelectionState GetPostChangeSelection()
        {
            return postChangeSelection;
        }
        public void SetPostChangeSelection(SelectionState currentSelection)
        {
            postChangeSelection = currentSelection;
        }


        public override string ToString()
        {
            return "Replace Sprite";
        }
    }
}
