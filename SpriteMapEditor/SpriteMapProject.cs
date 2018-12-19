using System.Collections.Generic;
using System.Drawing;
using QURO;

namespace SpriteMapEditor
{
    public class SpriteMapProject
    {
        public string SpriteSheetFileLocation { get; set; }
        public List<Sprite> SpriteMap { get; set; }

        public SpriteMapProject()
        {

        }

        public SpriteMapProject(string spriteSheetLocation, List<Sprite> spriteMap)
        {
            SpriteSheetFileLocation = spriteSheetLocation;
            SpriteMap = spriteMap;
        }
    }
}
