using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteMapEditor.SpriteMapModifications
{
    public interface ISpriteMapModification
    {
        void Do();
        void Undo();
        List<int> GetPreChangeSelection();
        void SetPreChangeSelection(List<int> currentSelection);
        List<int> GetPostChangeSelection();
        void SetPostChangeSelection(List<int> currentSelection);
    }
}
