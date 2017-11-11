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
    /// Logique d'interaction pour ParentControl.xaml
    /// </summary>
    public partial class ParentControl : UserControl
    {
        public ParentControl()
        {
            InitializeComponent();
        }
        private void HandleChildSignal(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Text.Text = "The Child control made this event happen.";
        }
    }
}
