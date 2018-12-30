using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using QURO;

namespace AnimationEditor.Modifications
{
    public static class ModHelper
    {
        public static void DoModificationWithSelectionTracking(IModification mod, ComboBox animBox, ListBox frameBox, ListBox frameSpriteBox)
        {
            mod.SetPreChangeSelection(new SelectionState(animBox, frameBox, frameSpriteBox));
            mod.Do();
            mod.SetPostChangeSelection(new SelectionState (animBox, frameBox, frameSpriteBox));
            Console.WriteLine("Perform: " + mod);
        }

        public static void UndoAndRestoreSelection(IModification mod, ComboBox animBox, ListBox frameBox, ListBox frameSpriteBox)
        {
            mod.Undo();
            RestoreSelection(mod.GetPreChangeSelection(), animBox, frameBox, frameSpriteBox);
            Console.WriteLine("Undo: " + mod);
        }

        public static void RedoAndRestoreSelection(IModification mod, ComboBox animBox, ListBox frameBox, ListBox frameSpriteBox)
        {
            mod.Do();
            RestoreSelection(mod.GetPostChangeSelection(), animBox, frameBox, frameSpriteBox);
            Console.WriteLine("Redo: " + mod);
        }

        public static void RestoreSelection(SelectionState selection, ComboBox animBox, ListBox frameBox, ListBox frameSpriteBox)
        {
            animBox.SelectedIndex = selection.SelectedAnimation;

            frameBox.SelectedIndices.Clear();
            foreach(int index in selection.SelectedFrames)
            {
                frameBox.SelectedIndices.Add(index);
            }

            frameSpriteBox.SelectedIndices.Clear();
            foreach(int index in selection.SelectedFrameSprites)
            {
                frameSpriteBox.SelectedIndices.Add(index);
            }
        }

        public static void SetSingleSelection(ListBox lb, int index)
        {
            lb.SelectedIndices.Clear();
            lb.SelectedIndex = index;
        }
    }
}
