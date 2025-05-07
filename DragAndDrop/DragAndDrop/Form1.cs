using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragAndDrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel2.AllowDrop = true;
            panel1.AllowDrop = true;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) //1
        {
            (sender as Control).DoDragDrop(new DataObject(pictureBox1), DragDropEffects.Move);
        }

        private void panel2_DragEnter(object sender, DragEventArgs e) //2
        {
            e.Effect = DragDropEffects.Move;    
        }

        private void panel2_DragDrop(object sender, DragEventArgs e) //3
        {
        }

        private void panel2_DragOver(object sender, DragEventArgs e)
        {
            var obj = e.Data.GetData(typeof(PictureBox));
            PictureBox p = obj as PictureBox;
            (sender as Control).Controls.Add(p);

            Point p1 = new Point(e.X, e.Y);
            Point p2 = (sender as Control).PointToClient(p1);

            //Point p3 = (sender as Control).PointToScreen(p2);
            //Console.WriteLine(e.X + " " + e.Y);

            p.Location = p2;

            Console.WriteLine((sender as Control).Controls.Count);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip dropDownStrip = new ToolTip();
            dropDownStrip.SetToolTip(panel1, "ceva");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var files = Directory.GetDirectoryRoot(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Console.WriteLine(files);
        }
    }
}
