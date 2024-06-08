using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TileEngine
{
    internal class cameraMovement : Tilengine //It's only a test game.
    {
        public cameraMovement() : base(new Vector(800, 500), "Camera Movement Test", Color.White) { }
        
        public List<Shape> shapes = new List<Shape>();
        public Shape player;

        public override void Load()
        {
            string[,] map = new string[10,10] { 
                {"W", "W", "W", "W", "W", ".", ".", ".", ".", "W"},
                {"W", ".", ".", ".", "W", ".", ".", ".", ".", "W"},
                {"W", ".", "W", ".", "W", "W", "W", "W", ".", "W"},
                {"W", ".", "W", ".", ".", ".", ".", "W", ".", "W"},
                {"W", ".", "W", "W", ".", ".", ".", "W", ".", "."},
                {"W", ".", ".", "W", "W", "W", "W", "W", ".", "."},
                {"W", ".", ".", "W", ".", ".", ".", ".", ".", "W"},
                {"W", ".", "p", "W", "W", "W", ".", ".", ".", "W"},
                {"W", ".", ".", ".", ".", "W", ".", ".", ".", "W"},
                {"W", "W", "W", "W", "W", "W", ".", ".", "W", "W"}
            };
            Tiles.AddRoom(map);
            foreach(Vector i in Tiles.GetTiles("W"))
            {
                shapes.Add(new Shape(i, new Vector(50, 50), Color.Black, "wall"));
            }
            foreach(Vector i in Tiles.GetTiles("p"))
            {
                shapes.Add(player = new Shape(i, new Vector(25, 25), Color.Red, "player"));
            }

            
            if (player != null)
            {
                if (player.position.x != 388)
                {
                    foreach(Shape s in shapes)
                    {
                        if (s != player)
                        {
                            s.position.x -= player.position.x - 388;
                        }
                    }
                    player.position.x = 388;
                }
                if (player.position.y != 238)
                {
                    foreach(Shape s in shapes)
                    {
                        if(s!=player)
                        {
                            s.position.y -= player.position.y - 238;
                        }
                    }
                    player.position.y = 238;
                }
            }
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
            if (keyS)
            {
                foreach (Shape s in shapes)
                {
                    s.position.y -= 1;
                }
                player.position.y += 1;
            }
            if(keyA)
            {
                foreach (Shape s in shapes)
                {
                    s.position.x += 1;
                }
                player.position.x -= 1;
            }
            if (keyD)
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
