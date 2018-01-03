using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Kontroll;

namespace Adapter.OpenTK.Kontroll
{
    public interface ITangentmottagare
    {
        void TangentTrycksNed(Tangent tangent);
    }
}
