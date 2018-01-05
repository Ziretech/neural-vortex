using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{
    public class GrafikfältMock : IGrafikfält
    {
        public bool HarVisats { get; private set; }

        public void Visa()
        {
            HarVisats = true;
        }
    }
}
