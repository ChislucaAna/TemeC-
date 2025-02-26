using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DeliverySimulator
{
    public class Courier
    {
        public int id;
        public string name;
        public List<string> assignedStreets;

        //this field won't be added into the database, it is for app use only
        public List<Package> assignedPackages;
        public class circle
        {
            public Point center;
            public int radius;

            public circle(Point center, int radius)
            {
                this.center = center;
                this.radius = radius;
            }   
        };
        public circle zone;

        public Courier(int id, string name,circle zone)
        {
            this.id = id;
            this.name = name;
            this.zone = zone;
            assignedStreets = new List<string>();  
            assignedPackages = new List<Package>();
        }

        public override string ToString()
        {
            return id+";"+name+";"+zone.center.X+";"+ zone.center.Y+";"+zone.radius;
        }
    }
}
