﻿using System;
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
    class RemoveFrame : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Frame> frames;
        private ListBox frameListBox;
        private int removeIndex;

        private Frame removedFrame; 

        public RemoveFrame(BindingList<Frame> frameList, ListBox frameBox, int index)
        {
            frames = frameList;
            frameListBox = frameBox;
            removeIndex = index;
        }

        public void Do()
        {
            removedFrame = frames[removeIndex];

            if(frames.Count == 1)
            {
                frames.Clear();
                frames.Add(new Frame());
            }
            else
                frames.RemoveAt(removeIndex);

            if (frames.Count > -1 && frameListBox.SelectedIndex > frames.Count - 1)
            {
                ModHelper.SetSingleSelection(frameListBox, frames.Count - 1);
            }
        }

        public void Undo()
        {
            if(removedFrame != null)
            {
                if (frames.Count == 1 && removeIndex == 0 && (frames[0].Sprites == null || frames[0].Sprites[0].Bounds == Rectangle.Empty))
                {
                    frames.Clear();
                    frames.Add(removedFrame);
                }
                else
                    frames.Insert(removeIndex, removedFrame);
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
            return "Remove Sprite";
        }
    }
}
