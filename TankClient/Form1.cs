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
      //  int [,] PlayerLocation;
        GameDetails details;
        public Form1()
        {
            InitializeComponent();
            details = new GameDetails();
        }

       public void updateGameDetails(String s) {
           details.update(s);
        }

        public void draw_play_ground(String msg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(draw_play_ground), new object[] { msg });
                return;
            }
           // Console.WriteLine(playground.Text);
           // playground.Text = msg;
            
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
          //  draw_play_ground("and");
          // timer();
            //time_thread.Start();
           // time = 5;
           // pictureBox2.Refresh();
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

        private void playground_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.C;
            Pen p1 = new Pen(Color.Red, 2.0f);
            Pen p2 = new Pen(Color.Blue, 2.0f);
            SolidBrush b1 = new SolidBrush(Color.White);
            SolidBrush b2 = new SolidBrush(Color.FromArgb(128, 179, 238, 58));
            g.FillRectangle(b1, 0, 0, pictureBox1.Width, pictureBox1.Height);
            g.DrawRectangle(p1, 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int i = 1; i < 10; i++)
            {
                g.DrawLine(p2, 0, i * pictureBox1.Height / 10, pictureBox1.Width, i * pictureBox1.Height / 10);
                g.DrawLine(p2, i * pictureBox1.Width / 10, 0, i * pictureBox1.Width / 10, pictureBox1.Height);
            }

            Font f = new Font("Arial", pictureBox1.Width / 20);
            g.DrawString("10", f, Brushes.Green, new PointF(0 * pictureBox1.Width / 10, 0 * pictureBox1.Height / 10));
            g.FillRectangle(b2, 0 * pictureBox1.Width / 10, 0 * pictureBox1.Height / 10, 3 * pictureBox1.Width / 10, pictureBox1.Height / 10);
            //}
            g.Flush();
        }

        
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            
            //Threadtimer();
           // String time2 = DateTime.Now.ToString("h:mm:ss");
            Graphics g = e.Graphics;
         //   g.Clear(Color.White);
            Pen p2 = new Pen(Color.Blue, 2.0f);
           // g.DrawRectangle(p2, 0, 0, pictureBox1.Width-1, pictureBox1.Height-1);
            Font f = new Font("Arial", pictureBox2.Width / 15);
            String s = "My Player Name : P";
            if (details.Connected) { s += details.myPlayerNumber; }
            s+="\nScore : " + "\nLife : " + "\nCoins :";
            g.DrawString(s, f, Brushes.Green, new PointF(2,2));
            g.Flush();
        }

        public void refreshPlayGround(){
            if (InvokeRequired)
            {
                this.Invoke(new Action(()=>{
                    pictureBox1.Refresh();
                }));
                return;
            }
            pictureBox1.Refresh();
        }

        public void refreshScoreBoard() {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    pictureBox2.Refresh();
                }));
                return;
            }
            pictureBox2.Refresh();
        }

        private void Other_Players_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
