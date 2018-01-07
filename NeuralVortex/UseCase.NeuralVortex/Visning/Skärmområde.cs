namespace UseCase.NeuralVortex.Visning
{
    public class Skärmområde
    {
        private readonly int _topp;
        private readonly int _botten;
        private readonly int _vänster;
        private readonly int _höger;

        public Skärmområde(int vänster, int botten, int höger, int topp)
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
