using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;

namespace Letiste
{
    class Metody
    {
        public ObservableCollection<ClassLet> nactiZeSouboru() //Najde a vypíše data 👓
        {
            ObservableCollection<ClassLet> cl = new ObservableCollection<ClassLet>();
            if (File.Exists("data.txt"))
            {
                StreamReader sr = new StreamReader("data.txt");
                
                while (!sr.EndOfStream)
                {
                    string input = sr.ReadLine();
                    string[] vstup = input.Split(';');
                    cl.Add(new ClassLet(vstup[0], vstup[1], vstup[2], Convert.ToDouble(vstup[3]), Convert.ToDateTime(vstup[4]), Convert.ToDateTime(vstup[5])));
                }
                sr.Close();

            }
            else
            {
                cl.Add(new ClassLet("Nic nebylo nalezeno 🤔",null,null,666,DateTime.Now, DateTime.Now));
            }
            return cl;
        }
    }
}
