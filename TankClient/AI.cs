using System;
using System.Collections ;

namespace sAstar
{
	class AI
	{
        static int size = 10;
		[STAThread]
		static void Main(string[] args)
		{
            
            int[,] new_array={
			{ 1, 1, 0, 0, 0, 0, 0, 1, 0, 0},
			{ 0, 4, 1, 0, 0, 0, 0, 0, 0, 0},
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{ 1, 0, 0, 1, 0, 1, 0, 0, 0, 0},
			{ 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
			{ 0, 0, 1, 0, 1, 1, 1, 1, 0, 0},
			{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{ 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
		    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{ 3, 0, 0, 0, 0, 0, 0, 0, 0, 0}
		};

            int ex=8, ey=7;
            int sx = 1, sy = 3;


            Console.Write(AI_brain(new_array, 100, sx, sy));

            Console.ReadLine();


		}

        public static String AI_brain(int[,]new_array, int health, int sx, int sy) {
            String[] answer = { "#LEFT", "#RIGHT", "#UP", "#DOWN" };
            
            string[,] ans;

            ans = go_to_health_or_coin(new_array, health, sx, sy);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(ans[i, j]); //road
                }
                Console.Write("\n");
            }
            

                if (sx!=size -1 && ans[sy,sx+1] == "o")
                    return answer[1];
                else if (sx != 0 && ans[sy, sx - 1] == "o")
                    return answer[0];
                else if (sy != 0 && ans[sy-1, sx ] == "o")
                    return answer[2];
                else if (sy != size - 1 && ans[sy + 1, sx] == "o")
                    return answer[3];
                else 
                    return answer[0];

        }

        public static string[,] go_to_health_or_coin(int[,] map, int health, int sx, int sy)
        {
            if (health < 80)
                return find_shortest_object(map,0,sx,sy);
                //We have to find health;
            else
                return find_shortest_object(map, 1, sx, sy);
                //Health is not a problem, We want coins
        }

        public static string[,] find_shortest_object(int[,] map,int x,int sx,int sy) { 
            int y;
            int count=0;
            int min=1000;
            int min_index=0;
            string[,] ans;
            int[,] object_positions = new int[100,2];

            if (x == 0)
                y = 4;
            else
                y = 3;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (map[i, j] == y) {
                        count++;
                        object_positions[count-1,0]=i;
                        object_positions[count - 1, 1] = j;
                        map[i, j] = 1;
                        
                    }
                    // 0 means nothing
                    //3 coin
                    //4 life pack
                    
                    else if (map[i, j] == 0 || map[i, j] == 3 || map[i, j] == 4 )
                        map[i, j] = 1;
                    else
                        map[i, j] = -1;
                }
            }

            for (int i = 0; i < count; i++)
            {
                ans=find_shortest_path(map, sx, sy, object_positions[i,1], object_positions[i , 0]);
                if(length_count(ans)<min){
                    min = length_count(ans);
                    min_index = i; 
                }
            }

            ans = find_shortest_path(map, sx, sy, object_positions[min_index,1], object_positions[ min_index , 0]);
            return ans;
        }
        public static string[,] find_shortest_path(int[,] new_array,int sx,int sy,int ex,int ey){
            Map m = new Map(new_array);

            ArrayList SolutionPathList = new ArrayList();

            //Create a node containing the goal state node_goal
            Node node_goal = new Node(null, null, 1, ex, ey);

            //Create a node containing the start state node_start
            Node node_start = new Node(null, node_goal, 1, sx, sy);


            //Create OPEN and CLOSED list
            SortedCostNodeList OPEN = new SortedCostNodeList();
            SortedCostNodeList CLOSED = new SortedCostNodeList();


            //Put node_start on the OPEN list
            OPEN.push(node_start);

            //while the OPEN list is not empty
            while (OPEN.Count > 0)
            {
                //Get the node off the open list 
                //with the lowest f and call it node_current
                Node node_current = OPEN.pop();

                //if node_current is the same state as node_goal we have found the solution;
                //break from the while loop;
                if (node_current.isMatch(node_goal))
                {
                    node_goal.parentNode = node_current.parentNode;
                    break;
                }

                //Generate each state node_successor that can come after node_current
                ArrayList successors = node_current.GetSuccessors();

                //for each node_successor or node_current
                foreach (Node node_successor in successors)
                {
                    //Set the cost of node_successor to be the cost of node_current plus
                    //the cost to get to node_successor from node_current
                    //--> already set while we are getting successors

                    //find node_successor on the OPEN list
                    int oFound = OPEN.IndexOf(node_successor);

                    //if node_successor is on the OPEN list but the existing one is as good
                    //or better then discard this successor and continue
                    if (oFound > 0)
                    {
                        Node existing_node = OPEN.NodeAt(oFound);
                        if (existing_node.CompareTo(node_current) <= 0)
                            continue;
                    }


                    //find node_successor on the CLOSED list
                    int cFound = CLOSED.IndexOf(node_successor);

                    //if node_successor is on the CLOSED list but the existing one is as good
                    //or better then discard this successor and continue;
                    if (cFound > 0)
                    {
                        Node existing_node = CLOSED.NodeAt(cFound);
                        if (existing_node.CompareTo(node_current) <= 0)
                            continue;
                    }

                    //Remove occurences of node_successor from OPEN and CLOSED
                    if (oFound != -1)
                        OPEN.RemoveAt(oFound);
                    if (cFound != -1)
                        CLOSED.RemoveAt(cFound);

                    //Set the parent of node_successor to node_current;
                    //--> already set while we are getting successors

                    //Set h to be the estimated distance to node_goal (Using heuristic function)
                    //--> already set while we are getting successors

                    //Add node_successor to the OPEN list
                    OPEN.push(node_successor);

                }
                //Add node_current to the CLOSED list
                CLOSED.push(node_current);
            }


            //follow the parentNode from goal to start node
            //to find solution
            Node p = node_goal;
            while (p != null)
            {
                SolutionPathList.Insert(0, p);
                p = p.parentNode;
            }

            //display solution

            string[,] ans=Map.PrintSolution(SolutionPathList);

            return ans;
        }

        private static int length_count(string[,] ans) {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (ans[i, j] == "o")
                        count++;
                }
            }
            return count;
        }
    }
}
