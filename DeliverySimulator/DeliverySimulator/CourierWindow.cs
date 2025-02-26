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
        string current_street;
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
            LoadStreets();
        }

        public void LoadStreets()
        {
            foreach(var street in courier.assignedStreets)
            {
                comboBox1.Items.Add(street);
            }
        }

        public void LoadPackages()
        {
            dataGridView1.Rows.Clear();
            if (current_street == null) //show all packages
            {
                foreach (var package in courier.assignedPackages)
                {
                    dataGridView1.Rows.Add(package);  
                }
            }
            else
            {
                foreach (var package in courier.assignedPackages)
                {
                    if (package.adress.street == current_street)
                    {
                        dataGridView1.Rows.Add(package);
                    }
                }
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

            dataGridView1.Rows.Clear();
            foreach (var package in sorted)
            {
                dataGridView1.Rows.Add(package.Key.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_street = comboBox1.SelectedItem.ToString() ;
            LoadPackages();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==dataGridView1.ColumnCount -1)
            {
                string rand = dataGridView1[0, e.RowIndex].Value.ToString() ;
                int id = Convert.ToInt32(rand[0].ToString());
                var p = from Package in Db.packages
                            where Package.id == id  
                            select Package;
                var pachet = p.First();
                pachet.deliveryStatus = true;
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                App.RefreshAllWindows();
            }
        }
    }
}
