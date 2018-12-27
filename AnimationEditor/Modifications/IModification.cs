using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationEditor.Modifications
{
    public interface IModification
    {
        void Do();
        void Undo();
        SelectionState GetPreChangeSelection();
        void SetPreChangeSelection(SelectionState currentSelection);
        SelectionState GetPostChangeSelection();
        void SetPostChangeSelection(SelectionState currentSelection);
    }
}
