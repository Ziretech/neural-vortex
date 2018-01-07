using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Visning
{
    public interface IKamera
    {
        void CentreraKameraMot(Skärmposition position);
        Skärmområde Synlighetsområde { get; }
    }

}
