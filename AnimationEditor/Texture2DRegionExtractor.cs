using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AnimationEditor
{
    static class Texture2DRegionExtractor
    {
        public static Texture2D GetTexture2DFromRegion(Texture2D source, GraphicsDevice graphics, Rectangle region)
        {
            var outputTex = new Texture2D(graphics, region.Width, region.Height);
            int pixelCount = region.Width * region.Height;
            Color[] pixelData = new Color[pixelCount];
            source.GetData(0, region, pixelData, 0, pixelCount);
            outputTex.SetData(pixelData);
            return outputTex;
        }
    }
}
