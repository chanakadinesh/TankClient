﻿using System;
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

        //Play Ground
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.C;

            drawGrid(g);
            drawBricks(g);
            drawWater(g);
            drawStones(g);
            drawPlayers(g);
            drawCoins(g);
            drawLifePacks(g);
            //Font f = new Font("Arial", pictureBox1.Width / 20);
            //g.DrawString("10", f, Brushes.Green, new PointF(0 * pictureBox1.Width / 10, 0 * pictureBox1.Height / 10));
            
            //}
            g.Flush();
        }

        //My Score Board
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
           
            Graphics g = e.Graphics;
            Pen p2 = new Pen(Color.Blue, 2.0f);
            Font f = new Font("Arial", pictureBox2.Width / 15);
            String s = "My Player Name : ";
            if (details.isGameStarted) { s += details.myPlayerNumber; }
            if (details.hasPlayerDetails)
            {
                string[,] p_data = details.playerDetail;
                for (int i = 0; i < details.playerCount; i++)
                {
                    if (p_data[i, 0] == details.myPlayerNumber)
                    {
                        s += "\nLife : " + p_data[i, 1] + "\nCoins : " + p_data[i, 2] + "\nPoints :" + p_data[i, 3];
                        break;
                    }
                }
            }
            //s += "\nScore : " + "\nLife : " + "\nCoins :";
            g.DrawString(s, f, Brushes.Green, new PointF(2,2));
            g.Flush();
        }

        //Refreah the form
        public void refreshAll(){
            if (InvokeRequired)
            {
                this.Invoke(new Action(()=>{
                    pictureBox1.Refresh();
                    pictureBox2.Refresh();
                    Other_Players.Refresh();
                }));
                return;
            }
            pictureBox1.Refresh();
            pictureBox2.Refresh();
            Other_Players.Refresh();
        }

        //Other players' details
        private void Other_Players_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p2 = new Pen(Color.Blue, 2.0f);
            Font f = new Font("Arial", Other_Players.Width / 20);
            String s = "Name\tHealth\tCoins\tPoints";
            //if (details.Connected) { s += details.myPlayerNumber; }
            if (details.hasPlayerDetails)
            {
                string[,] p_data = details.playerDetail;
                for (int i = 0; i < details.playerCount; i++)
                {
                    if (p_data[i, 0] != details.myPlayerNumber)
                    {
                        s += "\n" + p_data[i, 0] + "\t" + p_data[i, 1] + "\t" + p_data[i, 2] + "\t" + p_data[i, 3];
                    }
                }
            }
          //  s += "\nP1\t"+56 +"\t"+56+"\t"+456+ "\nP2  " + "\nP3 ";
            g.DrawString(s, f, Brushes.Green, new PointF(2, 2));
            g.Flush();

        }

        /****
         * drawing playground
         * ** drawing grid;
         * ** drawing bricks with conditions;
         * ** drawing water and stones;
         * ** drawing players;
         * ** drawing lifepacks;
         * ** drawing conis;
         * ** drawing bullets;
         * *******/
        private void drawGrid(Graphics g) {
            Pen p1 = new Pen(Color.Red, 2.0f);
            Pen p2 = new Pen(Color.Blue, 2.0f);
            SolidBrush b1 = new SolidBrush(Color.White);
          //  SolidBrush b2 = new SolidBrush(Color.FromArgb(128, 179, 238, 58));
            g.FillRectangle(b1, 0, 0, pictureBox1.Width, pictureBox1.Height);
            g.DrawRectangle(p1, 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int i = 1; i < 10; i++)
            {
                g.DrawLine(p2, 0, i * pictureBox1.Height / 10, pictureBox1.Width, i * pictureBox1.Height / 10);
                g.DrawLine(p2, i * pictureBox1.Width / 10, 0, i * pictureBox1.Width / 10, pictureBox1.Height);
            }
        }
        private void drawBricks(Graphics g) {
            if (details.Connected)
            {
                SolidBrush b2 = new SolidBrush(Color.FromArgb(180, 205, 102, 29));
                SolidBrush b3 = new SolidBrush(Color.FromArgb(180, 255, 127, 36));
                SolidBrush b4 = new SolidBrush(Color.FromArgb(180, 244, 164, 96));
                SolidBrush b1 = new SolidBrush(Color.FromArgb(180, 205, 55, 0));
                int[,] bricks = details.Bricks;
                //foreach (int[] loc in bricks) { 
                int len = bricks.Length;
                for (int i = 0; i < len / 3; i++)
                {
                    Image newImage;
                    if (bricks[i, 2] == 0)
                    {
                        //g.FillRectangle(b1, bricks[i, 0] * pictureBox1.Width / 10, bricks[i, 1] * pictureBox1.Height / 10, pictureBox1.Width / 10, pictureBox1.Height / 10);
                       newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\brick1.jpg");
                       
                    }
                    else if (bricks[i, 2] == 1)
                    {
                        //g.FillRectangle(b2, bricks[i, 0] * pictureBox1.Width / 10, bricks[i, 1] * pictureBox1.Height / 10, pictureBox1.Width / 10, pictureBox1.Height / 10);
                        newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\brick2.jpg");
                       
                    }
                    else if (bricks[i, 2] == 2)
                    {
                        //g.FillRectangle(b3, bricks[i, 0] * pictureBox1.Width / 10, bricks[i, 1] * pictureBox1.Height / 10, pictureBox1.Width / 10, pictureBox1.Height / 10);
                        newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\brick3.jpg");
                    }
                    else if (bricks[i, 2] == 3)
                    {
                        //g.FillRectangle(b4, bricks[i, 0] * pictureBox1.Width / 10, bricks[i, 1] * pictureBox1.Height / 10, pictureBox1.Width / 10, pictureBox1.Height / 10);
                        newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\brick4.jpg");
                       
                    }
                    else {
                        newImage = null;
                    }
                    if (bricks[i, 2] != 4)
                    {
                        Rectangle destRect = new Rectangle(0, 0, pictureBox1.Height, pictureBox1.Width);
                        Rectangle srcRect = new Rectangle(bricks[i, 0] * pictureBox1.Width / 10, bricks[i, 1] * pictureBox1.Height / 10, 100 * pictureBox1.Width / 517, 100 * pictureBox1.Height / 517);
                        GraphicsUnit units = GraphicsUnit.Pixel;
                        g.DrawImage(newImage, srcRect, destRect, units);
                    }
                }
            }
        }
        private void drawWater(Graphics g) {
            if (details.Connected) {
                SolidBrush b1 = new SolidBrush(Color.FromArgb(150, 0,154,205));
                int[,] water = details.Water;
                //foreach (int[] loc in bricks) { 
                int len = water.Length;
                for (int i = 0; i < len / 2; i++)
                {
                    //g.FillRectangle(b1, water[i, 0] * pictureBox1.Width / 10, water[i, 1] * pictureBox1.Height / 10, pictureBox1.Width / 10, pictureBox1.Height / 10);
                    Image newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\water.png");
                    Rectangle destRect = new Rectangle(0, 0, pictureBox1.Height, pictureBox1.Width);
                    Rectangle srcRect = new Rectangle(water[i, 0] * pictureBox1.Width / 10, water[i, 1] * pictureBox1.Height / 10, 100 * pictureBox1.Width / 261, 100 * pictureBox1.Height / 261);
                    GraphicsUnit units = GraphicsUnit.Pixel;
                    g.DrawImage(newImage, srcRect, destRect, units);
                }
            }
        }
        private void drawStones(Graphics g) {
            if (details.Connected)
            {
                SolidBrush b1 = new SolidBrush(Color.FromArgb(150, 105,105,105));
                int[,] stone = details.Stone;
                //foreach (int[] loc in bricks) { 
                int len = stone.Length;
                for (int i = 0; i < len / 2; i++)
                {
                    //g.FillRectangle(b1, stone[i, 0] * pictureBox1.Width / 10, stone[i, 1] * pictureBox1.Height / 10, pictureBox1.Width / 10, pictureBox1.Height / 10);
                    Image newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\stone.jpg");
                    Rectangle destRect = new Rectangle(0, 0, pictureBox1.Height, pictureBox1.Width);
                    Rectangle srcRect = new Rectangle(stone[i, 0] * pictureBox1.Width / 10, stone[i, 1] * pictureBox1.Height / 10, 100 * pictureBox1.Width / 261, 100 * pictureBox1.Height / 261);
                    GraphicsUnit units = GraphicsUnit.Pixel;
                    g.DrawImage(newImage, srcRect, destRect, units);
                }
            }
        }
        private void drawPlayers(Graphics g) {
            if (details.isGameStarted)
            {
                int[,] loc = details.playerLoc;
                //int len = bricks.Length;
                int len = details.playerCount;
                Font f = new Font("Arial", Other_Players.Width / 20);
                for (int i = 0; i < len; i++)
                {
                    Image newImage;
                    if (loc[i, 2] == 0)
                    {
                        newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\tank0.gif");

                    }
                    else if (loc[i, 2] == 1)
                    {
                        newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\tank1.gif");

                    }
                    else if (loc[i, 2] == 2)
                    {
                        newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\tank2.gif");
                    }
                    else if (loc[i, 2] == 3)
                    {
                        newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\tank3.gif");
                    }
                    else
                    {
                        newImage = null;
                    }
                    if (!details.hasPlayerDetails)
                    {
                        //if ([i, 2] != 4)
                        //{
                        Rectangle destRect = new Rectangle(0, 0, pictureBox1.Height, pictureBox1.Width);
                        Rectangle srcRect = new Rectangle(loc[i, 0] * pictureBox1.Width / 10, loc[i, 1] * pictureBox1.Height / 10, 160 * pictureBox1.Width / 517, 160 * pictureBox1.Height / 517);
                        GraphicsUnit units = GraphicsUnit.Pixel;
                        g.DrawImage(newImage, srcRect, destRect, units);
                        g.DrawString("P"+i, f, Brushes.Red, new PointF(loc[i, 0] * pictureBox1.Width / 10, loc[i, 1] * pictureBox1.Height / 10));
                    }
                    else
                    {
                        string[,] player = details.playerDetail;
                        if (player[i, 1] != "0")
                        {
                            Rectangle destRect = new Rectangle(0, 0, pictureBox1.Height, pictureBox1.Width);
                            Rectangle srcRect = new Rectangle(loc[i, 0] * pictureBox1.Width / 10, loc[i, 1] * pictureBox1.Height / 10, 160 * pictureBox1.Width / 517, 160 * pictureBox1.Height / 517);
                            GraphicsUnit units = GraphicsUnit.Pixel;
                            g.DrawImage(newImage, srcRect, destRect, units);
                            g.DrawString(player[i,0], f, Brushes.Red, new PointF(loc[i, 0] * pictureBox1.Width / 10, loc[i, 1] * pictureBox1.Height / 10));
                        }
                    }
                }
            }
        }
        private void drawLifePacks(Graphics g) {
            List<lifepack> lp = details.LifePacks;
            Image newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\lifepack.png");
            Rectangle destRect = new Rectangle(0, 0, pictureBox1.Height, pictureBox1.Width);
            Font f = new Font("Arial", Other_Players.Width / 30);
            if (lp.Count > 0)
            {
                for (int i = 0; i < lp.Count; i++)
                {
                    lifepack c = lp.ElementAt(i);
                    Rectangle srcRect = new Rectangle(c.X * pictureBox1.Width / 10, c.Y * pictureBox1.Height / 10, 100 * pictureBox1.Width / 261, 100 * pictureBox1.Height / 261);
                    GraphicsUnit units = GraphicsUnit.Pixel;
                    g.DrawImage(newImage, srcRect, destRect, units);
                    g.DrawString("L:" + c.L , f, Brushes.Blue, new PointF((c.X) * pictureBox1.Width / 10, (c.Y) * pictureBox1.Height / 10));
                    //Console.WriteLine(c.X + "/" + c.Y);
                }
            }
        }
        private void drawCoins(Graphics g) {
            List<coin> cl = details.Coins;
            Image newImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "img\\coin.png");
            Rectangle destRect = new Rectangle(0, 0, pictureBox1.Height, pictureBox1.Width);
            Font f = new Font("Arial", Other_Players.Width / 30);
            if(cl.Count>0){
                for(int i=0;i<cl.Count;i++){
                    coin c = cl.ElementAt(i);
                    Rectangle srcRect = new Rectangle(c.X * pictureBox1.Width / 10, c.Y * pictureBox1.Height / 10, 100 * pictureBox1.Width / 261, 100 * pictureBox1.Height / 261);
                    GraphicsUnit units = GraphicsUnit.Pixel;
                    g.DrawImage(newImage, srcRect, destRect, units);
                    g.DrawString("L:"+c.L+"\n/V:"+c.V, f, Brushes.Blue, new PointF((c.X) * pictureBox1.Width / 10, (c.Y) * pictureBox1.Height / 10));
                    //Console.WriteLine(c.X + "/" + c.Y);
                }
            }
        }
        private void drawBullets(Graphics g) { }

    }
}
