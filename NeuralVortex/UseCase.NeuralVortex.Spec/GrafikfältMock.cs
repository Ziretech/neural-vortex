using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{
    public class GrafikfältMock : IGrafikfält
    {
        public Yta HarVisatYta { get; private set; }

        public void Visa(Yta ytaAttVisa)
        {
            HarVisatYta = ytaAttVisa;
        }
    }
}
