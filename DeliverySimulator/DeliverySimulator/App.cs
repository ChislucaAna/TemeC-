using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySimulator
{
    public class App
    {
        public static void RefreshAllWindows()
        {
            Form1.ActiveForm.Refresh();
            foreach (CourierWindow item in Form1.openWindows)
            {
                item.LoadPackages();
            }
            CourierCompany.ActiveForm.Refresh();

        }
    }
}
