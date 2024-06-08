using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileEngine
{
    public class Vector
    {
        public double x { get; set; }
        public double y { get; set; }

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        
        public static Vector GetMiddleLocation(Vector position, Vector scale)
        {
            return new Vector((int)position.x + (int)scale.x / 2, (int)position.y + (int)scale.y / 2);
        }

        public Vector GetDirection(Vector to, Vector from)
        {
            return new Vector(to.x - from.x, to.y - from.y);
        }
        public static double GetDistance(Vector point1, Vector point2)
        {
            if(point1!= null && point2 != null)
            {
                double x = Math.Abs(point1.x - point2.x);
                double y = Math.Abs(point1.y - point2.y);
                return Math.Sqrt((x*x) + (y * y));
            }
            return 0;
        }
        public static Shape GetClosestShape(Vector position, string tag, Shape expection) 
        {
            List<Shape> shapes = Tilengine.GetShapesWithTag(tag);
            if (shapes.Count == 0) return null;
            Shape currentclosestshape = shapes[0];
            foreach(Shape s in shapes)
            {
                if (s != expection)
                {
                    if(GetDistance(s.position, position) < GetDistance(currentclosestshape.position, position)){
                        currentclosestshape = s;
                    }
                }
            }
            return currentclosestshape;
        }
    }
}
