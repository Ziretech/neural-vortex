using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;

namespace Adapter.OpenTK.Spec.Grafik
{
    public class VisaMock : IVisa
    {
        internal bool VisaHarAnropats { get; private set; }

        public void Visa()
        {
            VisaHarAnropats = true;
        }

        // REFACTOR Använd NSubstitute istället
    }
}
