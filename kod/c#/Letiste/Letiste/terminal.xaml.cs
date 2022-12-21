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
using System.Collections.ObjectModel;

namespace Letiste
{
    /// <summary>
    /// Interakční logika pro terminal.xaml
    /// </summary>
    public partial class terminal : Page
    {
        public terminal()
        {
            InitializeComponent();
            Metody met = new Metody();
            ObservableCollection<ClassLet> cl = met.nactiZeSouboru();
            listik.ItemsSource = cl;
        }
    }
}
