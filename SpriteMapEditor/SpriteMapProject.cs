using System.Collections.Generic;
using System.Drawing;
using QURO;

namespace SpriteMapEditor
{
    public class SpriteMapProject
    {
        public string SpriteSheetFileLocation { get; set; }
        public List<SpriteMapRegion> SpriteMap { get; set; }

        public SpriteMapProject()
        {

        }

        public SpriteMapProject(string spriteSheetLocation, List<SpriteMapRegion> spriteMap)
        {
            SpriteSheetFileLocation = spriteSheetLocation;
            SpriteMap = spriteMap;
        }
    }
}
