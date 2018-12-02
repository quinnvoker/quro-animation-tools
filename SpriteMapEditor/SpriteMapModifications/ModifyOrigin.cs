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

        private List<int> preChangeSelection;
        private List<int> postChangeSelection;

        public ModifyOrigin(List<SpriteMapRegion> spritesToEditOrigin,  int x = -1, int y = -1)
        {
            sprites = spritesToEditOrigin.ToList();
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
            return "Modify Sprite Origin";
        }
    }
}
