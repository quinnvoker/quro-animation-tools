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
    class AddAnimation : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Animation> animations;
        private ComboBox animationBox;
        private Animation animationToAdd; 

        public AddAnimation(BindingList<Animation> animList, ComboBox animBox, Animation anim = null)
        {
            animations = animList;
            animationBox = animBox;
            if (anim != null)
                animationToAdd = anim;
            else animationToAdd = new Animation();
        }

        public void Do()
        {
            animations.Add(animationToAdd);
            animationBox.SelectedIndex = animations.Count - 1;
        }

        public void Undo()
        {
            animations.RemoveAt(animations.Count - 1);
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
            return "Add Animation";
        }
    }
}
