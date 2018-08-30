using System;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex
{
    public class Område
    {
        private readonly Position _position;
        private readonly Yta _yta;

        public Område(Position position, Yta yta)
        {

            _position = position;
            _yta = yta;
        }

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
            _position = new Position(vänster, botten);
            _yta = new Yta(höger - vänster, topp - botten);
        }

        public int Topp => _position.Y + _yta.Höjd;
        public int Botten => _position.Y;
        public int Vänster => _position.X;
        public int Höger => _position.X + _yta.Bredd;

        public Position Position => _position;
        public Yta Yta => _yta;

        public override string ToString()
        {
            return $"({Vänster},{Botten})-({Höger},{Topp})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var område = (Område)obj;
            return
                område._position.Equals(_position) &&
                område._yta.Equals(_yta);
        }

        public override int GetHashCode()
        {
            return _position.GetHashCode() ^ _yta.GetHashCode();
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
