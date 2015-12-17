using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient
{
    class AI
    {
        private int size = 10;
        private static int[,] stufArray;

        public void findShortestPath(GameDetails gd,String end) {
            stufArray = new int[size, size];

            if(end=="L"){
                for (int i = 0; i < gd.LifePacks.Count; i++)
                    stufArray[gd.LifePacks[i].X, gd.LifePacks[i].Y] = 1000;
            }
            if (end == "C")
            {
                for (int i = 0; i < gd.Coins.Count; i++)
                    stufArray[gd.Coins[i].X, gd.Coins[i].Y] = 1000;
            }

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    stufArray[i, j] = 0;

            //block stone cels marked by 200
            for (int i = 0; i < gd.Stone.Length; i++)
            {
                int x = gd.Stone[i, 0];
                int y = gd.Stone[i, 1];
                stufArray[x, y] = 200;
            }

            //block brick cels marked by 300
            for (int i = 0; i < gd.Bricks.Length; i++)
            {
                int x = gd.Bricks[i, 0];
                int y = gd.Bricks[i, 1];
                stufArray[x, y] = 200;
            }

            //block water cels marked by 400
            for (int i = 0; i < gd.Water.Length; i++)
            {
                int x = gd.Water[i, 0];
                int y = gd.Water[i, 1];
                stufArray[x, y] = 400;
            }

            //block player location cels marked by 500
            for (int i = 0; i < gd.playerCount; i++)
            {
                int x = gd.playerLoc[i,0];
                int y = gd.playerLoc[i, 1];
                stufArray[x, y] = 500;
            }

            //set my player clocation

            try
            {
                int myNo = Int32.Parse(gd.myPlayerNumber.Substring(1));
                int myx = gd.playerLoc[myNo,0];
                int myy = gd.playerLoc[myNo, 1];
                stufArray[myx, myy] = 900;
                recortionFun(myx, myy);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void recortionFun(int i,int j) {
          
                if(stufArray[i,j]==1000 || i==0){return;}
                if (i != 0)
                    if (stufArray[i - 1, j] == 0)
                    {
                        stufArray[i - 1, j] = stufArray[i, j] + 1;
                        recortionFun(i - 1, j);
                    }

                if (stufArray[i, j] == 1000 || i == 9) { return; }
                if (i != 9)
                    if (stufArray[i + 1, j] == 0)
                    {
                        stufArray[i + 1, j] = stufArray[i, j] + 1;
                        recortionFun(i+1,j);
                    }

                if (stufArray[i, j] == 1000 || j == 0) { return; }
                if (j != 0)
                    if (stufArray[i, j-1] == 0)
                    {
                        stufArray[i, j-1] = stufArray[i, j] + 1;
                        recortionFun(i , j-1);
                    }

                if (stufArray[i, j] == 1000 || j == 9) { return; }
                if (j != 9)
                    if (stufArray[i , j+1] == 0)
                    {
                        stufArray[i, j+1] = stufArray[i, j] + 1;
                        recortionFun(i , j+1);
                    }
            }
    }
}
