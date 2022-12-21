using System;
using System.Collections.Generic;
using System.IO;
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

namespace Letiste
{
    /// <summary>
    /// Interakční logika pro Pridat_Pasazera.xaml
    /// </summary>
    public partial class Pridat_Pasazera : Page
    {
        public Pridat_Pasazera()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("data2.txt");
            while (!sr.EndOfStream)
            {
                listicek.Items.Add(sr.ReadLine());
            }
            sr.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            if (cp.IsChecked == true)
            {
                i = 1;
            }
            ClassOsoba co = new ClassOsoba(JM.Text,PR.Text,Convert.ToDouble(HM.Text),new ClassZavazadlo(Convert.ToDouble(zavazadlo.Text)),i);
            listicek.Items.Add(co.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("data2.txt");
            foreach(var a in listicek.Items)
            {
                sw.WriteLine(a.ToString());
            }
            sw.Close();
        }
    }
}
