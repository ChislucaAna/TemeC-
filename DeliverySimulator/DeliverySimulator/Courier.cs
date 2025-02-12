using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySimulator
{
    public class Courier
    {
        public int id;
        public string name;
        public List<string> assignedStreets;

        public struct point
        {
            public int x;
            public int y;
        }
        public struct circle
        {
            public point center;
            public int radius;
        };
        public circle zone;

        public Courier(int id, string name,circle zone)
        {
            this.id = id;
            this.name = name;
            this.zone = zone;
            assignedStreets = new List<string>();   
        }

        public override string ToString()
        {
            return id+";"+name+";"+zone.center.x+";"+ zone.center.y+";"+zone.radius;
        }
    }
}
