using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEventTutorial
{
    public class ShipmentEventArgs:EventArgs
    {
        private string message;

        public ShipmentEventArgs(string Message)
        {
            this.message = Message;
        }
        public string Message{
            get
            {
                return message;
            }
                
                }
    }
}
