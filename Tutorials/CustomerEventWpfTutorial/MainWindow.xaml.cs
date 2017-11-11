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

namespace CustomerEventWpfTutorial
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            this.btnCodeApproach.Click += new RoutedEventHandler(btnCodeApproach_Click);          
        }

        private void btnCodeApproach_Click(object sender, RoutedEventArgs e)
        {
           
            txtDisplayMessage.Text = "Managed Code Approach Button Is Clicked..!!!";
        }

        private void btnXAMLApproach_Click(object sender, RoutedEventArgs e)
        {
            txtDisplayMessage.Text = "Declarative(XAML) Approach Button Is Clicked..!!!";
            
        }

        private void myButtonSimple_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(); 
        }

    

        private void myButtonSimple_Tap(object sender, RoutedEventArgs e)
        {
            Console.WriteLine();
        }

        
    }
}
