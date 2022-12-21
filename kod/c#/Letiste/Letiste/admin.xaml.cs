using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interakční logika pro admin.xaml
    /// </summary>
    public partial class admin : Page
    {
        ObservableCollection<ClassLet> cl = new ObservableCollection<ClassLet>();
        public admin()
        {
            InitializeComponent();
            Metody met = new Metody();
            cl = met.nactiZeSouboru();
            listik.ItemsSource = cl;
        }



        private void od_Click(object sender, RoutedEventArgs e) //Odstraní údaje 💪
        {
            cl.Remove((ClassLet)listik.SelectedItem); //Odstraní z kolekce na základě vyabrané položky z listboxu
        }

        private void Zmenit_Click(object sender, RoutedEventArgs e) //Změní údaje 🎞
        {

            Output.Text = "";
            string output = "";
            string oz = "";
            string odk = "";
            string kam = "";
            double vzd = 0;
            if (Oznaceni.Text != " ")
            {
                oz = Oznaceni.Text;
            }
            else
            {
                output += "Označení nesmí být prázdné! ";
            }

            if (Odkud.Text != " ")
            {
                odk = Odkud.Text;
            }
            else
            {
                output += "Odkud nesmí být prázdný! ";
            }

            if (Kam.Text != " ")
            {
                kam = Kam.Text;
            }
            else
            {
                output += "Kam nesmí být prázdný! ";
            }

            if (Vzdalenost.Text != " ")
            {
                try
                {
                    vzd = Convert.ToDouble(Vzdalenost.Text);
                }
                catch
                {
                    output += "Vzdálenost musí to být číslo! ";
                }
            }
            else
            {
                output += "Vzdálenost nesmí být prázdná! ";
            }
            if (Odlet_datum.SelectedDate == null)
            {
                output += "Datum pro odlet není vybrán! ";
            }
            if (Prilet_datum.SelectedDate == null)
            {
                output += "Datum pro přílet není vybrán! ";
            }
            if (Prilet_cas.Text != " " && Odlet_cas.Text != " ")
            {

            }
            else
            {
                output += "Nebyl zadán čas odletu nebo příletu! ";
            }
            if (output == "")
            {
                string[] str_odl = Odlet_cas.Text.Split('/');
                DateTime datum_odletu =
                    new DateTime(Odlet_datum.SelectedDate.Value.Year, Odlet_datum.SelectedDate.Value.Month, Odlet_datum.SelectedDate.Value.Day,
                    Convert.ToInt32(str_odl[0]), Convert.ToInt32(str_odl[1]), Convert.ToInt32(str_odl[2])
                    );

                string[] str_priletu = Prilet_cas.Text.Split('/');
                DateTime datum_priletu =
                    new DateTime(Prilet_datum.SelectedDate.Value.Year, Prilet_datum.SelectedDate.Value.Month, Prilet_datum.SelectedDate.Value.Day,
                    Convert.ToInt32(str_priletu[0]), Convert.ToInt32(str_priletu[1]), Convert.ToInt32(str_priletu[2])
                    );

                cl.Remove((ClassLet)listik.SelectedItem);

                foreach (var item in cl)
                {
                    if (item.ToString() == listik.SelectedItem.ToString())
                    {
                        item.ZmenitUdaje(oz, odk, kam, vzd, datum_odletu, datum_priletu);
                        cl.Add(item);
                    }
                }


                if (File.Exists("data.txt"))
                {

                    StreamWriter sw = new StreamWriter("data.txt"); //Zapíšu si
                    foreach (var item in cl)
                    {
                        sw.WriteLine(item);
                    }
                    sw.Close();
                }
                else
                {
                    Output.Text = "Naskytla se chybka 🤣";
                }
                
            }
            else
            {
                Output.Text = output;
            }
        }

        private void listik_SelectionChanged_1(object sender, SelectionChangedEventArgs e) //Načte údaje do textboxů
        {

            ClassLet clas = (ClassLet)listik.SelectedItem;
            if (clas != null) { 
            Oznaceni.Text = clas.oznaceni;
            Odkud.Text = clas.odkud;
            Kam.Text = clas.kam;
            Vzdalenost.Text = clas.vzdalenost.ToString();
            Odlet_datum.SelectedDate = clas.odlet;
            string cas_od = clas.odlet.Hour.ToString() + "/" + clas.odlet.Minute.ToString() + "/" + clas.odlet.Second.ToString();
            Odlet_cas.Text = cas_od;
            string cas_pr = clas.prilet.Hour.ToString() + "/" + clas.prilet.Minute.ToString() + "/" + clas.prilet.Second.ToString();
            Prilet_datum.SelectedDate = clas.prilet;
            Prilet_cas.Text = cas_pr;
            }
        }
    }
}
