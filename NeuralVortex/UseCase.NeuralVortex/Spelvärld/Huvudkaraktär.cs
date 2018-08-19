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
        public Huvudkaraktär(int hälsa = 1)
        {
            MaxHälsa = Hälsa = hälsa;
        }

        public IGrafik Grafik { get; set; }

        public Spelvärldsposition Position { get; set; }

        public bool ÄrKritisktSkadad => Hälsa < 1;

        public int Hälsa { get; private set; }
        public int MaxHälsa { get; private set; }

        public void Skada()
        {
            Hälsa -= 1;
        }
    }
}
