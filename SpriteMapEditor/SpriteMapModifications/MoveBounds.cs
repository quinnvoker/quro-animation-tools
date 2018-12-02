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

        private List<int> preChangeSelection;
        private List<int> postChangeSelection;

        public MoveBounds(List<SpriteMapRegion> spritesToMove, int xDifference, int yDifference)
        {
            sprites = spritesToMove.ToList();
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

        public List<int> GetPreChangeSelection()
        {
            return preChangeSelection;
        }
        public void SetPreChangeSelection(List<int> currentSelection)
        {
            preChangeSelection = currentSelection;
        }
        public List<int> GetPostChangeSelection()
        {
            return postChangeSelection;
        }
        public void SetPostChangeSelection(List<int> currentSelection)
        {
            postChangeSelection = currentSelection;
        }

        public override string ToString()
        {
            return "Move Sprite Bounds";
        }
    }
}
