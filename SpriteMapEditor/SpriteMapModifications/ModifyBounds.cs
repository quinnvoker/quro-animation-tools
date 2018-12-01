using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QURO;
using Microsoft.Xna.Framework;

namespace SpriteMapEditor.SpriteMapModifications
{
    class ModifyBounds : ISpriteMapModification
    {
        private readonly List<SpriteMapRegion> sprites;

        private readonly int newXPosition;
        private readonly int newYPosition;
        private readonly int newWidth;
        private readonly int newHeight;

        private readonly List<Rectangle> oldBounds;

        public ModifyBounds(List<SpriteMapRegion> spritesToModify, int x = -1, int y = -1, int width = -1, int height = -1)
        {
            sprites = spritesToModify;
            newXPosition = x;
            newYPosition = y;
            newWidth = width;
            newHeight = height;

            oldBounds = new List<Rectangle>();

            for(int index = 0; index < sprites.Count; index++)
            {
                oldBounds.Add(sprites[index].Bounds);
            }
        }

        public void Do()
        {
            for (int index = 0; index < sprites.Count; index++)
            {
                Rectangle newBounds = sprites[index].Bounds;

                if (newXPosition > -1)
                    newBounds.X = newXPosition;
                if (newYPosition > -1)
                    newBounds.Y = newYPosition;
                if (newWidth > -1)
                    newBounds.Width = newWidth;
                if (newHeight > -1)
                    newBounds.Height = newHeight;

                sprites[index].Bounds = newBounds;
            }
        }

        public void Undo()
        {
            for (int index = 0; index < sprites.Count; index++)
            {
                sprites[index].Bounds = oldBounds[index];
            }
        }
    }
}
