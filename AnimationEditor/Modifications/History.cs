using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimationEditor.Modifications
{
    class History
    {
        private List<IModification> changes;
        private int position;

        public bool CanUndo
        {
             get { return position >= 0 && changes.Count > 0; }
        }

        public bool CanRedo
        {
            get { return position < changes.Count - 1; }
        }

        public History()
        {
            changes = new List<IModification>();
        }

        public void Add(IModification change)
        {
            if (position < changes.Count - 1)
            {
                changes.RemoveRange(position + 1, changes.Count - 1 - position);
            }
            changes.Add(change);
            position = changes.Count - 1;
        }

        public void Undo()
        {
            if (CanUndo)
            { 
                changes[position].Undo();
                position--;
            }
        }

        public void Undo(ComboBox animBox, ListBox frameBox, ListBox spriteBox)
        {
            if (CanUndo)
            {
                Console.Write("Hist.Pos(" + position + "): ");
                ModHelper.UndoAndRestoreSelection(changes[position], animBox, frameBox, spriteBox);
                position--;
            }
        }

        public void Redo()
        {
            if (CanRedo)
            {
                changes[position + 1].Do();
                position++;
            }
        }

        public void Redo(ComboBox animBox, ListBox frameBox, ListBox spriteBox)
        {
            if (CanRedo)
            {
                Console.Write("Hist.Pos(" + position + "): ");
                ModHelper.RedoAndRestoreSelection(changes[position + 1], animBox, frameBox, spriteBox);
                position++;
            }
        }

        public string NextUndoString()
        {
            if (!CanUndo)
                return "Undo...";
            else
                return "Undo " + changes[position];
        }

        public string NextRedoString()
        {
            if (!CanRedo)
                return "Redo...";
            else
                return "Redo " + changes[position + 1];
        }
    }
}
