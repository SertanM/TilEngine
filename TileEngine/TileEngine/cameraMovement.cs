using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileEngine
{
    internal class cameraMovement : Tilengine
    {
        public cameraMovement() : base(new Vector(800, 500), "Camera Movement Test", Color.Black) { }
        
        public List<Shape> shapes = new List<Shape>();
        public Shape player;

        public override void Load()
        {
            shapes.Add(new Shape(new Vector(10, 10), new Vector(10, 10), Color.White));
            shapes.Add(new Shape(new Vector(-100, 40), new Vector(100, 100), Color.Yellow));
            shapes.Add(player = new Shape(new Vector(400, 200), new Vector(50, 50), Color.Red));
        }
        public override void Update()
        {
            if (keyW)
            {
                foreach (Shape s in shapes) {
                    s.position.y += 1;
                }
                player.position.y -= 1;
            }
            else if (keyS)
            {
                foreach (Shape s in shapes)
                {
                    s.position.y -= 1;
                }
                player.position.y += 1;
            }
            else if(keyA)
            {
                foreach (Shape s in shapes)
                {
                    s.position.x += 1;
                }
                player.position.x -= 1;
            }
            else if (keyD)
            {
                foreach(Shape s in shapes)
                {
                    s.position.x -= 1;
                }
                player.position.x += 1;
            }
        }
    }
}
