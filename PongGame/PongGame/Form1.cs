using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        public class Ball
        {
            public int x;
            public int y;
            public const int size = 20;
            public int modifyXby = 10;
            public int modifyYby = 10;

            public Ball(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public class Player
        {
            public int scor=0;
            public int x;
            public int y;
            public const int width = 20;
            public const int height = 75;

            public Player(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        Player player1;
        Player player2;
        Ball ball;
        int uwu = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            player1 = new Player(0, pictureBox1.Height / 2 - Player.height / 2);
            player2 = new Player(pictureBox1.Width - Player.width, pictureBox1.Height / 2 - Player.height / 2);
            ball = new Ball(pictureBox1.Width / 2, pictureBox1.Height / 2);
            ball_move.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) //PLAYER2
            {
                player2.y -= 20;
            }
            if (e.KeyCode == Keys.Down) //PLAYER2
            {
                player2.y += 20;
            }
            if (e.KeyCode == Keys.W) //PLAYER1
            {
                player1.y -= 20;
            }
            if (e.KeyCode == Keys.S) //PLAYER1
            {
                player1.y += 20;
            }
            pictureBox1.Refresh();
        }

        public bool BallHitsWallOrPlayer() //peretele de sus sau jos->ricoseaza
        {
            if (ball.y <= 3)
            {
                return true;
            }
            if (ball.y >= pictureBox1.Height - 3)
            {
                return true;
            }
            return false;
        }


        //returneaza numarul playerului care adat gol
        public int goal() //peretele din parti=gol, 1=player1 ++, 2=player2++;
        {
            if (ball.x <= 3)
                return 2;
            if (ball.x >= pictureBox1.Width - 3)
                return 1;
            return 0;
        }


        private void ball_move_Tick(object sender, EventArgs e)
        {
            if(BallHitsWallOrPlayer())
            {
                ball.modifyYby *= -1;
                if (uwu % 2 == 0)
                {
                    uwu++;
                    ball.modifyXby *= -1;
                }
            }
            Rectangle r = new Rectangle(ball.x, ball.y, Ball.size, Ball.size);
            Rectangle p1 = new Rectangle(player1.x + Ball.size/2, player1.y, Player.width, Player.height);
            Rectangle p2 = new Rectangle(player2.x - Ball.size/2, player2.y, Player.width, Player.height);
            if (r.IntersectsWith(p1) || r.IntersectsWith(p2))
            {
                ball.modifyYby *= -1; ball.modifyXby *= -1;
            }
            else
            {
                int gol = goal();
                if(gol==2)
                {
                    player2.scor++;
                    refreshlabels();
                    ball = new Ball(pictureBox1.Width / 2, pictureBox1.Height / 2);
                }
                else
                {
                    if(gol==1)
                    {
                        player1.scor++;
                        refreshlabels();
                        ball = new Ball(pictureBox1.Width / 2, pictureBox1.Height / 2);
                    }
                }

            }
            ball.x += ball.modifyXby;
            ball.y += ball.modifyYby;
            pictureBox1.Refresh();
        }

        public void refreshlabels()
        {
            textBox1.Text=player1.scor.ToString();
            textBox2.Text=player2.scor.ToString();  
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            //paint borders
            Brush yellow  = new SolidBrush(Color.Orange);
            e.Graphics.FillRectangle(yellow, new Rectangle(0,0, pictureBox1.Width, 3));
            e.Graphics.FillRectangle(yellow, new Rectangle(0, pictureBox1.Height-3, pictureBox1.Width, 3));
            e.Graphics.FillRectangle(yellow, new Rectangle(0, 0, 3, pictureBox1.Height));
            e.Graphics.FillRectangle(yellow, new Rectangle(pictureBox1.Width-3,0, 3, pictureBox1.Height));
            //drawplayers
            Brush red = new SolidBrush(Color.Red);
            e.Graphics.FillRectangle(red, new Rectangle(player1.x, player1.y, Player.width, Player.height));
            e.Graphics.FillRectangle(red, new Rectangle(player2.x, player2.y, Player.width, Player.height));
            //drawball
            Brush blue = new SolidBrush(Color.Blue);
            e.Graphics.FillEllipse(blue, new Rectangle(ball.x,ball.y,Ball.size,Ball.size));
        }
    }
}
