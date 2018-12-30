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
    class RenameAnimation : IModification
    {
        private SelectionState preChangeSelection;
        private SelectionState postChangeSelection;

        private BindingList<Animation> anims;
        private int index;
        private string originalName;
        private string newName;

        public RenameAnimation(BindingList<Animation> animList, int index, string name)
        {
            anims = animList;
            this.index = index;
            originalName = anims[index].Name;
            newName = name;
        }

        public void Do()
        {
            anims[index].Name = newName;
            anims.ResetBindings();
        }

        public void Undo()
        {
            anims[index].Name = originalName;
            anims.ResetBindings();
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
            return "Rename Animation";
        }
    }
}

