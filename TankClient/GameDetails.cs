using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient
{
    class GameDetails
    {
        private String myId;
        private String[,] playerData; //Name,Score,Coins,Health
        private int[,] playerLocations; //x,y,direct
        private int[,] bricks; //x,y,damageLevel
        private int[] count; //number of bricks,water,stone
        private int[,] water;
        private int[,] stone;
        private bool gameStarted;
        private bool gameConnected;
        Parser paser;
        public GameDetails()
        {
            paser = new Parser(this);
            gameConnected = false;
            gameStarted = false;
            myId = "P#";
            playerData = new String[5, 4];
            playerLocations = new int[5, 3];

            count = new int[3];
        }
        public bool isGameStarted
        {
            get
            {
                return gameStarted;
            }
            set
            {
                gameStarted = value;
            }
        }

        public string myPlayerNumber
        {
            get
            {
                return myId;
            }
            set
            {
                myId = value;
            }
        }
        public int[,] Bricks
        {
            get
            {
                return bricks;
            }
            set
            {
                bricks = value;
            }
        }
        public int[,] Water
        {
            get
            {
                return water;
            }
            set
            {
                water = value;
            }
        }

        public int[,] Stone
        {
            get
            {
                return stone;
            }
            set
            {
                stone = value;
            }
        }
        public bool Connected {
            get
            {
                return gameConnected;
            }
            set {
                this.gameConnected=value;
            }
        }
        public void update(String s) {
            paser.ParseMessage(s);
        }
    }
}
