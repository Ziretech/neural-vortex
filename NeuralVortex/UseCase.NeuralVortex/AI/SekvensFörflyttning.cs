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
        private List<Spelvärldsposition> _förflyttningar;
        private Indexgenerator _indexgenerator;

        public SekvensFörflyttning(List<Spelvärldsposition> förflyttningar, Indexgenerator indexgenerator)
        {
            _förflyttningar = förflyttningar;
            _indexgenerator = indexgenerator;
        }

        public Spelvärldsposition NästaRiktning => _förflyttningar[_indexgenerator.NästaIndex(_förflyttningar.Count)];

        public interface Indexgenerator
        {
            int NästaIndex(int antalIndex);
        }

        public class IterativIndexgenerator : Indexgenerator
        {
            private int _nästa = 0;

            public int NästaIndex(int antalIndex)
            {
                if (_nästa >= antalIndex)
                    _nästa = 0;
                return _nästa++;
            }
        }

        public class SlumpmässigIndexgenerator : Indexgenerator
        {
            private Random _slump;

            public SlumpmässigIndexgenerator(Random generator)
            {
                _slump = generator;
            }

            public int NästaIndex(int antalIndex)
            {
                return _slump.Next() % antalIndex;
            }
        }
    }
}
