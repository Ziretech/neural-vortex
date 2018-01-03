using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{
    public class GrafikMock : IGrafik
    {
        public Skärmposition HarVisatsPåPosition { get; private set; }

        public void Visa(Skärmposition position)
        {
            HarVisatsPåPosition = position;
        }
    }
}
