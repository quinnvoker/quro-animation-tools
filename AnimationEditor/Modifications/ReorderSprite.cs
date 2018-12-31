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
    class ReorderSprite : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Sprite> sprites;
        private ListBox listBox;
        private int index;
        private int dir;

        public ReorderSprite(BindingList<Sprite> spriteList, ListBox spriteListBox, int direction)
        {
            sprites = spriteList;
            listBox = spriteListBox;
            index = spriteListBox.SelectedIndex;
            dir = Math.Sign(direction);
        }

        public void Do()
        {
            var movingFrame = sprites[index];
            sprites[index] = sprites[index + dir];
            sprites[index + dir] = movingFrame;
            ModHelper.SetSingleSelection(listBox, index + dir);
        }

        public void Undo()
        {
            var movingFrame = sprites[index + dir];
            sprites[index + dir] = sprites[index];
            sprites[index] = movingFrame;
            ModHelper.SetSingleSelection(listBox, index);
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
            return "Reorder Sprite";
        }
    }
}
