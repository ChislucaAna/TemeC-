using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySimulator
{
    public class Package
    {
        public int id;
        public string recipient;
        public class adr
        {
            public string street;
            public int number;

            public adr(string street, int number)
            {
                this.street = street;
                this.number = number;
            }
        }

        public adr adress;
        public Point location;
        public bool deliveryStatus;

        public Package(int id,string recipient, adr adress, Point location, bool deliveryStatus)
        {
            this.id = id;
            this.recipient = recipient;
            this.adress = adress;
            this.location = location;
            this.deliveryStatus = deliveryStatus;
        }

        public override string ToString()
        {
            return id + ";" + recipient + ";" + adress.street + ";" + adress.number + ";" + location.X + ";" + location.Y + ";" + deliveryStatus.ToString() ;
        }

        public double DistanceFromCourier(Courier.circle area)
        {
            return Math.Sqrt(Math.Pow(location.X - area.center.X, 2) + Math.Pow(location.Y - area.center.Y, 2));
        }
        public bool IsInArea(Courier.circle area)
        {
            if(Math.Pow(location.X-area.center.X,2)+ Math.Pow(location.Y - area.center.Y, 2)<=area.radius)
                return true;
            return false;
        }
    }
}
