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
        public void Har_nästa_riktning(int x, int y)
        {
            var förflyttning = new SekvensFörflyttning(new List<Spelvärldsposition> { new Spelvärldsposition(x, y) }, new SekvensFörflyttning.IterativIndexgenerator());
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(x, y)));
        }

        [TestCase(1, 0, -1, 0)]
        [TestCase(0, -1, 1, 0)]
        public void Har_två_riktningar(int x1, int y1, int x2, int y2)
        {
            var förflyttning = new SekvensFörflyttning(new List<Spelvärldsposition> { new Spelvärldsposition(x1, y1), new Spelvärldsposition(x2, y2) }, new SekvensFörflyttning.IterativIndexgenerator());
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(x1, y1)), "Första förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(x2, y2)), "Andra förflyttningen");
        }

        [Test]
        public void Repeterar_tredje_riktningen_efter_två_riktningar()
        {
            var förflyttning = new SekvensFörflyttning(new List<Spelvärldsposition> { new Spelvärldsposition(1, 0), new Spelvärldsposition(0, -1) }, new SekvensFörflyttning.IterativIndexgenerator());
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(1, 0)), "Första förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(0, -1)), "Andra förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(1, 0)), "Repetera första förflyttningen");
        }

        [Test]
        public void Väljer_riktning_slumpmässigt()
        {
            var slumpgenerator = new Random(11);
            var förflyttning = new SekvensFörflyttning(new List<Spelvärldsposition> { new Spelvärldsposition(1, 0), new Spelvärldsposition(0, -1) }, new SekvensFörflyttning.SlumpmässigIndexgenerator(slumpgenerator));
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(0, -1)), "Första förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(0, -1)), "Andra förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(0, -1)), "Tredje förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(1, 0)), "Fjärde förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(0, -1)), "Femte förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(1, 0)), "Sjätte förflyttningen");
        }

        [Test]
        public void Väljer_olika_när_samma_generator_används_av_olika_förflyttningar()
        {
            var slumpgenerator = new Random(11);
            var förflyttning = new SekvensFörflyttning(new List<Spelvärldsposition> { new Spelvärldsposition(1, 0), new Spelvärldsposition(0, -1) }, new SekvensFörflyttning.SlumpmässigIndexgenerator(slumpgenerator));
            var annanFörflyttning = new SekvensFörflyttning(new List<Spelvärldsposition> { new Spelvärldsposition(1, 0), new Spelvärldsposition(0, -1) }, new SekvensFörflyttning.SlumpmässigIndexgenerator(slumpgenerator));
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(0, -1)), "Första förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(0, -1)), "Andra förflyttningen");
            Assert.That(förflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(0, -1)), "Tredje förflyttningen");
            Assert.That(annanFörflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(1, 0)), "Fjärde förflyttningen");
            Assert.That(annanFörflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(0, -1)), "Femte förflyttningen");
            Assert.That(annanFörflyttning.NästaRiktning, Is.EqualTo(new Spelvärldsposition(1, 0)), "Sjätte förflyttningen");
        }
    }
}
