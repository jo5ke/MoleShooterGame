using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoleShootGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        int score = 0;
        int total_shots = 0;
        int miss_shot = 0;

        void fn_shot()
        {
            score++;
            total_shots++;
            label1.Text = "Score=" + score;
            label3.Text = "Total Shots=" + total_shots;
            shot_voice();
        }

        void fn_miss_shot()
        {
            miss_shot++;
            label2.Text = "Missing Shots=" + miss_shot;
            total_shots++;
            shot_voice();
        }

        void shot_voice()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\JoskeG\Desktop\MolePics\gunshot.wav");
            player.Play();
        }

        void reset()
        {
            score = 0;
            total_shots = 0;
            miss_shot = 0;
            label1.Text = "Score=" + score;
            label3.Text = "Total Shots=" + total_shots;
            label2.Text = "Missing Shots=" + miss_shot;
            timer1.Start();
            label4.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x, y;
            x = r.Next(0,400);
            y = r.Next(200, 330);
            pictureBox1.Location = new Point(x, y);

            if(miss_shot>=10)
            {
                timer1.Stop();
                label4.Text = "Game over";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fn_shot();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            fn_miss_shot();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult di = MessageBox.Show("Are you sure?","Once again?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (di == DialogResult.Yes)
                Close();
        }
    }
}
