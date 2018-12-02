using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using QURO;

namespace SpriteMapEditor.SpriteMapModifications
{
    public static class ModHelper
    {
        public static void DoModificationWithSelectionTracking(SpriteMapModifications.ISpriteMapModification mod, ListBox listBox)
        {
            mod.SetPreChangeSelection(GetSelectionList(listBox));
            mod.Do();
            mod.SetPostChangeSelection(GetSelectionList(listBox));
        }

        public static void UndoAndRestoreSelection(SpriteMapModifications.ISpriteMapModification mod, ListBox listBox)
        {
            mod.Undo();
            SelectFromList(listBox, mod.GetPreChangeSelection());
        }

        public static void RedoAndRestoreSelection(SpriteMapModifications.ISpriteMapModification mod, ListBox listBox)
        {
            mod.Do();
            SelectFromList(listBox, mod.GetPostChangeSelection());
        }

        public static List<int> GetSelectionList(ListBox listBox)
        {
            List<int> result = new List<int>();
            foreach(int currentIndex in listBox.SelectedIndices)
            {
                result.Add(currentIndex);
            }
            return result;
        }

        public static void SelectFromList(ListBox listBox, List<int> newSelection)
        {
            listBox.SelectedIndices.Clear();
            var source = (BindingList<SpriteMapRegion>)listBox.DataSource;
            foreach (int currentIndex in newSelection)
            {
                if(currentIndex < source.Count)
                    listBox.SelectedIndex = currentIndex;
            }
        }
    }
}
