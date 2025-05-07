using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ShortestPathMatrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowDrop = true;
        }

        int n;
        //47
        int m;

        int[,] grid = new int[20, 20]; //elementele 
        bool[,] vizitat = new bool[20, 20]; //avoid visiting the same cell twice
        int[,] distante = new int[20, 20]; //distances
        List<(int, int)> Pasi = new List<(int,int)>(); //pasi

        //pt animatie
        int indexPas = 0;
        (int, int) p;
        private void Set_Click(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox1.Text);
            m = Convert.ToInt32(textBox2.Text);

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;


            for (int i = 0; i < m; i++)
            {
                var imageCol = new DataGridViewImageColumn();
                imageCol.Width = 50;
                imageCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.Columns.Add(imageCol);
            }

            for (int i = 0; i < n; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = 50;
                dataGridView1.Rows.Add(row);
            }

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < m; x++)
                {
                    Bitmap bmp = new Bitmap(50, 50);
                    Graphics g = Graphics.FromImage(bmp);
                    g.Clear(Color.White);
                    dataGridView1.Rows[y].Cells[x].Value = bmp;

                }
            }


            Console.WriteLine(dataGridView1.ColumnCount.ToString());
            Console.WriteLine(dataGridView1.RowCount.ToString());
            dataGridView1.Refresh();

        }

        public void printGrid()
        {
            Console.WriteLine("printing grid");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(grid[i,j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }
        public void printDistances()
        {
            Console.WriteLine("printing distances");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(distante[i, j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }


        public (int,int) Find(int code)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i, j] == code)
                        return (i, j);
                }
            }
            return (0, 0);
        }


        void bk((int,int) current, (int,int) goal) //fin dhortest path
        {
            Queue<(int, int)> s = new Queue<(int, int)>();
            int icurrent = current.Item1;
            int jcurrent = current.Item2;
            s.Enqueue((icurrent, jcurrent));
            while (s.Any())
            {
                var (x, y) = s.Dequeue();
                icurrent = x; jcurrent = y; 

                if (icurrent + 1 < n)
                {
                    if (grid[icurrent + 1, jcurrent] != -1 && !vizitat[icurrent + 1, jcurrent])
                    {
                        vizitat[icurrent + 1, jcurrent] = true;
                        distante[icurrent + 1, jcurrent] = distante[icurrent, jcurrent] + 1;
                        s.Enqueue((icurrent + 1, jcurrent));
                    }
                }
                if (icurrent - 1 >=0)
                {
                    if (grid[icurrent - 1, jcurrent] != -1 && !vizitat[icurrent - 1, jcurrent])
                    {
                        vizitat[icurrent - 1, jcurrent] = true;
                        distante[icurrent - 1, jcurrent] = distante[icurrent, jcurrent] + 1;
                        s.Enqueue((icurrent - 1, jcurrent));
                    }
                }
                if (jcurrent + 1 < m)
                {
                    if (grid[icurrent, jcurrent + 1] != -1 && !vizitat[icurrent, jcurrent + 1])
                    {
                        vizitat[icurrent, jcurrent + 1] = true;
                        distante[icurrent, jcurrent + 1] = distante[icurrent, jcurrent] + 1;
                        s.Enqueue((icurrent, jcurrent + 1));
                    }
                }
                if (jcurrent - 1 >= 0)
                {
                    if (grid[icurrent, jcurrent - 1] != -1 && !vizitat[icurrent, jcurrent - 1])
                    {
                        vizitat[icurrent, jcurrent - 1] = true;
                        distante[icurrent, jcurrent - 1] = distante[icurrent, jcurrent] + 1;
                        s.Enqueue((icurrent, jcurrent - 1));
                    }
                }
            }
            printDistances();
        }

        public void salveazaPasi()
        {
            (int, int) pozpisica = Find(1);
            (int, int) pozTuna = Find(2);

            //mergem invers in matrice pe drumul cel mai scurt
            (int, int) pozCurenta = pozTuna;
            while (pozCurenta != pozpisica)
            {
                int x = pozCurenta.Item1;
                int y = pozCurenta.Item2;

                //mergi pe pasul cu valoarea minima posibila
                
                List<(int,int)> posibilitati = new List<(int,int)>();

                if(x+1<n)
                    posibilitati.Add((x+1,y));
                if(x-1>=0)
                    posibilitati.Add((x -1, y));
                if(y+1<m)
                    posibilitati.Add((x, y+1));
                if(y-1>=0)
                    posibilitati.Add((x, y-1));

                printDistances();

                foreach(var p in posibilitati)
                {
                    Console.Write(p.Item1 + " " + p.Item2+";"); 
                }
                Console.WriteLine();

                posibilitati = posibilitati.OrderBy(n => distante[n.Item1, n.Item2]).ToList();


                //add step
                Pasi.Add(posibilitati.First());

                //update position
                pozCurenta = posibilitati.First();
                Console.WriteLine(pozCurenta.Item1 + " " + pozCurenta.Item2);
            }
        }

        public void printeazaPasi()
        {
            foreach ( var p in Pasi)
            {
                Console.WriteLine(p.Item1 + " " + p.Item2);
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            (int,int) pozpisica = Find(1);
            (int,int)  pozTuna = Find(2);
            vizitat[pozpisica.Item1, pozpisica.Item2] = true;
            distante[pozpisica.Item1, pozpisica.Item2] = 0;

            //adaugam obstacolele si in matricea de distante
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i, j] == -1)
                        distante[i, j] = 1000;
                }
            }
            bk(pozpisica, pozTuna);
            //salveaza toti pasii din matricea de distante intro lista, mergand invers
            salveazaPasi();
            printeazaPasi();
            //incepe animatia
            indexPas = Pasi.Count - 1;
            p = Find(1);
            timer1.Start();
        }

        private void Select(object sender, MouseEventArgs e) //start drag
        {
            var s = sender as PictureBox;
            panel1.DoDragDrop(s,DragDropEffects.Copy);

        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e) //add to cells
        {
            Console.WriteLine(e.X.ToString());
            Console.WriteLine(e.Y.ToString());
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X,e.Y));

            Console.WriteLine(clientPoint.X.ToString());
            Console.WriteLine(clientPoint.Y.ToString());

            int row = clientPoint.Y / 50;
            int col = clientPoint.X / 50;

            PictureBox pic = e.Data.GetData(typeof(PictureBox)) as PictureBox;
            Bitmap bmp = new Bitmap(pic.Image,50,50);  
            Console.WriteLine(col + " " + row);
            if (row >= 0 && col >= 0 && row < dataGridView1.RowCount && col < dataGridView1.ColumnCount)
            {
                dataGridView1[col, row].Value = bmp;
                grid[row, col] = Convert.ToInt32(pic.Tag.ToString());
            }
            Console.WriteLine("dropped");
            printGrid();
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("tick");
            Console.WriteLine(indexPas);
            if (indexPas == -1) return;
            (int, int) nextcell = Pasi[indexPas];
            (dataGridView1[p.Item2, p.Item1].Value, dataGridView1[nextcell.Item2, nextcell.Item1].Value) =
                (dataGridView1[nextcell.Item2, nextcell.Item1].Value, dataGridView1[p.Item2, p.Item1].Value);
            p = nextcell;
            indexPas--;
        }
    }
}
