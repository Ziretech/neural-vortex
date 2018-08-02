using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex
{
    public class Andel
    {
        private double _andel;

        public Andel(double procent)
        {
            if(procent < 0.0)
            {
                throw new ArgumentException("Kan inte skapa andel mindre än 0%.");
            }
            if(procent > 1.0)
            {
                throw new ArgumentException("Kan inte skapa andel större än 100%.");
            }
            _andel = procent;
        }

        public int Av(int max)
        {
            return (int)(max * _andel);
        }
    }
}
