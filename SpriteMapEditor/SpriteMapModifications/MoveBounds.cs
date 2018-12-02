using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QURO;
using Microsoft.Xna.Framework;

namespace SpriteMapEditor.SpriteMapModifications
{
    class MoveBounds : ISpriteMapModification
    {
        private readonly List<SpriteMapRegion> sprites;

        private readonly int xDiff;
        private readonly int yDiff;
        private readonly List<Rectangle> oldBoundsList;

        private List<int> preChangeSelection;
        private List<int> postChangeSelection;

        public MoveBounds(List<SpriteMapRegion> spritesToMove, int xDifference, int yDifference, List<Rectangle> preDragBounds = null)
        {
            sprites = spritesToMove.ToList();
            xDiff = xDifference;
            yDiff = yDifference;
            oldBoundsList = preDragBounds.ToList();
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
            if (oldBoundsList != null)
            {
                for(int index = 0; index < sprites.Count; index++)
                {
                    sprites[index].Bounds = oldBoundsList[index];
                }
            }
            else
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
            return "Move Sprite Bounds: (" + xDiff + ", " + yDiff + "), New Position of "+ sprites[0].Name +": (" + (sprites[0].Bounds.X) + ", " + (sprites[0].Bounds.Y) + ")";
        }
    }
}
