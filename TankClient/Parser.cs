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
                  //  gd.myPlayerNumber = s.Substring(2, 2);
                    parseStart(s);  
                    gd.isGameStarted = true;
                    break;
                case "I:":
                    parseInit(s);
                    gd.Connected = true;
                    break;
                case "G:":
                    parseGround(s);
                    gd.hasPlayerDetails = true;
                    break;
                case "L:":
                    parseLifepacks(s);
                    break;
                case "C:":
                    parseCoins(s);
                    break;
                default:
                    break;
            }
        }

        private void parseStart(string s)
        {
            s = s.Substring(0, s.Length - 2);
            string[] parts = s.Split(':');
            gd.playerCount = parts.Length - 1;
            int[,] loc = new int[parts.Length - 1, 3];
           // string[,] p_data = new string[parts.Length - 1, 4];
            for (int i = 1; i < parts.Length; i++)
            {
                string y = parts[i];
                string []y1 = y.Split(';');
                string[] y2 = y1[1].Split(',');
                loc[i - 1, 0] = Convert.ToInt32(y2[0]);
                loc[i - 1, 1] = Convert.ToInt32(y2[1]);
                loc[i - 1, 2] = Convert.ToInt32(y1[2]);

            }
            gd.playerLoc = loc;
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
                bricksLoc[count, 2] = 0;
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

        private void parseGround(String s) {
            s = s.Substring(0, s.Length - 2);
            string[] parts = s.Split(':');
            string[,] p_data = gd.playerDetail;
            int[,] loc = gd.playerLoc;
            int[,] brick = gd.Bricks;
            foreach (string y in parts)
            {
                if (y == "G") { }
                else if (y[0] == 'P')
                {

                    int p_id = (int)Char.GetNumericValue(y[1]);
                    string [] y1=y.Split(';');
                    p_data[p_id, 0] = y1[0];
                    string[] y2 = y1[1].Split(',');
                    loc[p_id, 0] = Convert.ToInt32(y2[0]);
                    loc[p_id, 1] = Convert.ToInt32(y2[1]);
                    loc[p_id, 2] = Convert.ToInt32(y1[2]);
                    p_data[p_id, 1] = y1[4];
                    p_data[p_id, 2] = y1[5];
                    p_data[p_id, 3] = y1[6];
                }
                else {
                    string[] y1 = y.Split(';');
                    for(int i=0;i<y1.Length;i++){
                        string[] y2 = y1[i].Split(',');
                        brick[i, 0] = Convert.ToInt32(y2[0]);
                        brick[i, 1] = Convert.ToInt32(y2[1]);
                        brick[i, 2] = Convert.ToInt32(y2[2]);
                    }
                    
                }
            }
            gd.playerDetail = p_data;
            gd.playerLoc = loc;
            gd.Bricks = brick;
        }

        private void parseCoins(String s) {
            s = s.Substring(0, s.Length - 2);
            string[] parts = s.Split(':');
            List<coin> co = gd.Coins;
            string[] y = parts[1].Split(',');
            int lx = Convert.ToInt32(y[0]);
            int ly = Convert.ToInt32(y[1]);
            int lt = Convert.ToInt32(parts[2]);
            int lv = Convert.ToInt32(parts[3]);
            co.Add(new coin(lx, ly, lt, lv));
            gd.Coins = co;
        }
        private void parseLifepacks(string s) {
            s = s.Substring(0, s.Length - 2);
            string[] parts = s.Split(':');
            List<lifepack> lp = gd.LifePacks;
            string[] y = parts[1].Split(',');
            int lx = Convert.ToInt32(y[0]);
            int ly = Convert.ToInt32(y[1]);
            int lt = Convert.ToInt32(parts[2]);
            //int lv = Convert.ToInt32(parts[3]);
            lp.Add(new lifepack(lx, ly, lt));
            gd.LifePacks = lp;
        }
    }
}
