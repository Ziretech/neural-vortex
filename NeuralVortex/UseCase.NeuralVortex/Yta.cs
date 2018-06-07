namespace UseCase.NeuralVortex
{
    public class Yta
    {
        private readonly int _bredd;
        private readonly int _höjd;

        public Yta(int bredd, int höjd)
        {
            _bredd = bredd;
            _höjd = höjd;
        }

        public int Bredd => _bredd;
        public int Höjd => _höjd;

        public override string ToString()
        {
            return $"{_bredd}x{_höjd}";
        }
    }
}