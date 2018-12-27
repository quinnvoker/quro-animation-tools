using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationEditor.Modifications
{
    public class SelectionState
    {
        public int SelectedAnimation { get; set; }
        public List<int> SelectedFrames { get; set; }
        public List<int> SelectedFrameSprites { get; set; }

        public SelectionState(ComboBox animationComboBox, ListBox frameListBox, ListBox frameSpriteListBox)
        {
            SelectedAnimation = animationComboBox.SelectedIndex;
            SelectedFrames = frameListBox.SelectedIndices.Cast<int>().ToList();
            SelectedFrameSprites = frameSpriteListBox.SelectedIndices.Cast<int>().ToList();
        }
    }
}
