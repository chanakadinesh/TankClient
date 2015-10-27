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
            char type = s[0];
            if (type == (char)'S' || type == (char)'S')
            {
                try
                {
                    gd.myPlayerNumber = (int)Char.GetNumericValue(s[3]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Paser : "+e.Message);
                }
                gd.Connected = true;
            }
            
        }        
    }
}
