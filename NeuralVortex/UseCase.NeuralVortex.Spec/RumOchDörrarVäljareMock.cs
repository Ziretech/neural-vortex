using UseCase.NeuralVortex.Kartgenerering;

namespace UseCase.NeuralVortex.Spec
{
    public class RumOchDörrarVäljareMock : IRumOchDörrarVäljare
    {
        public int AntalSteg { get; set; }

        public bool ÄrKartanFärdig()
        {
            return AntalSteg == 0;
        }
    }
}
