using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Elev
        {
            public string nume;
            public string prenume;
            public Elev(string nume, string prenume)
            {
                this.nume = nume;
                this.prenume = prenume; 
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> map = new Dictionary<int, string>()
            {
                {1,"soarec" },
                {2,"mara" },
                {3,"arz" },
                {4,"zare" }
            };

            List<string> list = new List<string>()
            {
                "sal",
                "al",
                "bal"
            };


            var ceva = map.Select(x => x.Key.ToString());
            foreach (var c in ceva)
            {
                Console.WriteLine(c);   
            }

            var w = map.OrderBy(x => x.Value).Reverse().ToList();
            Console.WriteLine(w.First().ToString());

            Elev e1 = new Elev("C", "B");
            Elev e2 = new Elev("D", "E");
            List<Elev> elevs = new List<Elev>()
            { e1,e2};
            var ordered =elevs.OrderBy(x => x.nume).ToList();  
            Console.WriteLine(ordered.First().nume);
        }
    }
}
