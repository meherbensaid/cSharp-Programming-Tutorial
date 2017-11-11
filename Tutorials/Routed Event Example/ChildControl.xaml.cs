using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Routed_Event_Example
{
    /// <summary>
    /// Logique d'interaction pour ChildControl.xaml
    /// </summary>
    public partial class ChildControl : UserControl
    {
        public ChildControl()
        {
            InitializeComponent();
        }
        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent(
       "Tap", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChildControl));

        // Provide CLR accessors for the event
        public event RoutedEventHandler Tap
        {
            add { AddHandler(TapEvent, value); }
            remove { RemoveHandler(TapEvent, value); }
        }

        private void SignalParent(object sender, System.Windows.RoutedEventArgs e)
        {
            this.RaiseEvent(new RoutedEventArgs(TapEvent, this));
        }
    }
}
