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

        public Andel(int del, int max) : this((double)del / max) { }

        public int Av(int max)
        {
            return (int)(max * _andel);
        }

        public override string ToString()
        {
            return $"{Math.Truncate(_andel * 100)}%";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var andel = (Andel)obj;
            return (int)(andel._andel * 100.0) == (int)(_andel * 100.0);
        }

        public override int GetHashCode()
        {
            return _andel.GetHashCode();
        }
    }
}
