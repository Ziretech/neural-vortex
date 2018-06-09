using System;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex
{
    public class Område
    {
        protected readonly int _topp;
        protected readonly int _botten;
        protected readonly int _vänster;
        protected readonly int _höger;
        private Spelvärldsposition position;
        private Spelvärldsyta yta;

        public Område(Position position, Yta yta) : this(position.X, position.Y, position.X + yta.Bredd, position.Y + yta.Höjd) { }

        public Område(int vänster, int botten, int höger, int topp)
        {
            if(vänster > höger)
            {
                throw new ArgumentException($"Område kan inte ha värdet för vänster ({vänster}) högre än värdet för höger ({höger}).");
            }
            if (botten > topp)
            {
                throw new ArgumentException($"Område kan inte ha värdet för botten ({botten}) högre än värdet för topp ({topp}).");
            }
            _topp = topp;
            _botten = botten;
            _vänster = vänster;
            _höger = höger;
        }

        public int Topp => _topp;
        public int Botten => _botten;
        public int Vänster => _vänster;
        public int Höger => _höger;

        public override string ToString()
        {
            return $"({_vänster},{_botten})-({_höger},{_topp})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var område = (Område)obj;
            return
                område._vänster.Equals(_vänster) &&
                område._botten.Equals(_botten) &&
                område._höger.Equals(_höger) &&
                område._topp.Equals(_topp);
        }

        public override int GetHashCode()
        {
            return _vänster ^ _botten ^ _höger ^ _topp;
        }

        public bool Omsluter(Område område)
        {
            return !(område.Vänster < Vänster 
                || område.Botten < Botten 
                || område.Höger > Höger
                || område.Topp > Topp);
        }
    }
}
