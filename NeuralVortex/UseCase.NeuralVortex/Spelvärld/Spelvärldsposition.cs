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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var position = (Spelvärldsposition)obj;
            return position._x.Equals(_x) && position._y.Equals(_y);
        }

        public override int GetHashCode()
        {
            return _x ^ _y;
        }

        public override string ToString()
        {
            return $"{_x}x{_y}";
        }
    }
}
