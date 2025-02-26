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
    public partial class CourierWindow : Form
    {
        public CourierWindow(Courier courier)
        {
            InitializeComponent();
            this.courier = courier;
        }

        Courier courier;

        private void CourierWindow_Load(object sender, EventArgs e)
        {
            label1.Text = courier.name;
            //loadam in textbox toate pachetele care trebuie livrate de curier
            var undeliveredPackages = from package in Db.packages
                                      where package.deliveryStatus==false
                                      select package;
            //un pachet apartine unui curier daca si numai daca adresa este pe una din strazile care
            //ii revin curierului sau pachetul se afla in zona de actiune a curierului
            foreach(var package in undeliveredPackages )
            {
                if (courier.assignedStreets.Contains(package.adress.street) || package.IsInArea(courier.zone))
                    courier.assignedPackages.Add(package);
            }
            LoadPackages();
        }

        public void LoadPackages()
        {
            textBox1.Clear();
            foreach (var package in courier.assignedPackages)
            {
                textBox1.AppendText(package.ToString());
                textBox1.AppendText(System.Environment.NewLine);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<Package,double> packagesByDistance = new Dictionary<Package,double>();
            foreach (var package in courier.assignedPackages)
            {
                packagesByDistance.Add(package, package.DistanceFromCourier(courier.zone));
                Console.WriteLine(package.ToString());
            }
            var sorted = packagesByDistance.OrderBy(n => n.Value);
            textBox1.Clear();
            foreach (var package in sorted)
            {
                textBox1.AppendText(package.Key.ToString());
                Console.WriteLine(package.Value.ToString());    
                textBox1.AppendText(System.Environment.NewLine);
            }
        }
    }
}
