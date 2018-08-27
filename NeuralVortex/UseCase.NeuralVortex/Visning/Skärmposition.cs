using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Visning
{
    public class Skärmposition : Position
    {
        public Skärmposition(int x, int y) : base(x, y) { }
        public Skärmposition(Position position) : base(position) { }

        public Skärmposition Plus(Skärmposition andraPositionen)
        {
            return new Skärmposition(((Position)this).Plus(andraPositionen));
        }

        public Skärmposition Plus(Skärmyta yta)
        {
            return new Skärmposition(((Position)this).Plus(yta));
        }

        public Skärmposition Minus(Skärmposition skärmposition)
        {
            return new Skärmposition(((Position)this).Minus(skärmposition));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var position = (Skärmposition)obj;
            return position.X.Equals(X) && position.Y.Equals(Y);
        }
        
        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
