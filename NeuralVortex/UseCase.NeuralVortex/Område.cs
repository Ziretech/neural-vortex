namespace UseCase.NeuralVortex
{
    public class Område
    {
        protected readonly int _topp;
        protected readonly int _botten;
        protected readonly int _vänster;
        protected readonly int _höger;

        public Område(int vänster, int botten, int höger, int topp)
        {
            _topp = topp;
            _botten = botten;
            _vänster = vänster;
            _höger = höger;
        }

        public int Topp => _topp;
        public int Botten => _botten;
        public int Vänster => _vänster;
        public int Höger => _höger;
    }
}
