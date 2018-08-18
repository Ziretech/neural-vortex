using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Visning
{
    public interface IGradvisGrafik
    {
        void Visa(Skärmposition position, Andel andel);
        void VisaCenterBotten(Andel andel);
    }
}
