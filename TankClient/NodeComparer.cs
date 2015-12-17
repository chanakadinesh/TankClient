using System;
using System.Collections ;
namespace sAstar
{
	
	public class NodeComparer:IComparer
	{
		public NodeComparer()
		{
			
		}
	
		public int Compare(object x, object y)
		{
			return ((Node)x).totalCost -  ((Node) y).totalCost ;
		}
	}
}
