using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;

        }

        int growxby = -5;
        int growyby = -5;
        int lives = 3;
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Use left and right keys to move player");
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                player.Location = new Point(player.Location.X + 20, player.Location.Y);
            }
            if (e.KeyCode == Keys.Left)
            {
                player.Location = new Point(player.Location.X - 20, player.Location.Y);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Location = new Point(ball.Location.X + growxby, ball.Location.Y + growyby);
            if (ball.Bounds.IntersectsWith(player.Bounds))
            {
                growyby = (-1) * growyby;

                //daca vine din dreapta si cade pe marginea din stanga se modifica cu 90
                if (ball.Right < player.Left + player.Width / 2 && growxby < 0) //merge spre stanfa
                {
                    growxby = -growxby;
                }
                //daca vine din stanga si cade pe marginea din dreapta se modifica cu 90
                if (ball.Right > player.Left + player.Width / 2 && growxby > 0) //merge spre dreapta
                {
                    growxby = -growxby;
                }
                ball.Location = new Point(ball.Location.X + 5*growxby, ball.Location.Y + 5*growyby);
            }
            foreach (PictureBox p in this.Controls.OfType<PictureBox>())
            {
                if (p.Tag.ToString() == "brick")
                {
                    if (ball.Bounds.IntersectsWith(p.Bounds) && p.Visible)
                    {
                        growyby = (-1) * growyby;
                        growxby = (-1) * growxby;
                        p.Visible = false;
                    }
                }
            }
            if (ball.Location.Y > this.Height)
            {
                timer1.Stop();
                growyby = (-1) * growyby;
                ball.Location = new Point(player.Left + player.Width / 2 - ball.Width / 2, player.Location.Y - ball.Height);
                timer1.Start();
                lives--;
                label1.Text = "Lives: " + lives;
                if (lives == 0)
                {
                    timer1.Stop();
                    MessageBox.Show("You lost.");
                    Application.Exit();

                }
            }
            if (ball.Location.X < 0 || ball.Location.X > this.Width)
            {
                growxby = -growxby;
            }
            if(ball.Location.Y < 0)
            {
                growyby = -growyby;
                growxby = -growxby;
            }
        }
    }
}
