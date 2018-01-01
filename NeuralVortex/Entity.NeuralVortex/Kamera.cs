using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.NeuralVortex
{
    public class Kamera
    {
        private int _x;
        private int _y;
        private int _bredd;
        private int _höjd;

        public Kamera(int x, int y, int bredd, int höjd)
        {
            if(bredd < 1)
            {
                throw new ArgumentException("Kamerans bredd får inte vara mindre än 1.");
            }
            if (höjd < 1)
            {
                throw new ArgumentException("Kamerans höjd får inte vara mindre än 1.");
            }

            _x = x;
            _y = y;
            _bredd = bredd;
            _höjd = höjd;
        }

        public int BeräknaXPosition(int x)
        {
            return x + _x;
        }

        public int BeräknaYPosition(int y)
        {
            return y + _y;
        }

        public int Topp => _y + _höjd;
        public int Botten => _y;
        public int Vänster => _x;
        public int Höger => _x + _bredd;
    }
}
