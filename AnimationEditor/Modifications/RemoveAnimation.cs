using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using QURO;
using QURO.Animation;
using System.Windows.Forms;

namespace AnimationEditor.Modifications
{
    class RemoveAnimation : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Animation> animations;
        private ComboBox animationBox;
        private int removeIndex;

        private Animation removedAnim; 

        public RemoveAnimation(BindingList<Animation> anims, ComboBox animBox, int index)
        {
            animations = anims;
            animationBox = animBox;
            removeIndex = index;
        }

        public void Do()
        {
            if (removeIndex > -1 && removeIndex < animations.Count)
            {
                removedAnim = animations[removeIndex];
                if (animations.Count == 1)
                {
                    animations[removeIndex] = new Animation();
                }
                else
                {
                    animations.RemoveAt(removeIndex);
                    if (animationBox.SelectedIndex > animations.Count - 1)
                    {
                        animationBox.SelectedIndex--;
                    }
                }
            }
        }

        public void Undo()
        {
            if(removedAnim != null)
            {
                if (animations.Count == 1 && removeIndex == 0 && animations[0].Frames.Length == 1 && animations[0].Frames[0].Sprites[0].Bounds == Rectangle.Empty)
                {
                    animations[0] = removedAnim;
                }
                else
                    animations.Insert(removeIndex, removedAnim);
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
            return "Remove Animation";
        }
    }
}
