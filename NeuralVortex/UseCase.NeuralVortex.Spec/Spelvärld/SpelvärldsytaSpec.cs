using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec.Spelvärld
{
    [TestFixture]
    public class SpelvärldsytaSpec
    {
        [TestCase(1, 2)]
        [TestCase(5, 7)]
        public void Skapas_med_en_bredd_och_höjd(int bredd, int höjd)
        {
            var yta = new Spelvärldsyta(bredd, höjd);
            Assert.That(yta.Bredd, Is.EqualTo(bredd));
            Assert.That(yta.Höjd, Is.EqualTo(höjd));
        }
    }
}
