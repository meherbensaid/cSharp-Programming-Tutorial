using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

        CancellationTokenSource tokenSource = new CancellationTokenSource();

        private void button_Click(object sender, RoutedEventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            textBlock.Text = "";
            label.Content = "Milliseconds: ";

            List<Task> tasks = new List<Task>();
            var watch = Stopwatch.StartNew();
            var ui = TaskScheduler.FromCurrentSynchronizationContext();
            for (int i = 2; i < 20; i++)
            {
                var j = i;
                var compute = Task.Factory.StartNew(() =>
                {
                  return SumRootN(j);
                },tokenSource.Token);

                tasks.Add(compute);

                var diplayResult = compute.ContinueWith(resultTask => {

                    textBlock.Text += "root " + j.ToString() + " " +
                                   compute.Result.ToString() + Environment.NewLine;
                },CancellationToken.None,TaskContinuationOptions.OnlyOnRanToCompletion,ui);
                    
                var displayWhenCancel=compute.ContinueWith(resultTask=> { 
                            textBlock.Text += "root " + j.ToString() + "canceled"
                              + Environment.NewLine;

                }, CancellationToken.None,TaskContinuationOptions.OnlyOnCanceled, ui);
            }

            
            Task.Factory.ContinueWhenAll(tasks.ToArray(),
               result =>
               {
                   var time = watch.ElapsedMilliseconds;
                       label.Content += time.ToString();
               },CancellationToken.None,TaskContinuationOptions.None,ui);

        }

        public double SumRootN(int root)
        {
            double result = 0;
            for (int i = 1; i < 10000000; i++)
            {
                tokenSource.Token.ThrowIfCancellationRequested();
                result += Math.Exp(Math.Log(i) / root);
            }
            return result;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            tokenSource.Cancel();
            textBlock.Text += "Cancel" + Environment.NewLine;
        }
    }
}
