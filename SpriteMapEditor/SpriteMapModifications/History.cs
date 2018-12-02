using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteMapEditor.SpriteMapModifications
{
    class History
    {
        private List<ISpriteMapModification> changes;
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
            changes = new List<ISpriteMapModification>();
        }

        public void Add(ISpriteMapModification change)
        {
            if (position < changes.Count - 1)
            {
                changes.RemoveRange(position + 1, changes.Count - 1 - position);
            }
            changes.Add(change);
            position = changes.Count - 1;
            //Console.WriteLine("Available Undo Steps: " + changes.Count + "; Current Undo Position: " + position);
        }

        public void Undo()
        {
            if (CanUndo)
            { 
                changes[position].Undo();
                position--;
            }
        }

        public void Undo(ListBox listBox)
        {
            if (CanUndo)
            {
                ModHelper.UndoAndRestoreSelection(changes[position], listBox);
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

        public void Redo(ListBox listBox)
        {
            if (CanRedo)
            {
                ModHelper.RedoAndRestoreSelection(changes[position + 1], listBox);
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
