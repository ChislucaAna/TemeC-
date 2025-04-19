using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nationala2018
{
    public class Db
    {
        public static List<Utilizator> utilizatori = new List<Utilizator>();
        public static List<Lectie> lectii = new List<Lectie>();

        public static void init()
        {
            string line;
            using(StreamReader r = new StreamReader("utilizatori.txt"))
            {
                while((line=r.ReadLine())!=null)
                {
                    string[] fields = line.Split('*');

                    utilizatori.Add(new Utilizator(utilizatori.Count, fields[0], fields[1], fields[2]));
                }
                r.Close();
            }
            using (StreamReader r = new StreamReader("lectii.txt"))
            {
                while ((line = r.ReadLine()) != null)
                {
                    string[] fields = line.Split('*');

                    Console.WriteLine(fields[4]);
                    lectii.Add(new Lectie(lectii.Count, Convert.ToInt16(fields[0]), fields[1], fields[2], DateTime.ParseExact(fields[4],"M/dd/yyyy h:mm:ss tt", new CultureInfo("en-US")),
                        fields[3]));
                }
                r.Close();
            }

        }
    }
}
