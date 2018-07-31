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
    class KartritareSpec
    {
        private const int DÖRR_INDEX = 2;
        private const int RUM_INDEX = 1;

        [Test]
        public void Skapar_tom_karta()
        {
            var karta = new Kartritare(new Spelvärldsyta(1, 1)).Karta;
            Assert.That(karta.Indexar, Is.EquivalentTo(new int[] { 0 }));
        }
        [Test]
        public void Skapar_tom_2x2_karta()
        {
            var karta = new Kartritare(new Spelvärldsyta(2, 2)).Karta;
            Assert.That(karta.Indexar, Is.EqualTo(new int[] { 0, 0, 0, 0 }));
        }
        [Test]
        public void Skapar_tom_assymetrisk_karta()
        {
            var karta = new Kartritare(new Spelvärldsyta(2, 1)).Karta;
            Assert.That(karta.Indexar, Is.EqualTo(new int[] { 0, 0 }));
        }
        [Test]
        public void Skapar_ett_rum()
        {
            var ritare = new Kartritare(new Spelvärldsyta(2, 2));
            ritare.SkapaYta(new Spelvärldsområde(new Spelvärldsposition(0, 0), new Spelvärldsyta(1, 1)));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { RUM_INDEX, 0, 0, 0 }));
        }
        [Test]
        public void Skapar_ett_rum_på_1_0()
        {
            var ritare = new Kartritare(new Spelvärldsyta(2, 2));
            ritare.SkapaYta(new Spelvärldsområde(new Spelvärldsposition(1, 0), new Spelvärldsyta(1, 1)));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { 0, RUM_INDEX, 0, 0 }));
        }
        [Test]
        public void Skapar_ett_rum_på_0_1()
        {
            var ritare = new Kartritare(new Spelvärldsyta(2, 2));
            ritare.SkapaYta(new Spelvärldsområde(new Spelvärldsposition(0, 1), new Spelvärldsyta(1, 1)));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { 0, 0, RUM_INDEX, 0 }));
        }
        [Test]
        public void Skapar_ett_rum_på_1_1()
        {
            var ritare = new Kartritare(new Spelvärldsyta(3, 2));
            ritare.SkapaYta(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(1, 1)));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { 0, 0, 0, 0, RUM_INDEX, 0 }));
        }
        [Test]
        public void Skapar_ett_2x1_rum()
        {
            var ritare = new Kartritare(new Spelvärldsyta(2, 2));
            ritare.SkapaYta(new Spelvärldsområde(new Spelvärldsposition(0, 0), new Spelvärldsyta(2, 1)));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { RUM_INDEX, RUM_INDEX, 0, 0 }));
        }
        [Test]
        public void Skapar_ett_1x2_rum()
        {
            var ritare = new Kartritare(new Spelvärldsyta(2, 2));
            ritare.SkapaYta(new Spelvärldsområde(new Spelvärldsposition(0, 0), new Spelvärldsyta(1, 2)));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { RUM_INDEX, 0, RUM_INDEX, 0 }));
        }
        [Test]
        public void Skapar_ett_2x1_rum_på_1_1()
        {
            var ritare = new Kartritare(new Spelvärldsyta(3, 3));
            ritare.SkapaYta(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(2, 1)));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { 0, 0, 0, 0, RUM_INDEX, RUM_INDEX, 0, 0, 0 }));
        }
        [Test]
        public void Skapar_två_rum()
        {
            var ritare = new Kartritare(new Spelvärldsyta(2, 2));
            ritare.SkapaYta(new Spelvärldsområde(new Spelvärldsposition(0, 0), new Spelvärldsyta(1, 1)));
            ritare.SkapaYta(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(1, 1)));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { RUM_INDEX, 0, 0, RUM_INDEX }));
        }
        [Test]
        public void Skapar_en_dörr()
        {
            var ritare = new Kartritare(new Spelvärldsyta(2, 2));
            ritare.SkapaDörr(new Spelvärldsposition(0, 0));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { DÖRR_INDEX, 0, 0, 0 }));
        }
        [Test]
        public void Skapar_en_dörr_på_1_0()
        {
            var ritare = new Kartritare(new Spelvärldsyta(2, 2));
            ritare.SkapaDörr(new Spelvärldsposition(1, 0));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { 0, DÖRR_INDEX, 0, 0 }));
        }
        [Test]
        public void Skapar_en_dörr_på_1_1()
        {
            var ritare = new Kartritare(new Spelvärldsyta(2, 2));
            ritare.SkapaDörr(new Spelvärldsposition(1, 1));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { 0, 0, 0, DÖRR_INDEX }));
        }
        [Test]
        public void Skapar_en_dörr_på_1_1_i_3x2_värld()
        {
            var ritare = new Kartritare(new Spelvärldsyta(3, 2));
            ritare.SkapaDörr(new Spelvärldsposition(1, 1));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { 0, 0, 0, 0, DÖRR_INDEX, 0 }));
        }
        [Test]
        public void Skapar_två_dörrar()
        {
            var ritare = new Kartritare(new Spelvärldsyta(2, 2));
            ritare.SkapaDörr(new Spelvärldsposition(0, 0));
            ritare.SkapaDörr(new Spelvärldsposition(1, 1));
            Assert.That(ritare.Karta.Indexar, Is.EqualTo(new int[] { DÖRR_INDEX, 0, 0, DÖRR_INDEX }));
        }

        [Test]
        public void Gör_undantag_för_att_skapas_utan_spelvärldsyta()
        {
            try
            {
                new Kartritare(null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("spelvärldsskapare"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("utan spelvärldsyta"));
            }
        }
        [TestCase(0, 1, "bredd")]
        [TestCase(1, 0, "höjd")]
        public void Gör_undantag_för_att_skapa_spelvärldsyta_med_dimension_mindre_än_1(int bredd, int höjd, string beskrivning)
        {
            try
            {
                new Kartritare(new Spelvärldsyta(bredd, höjd));
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("spelvärldsskapare"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("spelvärldsyta"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("minst 1"));
                Assert.That(undantag.Message.ToLower(), Does.Contain(beskrivning));
            }
        }
        [Test]
        public void Gör_undantag_för_att_skapa_rum_utan_område()
        {
            try
            {
                new Kartritare(new Spelvärldsyta(1, 1))
                    .SkapaYta(null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("rum"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("område"));
            }
        }
        [Test]
        public void Gör_undantag_för_rum_som_placeras_med_någon_del_utanför_kartan()
        {
            try
            {
                new Kartritare(new Spelvärldsyta(1, 1))
                    .SkapaYta(new Spelvärldsområde(new Spelvärldsposition(0, 0), new Spelvärldsyta(1, 2)));
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("rum"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("placeras inom karta"));
            }
        }
        [TestCase(0, 1, "bredd")]
        [TestCase(1, 0, "höjd")]
        public void Gör_undantag_för_att_skapa_rum_med_dimension_0(int bredd, int höjd, string beskrivning)
        {
            try
            {
                new Kartritare(new Spelvärldsyta(1, 1))
                    .SkapaYta(new Spelvärldsområde(new Spelvärldsposition(0, 0), new Spelvärldsyta(bredd, höjd)));
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("rum"));
                Assert.That(undantag.Message.ToLower(), Does.Contain(beskrivning));
            }
        }

        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        public void Gör_undantag_för_att_placera_dörr_utanför_kartan(int x, int y)
        {
            try
            {
                new Kartritare(new Spelvärldsyta(1, 1)).SkapaDörr(new Spelvärldsposition(x, y));
                Assert.Fail("Inget undantag gjordes för att dörren placeras utanför kartan.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("dörr"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("utanför kartan"));
            }
        }
    }
}
