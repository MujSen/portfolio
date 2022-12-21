using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letiste
{
    class ClassPasazer
    {
        public int id { get; protected set; }
        public ClassPasazer(int i)
        {
            id = i;
        }
    }
}
