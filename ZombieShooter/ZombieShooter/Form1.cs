using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ZombieShooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            refreshLabels();
        }

        int ammo = 10;
        int kills = 0;
        int health = 100;
        bool gameInProgress = false;
        List<PictureBox> zombies = new List<PictureBox>();
        List<Gunshot> gunshots = new List<Gunshot>();
        public string playerDirection="down";

        public class Gunshot
        {
            public string direction; //up,down,left or right depending on player orientation at the time of the shot
            public Rectangle ammo; //graphical representation of gunshot

            public Gunshot(string direction)
            {
                this.direction = direction;
            }
        }
        public void refreshLabels()
        {
            label1.Text = "Ammo: ";
            label1.Text += ammo;

            label2.Text = "Kills: ";
            label2.Text += kills;

            if(health>1)
                progressBar1.Value = health;
        }

        public void startNewGame()
        {
            kills = 0;
            health = 100;
            gunshots.Clear();
            ammo = 10;
            foreach (var zombie in zombies.ToList())
            {
                this.Controls.Remove(zombie);
            }
            zombies.Clear();
            gameInProgress = true;
            playerDirection = "down";
            player.Image = Image.FromFile("up.png");
            refreshLabels();
            spawner.Start();
            moveZombies.Start();
            moveAmmo.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //move player
        {
            if (e.KeyCode == Keys.Enter && gameInProgress == false)
            {
                startNewGame();
            }
            if (e.KeyCode == Keys.Up)
            {
                player.Image = Image.FromFile("up.png");
                playerDirection = "up";
                player.Location = new Point(player.Location.X, player.Location.Y - 10);
            }
            if (e.KeyCode == Keys.Down)
            {
                player.Image = Image.FromFile("down.png");
                playerDirection = "down";
                player.Location = new Point(player.Location.X, player.Location.Y + 10);
            }
            if (e.KeyCode == Keys.Left)
            {
                player.Image = Image.FromFile("left.png");
                playerDirection = "left";
                player.Location = new Point(player.Location.X - 10, player.Location.Y);
            }
            if (e.KeyCode == Keys.Right)
            {
                player.Image = Image.FromFile("right.png");
                playerDirection = "right";
                player.Location = new Point(player.Location.X + 10, player.Location.Y);
            }
            Rectangle playerHitbox = new Rectangle(player.Location, player.Size);   
            Rectangle ammoHitbox = new Rectangle(ammoPicturebox.Location, ammoPicturebox.Size); 
            if (playerHitbox.IntersectsWith(ammoHitbox))
            {
                ammoHitbox.Location= new Point(-100, -100);
                ammo = 10;
                refreshLabels();
                ammoPicturebox.Visible = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                shoot();
            }
        }

        public void shoot()
        {
            if (ammo < 1)
            {
                Random rnd = new Random();
                int x = rnd.Next(0, this.Width);
                int y = rnd.Next(0, this.Height);
                ammoPicturebox.Location = new Point(x, y);
                ammoPicturebox.Visible = true;
            }
            else
            {
                ammo--;
                Gunshot g = new Gunshot(playerDirection);
                g.ammo = new Rectangle(new Point(player.Location.X + player.Width / 2, player.Location.Y + player.Height / 2), new Size(5, 5));
                gunshots.Add(g);
            }
            refreshLabels();
        }

        public void endGame()
        {
            player.Image = Image.FromFile("dead.png");
            gameInProgress = false;
            spawner.Stop();
            moveZombies.Stop();
            moveAmmo.Stop();

            MessageBox.Show("You lost");


        }

        private void moveZombies_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("moving zombies");
            Rectangle playerHitbox = new Rectangle(player.Location, player.Size);
            foreach (var zombie in zombies.ToList())
            {
                Rectangle zombieHitBox = new Rectangle(zombie.Location, zombie.Size);
                if (playerHitbox.IntersectsWith(zombieHitBox))
                {
                    health -= 10;
                    refreshLabels();
                    if (health < 1)
                    {
                        endGame();
                    }
                }
                else
                {
                    foreach (var ammo in gunshots.ToList())
                    {
                        if (ammo.ammo.IntersectsWith(zombieHitBox))
                        {
                            kills++;
                            refreshLabels();
                            this.Controls.Remove(zombie);
                            zombies.Remove(zombie);
                            gunshots.Remove(ammo);
                            break;
                        }
                    }
                    if(zombie.Location.Y<player.Location.Y)
                    {
                        zombie.Location = new Point(zombie.Location.X, zombie.Location.Y + 10);
                    }
                    if (zombie.Location.Y > player.Location.Y)
                    {
                        zombie.Location = new Point(zombie.Location.X, zombie.Location.Y - 10);
                    }
                    if (zombie.Location.X < player.Location.X)
                    {
                        zombie.Location = new Point(zombie.Location.X + 10, zombie.Location.Y);
                    }
                    if (zombie.Location.X > player.Location.X)
                    {
                        zombie.Location = new Point(zombie.Location.X - 10, zombie.Location.Y);
                    }
                }
            }
        }

        private void spawner_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int x = rnd.Next(0, this.Width);
            //din partea de jos a ecranului
            PictureBox zombie = new PictureBox();
            zombie.Image = Image.FromFile("zup.png");
            zombie.Location = new System.Drawing.Point(x, this.Height + 50);
            zombie.Size = new System.Drawing.Size(62, 82);
            zombie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Controls.Add(zombie);
            zombies.Add(zombie);
            Console.WriteLine("zombie spawned");
        }

        private void moveAmmo_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var ammo in gunshots.ToList())
            {
                if (ammo.ammo.X < 0 || ammo.ammo.Y < 0 || ammo.ammo.X > this.Width || ammo.ammo.Y > this.Height)
                {
                    gunshots.Remove(ammo);
                }
                else
                {
                    if (ammo.direction == "up")
                    {
                        ammo.ammo.Y -= 10;
                    }
                    if (ammo.direction == "down")
                    {
                        ammo.ammo.Y += 10;
                    }
                    if (ammo.direction == "left")
                    {
                        ammo.ammo.X -= 10;
                    }
                    if (ammo.direction == "right")
                    {
                        ammo.ammo.X += 10;
                    }
                }
                e.Graphics.FillRectangle(Brushes.Red, ammo.ammo);
            }
        }
    }
}
