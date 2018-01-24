using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class YtaSpec
    {
        [TestCase(1, 2)]
        [TestCase(5, 7)]
        public void Skapas_med_en_bredd_och_höjd(int bredd, int höjd)
        {
            var yta = new Yta(bredd, höjd);
            Assert.That(yta.Bredd, Is.EqualTo(bredd));
            Assert.That(yta.Höjd, Is.EqualTo(höjd));
        }
    }
}
