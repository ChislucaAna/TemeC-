using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliverySimulator
{
    public partial class CourierCompany : Form
    {
        public CourierCompany()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Db.packages.Add(new Package(Db.packages.Count,textBox1.Text,
                new Package.adr(textBox2.Text,Convert.ToInt32(textBox6.Text)),
                new Point(Convert.ToInt32(textBox4.Text),Convert.ToInt32(textBox5.Text)),false));
            App.RefreshAllWindows();
        }
        public void LoadPackages()
        {
            textBox1.Clear();
            foreach (var package in Db.packages)
            {
                textBox1.AppendText(package.ToString());
                textBox1.AppendText(System.Environment.NewLine);
            }
        }

        private void CourierCompany_Load(object sender, EventArgs e)
        {
            LoadPackages();
        }

        private void CourierCompany_Paint(object sender, PaintEventArgs e)
        {
            LoadPackages();
        }
    }
}
