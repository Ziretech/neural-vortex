using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Visning
{
    public class Skärmyta
    {
        private readonly int _bredd;
        private readonly int _höjd;

        public Skärmyta(int bredd, int höjd)
        {
            _bredd = bredd;
            _höjd = höjd;
        }

        public int Bredd => _bredd;

        public int Höjd => _höjd;
    }
}
