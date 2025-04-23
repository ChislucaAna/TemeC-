using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMarioGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        bool left = false;
        bool right = false;
        bool jump = false;
        int playerJumpHeight=0;
        bool playerFalling = true;
        int coins = 0;
        private void MainTimerEvent(object sender, EventArgs e)
        {
            //gravitatie
            playerFalling = true;
            foreach (PictureBox p in this.Controls.OfType<PictureBox>())
            {
                if (p.Tag == null) continue;
                if (p.Tag.ToString() == "platform")
                {
                    if (player.Location.X > p.Location.X - player.Width && player.Location.X < p.Location.X + p.Width +player.Width
                        && player.Location.Y + player.Height >= p.Location.Y &&
                        player.Location.Y + player.Height <= p.Location.Y + 5) //playerul sta pe o platforma
                    {
                        playerFalling = false;
                        Console.WriteLine("player stopped falling");
                    }
                }
                if (p.Tag.ToString() == "coin")
                {
                    if (player.Bounds.IntersectsWith(p.Bounds))
                    {
                        coins++;
                        txtScore.Text = "Score: " + coins.ToString();
                        this.Controls.Remove(p);
                    }
                }
                if(p.Tag.ToString() == "key" && player.Bounds.IntersectsWith(p.Bounds))
                {
                    door.Image = Image.FromFile("door-open.jpg");
                    this.Controls.Remove(p);
                }
                if(p.Name=="door" && player.Bounds.IntersectsWith(p.Bounds))
                {
                    GameTimer.Stop();
                    var result = MessageBox.Show("You won. press ok to restart the game.","won",MessageBoxButtons.OK);
                    if(result == DialogResult.OK)
                    {
                        Form1 f = new Form1();
                        f.Show();
                        this.Hide();
                    }
                }
            }
            //movement
            if (left)
            {
                if(player.Location.X>60)
                    player.Location = new Point(player.Location.X - 10, player.Location.Y);
                if(background.Left<0)
                    background.Left += 10;
                foreach (PictureBox p in this.Controls.OfType<PictureBox>())
                {
                    if ((string)p.Tag == "platform" || (string)p.Tag == "key" || (string)p.Tag == "coin" || (string)p.Tag == "door")
                        p.Left += 10;
                }
            }
            if (right)
            {
                if(player.Location.X +player.Width <this.Width-60)
                    player.Location = new Point(player.Location.X + 10, player.Location.Y);
                if (background.Left > -1372)
                    background.Left -= 10;
                foreach (PictureBox p in this.Controls.OfType<PictureBox>())
                {
                    if ((string)p.Tag == "platform" || (string)p.Tag == "key" || (string)p.Tag == "coin" || (string)p.Tag == "door")
                        p.Left -= 10;
                }
            }
            if (jump)
            {
                jump = false;
                playerJumpHeight += 10;
            }
            if (playerJumpHeight > 0)
            {
                playerJumpHeight--;
                player.Location = new Point(player.Location.X, player.Location.Y - 20);
            }
            if (playerFalling)
            {
                player.Location = new Point(player.Location.X, player.Location.Y + 5);
            }
            if (player.Location.Y > this.Height)
            {
                GameTimer.Stop();
                var result = MessageBox.Show("You lost. press ok to restart the game.", "lost", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) //left
            {
                left = true;
            }
            if (e.KeyCode == Keys.D) //right
            {
                right = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) //left
            {
                left = false;
            }
            if (e.KeyCode == Keys.D) //right
            {
                right = false;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameTimer.Start();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.ToLower(e.KeyChar) == 'w' && !playerFalling) //jump
            {
                jump = true;
                Console.WriteLine(jump);
            }
        }
    }
}
