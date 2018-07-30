using System.Collections.Generic;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{
    public class SpelvärldMock : ISpelvärld
    {
        public Huvudkaraktär Huvudkaraktär { get; set; }
        public IGrafik MiljöGrafik { get; set; }
        public IEnumerable<Fiende> Fienden { get; set; }
        public List<Fiende> BorttagenFiende { get; private set; }

        public SpelvärldMock()
        {
            Fienden = new List<Fiende>();
            BorttagenFiende = new List<Fiende>();
        }

        public void DödaFiende(Fiende fiende)
        {
            BorttagenFiende.Add(fiende);
        }
    }
}
