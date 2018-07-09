using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.AI;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec.AI
{
    [TestFixture]
    public class SekvensFörflyttningSpec
    {
        [Test]
        public void HarNästaRiktningÄrHöger()
        {
            var förflyttning = new SekvensFörflyttning();
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(1, 0)));
        }
        [Test]
        public void HarNästaRiktningÅtVänster()
        {
            var förflyttning = new SekvensFörflyttning();
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(-1, 0)));
        }
    }
}
