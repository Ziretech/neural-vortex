using UseCase.NeuralVortex.Kontroll;

namespace UseCase.NeuralVortex.Spec
{
    internal class FlyttaVarelserMock : IFlyttaVarelser
    {
        public Tangent FlyttadesAvTangent { get; private set; }

        public void Flytta(Tangent tangent)
        {
            FlyttadesAvTangent = tangent;
        }

        // REFACTOR Använd NSubstitute istället
    }
}