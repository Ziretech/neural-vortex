using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Spelvärld
{
    public class Spelvärldsposition
    {
        private readonly int _x;
        private readonly int _y;

        public int X => _x;
        public int Y => _y;

        public Spelvärldsposition(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
