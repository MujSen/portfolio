using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letiste
{
    class ClassLetadlo
    {
        public string oznaceni { get; protected set; }
        public string pocetSedadel { get; protected set; }
        public string minPocetPosadky { get; protected set; }
        public ClassLetadlo(string oz, string po, string mi)
        {
            oznaceni = oz;
            pocetSedadel = po;
            minPocetPosadky = mi;
        }
    }
}
