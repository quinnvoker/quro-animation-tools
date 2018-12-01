using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QURO;

namespace SpriteMapEditor.SpriteMapModifications
{
    class MoveBounds : ISpriteMapModification
    {
        private readonly List<SpriteMapRegion> sprites;

        private readonly int xDiff;
        private readonly int yDiff;

        public MoveBounds(List<SpriteMapRegion> spritesToMove, int xDifference, int yDifference)
        {
            sprites = spritesToMove;
            xDiff = xDifference;
            yDiff = yDifference;
        }

        public void Do()
        {
            foreach (SpriteMapRegion sprite in sprites)
            {
                var newBounds = sprite.Bounds;
                newBounds.X += xDiff;
                newBounds.Y += yDiff;
                sprite.Bounds = newBounds;
            }
        }
        public void Undo()
        {
            foreach (SpriteMapRegion sprite in sprites)
            {
                var newBounds = sprite.Bounds;
                newBounds.X -= xDiff;
                newBounds.Y -= yDiff;
                sprite.Bounds = newBounds;
            }
        }
    }
}
