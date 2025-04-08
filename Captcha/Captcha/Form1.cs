using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Captcha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int chosenIndex;
        string chosenName;
        int nrAparitii;
        Dictionary<int, string> map = new Dictionary<int, string>()
        { {0,"bird_" },
            {1,"dog_"},
    {2,"cat_" } };

        private void pictureBox1_Click(object sender, EventArgs e) //select/deselect
        {
            //MessageBox.Show("clicked");
            if((sender as PictureBox).Tag.ToString().Contains("selected"))
            {
                //MessageBox.Show("deselecting");
                //deselect
                (sender as PictureBox).Tag=(sender as PictureBox).Tag.ToString().Replace("selected", "");
                (sender as PictureBox).BorderStyle = BorderStyle.None;   
            }
            else
            {
                //select
                //MessageBox.Show("selecting");
                (sender as PictureBox).Tag += "selected";
                (sender as PictureBox).BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void button1_Click(object sender, EventArgs e) //check captcha
        {
            bool ok = true;
            List<PictureBox> list = this.Controls.OfType<PictureBox>().ToList();
            foreach (PictureBox pictureBox in list)
            {
                if((pictureBox.Tag.ToString().Contains("selected") && !pictureBox.Tag.ToString().Contains(map[chosenIndex]))
                    || (!pictureBox.Tag.ToString().Contains("selected") && pictureBox.Tag.ToString().Contains(map[chosenIndex])))
                {
                    MessageBox.Show("nu ai selectat corect");
                    ok = false;
                    break;
                }
            }
            if(ok)
            {
                MessageBox.Show("Ai selectat corect");
            }
            clearselections();
        }

        public void clearselections()
        {
            List<PictureBox> list = this.Controls.OfType<PictureBox>().ToList();
            foreach (PictureBox pictureBox in list)
            {
                
                if (pictureBox.Tag.ToString().Contains("selected"))
                {
                    Console.WriteLine("clearing selection");
                    pictureBox.Tag = pictureBox.Tag.ToString().Replace("selected", "");
                    pictureBox.BorderStyle = BorderStyle.None;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            chosenIndex = rnd.Next(0,3);
            nrAparitii = rnd.Next(1, 4); //cate imagini exista cu chestia ce tre so selectezi

            label1.Text += map[chosenIndex].Remove(map[chosenIndex].Length-1,1);

            Random rng = new Random();
            List<PictureBox> list = this.Controls.OfType<PictureBox>().ToList();
            var shuffled = list.OrderBy(n => rng.Next()).ToList();

            foreach (PictureBox p in list)
            {
                Console.WriteLine(nrAparitii);
                if (nrAparitii > 0)
                {
                    p.Tag = map[chosenIndex] ;
                    p.Image = Image.FromFile(p.Tag + nrAparitii.ToString() + ".jpg");
                    nrAparitii--;
                }
                else
                {
                    int val = 0;
                    do
                    {
                        val = rnd.Next(0, map.Count);
                        p.Tag = map[val];
                        Console.WriteLine(val);
                    } while (val==chosenIndex);
                    p.Image = Image.FromFile(p.Tag + rnd.Next(1,4).ToString() + ".jpg");
                }
                Thread.Sleep(100);  
            }
        }
    }
}
