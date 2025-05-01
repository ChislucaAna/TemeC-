using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowGane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        Random rnd = new Random();
        int score = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            initPositions();
        }

        public void initPositions()
        {
            foreach (PictureBox p in this.Controls.OfType<PictureBox>())
            {
                if (p.Tag.ToString() == "baloon")
                {
                    int x = rnd.Next(player.Right, this.Width);
                    int y = rnd.Next(this.Height + 10, this.Height + 100);

                    p.Location = new Point(x, y);
                }
            }
            arrow.Location = new Point(-100, -100);
            explosion.Location = new Point(-100, -100);
        }

        private void movement(object sender, EventArgs e)
        {
            explosion.Location = new Point(-100, -100);
            foreach (PictureBox p in this.Controls.OfType<PictureBox>())
            {
                if (p.Tag.ToString() == "baloon")
                {
                    if(p.Top>bordertop.Bottom)
                        p.Location = new Point(p.Location.X, p.Location.Y - 10);
                    else
                    {
                        int x = rnd.Next(player.Right, this.Width);
                        int y = rnd.Next(this.Height + 10, this.Height + 100);

                        p.Location = new Point(x, y);
                    }
                }
            }

            if(arrow.Location.X>0 && arrow.Location.X<this.Width)
            {
                arrow.Location = new Point(arrow.Location.X+40, arrow.Location.Y);

                foreach (PictureBox p in this.Controls.OfType<PictureBox>())
                {
                    if (p.Tag.ToString() == "baloon")
                    {
                        if(p.Bounds.IntersectsWith(arrow.Bounds))
                        {
                            explosion.Location = p.Location; //explozie

                            //remove arrow and baloon
                            arrow.Location = new Point(-100, -100);
                            player.Image = Image.FromFile("idle.png");
                            int x = rnd.Next(player.Right, this.Width);
                            int y = rnd.Next(this.Height + 10, this.Height + 100);
                            p.Location = new Point(x, y);

                            //increment score
                            score++;
                            txtScore.Text = "Score: "+score.ToString();

                        }
                    }
                }
            }
            else
            {
                arrow.Location = new Point(-100, -100);
                player.Image = Image.FromFile("idle.png");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if(arrow.Location.Equals(new Point(-100,-100)))
                {
                    arrow.Location = new Point(player.Right, player.Top + player.Height / 2 - arrow.Width/2);
                    player.Image = Image.FromFile("shoot.png");
                }
            }
        }
    }
}
