using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ThreadTaskTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "";
            label.Content = "Milliseconds: ";

            List<Task> tasks = new List<Task>();
            var watch = Stopwatch.StartNew();
            for (int i = 2; i < 20; i++)
            {
               
                var j = i;
                var t = Task.Factory.StartNew(() =>
                {
                    var result = SumRootN(j);
                    Dispatcher.BeginInvoke(new Action(() =>
                        textBlock.Text += "root " + j.ToString() + " " +
                                   result.ToString() + Environment.NewLine), null);
                });
                tasks.Add(t);
            }

            Task.Factory.ContinueWhenAll(tasks.ToArray(),
               result =>
               {
                   var time = watch.ElapsedMilliseconds;
                   this.Dispatcher.BeginInvoke(new Action(() =>
                       label.Content += time.ToString()));
               });

        }

        public static double SumRootN(int root)
        {
            double result = 0;
            for (int i = 1; i < 10000000; i++)
            {
                result += Math.Exp(Math.Log(i) / root);
            }
            return result;
        }
    }
}
