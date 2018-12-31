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
    class MoveSprite : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Sprite> sprites;
        private ListBox listBox;
        private List<int> indices;
        private Vector2 dist;

        public MoveSprite(BindingList<Sprite> spriteList, ListBox spriteListBox, Vector2 distance)
        {
            sprites = spriteList;
            listBox = spriteListBox;
            indices = new List<int>();
            foreach(int index in spriteListBox.SelectedIndices)
            {
                indices.Add(index);
            }
            dist = distance;
        }

        public void Do()
        {
            foreach (int index in indices)
            {
                sprites[index].Offset += dist;
            }
        }

        public void Undo()
        {
            foreach (int index in indices)
            {
                sprites[index].Offset -= dist;
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
            if (indices.Count == 1)
                return "Move Sprite";
            else
                return "Move Sprites";
        }
    }
}

