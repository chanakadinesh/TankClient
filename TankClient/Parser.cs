using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient
{
    class Parser
    {
        public string get_playground() {
            string s="";
            for(int j=0;j<10;j++){
                for (int i = 0; i < 10; i++) {
                    s +="N ";
                }
                s += "\r\n";
            }
                return s;
        }
    }
}
