using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileEngine
{
    internal class FlappyBirdGame : Tilengine
    {
        public FlappyBirdGame() : base(new Vector(800, 500), "FlappyBird"){}
        
        Shape player;
        Shape pipe0;
        Shape pipe1;
        Shape zone;
        int randomNum = 350; //0 to 350
        Random rnd = new Random();
        public override void Load()
        {
            player = new Shape(new Vector(70, 200), new Vector(50,50), Color.Yellow, "player");
            zone = new Shape(new Vector(-70, 0), new Vector(20, 10000), Color.Blue, "zone");
            createPipe();
        }

        public override void Update()
        {
            pipe0.position.x -= 2;
            pipe1.position.x -= 2;
            if(keyW) player.position.y -= 1;
            if(keyS) player.position.y += 1;
            if(player.isCollided(player, "Pipe")) Environment.Exit(0);
            if (pipe0.isCollided(pipe0, "zone")) createPipe();
        }

        private void createPipe()
        {
            randomNum = rnd.Next(350);
            pipe0 = new Shape(new Vector(900, 0), new Vector(50, randomNum), Color.Green, "Pipe");
            pipe1 = new Shape(new Vector(900, randomNum + 150), new Vector(50, 1000), Color.Green, "Pipe");
        }
    }
}
