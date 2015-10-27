using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient
{
    class Parser
    {
        private GameDetails gd;
        public Parser(GameDetails gd) {
            this.gd = gd;
        }
        public void ParseMessage(String s){
            String type = s.Substring(0,2);
            switch(type)
            {
                case "S:":
                    //.myPlayerNumber = (int)Char.GetNumericValue(s[3]);
                    gd.myPlayerNumber = s.Substring(2, 2);
                    gd.isGameStarted = true;
                    break;
                case "I:":
                    parseInit(s);
                    gd.Connected = true;
                    break;
                case "G:":
                    break;
                case "L:":
                    break;
                case "C:":
                    break;
                default:
                    break;
            }
        }
        private void parseInit(String s)
        {
            string[] parts = s.Split(':');
            gd.myPlayerNumber=parts[1];

            //Setting Bricks
            string[] bricks = parts[2].Split(';');
            int[,] bricksLoc = new int[bricks.Length, 3];
            int count=0;
            foreach( string loc in bricks){
                string [] locNum =loc.Split(',');
                bricksLoc[count,0] = Convert.ToInt32(locNum[0]);
                bricksLoc[count, 1] = Convert.ToInt32(locNum[1]);
                if (count % 4 == 0) { bricksLoc[count, 2] = 0; }
                else if (count % 4 == 1) { bricksLoc[count, 2] = 1; }
                else if (count % 4 == 2) { bricksLoc[count, 2] = 2; }
                else if (count % 4 == 3) { bricksLoc[count, 2] = 3; }
                else { }
                count++;
            }
            gd.Bricks = bricksLoc;

            //Setting Water;
           // Console.WriteLine(parts[4]);
            string[] water = parts[4].Split(';');
            int[,] waterLoc = new int[water.Length, 2];
            String final = water[water.Length - 1];
            final = final.Substring(0,3);
            water[water.Length - 1]=final;
            count = 0;
            foreach (string loc in water)
            {
                string[] locNum = loc.Split(',');
                waterLoc[count, 0] = Convert.ToInt32(locNum[0]);
                waterLoc[count, 1] = Convert.ToInt32(locNum[1]); 
                count++;
            }
            gd.Water = waterLoc;

            //Setting Stone
            string[] stone = parts[3].Split(';');
            int[,] stoneLoc = new int[stone.Length, 2];
            count = 0;
            foreach (string loc in stone)
            {
                string[] locNum = loc.Split(',');
                stoneLoc[count, 0] = Convert.ToInt32(locNum[0]);
                stoneLoc[count, 1] = Convert.ToInt32(locNum[1]);
                count++;
            }
            gd.Stone = stoneLoc;
        }
    }
}
