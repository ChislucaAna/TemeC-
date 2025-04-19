using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nationala2018
{
    public partial class CentenarLogare : Form
    {
        public CentenarLogare()
        {
            InitializeComponent();
        }
        public static bool utilizatorLogat = false;
        private void button1_Click(object sender, EventArgs e)
        {
            var query = from u in Db.utilizatori
                        where u.Nume == textBox1.Text && u.Parola == textBox2.Text
                        select u;
            if (query.Any())
            {
                utilizatorLogat = true;
                MessageBox.Show("Utilizator logat cu succes.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Utilizatorul nu a fost gasit.");
            }
        }

        private void CentenarLogare_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var query = from u in Db.utilizatori
                        where u.Nume == textBox1.Text && u.Parola == textBox2.Text
                        select u;
            if (query.Any())
            {
                utilizatorLogat = true;
                MessageBox.Show("Utilizator logat cu succes.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Emailul nu a fost gasit in baza de date.");
            }
        }
    }
}
