using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient
{
    class GameDetails
    {
        private int myId;
        private String[,] playerData; //Name,Score,Coins,Health
        private int[,] playerLocations; //x,y,direct
        private int[,] bricks; //x,y,damageLevel
        private int[] count; //number of bricks,water,stone
        private bool gameStarted;
        private bool gameConnected;
        Parser paser;
        public GameDetails()
        {
            paser = new Parser(this);
            gameConnected = false;
            gameStarted = false;
            myId = 3;
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

        public int myPlayerNumber
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
