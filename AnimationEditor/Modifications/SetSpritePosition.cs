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
    class SetSpritePosition : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Sprite> sprites;
        private ListBox listBox;
        private int index;
        private Vector2 originalPosition;
        private Vector2 newPosition;

        public SetSpritePosition(BindingList<Sprite> spriteList, ListBox spriteListBox, Vector2 newPos)
        {
            sprites = spriteList;
            listBox = spriteListBox;
            index = spriteListBox.SelectedIndex;
            originalPosition = sprites[index].Offset;
            newPosition = newPos;
        }

        public void Do()
        {
            sprites[index].Offset = newPosition;
        }

        public void Undo()
        {
            sprites[index].Offset = originalPosition;
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
            return "Set Sprite Position";
        }
    }
}

