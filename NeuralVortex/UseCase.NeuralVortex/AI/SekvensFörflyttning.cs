using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.AI
{
    public class SekvensFörflyttning : IRiktningsgenerator
    {
        private int _nästa = 0;
        private List<Spelvärldsposition> _förflyttningar;

        public SekvensFörflyttning(List<Spelvärldsposition> förflyttningar)
        {
            _förflyttningar = förflyttningar;
        }

        public Spelvärldsposition NästaRiktning
        {
            get
            {
                if (_nästa >= _förflyttningar.Count)
                    _nästa = 0;

                return _förflyttningar[_nästa++];
            }
        }
    }
}
