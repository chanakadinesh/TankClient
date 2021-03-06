﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TankClient

{
    class GameDetails
    {
        private String myId;
        private String[,] playerData; //Name,Health,Coins,Score
        private int[,] playerLocations; //x,y,direct
        private int p_count;  //number of players;
        private int[,] bricks; //x,y,damageLevel
        private int[] count; //number of bricks,water,stone
        private int[,] water;
        private int[,] stone;
        private bool gameStarted;
        private bool gameConnected;
        private bool hasplayerDetails;

        private List<coin> coinList;
        private List<lifepack> lifepackList;

        Parser paser;
        public GameDetails()
        {
            paser = new Parser(this);
            gameConnected = false;
            gameStarted = false;
            hasplayerDetails = false;
            myId = "P#";
            playerData = new String[5, 4];
            playerLocations = new int[5, 3];
            p_count = 0;
            count = new int[3];
            coinList =new List<coin>{};
            lifepackList = new List<lifepack> { };

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
        public List<coin> Coins
        {
            get
            {
                return coinList;
            }
            set
            {
                coinList = value;
            }
        }
        public List<lifepack> LifePacks
        {
            get
            {
                return lifepackList;
            }
            set
            {
                lifepackList = value;
            }
        }
        public bool hasPlayerDetails
        {
            get
            {
                return hasplayerDetails;
            }
            set
            {
                hasplayerDetails = value;
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
            
            //coin update
            List<coin> temp = coinList;
            for (int i = 0; i < coinList.Count; i++) {
                //Console.WriteLine("Dead \t" + coinList[i].DeadTime +"\t"+ coinList[i].X + coinList[i].Y);
                //Console.WriteLine("watch"+Parser.watch.ElapsedMilliseconds);

                if (coinList[i].DeadTime < Parser.watch.ElapsedMilliseconds)
                {
                    //Console.WriteLine("removed \n");
                    temp.Remove(temp[i]);
                }
            }
            coinList = temp;

            //life pack update
            List<lifepack> temp2 = lifepackList;
            for (int i = 0; i < lifepackList.Count; i++)
            {
                if (lifepackList[i].DeadTime < Parser.watch.ElapsedMilliseconds)
                {
                    temp2.Remove(temp2[i]);
                    Console.WriteLine("removed \n");
                }
            }
            lifepackList = temp2;

        }
        
        public int[,] playerLoc{
            get { return playerLocations; }
            set { playerLocations = value; }
        }
        public string[,] playerDetail
        {
            get { return playerData; }
            set { playerData = value; }
        }
        public int playerCount
        {
            get { return p_count; }
            set { p_count = value; }
        }
    }

    class coin
    {
        private int x, y, l, v;
        private float deadTime;
        public coin(int x, int y, int l, int v,Stopwatch watch)
        {
            this.x = x;
            this.y = y;
            this.l = l;
            this.v = v;
            deadTime = watch.ElapsedMilliseconds + (float)l;
        }
        public float DeadTime{
            get { return deadTime; }
        } 
        public int X{
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int L
        {
            get { return l; }
            set { l = value; }
        }
        public int V
        {
            get { return v; }
            set { v = value; }
        }
    }

    class lifepack
    {
        private int x,y,l;
        private float deadTime;
        public lifepack(int x, int y, int l, Stopwatch watch)
        {
            this.x=x;
            this.y=y;
            this.l=l;
            deadTime = watch.ElapsedMilliseconds + (float)l;
        }
        public int X{
            get { return x; }
            set { x = value; }
        }
        public float DeadTime
        {
            get { return deadTime; }
        } 
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int L
        {
            get { return l; }
            set { l = value; }
        }

    }
}
