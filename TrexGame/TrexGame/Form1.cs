using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrexGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        int jumpheight = 0;
        bool gameInProgress = false;
        int score = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumpheight==0 && trex.Bounds.IntersectsWith(ground.Bounds)) //you cant doublejump
            {
                jumpheight = 10;
            }
        }

        private void trexmovement_Tick(object sender, EventArgs e)
        {
            if(jumpheight>=1)
            {
                jumpheight--;
                Console.WriteLine(jumpheight);
                trex.Location = new Point(trex.Location.X, trex.Location.Y-15);       
            }
            foreach (PictureBox p in this.Controls.OfType<PictureBox>())
            {
                if(trex.Bounds.IntersectsWith(p.Bounds) && p.Tag.ToString()=="obstacle")
                {
                    gameInProgress = false;
                    jump.Stop();
                    background.Stop();
                    MessageBox.Show("trex is dead");
                    Form1 form1= new Form1();
                    form1.Show();
                    this.Hide();
                }
            }
        }

        private void background_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox p in this.Controls.OfType<PictureBox>())
            {
                if (p.Tag.ToString() == "obstacle")
                {
                    p.Location = new Point(p.Location.X - 15, p.Location.Y);
                    if (p.Location.X < -50)
                    {
                        Random rnd = new Random();
                        p.Location = new Point(this.Width + rnd.Next(30,200), p.Location.Y);
                        score++;
                        txtscore.Text = "Score: " + score.ToString();
                        if(score%10==0)
                        {
                            background.Interval -= 10;
                        }
                    }
                }
            }
        }

        public void Start()
        {
            var mes = MessageBox.Show("Press Ok to start the game.", "Start game", MessageBoxButtons.OKCancel);
            if (mes == DialogResult.OK)
            {
                gameInProgress = true;
                jump.Start();
                background.Start();
                gravity.Start();
            }
            else
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void gravity_Tick(object sender, EventArgs e)
        {
            if ((!trex.Bounds.IntersectsWith(ground.Bounds)) && jumpheight==0) //trex is in the air, we add graivity
            {
                trex.Location = new Point(trex.Location.X, trex.Location.Y + 10);
            }
        }
    }
}
