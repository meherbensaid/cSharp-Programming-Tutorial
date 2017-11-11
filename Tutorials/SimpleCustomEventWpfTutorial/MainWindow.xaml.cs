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

namespace SimpleCustomEventWpfTutorial
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageEvent += MainWindowtestMethod;
        }
        public delegate void MessagDelegate(object o, MessageEventArgs e); 
        public event MessagDelegate MessageEvent;

        public void RaiseHandler(MessageEventArgs e)
        {
           
            if (MessageEvent != null)
            {
                MessageEvent(this, e);
            }
        }
        public void MainWindowtestMethod(object o,MessageEventArgs e)
        {
            //this.Close();
            Window1 w = new Window1();
            w.textBlock.Text = "hey";
            w.Show();
           
            Console.WriteLine("this Main Window test Mothod when click on button {0}",e.Message);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            RaiseHandler(new MessageEventArgs(this.button.Name));
            e.Handled = true;
        }

        private void button_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
