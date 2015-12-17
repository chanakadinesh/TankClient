using System;
using System.Collections ;
namespace sAstar
{
	
	public class Map
	{
        static int[,] Mapdata;
        static int size = 10;
        

		public Map(int[,] new_array)
		{
            Mapdata = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Mapdata[i, j] = new_array[i, j];   
                }
            }
		}

		public static int  getMap(int x,int y)
		{
			int yMax =Mapdata.GetUpperBound (0);
			int xMax =Mapdata.GetUpperBound (1);
			if (x<0 ||  x>xMax)
				return -1;
			else if (y<0 || y>yMax)
				return -1;
			else
				return Mapdata[y,x];
		}


		static public string[,] PrintSolution(ArrayList solutionPathList)
		{
			int yMax =Mapdata.GetUpperBound (0);
			int xMax =Mapdata.GetUpperBound (1);
            string[,] ans = new string[size, size];

			for(int j=0;j<=yMax;j++) 
			{
				for(int i=0;i<=xMax;i++) 
				{
					bool solutionNode = false;
					foreach(Node n in solutionPathList) 
					{
						Node tmp = new Node(null,null,0,i,j);
						
						if(n.isMatch (tmp))
						{
							solutionNode = true;
							break;
						}
					}
					if(solutionNode){
						Console.Write("o "); //solution path
                        ans[j,i]="o";
                    }
                    else if (Map.getMap(i, j) == -1)
                    {
                        Console.Write("# "); //wall
                        ans[j,i] = "#";
                    }
                    else
                    {
                        Console.Write(". "); //road
                        ans[j,i] = ".";
                    }
				}
				Console.WriteLine("");
			}
            return ans;
        }
	}
}
