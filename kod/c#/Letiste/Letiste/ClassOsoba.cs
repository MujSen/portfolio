using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letiste
{
    class ClassOsoba
    {
        public string jmeno { get; protected set; }
        public string prijmeni { get; protected set; }
        public double hmotnost { get; protected set; }

        public int urceni { get; protected set; } //0 - pasažér , 1 - posádka

        public ClassZavazadlo zavazadla { get; protected set; }
        public ClassOsoba(string jm, string pr, double hm, ClassZavazadlo zav, int ur)
        {
            urceni = ur;
            zavazadla = zav;
            jmeno = jm;
            prijmeni = pr;
            hmotnost = hm;
        }
        public override string ToString()
        {
            string[] al = { "Je pasažér", "Je člen posádky" };
            return "jmeno: "+jmeno + " prijmeni: " + prijmeni + " hmotnost: " + hmotnost.ToString() + " hmotnost zavazadla: " +zavazadla.hmotnost.ToString() + " " + al[urceni];
        }
    }
}
