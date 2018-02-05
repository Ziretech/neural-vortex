using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Spelvärld
{
    public class Spelvärldsposition : Position
    {
        public Spelvärldsposition(int x, int y) : base(x, y) { }
        public Spelvärldsposition(Position position) : base(position) { }

        public Spelvärldsposition Plus(Spelvärldsposition position)
        {
            return new Spelvärldsposition(((Position)this).Plus(position));
        }

        public Spelvärldsposition Plus(Spelvärldsyta yta)
        {
            return new Spelvärldsposition(((Position)this).Plus(yta));
        }

        public Spelvärldsposition Minus(Spelvärldsposition position)
        {
            return new Spelvärldsposition(((Position)this).Minus(position));
        }
    }
}
