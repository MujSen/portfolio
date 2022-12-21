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
using System.Windows.Shapes;

namespace Letiste
{
    /// <summary>
    /// Interakční logika pro OvladaciOkno.xaml
    /// </summary>
    public partial class OvladaciOkno : Window
    {
        public List<ClassLet> lety = new List<ClassLet>() { new ClassLet("10","Seattle","Wyoming",15,new DateTime(2015, 10, 16, 20, 15, 20), new DateTime(2015, 10, 16,10,15,20)) };
        public OvladaciOkno()
        {
            InitializeComponent();
        }

        private void Ter_Click(object sender, RoutedEventArgs e)
        {
            terminal term = new terminal();
            ahojda.Content = term;
            
        }

        private void Adm_Click(object sender, RoutedEventArgs e)
        {
            admin term = new admin();
            ahojda.Content = term;
        }

        private void dom_Click(object sender, RoutedEventArgs e)
        {
            ahojda.Content = null;
        }

        private void pr(object sender, RoutedEventArgs e)
        {
            PridatLet term = new PridatLet();
            ahojda.Content = term;
        }

        private void pasa_Click(object sender, RoutedEventArgs e)
        {
            Pridat_Pasazera term = new Pridat_Pasazera();
            ahojda.Content = term;
        }
    }
}
