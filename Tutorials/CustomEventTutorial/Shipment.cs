using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventTutorial
{
   public class Shipment
    {
        private string trackingValue;

        public delegate void shipmentHandler(object o, ShipmentEventArgs eventArgs);

        public event shipmentHandler eventHandler;

        public string TrackingValue {

            set
            {
                trackingValue = value;
                if (trackingValue.Length != 0)
                {
                    ShipmentEventArgs eventArgs = new ShipmentEventArgs("item has been shiped");
                    eventHandler(this, eventArgs);
                }
            }
                
                }
    }
}
