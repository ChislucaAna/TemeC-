using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport
{
    public class Db
    {
        public BindingList<Session> Sessions { get; set; } = new BindingList<Session>();

        public void Load()
        { 
            StreamReader reader = new StreamReader("sessions.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(';');
                Sessions.Add(new Session(Convert.ToInt32(fields[0]),
                    Convert.ToInt32(fields[1]),
                    fields[2], Convert.ToInt32(fields[3]), fields[4]));
            }
        }

        public void Save()
        {
            using (StreamWriter writer = new StreamWriter("Sessions.txt", false))
            {
                foreach (Session session in Sessions)
                {
                    writer.WriteLine(session.ToString());
                }
            }
        }

        public void PrintAllSessions()
        {
            foreach (Session session in Sessions)
            {
                Console.WriteLine(session.ToString());
            }
        }
    }
}
