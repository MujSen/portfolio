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

namespace Letiste
{
    /// <summary>
    /// Interakční logika pro PridatLet.xaml
    /// </summary>
    public partial class PridatLet : Page
    {
        public PridatLet()
        {
            InitializeComponent();
        }

        private void Pridat_Click(object sender, RoutedEventArgs e)
        {
            Output.Text= "";



            string output = "";
            string oz ="";
            string odk="";
            string kam="";
            double vzd=0;
            if(Oznaceni.Text != " ")
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
            if ( Odlet_datum.SelectedDate == null)
            {
                output += "Datum pro odlet není vybrán! ";
            }
            if (Prilet_datum.SelectedDate == null)
            {
                output += "Datum pro přílet není vybrán! ";
            }
            if(Prilet_cas.Text != " " && Odlet_cas.Text != " ")
            {
                
            }
            else
            {
                output += "Nebyl zadán čas odletu nebo příletu! ";
            }
            if(output == "")
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
                
                ClassLet letim = (new ClassLet(oz, odk, kam, vzd, datum_odletu, datum_priletu));
                

                if (File.Exists("data.txt"))
                {
                    StreamWriter sw = new StreamWriter("data.txt", true);
                    sw.WriteLine(letim.Zapsat());
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new StreamWriter("data.txt");
                    sw.WriteLine(letim.Zapsat());
                    sw.Close();
                }
                Output.Text = "Let úspěšně zaregistrován!";
            }
            else
            {
                Output.Text = output;
            }

        }
    }
}
