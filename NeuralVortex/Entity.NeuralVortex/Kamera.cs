using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.NeuralVortex
{
    public class Kamera
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _bredd;
        private readonly int _höjd;
        private readonly int _brickbredd;
        private readonly int _brickhöjd;

        public Kamera(int x, int y, int bredd, int höjd, int brickbredd, int brickhöjd)
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
            _brickbredd = brickbredd;
            _brickhöjd = brickhöjd;
        }

        public int BeräknaXPosition(int x)
        {
            return (x + _x) * _brickbredd;
        }

        public int BeräknaYPosition(int y)
        {
            return (y + _y) * _brickhöjd;
        }

        public int Topp => (_y + _höjd) * _brickhöjd;
        public int Botten => _y * _brickhöjd;
        public int Vänster => _x * _brickbredd;
        public int Höger => (_x + _bredd) * _brickbredd;
    }
}
