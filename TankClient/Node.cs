using System;
using System.Collections ;
namespace sAstar
{
	
	public class Node:IComparable 
	{

		public int totalCost
		{
			get 
			{
				return g+h;
			}
			set
			{
				totalCost = value;
			}
		}
		public int g;
		public int h;


		
		public int x;
		public int y;

		
		private Node _goalNode;
		public Node parentNode;
		private int gCost;


		public Node(Node parentNode, Node goalNode, int gCost,int x, int y)
		{
			
			this.parentNode = parentNode;
			this._goalNode = goalNode;
			this.gCost = gCost;
			this.x=x;
			this.y=y;
			InitNode();
		}
	
		private void InitNode()
		{
			this.g = (parentNode!=null)? this.parentNode.g + gCost:gCost;
			this.h = (_goalNode!=null)? (int) Euclidean_H():0;
		}

		private double Euclidean_H()
		{
			double xd = this.x - this._goalNode .x ;
			double yd = this.y - this._goalNode .y ;
			return Math.Sqrt((xd*xd) + (yd*yd));
		}
		
		public int CompareTo(object obj)
		{
			
			Node n = (Node) obj;
			int cFactor = this.totalCost - n.totalCost ;
			return cFactor;
		}

		public bool isMatch(Node n)
		{
			if (n!=null)
				return (x==n.x && y==n.y);
			else
				return false;
		}

		public ArrayList GetSuccessors()
		{
			ArrayList successors = new ArrayList ();

			for (int xd=-1;xd<=1;xd++)
			{
				for (int yd=-1;yd<=1;yd++)
				{
                    if (Math.Abs(xd) + Math.Abs(yd) == 2) continue;

					else if (Map.getMap (x+xd,y+yd) !=-1)
					{
						Node n = new Node (this,this._goalNode ,Map.getMap (x+xd,y+yd) ,x+xd,y+yd);
						if (!n.isMatch (this.parentNode) && !n.isMatch (this))
                            successors.Add (n);

					}
				}
			}
			return successors;
		}
	}
}
