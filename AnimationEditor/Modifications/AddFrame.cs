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
    class AddFrame : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Frame> frames;
        private ListBox frameListBox;
        private Frame frameToAdd; 

        public AddFrame(BindingList<Frame> frameList, ListBox frameBox, Frame frame = null)
        {
            frames = frameList;
            frameListBox = frameBox;
            if (frame != null)
                frameToAdd = frame;
            else frameToAdd = new Frame();
        }

        public void Do()
        {
            int newSelectedIndex;

            //if only frame in animation is uninitiated and input is not empty, clear the list
            if (frameToAdd.Name != "empty" &&
                frames.Count == 1 &&
                frames[0].Sprites.Count == 1 &&
                frames[0].Sprites[0].Name == "empty")
            {
                frames.Clear();
            }

            if (frameListBox.SelectedItem == null || frameListBox.SelectedIndex == frames.Count - 1)
            {
                frames.Add(frameToAdd);
                newSelectedIndex = frames.Count - 1;
            }
            else
            {
                frames.Insert(frameListBox.SelectedIndex + 1, frameToAdd);
                newSelectedIndex = frameListBox.SelectedIndex + 1;
            }
            ModHelper.SetSingleSelection(frameListBox, newSelectedIndex);
        }

        public void Undo()
        {
            if(frames.Count < 2)
            {
                frames.Clear();
                frames.Add(new Frame());
            }
            else if(postChangeSelection!= null)
            {
                int addedFrameIndex = postChangeSelection.SelectedFrames[0];
                frames.RemoveAt(addedFrameIndex);
                if(addedFrameIndex > 0)
                {
                    ModHelper.SetSingleSelection(frameListBox, addedFrameIndex - 1);
                }
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
            return "Add Frame";
        }
    }
}
