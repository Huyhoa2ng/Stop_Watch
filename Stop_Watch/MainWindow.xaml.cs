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
using System.Windows.Threading;
using System.Threading;
using System.Runtime;
using System.Diagnostics;
using System.Timers;
namespace Stop_Watch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch _stopWatch;
        private System.Timers.Timer _timer;
        public MainWindow()
        {
            InitializeComponent();
            _stopWatch = new Stopwatch();
            _timer = new System.Timers.Timer(interval: 1000);
            _timer.Elapsed += OntimeElapsed;
            
        }

        private void OntimeElapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(()=> lblRunning.Content = _stopWatch.Elapsed.ToString(format:@"hh\:mm\:ss"));
            Application.Current.Dispatcher.Invoke(() =>lblTotal.Content = _stopWatch.Elapsed.ToString(format: @"hh\:mm\:ss"));

        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnStartStop_Click(object sender, RoutedEventArgs e)
        {
            
            if(btnStartStop.Content =="Start")
            {
                btnStartStop.Content = "Stop";
                btnExit.IsEnabled = false;
                btnReset.IsEnabled = false;
               _stopWatch.Start();
                _timer.Start();
            }
            else
            {
                btnStartStop.Content = "Start";
                btnReset.IsEnabled = true;
                btnExit.IsEnabled = true;
                _stopWatch.Stop();
                _timer.Stop();
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            lblRunning.Content = "00:00:00";
            lblTotal.Content = "00:00:00";
        }
    }
}
