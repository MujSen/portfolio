using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letiste
{
    class ClassZavazadlo
    {
        public double hmotnost { get; protected set; }
        public ClassZavazadlo( double hm)
        {
            hmotnost = hm;
        }
    }
}
