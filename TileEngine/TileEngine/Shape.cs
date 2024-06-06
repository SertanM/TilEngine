using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileEngine
{
    public class Shape
    {
        public Vector position {  get; set; }
        public Vector scale { get; set; }
        public Color color = Color.Black;
        public string tag;

        public Shape(Vector position, Vector scale, Color color, string tag = "default")
        {
            this.position = position;
            this.scale = scale;
            this.color = color;
            this.tag = tag;
            Tilengine.RegisterShape(this);
        }

        public bool isCollided(Shape shape, string tag)
        {
            List<Shape> p = Tilengine.GetShapesWithTag(tag);
            foreach (Shape s in p)
            {
                if (s.position.y + s.scale.y > shape.position.y && shape.position.y + shape.scale.y > s.position.y
                    && s.position.x + s.scale.x > shape.position.x && shape.position.x + shape.scale.x > s.position.x)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
