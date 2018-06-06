using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Spelvärld;

namespace Adapter.Spelvärld.Spec
{
    [TestFixture]
    class SpelvärldsskapareSpec
    {
        [Test]
        public void Skapar_tom_karta()
        {
            var karta = new Spelvärldsskapare(new Spelvärldsyta(1, 1)).ByggKarta();
            Assert.That(karta, Is.EquivalentTo(new int[] { 0 }));
        }
        [Test]
        public void Skapar_tom_2x2_karta()
        {
            var karta = new Spelvärldsskapare(new Spelvärldsyta(2, 2)).ByggKarta();
            Assert.That(karta, Is.EqualTo(new int[] { 0, 0, 0, 0 }));
        }
        [Test]
        public void Skapar_tom_assymetrisk_karta()
        {
            var karta = new Spelvärldsskapare(new Spelvärldsyta(2, 1)).ByggKarta();
            Assert.That(karta, Is.EqualTo(new int[] { 0, 0 }));
        }
        [Test]
        public void Skapar_ett_rum()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(2, 2));
            skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(0, 0), new Spelvärldsyta(1, 1)));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 1, 0, 0, 0 }));
        }
        [Test]
        public void Skapar_ett_rum_på_1_0()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(2, 2));
            skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(1, 0), new Spelvärldsyta(1, 1)));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 0, 1, 0, 0 }));
        }
        [Test]
        public void Skapar_ett_rum_på_0_1()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(2, 2));
            skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(0, 1), new Spelvärldsyta(1, 1)));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 0, 0, 1, 0 }));
        }
        [Test]
        public void Skapar_ett_rum_på_1_1()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(3, 2));
            skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(1, 1)));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 0, 0, 0, 0, 1, 0 }));
        }
        [Test]
        public void Skapar_ett_2x1_rum()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(2, 2));
            skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(0, 0), new Spelvärldsyta(2, 1)));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 1, 1, 0, 0 }));
        }
        [Test]
        public void Skapar_ett_1x2_rum()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(2, 2));
            skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(0, 0), new Spelvärldsyta(1, 2)));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 1, 0, 1, 0 }));
        }
        [Test]
        public void Skapar_ett_2x1_rum_på_1_1()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(3, 3));
            skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(2, 1)));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 0, 0, 0, 0, 1, 1, 0, 0, 0 }));
        }
        [Test]
        public void Skapar_två_rum()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(2, 2));
            skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(0, 0), new Spelvärldsyta(1, 1)));
            skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(1, 1)));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 1, 0, 0, 1 }));
        }
        [Test]
        public void Skapar_en_dörr()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(2, 2));
            skapare.SkapaDörr(new Spelvärldsposition(0, 0));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 1, 0, 0, 0 }));
        }
        [Test]
        public void Skapar_en_dörr_på_1_0()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(2, 2));
            skapare.SkapaDörr(new Spelvärldsposition(1, 0));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 0, 1, 0, 0 }));
        }
        [Test]
        public void Skapar_en_dörr_på_1_1()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(2, 2));
            skapare.SkapaDörr(new Spelvärldsposition(1, 1));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 0, 0, 0, 1 }));
        }
        [Test]
        public void Skapar_en_dörr_på_1_1_i_3x2_värld()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(3, 2));
            skapare.SkapaDörr(new Spelvärldsposition(1, 1));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 0, 0, 0, 0, 1, 0 }));
        }
        [Test]
        public void Skapar_två_dörrar()
        {
            var skapare = new Spelvärldsskapare(new Spelvärldsyta(2, 2));
            skapare.SkapaDörr(new Spelvärldsposition(0, 0));
            skapare.SkapaDörr(new Spelvärldsposition(1, 1));
            Assert.That(skapare.ByggKarta(), Is.EqualTo(new int[] { 1, 0, 0, 1 }));
        }

        // TODO Spelvärldsskapare
        // felhantering
        // placera rum (delvis) utanför kartan
        // rum med dimensioner < 1
        // karta med dimensioner < 1
        // skapa dörr utanför kartan
    }
}
