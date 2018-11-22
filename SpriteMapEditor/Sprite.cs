using System.Drawing;

namespace SpriteMapEditor
{
    public class Sprite
    {
        public string Name { get; set; }
        public Rectangle Bounds { get; set; }

        public Sprite()
        {
            Name = "unnamed";
            Bounds = new Rectangle(1, 1, 8, 8);
        }

        public Sprite(string name, Rectangle bounds)
        {
            Name = name;
            Bounds = bounds;
        }
    }
}
