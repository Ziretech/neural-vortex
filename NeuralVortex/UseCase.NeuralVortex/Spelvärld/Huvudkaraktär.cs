using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex
{
    public class Huvudkaraktär
    {
        private int _hälsa;

        public Huvudkaraktär(int hälsa = 1)
        {
            _hälsa = hälsa;
        }

        public IGrafik Grafik { get; set; }

        public Spelvärldsposition Position { get; set; }

        public bool ÄrKritisktSkadad => _hälsa < 1;

        public void Skada()
        {
            _hälsa -= 1;
        }
    }
}
