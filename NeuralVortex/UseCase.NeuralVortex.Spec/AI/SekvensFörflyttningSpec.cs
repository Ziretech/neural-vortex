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
        [TestCase(1, 0)]
        [TestCase(-1, 0)]
        [TestCase(0, 1)]
        [TestCase(0, -1)]
        public void HarNästaRiktning(int x, int y)
        {
            var förflyttning = new SekvensFörflyttning(new List<Spelvärldsposition> { new Spelvärldsposition(x, y) });
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(x, y)));
        }

        [TestCase(1, 0, -1, 0)]
        [TestCase(0, -1, 1, 0)]
        public void HarTvåRiktningar(int x1, int y1, int x2, int y2)
        {
            var förflyttning = new SekvensFörflyttning(new List<Spelvärldsposition> { new Spelvärldsposition(x1, y1), new Spelvärldsposition(x2, y2) });
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(x1, y1)), "Första förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(x2, y2)), "Andra förflyttningen");
        }

        [Test]
        public void RepeterarTredjeRiktningenEfterTvåRiktningar()
        {
            var förflyttning = new SekvensFörflyttning(new List<Spelvärldsposition> { new Spelvärldsposition(1, 0), new Spelvärldsposition(0, -1) });
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(1, 0)), "Första förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(0, -1)), "Andra förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(1, 0)), "Repetera första förflyttningen");
        }
    }
}
