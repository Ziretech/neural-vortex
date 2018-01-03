using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Visning
{
    public class Yta
    {
        private readonly int _topp;
        private readonly int _botten;
        private readonly int _vänster;
        private readonly int _höger;

        public Yta(int topp, int botten, int vänster, int höger)
        {
            _topp = topp;
            _botten = botten;
            _vänster = vänster;
            _höger = höger;
        }

        public int Topp => _topp;
        public int Botten => _botten;
        public int Vänster => _vänster;
        public int Höger => _höger;
    }
}
