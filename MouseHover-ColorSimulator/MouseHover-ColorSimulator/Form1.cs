using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseHover_ColorSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int locationX=0, locationY = 0;
        private bool isColored = true;
        private void pictureBox1_MouseLeave(object sender, EventArgs e) //Cand iesi efectul e acelasi pt ambele
        {
            pictureBox1.Image = Image.FromFile("trandafir_necolorat.png");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            (sender as PictureBox).Image = Image.FromFile("trandafir_colorat.png");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isColored)
            {
                pictureBox2.Image = Image.FromFile("trandafir_necolorat.png"); // Display the uncolored image
            }
            else
            {
                pictureBox2.Image = Image.FromFile("trandafir_colorat.png"); // Display the colored image
            }

            isColored = !isColored; // Toggle the flag for the next tick
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            timer1.Start();
               
        }
    }
}
