using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Spelvärld
{
    public class Karta
    {
        public int Bredd { get; }
        public int Höjd { get; }
        public int[] Indexar { get; }

        private const int MIN_BREDD = 1;
        private const int MIN_HÖJD = 1;

        public Karta(int bredd, int höjd, int[] indexar)
        {
            if(bredd < MIN_BREDD)
            {
                throw new ArgumentException($"Bredd är {bredd}, men får inte vara mindre än {MIN_BREDD}.");
            }
            if(höjd < MIN_HÖJD)
            {
                throw new ArgumentException($"Höjd är {höjd}, men får inte vara mindre än {MIN_HÖJD}.");
            }
            if(indexar == null)
            {
                throw new ArgumentException("Index kan inte vara null");
            }
            if(indexar.Length != bredd * höjd)
            {
                throw new ArgumentException($"antal index ({indexar.Length}) inte lika med bredd * höjd ({bredd * höjd})");
            }
            Bredd = bredd;
            Höjd = höjd;
            Indexar = indexar;
        }

        public Hinderkarta SkapaHinderkarta(int[] hinderlista)
        {
            if (hinderlista.Length < 1)
            {
                return new Hinderkarta(new[] { false }, Bredd);
            }
            
            return new Hinderkarta(Indexar.Select(x => hinderlista.Any(y => x == y)).ToArray(), Bredd);
        }
    }
}
