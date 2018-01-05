using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Visning
{
    public class Skärmposition
    {
        private int _x;
        private int _y;

        public Skärmposition(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X => _x;
        public int Y => _y;

        public Skärmposition Plus(Skärmposition andraPositionen)
        {
            return new Skärmposition(_x + andraPositionen.X, _y + andraPositionen.Y);
        }

        public Skärmposition Plus(Skärmyta yta)
        {
            return new Skärmposition(_x + yta.Bredd, _y + yta.Höjd);
        }

        public Skärmposition Minus(Skärmposition skärmposition)
        {
            return new Skärmposition(_x - skärmposition.X, _y - skärmposition.Y);
        }
    }
}
