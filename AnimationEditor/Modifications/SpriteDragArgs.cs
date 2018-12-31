using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimationEditor.Modifications
{
    class SpriteDragArgs : EventArgs
    {
        public Vector2 DragDistance { get; private set; }

        public SpriteDragArgs(Vector2 drag)
        {
            DragDistance = drag;
        }
    }
}
