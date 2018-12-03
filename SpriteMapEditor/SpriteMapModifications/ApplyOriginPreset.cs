using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QURO;
using Microsoft.Xna.Framework;

namespace SpriteMapEditor.SpriteMapModifications
{
    class ApplyOriginPreset : ISpriteMapModification
    {
        private readonly List<SpriteMapRegion> sprites;

        private readonly OriginPreset preset;

        private readonly List<Vector2> oldOrigins;

        private List<int> preChangeSelection;
        private List<int> postChangeSelection;

        public ApplyOriginPreset(List<SpriteMapRegion> spritesToEditOrigin, OriginPreset presetToApply)
        {
            sprites = spritesToEditOrigin.ToList();
            preset = presetToApply;

            oldOrigins = new List<Vector2>();
            for (int index = 0; index < sprites.Count; index++)
            {
                oldOrigins.Add(sprites[index].Origin);
            }
        }

        public void Do()
        {
            foreach(SpriteMapRegion sprite in sprites)
            {
                Vector2 newOrigin = sprite.Origin;

                switch (preset)
                {
                    case OriginPreset.TopLeft:
                        newOrigin = Vector2.Zero;
                        break;
                    case OriginPreset.Top:
                        newOrigin = new Vector2(sprite.Bounds.Width / 2, 0);
                        break;
                    case OriginPreset.TopRight:
                        newOrigin = new Vector2(sprite.Bounds.Width, 0);
                        break;
                    case OriginPreset.Left:
                        newOrigin = new Vector2(0, sprite.Bounds.Height / 2);
                        break;
                    case OriginPreset.Center:
                        newOrigin = new Vector2(sprite.Bounds.Width / 2, sprite.Bounds.Height / 2);
                        break;
                    case OriginPreset.Right:
                        newOrigin = new Vector2(sprite.Bounds.Width, sprite.Bounds.Height / 2);
                        break;
                    case OriginPreset.BottomLeft:
                        newOrigin = new Vector2(0, sprite.Bounds.Height);
                        break;
                    case OriginPreset.Bottom:
                        newOrigin = new Vector2(sprite.Bounds.Width / 2, sprite.Bounds.Height);
                        break;
                    case OriginPreset.BottomRight:
                        newOrigin = new Vector2(sprite.Bounds.Width, sprite.Bounds.Height);
                        break;
                    default:
                        break;
                }

                sprite.Origin = newOrigin;
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
            return "Set Origin to " + preset;
        }
    }
}
