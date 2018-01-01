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
            _x = x;
            _y = y;
            _bredd = bredd;
            _höjd = höjd;
        }

        public int BeräknaXPosition(int x)
        {
            return x;
        }

        public int BeräknaYPosition(int y)
        {
            return y;
        }
    }
}
