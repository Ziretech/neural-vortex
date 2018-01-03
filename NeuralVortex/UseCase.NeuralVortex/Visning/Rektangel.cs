using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex
{
    public class Rektangel
    {
        private readonly int _bredd;
        private readonly int _höjd;

        public int Bredd => _bredd;
        public int Höjd => _höjd;

        public Rektangel(int bredd, int höjd)
        {
            _bredd = bredd;
            _höjd = höjd;
        }
    }
}
