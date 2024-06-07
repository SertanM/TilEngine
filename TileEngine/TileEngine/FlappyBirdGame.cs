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
        public FlappyBirdGame() : base(new Vector(800, 500), "FlappyBird", Color.Black){}
        
        Shape player;
        Shape pipe0;
        Shape pipe1;
        Shape coin;
        int score = 0;
        int pipeSpeed = 5;
        int randomNum = 350; //0 to 350
        Random rnd = new Random();
        public override void Load()
        {
            player = new Shape(new Vector(70, 200), new Vector(50,50), Color.Yellow, "player");
            new Shape(new Vector(-70, 0), new Vector(20, 10000), Color.Blue, "zone");
            new Shape(new Vector(70,-1), new Vector(1,1), Color.Blue, "Pipe");
            new Shape(new Vector(70, 500), new Vector(1, 1), Color.Blue, "Pipe");
            createPipe();
        }

        public override void Update()
        {
            pipe0.position.x -= pipeSpeed;
            pipe1.position.x -= pipeSpeed;
            coin.position.x -= pipeSpeed;
            if(keyW) player.position.y -= 2;
            if(keyS) player.position.y += 2;
            if(player.isCollided(player, "Pipe")) Environment.Exit(0);
            if (player.isCollided(player, "Coin"))
            {
                score++;
                coin.activeSelf = false;
                Console.WriteLine(score);
            }
            if (pipe0.isCollided(pipe0, "zone")) createPipe();
        }

        private void createPipe()
        {
            randomNum = rnd.Next(350);
            if (score != 0 && score % 10 == 0) pipeSpeed++;
            pipe0 = new Shape(new Vector(900, 0), new Vector(50, randomNum), Color.Green, "Pipe");
            pipe1 = new Shape(new Vector(900, randomNum + 150), new Vector(50, 1000), Color.Green, "Pipe");
            coin = new Shape(new Vector(912, randomNum + 62.5), new Vector(25, 25), Color.Bisque, "Coin", true);
        }
    }
}
