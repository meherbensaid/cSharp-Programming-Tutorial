using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCustomEventWpfTutorial
{
    public class MessageEventArgs : EventArgs
    {
        private string _message;
        public MessageEventArgs(string message)
        {
            _message = message;
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
