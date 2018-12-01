using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QURO;
using Microsoft.Xna.Framework;

namespace SpriteMapEditor.SpriteMapModifications
{
    class ModifyOrigin : ISpriteMapModification
    {
        private readonly List<SpriteMapRegion> sprites;

        private readonly int newOriginX;
        private readonly int newOriginY;

        private readonly List<Vector2> oldOrigins;

        public ModifyOrigin(List<SpriteMapRegion> spritesToEditOrigin, int x = -1, int y = -1)
        {
            sprites = spritesToEditOrigin;
            newOriginX = x;
            newOriginY = y;

            oldOrigins = new List<Vector2>();
            for(int index = 0; index < sprites.Count; index++)
            {
                oldOrigins.Add(sprites[index].Origin);
            }
        }

        public void Do()
        {
            for (int index = 0; index < sprites.Count; index++)
            {
                var newOrigin = sprites[index].Origin;

                if (newOriginX > -1)
                    newOrigin.X = newOriginX;
                if (newOriginY > -1)
                    newOrigin.Y = newOriginY;

                sprites[index].Origin = newOrigin;
            }
        }

        public void Undo()
        {
            for (int index = 0; index < sprites.Count; index++)
            {
                sprites[index].Origin = oldOrigins[index];
            }
        }
    }
}
