using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventTutorial
{
    public class SubscribeShipment
    {
        public Shipment shipemnt;

        public SubscribeShipment()
        {
            shipemnt = new Shipment();
            shipemnt.eventHandler += LogBeforeShip;
            shipemnt.TrackingValue = "123";
        }



        public void LogBeforeShip(object o,ShipmentEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
