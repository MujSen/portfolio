using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letiste
{
    /// <summary>
    /// Označení letu, odkud, kam, vzdálenost, odlet, přílet
    /// </summary>
    public class ClassLet
    {
        public string oznaceni { get; protected set; }
        public string odkud { get; protected set; }
        public string kam { get; protected set; }
        public double vzdalenost { get; protected set; }
        public DateTime odlet { get; protected set; }
        public DateTime prilet { get; protected set; }
        public ClassLet(string oz, string odk, string ka, double vz, DateTime od, DateTime pr)
        {
            oznaceni = oz;
            odkud = odk;
            kam = ka;
            vzdalenost = vz;
            odlet = od;
            prilet = pr;
        }
        public string Zapsat()
        {
            return oznaceni+";"+odkud + ";" + kam + ";" +vzdalenost.ToString() + ";" +odlet.ToString() + ";" +prilet.ToString() + ";";
        }
        public override string ToString()
        {
            return oznaceni+"   "+odkud + " do " +kam + "   " +vzdalenost + "km   " +odlet + "   " +prilet;
        }
        public void ZmenitUdaje(string oz, string odk, string ka, double vz, DateTime od, DateTime pr)
        {
            oznaceni = oz;
            odkud = odk;
            kam = ka;
            vzdalenost = vz;
            odlet = od;
            prilet = pr;
        }
    }
}
