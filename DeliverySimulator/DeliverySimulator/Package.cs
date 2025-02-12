using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySimulator
{
    public class Package
    {
        public int id;
        public string recipient;
        public struct adr
        {
            public string street;
            public int number;
        }
        public struct loc
        {
            public int x;
            public int y;
        }

        public adr adress;
        public loc location;
        public bool deliveryStatus;

        public Package(int id,string recipient, adr adress, loc location, bool deliveryStatus)
        {
            this.id = id;
            this.recipient = recipient;
            this.adress = adress;
            this.location = location;
            this.deliveryStatus = deliveryStatus;
        }

        public override string ToString()
        {
            return id + ";" + recipient + ";" + adress.street + ";" + adress.number + ";" + location.x + ";" + location.y + ";" + deliveryStatus.ToString() ;
        }
    }
}
