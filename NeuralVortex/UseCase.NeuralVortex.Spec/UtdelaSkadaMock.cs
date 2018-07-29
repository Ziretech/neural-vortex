namespace UseCase.NeuralVortex.Spec
{
    internal class UtdelaSkadaMock : IUtdelaSkada
    {
        internal bool UtdelaHarAnropats { get; private set; }

        public void Utdela()
        {
            UtdelaHarAnropats = true;
        }
    }
}