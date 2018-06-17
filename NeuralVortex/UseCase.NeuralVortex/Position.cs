using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex
{
    public class Position
    {
        private readonly int _x;
        private readonly int _y;

        public int X => _x;
        public int Y => _y;

        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Position(Position position)
        {
            _x = position.X;
            _y = position.Y;
        }

        public Position Plus(Position andraPositionen)
        {
            return new Position(X + andraPositionen.X, Y + andraPositionen.Y);
        }

        public Position Plus(Yta yta)
        {
            return new Position(_x + yta.Bredd, _y + yta.Höjd);
        }

        public Position Minus(Position position)
        {
            return new Position(X - position.X, Y - position.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var position = (Position)obj;
            return position._x.Equals(_x) && position._y.Equals(_y);
        }

        public override int GetHashCode()
        {
            return _x ^ _y;
        }

        public override string ToString()
        {
            return $"{_x},{_y}";
        }
    }
}
