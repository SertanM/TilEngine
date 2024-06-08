using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TileEngine
{
    public static class Tiles
    {
        public static List<string[,]> Rooms = new List<string[,]>();
        public static int CurrentRoom = 0;
        public static int tileSize = 50;

        public static void AddRoom(string[,] room)
        {
            Rooms.Add(room);
        }

        public static string[,] GetCurrentRoom()
        {
            return Rooms[CurrentRoom];
        } 
        public static List<Vector> GetTiles(string tileName)
        {
            List<Vector> v = new List<Vector>();
            for(int x = 0; x< GetCurrentRoom().GetLength(1); x++)
            {
                for(int y = 0; y< GetCurrentRoom().GetLength(0); y++)
                {
                    if (GetCurrentRoom()[y,x]== tileName)
                    {
                        v.Add(new Vector(x * tileSize,y * tileSize));
                    }
                }
            }
            return v;
        }
    }
}
