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
        }
    }
}
