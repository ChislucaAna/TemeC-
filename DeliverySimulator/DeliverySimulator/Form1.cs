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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<CourierWindow> openWindows = new List<CourierWindow>();

        private void Form1_Load(object sender, EventArgs e)
        {
            Db.GetData();
            foreach(Courier courier in Db.couriers)
            {
                CourierWindow courierWindow = new CourierWindow(courier);
                openWindows.Add(courierWindow);
                courierWindow.Show();
            }
            CourierCompany company = new CourierCompany();
            company.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Db.SaveData();
            foreach (CourierWindow item in openWindows)
            {
                item.Close();
            }
            this.Close();
        }
    }
}
