using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Visning
{
    public class Skärmyta : Yta
    {
        public Skärmyta(int bredd, int höjd) : base(bredd, höjd) { }

        public Skärmyta(Yta yta) : base(yta) { }

        public Skärmyta MultipliceratMed(Yta yta)
        {
            return new Skärmyta(MultiplicerasMed(yta));
        }
    }
}
