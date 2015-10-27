namespace TankClient
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serverDisplay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connect_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.display = new System.Windows.Forms.TextBox();
            this.up_btn = new System.Windows.Forms.Button();
            this.left_btn = new System.Windows.Forms.Button();
            this.down_btn = new System.Windows.Forms.Button();
            this.right_btn = new System.Windows.Forms.Button();
            this.shoot_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Other_Players = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Other_Players)).BeginInit();
            this.SuspendLayout();
            // 
            // serverDisplay
            // 
            this.serverDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverDisplay.Location = new System.Drawing.Point(554, 436);
            this.serverDisplay.Multiline = true;
            this.serverDisplay.Name = "serverDisplay";
            this.serverDisplay.ReadOnly = true;
            this.serverDisplay.Size = new System.Drawing.Size(272, 39);
            this.serverDisplay.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(765, 475);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Display";
            // 
            // connect_btn
            // 
            this.connect_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect_btn.Location = new System.Drawing.Point(554, 307);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(58, 93);
            this.connect_btn.TabIndex = 1;
            this.connect_btn.Text = "Connect Client";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(590, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Messages";
            // 
            // display
            // 
            this.display.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.display.Location = new System.Drawing.Point(767, 495);
            this.display.Multiline = true;
            this.display.Name = "display";
            this.display.ReadOnly = true;
            this.display.Size = new System.Drawing.Size(59, 17);
            this.display.TabIndex = 6;
            // 
            // up_btn
            // 
            this.up_btn.Location = new System.Drawing.Point(682, 278);
            this.up_btn.Name = "up_btn";
            this.up_btn.Size = new System.Drawing.Size(41, 41);
            this.up_btn.TabIndex = 7;
            this.up_btn.Text = "U";
            this.up_btn.UseVisualStyleBackColor = true;
            this.up_btn.Click += new System.EventHandler(this.up_btn_Click);
            // 
            // left_btn
            // 
            this.left_btn.Location = new System.Drawing.Point(635, 325);
            this.left_btn.Name = "left_btn";
            this.left_btn.Size = new System.Drawing.Size(41, 41);
            this.left_btn.TabIndex = 8;
            this.left_btn.Text = "L";
            this.left_btn.UseVisualStyleBackColor = true;
            this.left_btn.Click += new System.EventHandler(this.left_btn_Click);
            // 
            // down_btn
            // 
            this.down_btn.Location = new System.Drawing.Point(682, 372);
            this.down_btn.Name = "down_btn";
            this.down_btn.Size = new System.Drawing.Size(41, 41);
            this.down_btn.TabIndex = 9;
            this.down_btn.Text = "D";
            this.down_btn.UseVisualStyleBackColor = true;
            this.down_btn.Click += new System.EventHandler(this.down_btn_Click);
            // 
            // right_btn
            // 
            this.right_btn.Location = new System.Drawing.Point(729, 325);
            this.right_btn.Name = "right_btn";
            this.right_btn.Size = new System.Drawing.Size(41, 41);
            this.right_btn.TabIndex = 10;
            this.right_btn.Text = "R";
            this.right_btn.UseVisualStyleBackColor = true;
            this.right_btn.Click += new System.EventHandler(this.right_btn_Click);
            // 
            // shoot_btn
            // 
            this.shoot_btn.Location = new System.Drawing.Point(682, 325);
            this.shoot_btn.Name = "shoot_btn";
            this.shoot_btn.Size = new System.Drawing.Size(41, 41);
            this.shoot_btn.TabIndex = 11;
            this.shoot_btn.Text = "S";
            this.shoot_btn.UseVisualStyleBackColor = true;
            this.shoot_btn.Click += new System.EventHandler(this.shoot_btn_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(30, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(565, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(240, 116);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // Other_Players
            // 
            this.Other_Players.Location = new System.Drawing.Point(567, 134);
            this.Other_Players.Name = "Other_Players";
            this.Other_Players.Size = new System.Drawing.Size(237, 138);
            this.Other_Players.TabIndex = 14;
            this.Other_Players.TabStop = false;
            this.Other_Players.Paint += new System.Windows.Forms.PaintEventHandler(this.Other_Players_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(838, 521);
            this.Controls.Add(this.Other_Players);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.shoot_btn);
            this.Controls.Add(this.right_btn);
            this.Controls.Add(this.down_btn);
            this.Controls.Add(this.left_btn);
            this.Controls.Add(this.up_btn);
            this.Controls.Add(this.display);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverDisplay);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Other_Players)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serverDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox display;
        private System.Windows.Forms.Button up_btn;
        private System.Windows.Forms.Button left_btn;
        private System.Windows.Forms.Button down_btn;
        private System.Windows.Forms.Button right_btn;
        private System.Windows.Forms.Button shoot_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox Other_Players;
    }
}

