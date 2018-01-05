using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec.Visning
{
    [TestFixture]
    public class SkärmytaSpec
    {
        [Test]
        public void Har_angiven_bredd()
        {
            var yta = new Skärmyta(2, 5);
            Assert.That(yta.Bredd, Is.EqualTo(2));
        }

        [Test]
        public void Har_angiven_höjd()
        {
            var yta = new Skärmyta(2, 5);
            Assert.That(yta.Höjd, Is.EqualTo(5));
        }
    }
}
