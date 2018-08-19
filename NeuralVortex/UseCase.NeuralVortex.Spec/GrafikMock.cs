using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{
    public class GrafikMock : IGrafik, IGradvisGrafik
    {
        public Skärmposition HarVisatsPåPosition { get; private set; }
        public Andel HarVisatsMedAndel { get; private set; }
        public bool HarVisatsPåCenterBotten { get; private set; }
        public Andel HarVisatsPåCenterBottenMedAndel { get; private set; }

        public GrafikMock(Skärmyta dimensioner = null)
        {
            Dimensioner = dimensioner;
        }

        public Skärmyta Dimensioner { get; private set; }

        public void Visa(Skärmposition position)
        {
            HarVisatsPåPosition = position;
            HarVisatsMedAndel = new Andel(1.0);
        }

        public void Visa(Skärmposition position, Andel andel)
        {
            HarVisatsPåPosition = position;
            HarVisatsMedAndel = andel;
        }

        public void VisaCenterBotten()
        {
            HarVisatsPåCenterBotten = true;
        }

        public void VisaCenterBotten(Andel andel)
        {
            HarVisatsPåCenterBottenMedAndel = andel;
        }

        // REFACTOR Använd NSubstitute istället
    }
}
