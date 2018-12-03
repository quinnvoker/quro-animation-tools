using System.Collections.Generic;
using System.Drawing;
using QURO;

namespace SpriteMapEditor
{
    public class SpriteMapProject
    {
        public Image SpriteSheet { get; set; }
        public List<SpriteMapRegion> SpriteMap { get; set; }

        public SpriteMapProject()
        {
        }
    }
}
