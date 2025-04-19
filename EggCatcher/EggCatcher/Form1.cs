using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EggCatcher.Properties;

namespace EggCatcher
{
    public partial class EggCatcher : Form
    {
        public EggCatcher()
        {
            InitializeComponent();
        }

        bool selected = false;
        List<PictureBox> eggs = new List<PictureBox>();
        int score = 0;
        private void EggCatcher_MouseMove(object sender, MouseEventArgs e)
        {
            if (selected)
            {
                Console.WriteLine("moving basket");
                if(e.Y<2*(this.Height/3))
                    basket.Location = new Point(e.X - basket.Width / 2, 2 * (this.Height / 3) - basket.Height / 2);
                else
                    basket.Location = new Point(e.X - basket.Width / 2, e.Y - basket.Height / 2);
            }
        }

        private void basket_MouseDown(object sender, MouseEventArgs e)
        {
            selected= !selected;
        }

        private void eggmovement(object sender, EventArgs e)
        {
            foreach (PictureBox pictureBox in eggs.ToList())
            {
                pictureBox.Location=new Point(pictureBox.Location.X, pictureBox.Location.Y+20);
                if (pictureBox.Location.Y > this.Height)
                {
                    this.Controls.Remove(pictureBox);
                    eggs.Remove(pictureBox);
                    score--;
                    label1.Text = score.ToString();
                    if (score<0)
                    {
                        timer1.Stop();
                        timer2.Stop();
                        MessageBox.Show("You lost.");
                        Application.Exit();
                    }
                }
                else//if egg intersects basket we remove it and add one to the score
                {
                    Rectangle pictureboxr = new Rectangle(pictureBox.Location, pictureBox.Size);
                    Rectangle basketr = new Rectangle(basket.Location, basket.Size);
                    if (pictureboxr.IntersectsWith(basketr))
                    {
                        this.Controls.Remove(pictureBox);
                        eggs.Remove(pictureBox);
                        score++;
                        label1.Text = score.ToString();
                        if(timer2.Interval>300)
                            timer2.Interval -= 200; //ouale sa se spauneze din ce in ce mai repede
                    }
                }
            }
            Console.WriteLine(eggs.Count);  
        }

        private void eggspawner(object sender, EventArgs e)
        {
            //spawn new egg
            Random rnd = new Random();
            PictureBox egg = new PictureBox();
            egg.Image = Image.FromFile("egg.png");
            egg.Location = new System.Drawing.Point(rnd.Next(0,this.Width), 0);
            egg.Name = "egg";
            egg.Size = new System.Drawing.Size(50, 50);
            egg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Controls.Add(egg);
            eggs.Add(egg);  
        }

        private void EggCatcher_Load(object sender, EventArgs e)
        {
            timer1.Start(); //eggmovement
            timer2.Start(); //eggspawner 
        }

        private void EggCatcher_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle grass = new Rectangle(new Point(0, 2 * (this.Height / 3) - basket.Height / 2), new Size(this.Width, this.Height / 3+basket.Height/2));
            g.FillRectangle(new SolidBrush(Color.Green), grass);
            Rectangle sky = new Rectangle(new Point(0,0), new Size(this.Width, 2*(this.Height / 3)-basket.Height/2));
            g.FillRectangle(new SolidBrush(Color.Blue), sky);
        }
    }
}
