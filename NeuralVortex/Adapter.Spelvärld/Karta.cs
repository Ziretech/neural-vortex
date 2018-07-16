using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Spelvärld
{
    class Karta
    {
        public int Bredd { get; }
        public int Höjd { get; }
        public int[] Indexar { get; }

        public Karta(int bredd, int höjd, int[] indexar)
        {
            Bredd = bredd;
            Höjd = höjd;
            Indexar = indexar;
        }

        public Hinderkarta SkapaHinderkarta(int[] hinderlista)
        {
            return new Hinderkarta(new[] { false, true, true, false }, 2);
        }
    }
}
