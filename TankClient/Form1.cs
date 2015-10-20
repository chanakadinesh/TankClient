using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankClient
{

    public partial class Form1 : Form
    {
        Connection con;
        public Form1()
        {
            InitializeComponent();
        }

        public void WriteDisplay(String msg) {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(WriteDisplay), new object[] { msg });
                return;
            }
            display.Text = msg+"\r\n";
          //  serverDisplay.ScrollToCaret();
        }
        public void DisplayServerMessage(String msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(DisplayServerMessage), new object[] { msg });
                return;
            }
            serverDisplay.Text = msg + "\r\n";
            //  serverDisplay.ScrollToCaret();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            con = new Connection(this);
            con.startClient();
            this.send_btn.Enabled=true;
        }

        private void send_btn_Click(object sender, EventArgs e)
        {
              string msg = "";
                switch(comboBox1.SelectedIndex){
                    case 1:
                        msg = "UP#";
                        break;
                    case 2:
                        msg="DOWN#";
                        break;
                    case 3:
                        msg="LEFT#";
                        break;
                    case 4:
                        msg="RIGHT#";
                        break;
                    case 5:
                        msg = "SHOOT#";
                        break;
                    default:
                        msg="";
                        break;
                }
                con.sendToServer(msg);
               // this.comboBox1.SelectedIndex = 0;
            }
    }
}
