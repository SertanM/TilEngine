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
        public bool activeSelf = true;

        public void SetActive(bool activeSelf)
        {
            this.activeSelf = activeSelf;
        }

        public Shape(Vector position, Vector scale, Color color, string tag = "default", bool activeSelf=true)
        {
            this.position = position;
            this.scale = scale;
            this.color = color;
            this.tag = tag;
            this.activeSelf = activeSelf;
            Tilengine.RegisterShape(this);
        }

        public bool isCollided(Shape shape, string tag)
        {
            List<Shape> p = Tilengine.GetShapesWithTag(tag);
            foreach (Shape s in p)
            {
                if (s.activeSelf)
                {
                    if (s.position.y + s.scale.y > shape.position.y && shape.position.y + shape.scale.y > s.position.y
                    && s.position.x + s.scale.x > shape.position.x && shape.position.x + shape.scale.x > s.position.x)
                    {
                        return true;
                    }
                }
                    
            }
            return false;
        }
    }
}
