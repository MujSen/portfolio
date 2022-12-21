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
using System.IO;
using System.Windows.Threading;

namespace Letiste
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopUp pop = new PopUp();
            
            DispatcherTimer timer = null;
            void StartTimer()
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += new EventHandler(timer_Elapsed);
                timer.Start();
            }

            void timer_Elapsed(object sender, EventArgs e)
            {
                timer.Stop();

                pop.Show();
            }
            StartTimer();
        }

        private void spust_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            OvladaciOkno ov = new OvladaciOkno();
            ov.Show();
        }
    }
}
