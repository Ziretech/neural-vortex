using NUnit.Framework;

namespace Adapter.OpenTK.Spec.Grafik
{
    public class FyrkantVerifierare
    {
        private int _hörn1x;
        private int _hörn1y;
        private int _hörn2x;
        private int _hörn2y;

        public int AntalHörn { get; set; }

        public void VerifieraHörn(int x, int y)
        {
            if(AntalHörn == 0)
            {
                _hörn1x = x;
                _hörn1y = y;
            } else if(AntalHörn == 1)
            {
                Assert.That(_hörn1y, Is.EqualTo(y));
                _hörn2x = x;
            } else if(AntalHörn == 2)
            {
                Assert.That(_hörn2x, Is.EqualTo(x));
                _hörn2y = y;
            } else if(AntalHörn == 3)
            {
                Assert.That(_hörn1x, Is.EqualTo(x));
                Assert.That(_hörn2y, Is.EqualTo(y));                    
            }
            else
            {
                Assert.Fail("Fler än fyra hörn kan inte definieras för en fyrkant.");
            }

            AntalHörn++;
        }

        public bool StämmerHörn1(int x, int y)
        {
            return _hörn1x == x && _hörn1y == y;
        }

        public bool StämmerHörn2(int x, int y)
        {
            return _hörn2x == x && _hörn2y == y;
        }
    }
}