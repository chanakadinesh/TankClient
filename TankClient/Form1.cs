using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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
            display.Text += msg+"\r\n";
          //  serverDisplay.ScrollToCaret();
        }
        public void DisplayServerMessage(String msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(DisplayServerMessage), new object[] { msg });
                return;
            }
            serverDisplay.Text += msg + "\r\n";
            //  serverDisplay.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new Connection(this);
            con.startClient();
            connect_btn.Enabled = false;
            left_btn.Enabled = true;
            up_btn.Enabled = true;
            right_btn.Enabled = true;
            down_btn.Enabled = true;
            shoot_btn.Enabled = true;
        }

        private void up_btn_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(state => con.writing_on_server("UP#")));
        }

        private void left_btn_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(state => con.writing_on_server("LEFT#")));
        }
        private void right_btn_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(state => con.writing_on_server("RIGHT#")));
        }

        private void down_btn_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(state => con.writing_on_server("DOWN#")));
        }

        private void shoot_btn_Click_1(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(state => con.writing_on_server("SHOOT#")));
        }


    }
}
