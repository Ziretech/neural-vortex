namespace Adapter.OpenTK.Grafik
{
    public class Vektor
    {
        private readonly int _x;
        private readonly int _y;

        public Vektor(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X => _x;
        public int Y => _y;
    }
}
