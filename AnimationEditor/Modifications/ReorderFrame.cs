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
    class ReorderFrame : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Frame> frames;
        private ListBox listBox;
        private int index;
        private int dir;

        public ReorderFrame(BindingList<Frame> frameList, ListBox frameListBox, int direction)
        {
            frames = frameList;
            listBox = frameListBox;
            index = frameListBox.SelectedIndex;
            dir = Math.Sign(direction);
        }

        public void Do()
        {
            var movingFrame = frames[index];
            frames[index] = frames[index + dir];
            frames[index + dir] = movingFrame;
            ModHelper.SetSingleSelection(listBox, index + dir);
        }

        public void Undo()
        {
            var movingFrame = frames[index + dir];
            frames[index + dir] = frames[index];
            frames[index] = movingFrame;
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
            return "Move Frame";
        }
    }
}
