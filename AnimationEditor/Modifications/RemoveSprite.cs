using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QURO;
using QURO.Animation;
using System.Windows.Forms;

namespace AnimationEditor.Modifications
{
    class RemoveSprite : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Sprite> sprites;
        private ListBox spriteListBox;
        private int removeIndex;

        private Sprite removedSprite; 

        public RemoveSprite(BindingList<Sprite> spriteList, ListBox spriteBox, int index)
        {
            sprites = spriteList;
            spriteListBox = spriteBox;
            removeIndex = index;
        }

        public void Do()
        {
            if(removeIndex > -1 && removeIndex < sprites.Count)
            {
                removedSprite = sprites[removeIndex];

                if(sprites.Count == 1)
                {
                    sprites.Clear();
                }
                else
                    sprites.RemoveAt(removeIndex);

                if (sprites.Count > -1 && spriteListBox.SelectedIndex > sprites.Count - 1)
                {
                    ModHelper.SetSingleSelection(spriteListBox, sprites.Count - 1);
                }
            }
        }

        public void Undo()
        {
            if(removedSprite != null)
            {
                sprites.Insert(removeIndex, removedSprite);
            }
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
            return "Remove Frame";
        }
    }
}
