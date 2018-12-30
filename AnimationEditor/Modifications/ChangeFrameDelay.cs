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
    class ChangeFrameDelay : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Frame> frames;
        private ListBox listBox;
        private List<int> indices;
        private Dictionary<int, float> originalDelays;
        private float newDelay;

        public ChangeFrameDelay(BindingList<Frame> frameList, ListBox frameListBox, float delay)
        {
            frames = frameList;
            listBox = frameListBox;
            indices = new List<int>();
            originalDelays = new Dictionary<int, float>();
            foreach (int i in frameListBox.SelectedIndices)
            {
                indices.Add(i);
                originalDelays.Add(i, frames[i].Delay);
            }
            newDelay = delay;
        }

        public void Do()
        {
            foreach (int index in indices)
            {
                frames[index].Delay = newDelay;
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
                frames[index].Delay = originalDelays[index];
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
                return "Change Frame Delay";
            else
                return "Change Frame Delays";
        }
    }
}

