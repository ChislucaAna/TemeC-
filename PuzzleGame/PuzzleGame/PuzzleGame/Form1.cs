using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace PuzzleGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap source;
        Bitmap[,] pieces = new Bitmap[3, 3]; //ideal state of puzzle
        Bitmap[,] suffledPieces = new Bitmap[3, 3];  //current state of puzzle

        //SWAP variables
        PictureBox first=null;
        PictureBox second=null;
        int seconds = 0;
        int minutes = 0;
        int hours = 0;  
        private void Form1_Load(object sender, EventArgs e)
        { 

            //generate source image of desired size
            source = new Bitmap(fullImage.Image, fullImage.Width, fullImage.Height);
            //generate puzzle pieces
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pieces[i,j]=new Bitmap(fullImage.Width/3, fullImage.Height/3);
                    pieces[i, j].Tag = i.ToString() + j.ToString();
                    suffledPieces[i,j]=pieces[i,j];
                    suffledPieces[i, j].Tag = pieces[i, j].Tag;

                    Graphics g = Graphics.FromImage(pieces[i,j]);
                    g.DrawImage(source, -j * fullImage.Width / 3, -i * fullImage.Width / 3);

                    var query = from p in this.Controls.OfType<PictureBox>()
                                where p.Name == "pictureBox" + i.ToString() + j.ToString()
                                select p;
                    var result = query.First();
                    result.Image = pieces[i, j]; //ordinea corecta o ai in pieces ca sa verifici la final
                }
            }
            //shuufle();
            secunde.Start();
        }

        private void secunde_Tick(object sender, EventArgs e)
        {
            seconds++;
            if(seconds >60)
            {
                minutes++;
                seconds = 0;
            }
            if (minutes > 60)
            {
                hours++;
                minutes = 0;
            }
            label1.Text = hours.ToString() + ":" +minutes.ToString()+ ":"+ seconds.ToString();
        }

        public void PrintIdealState()
        {
            Console.WriteLine("Printing ideal state:");
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Console.Write(pieces[i, j].Tag.ToString() + " ");  
        }

        public void PrintCurrentState()
        {
            Console.WriteLine("Printing current state:");
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Console.Write(suffledPieces[i, j].Tag.ToString() + " ");
        }

        public void shuufle()
        {
            var query = from p in this.Controls.OfType<PictureBox>()
                        where p.Tag.ToString() == "piece"
                        select p;
            var array = query.ToArray();
            var rnd = new Random();
            array = array.OrderBy(x => rnd.Next()).ToArray();
            int index = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    suffledPieces[i, j] = new Bitmap(array[index].Image, fullImage.Width / 3, fullImage.Height / 3);
                    var result1 = GetPictureBoxArrayIndex(array[index]);
                    int i1 = result1.Item1;
                    int j1 = result1.Item2;
                    suffledPieces[i, j].Tag = i1.ToString() + j1.ToString();
                    index++;
                }
            }

            refreshPuzzle();
            PrintIdealState();
            PrintCurrentState();
        }

        private void button1_Click(object sender, EventArgs e) //shuffle
        {
            shuufle();
        }

        public void refreshPuzzle() //sync images with shuffled pieces array after swap
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    var Picturebox = from p in this.Controls.OfType<PictureBox>()
                                     where p.Name == "pictureBox" + i.ToString() + j.ToString()
                                     select p;
                    var pic = Picturebox.First();
                    pic.Image = suffledPieces[i, j];
                }
            }
        }

        public (int,int) GetPictureBoxArrayIndex(PictureBox p)
        {
            string name = p.Name;
            string last2 = String.Copy(name.Substring(name.LastIndexOf('x') + 1));
            int i = Convert.ToInt32(last2[0].ToString());
            int j = Convert.ToInt32(last2[1].ToString());
            return (i, j);
        }

        private void button2_Click(object sender, EventArgs e) //pause
        {
            if (secunde.Enabled)
            {
                button2.Text = "Resume";
            }
            else
            {
                button2.Text = "Pause";
            }

            secunde.Enabled = !secunde.Enabled; 
        }

        private void button3_Click(object sender, EventArgs e) //quit
        {
            Application.Exit();
        }

        public bool checkForWin()
        {
            bool won = true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (suffledPieces[i, j].Tag.ToString() != pieces[i, j].Tag.ToString())
                        won = false;
            return won;
        }

        private void pictureBox22_MouseDown(object sender, MouseEventArgs e) //select image/swap two images
        {
            if(first==null)
            {
                first = sender as PictureBox;   
            }
            else
            {
                second = sender as PictureBox;  
                (first.Image,second.Image)=(second.Image,first.Image);
                var result1 = GetPictureBoxArrayIndex(first);
                var result2 = GetPictureBoxArrayIndex(second);

                int i1 = result1.Item1;
                int j1 = result1.Item2;

                Console.WriteLine(i1 + " " + j1);


                int i2 = result2.Item1;
                int j2 = result2.Item2;

                Console.WriteLine(i2 + " " + j2);

                (suffledPieces[i1, j1],suffledPieces[i2, j2]) = (suffledPieces[i2, j2], suffledPieces[i1, j1]);


                refreshPuzzle();

                if(checkForWin())
                {
                    secunde.Stop();
                    MessageBox.Show("You won!Shuffing again..");
                    shuufle();
                    seconds = 0;
                }
                else
                {
                    Console.WriteLine("Didnt win yet");
                    PrintCurrentState();
                    PrintIdealState();
                }


                first = null;
                second = null;
            }
        }
    }
}
