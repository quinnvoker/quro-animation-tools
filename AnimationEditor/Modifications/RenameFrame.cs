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
    class RenameFrame : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Frame> frames;
        private ListBox listBox;
        private List<int> indices;
        private Dictionary<int, string> originalNames;
        private string newName;

        public RenameFrame(BindingList<Frame> frameList, ListBox frameListBox, string name)
        {
            frames = frameList;
            listBox = frameListBox;
            indices = new List<int>();
            originalNames = new Dictionary<int, string>();
            foreach(int i in frameListBox.SelectedIndices)
            {
                indices.Add(i);
                originalNames.Add(i, frames[i].Name);
            }
            newName = name;
        }

        public void Do()
        {
            foreach (int index in indices)
            {
                frames[index].Name = newName;
            }
            frames.ResetBindings();
            listBox.SelectedIndices.Clear();
            foreach (int index in indices)
            {
                listBox.SelectedIndices.Add(index);
            }
        }

        public void Undo()
        {
            foreach (int index in indices)
            {
                frames[index].Name = originalNames[index];
            }
            frames.ResetBindings();
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
                return "Rename Frame";
            else
                return "Rename Frames";
        }
    }
}

