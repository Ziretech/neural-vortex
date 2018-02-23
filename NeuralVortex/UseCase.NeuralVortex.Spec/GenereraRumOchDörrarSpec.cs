using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spec.Kartgenerering;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class GenereraRumOchDörrarSpec
    {
        [TestCase(false, true, "spelvärldsskapare")]
        [TestCase(true, false, "rumochdörrarväljare")]
        public void Gör_undantag_om_skapare_saknas(bool användSkapare, bool användVäljare, string beskrivning)
        {
            var skapare = användSkapare ? new SpelvärldsskapareMock() : null;
            var väljare = användVäljare ? new RumOchDörrarVäljareMock() : null;

            try
            {
                var generera = new GenereraRumOchDörrar(skapare, väljare);
                Assert.Fail("Inget untantag gjordes.");
            }
            catch(ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("genererarumochdörrar"));
                Assert.That(undantag.Message.ToLower(), Does.Contain(beskrivning));
            }
        }

        [Test]
        public void Genererar_en_tom_karta()
        {
            var skapare = new SpelvärldsskapareMock();
            var väljare = new RumOchDörrarVäljareMock { AntalSteg = 0 };
            var generera = new GenereraRumOchDörrar(skapare, väljare);
            generera.Generera();
            Assert.That(skapare.AnropadesMedRum, Is.Empty);
            Assert.That(skapare.Dörrar, Is.Empty);
        }

        [Test]
        public void Genererar_en_karta_med_ett_3x3_rum_på_1_1()
        {
            var skapare = new SpelvärldsskapareMock();
            var väljare = new RumOchDörrarVäljareMock { AntalSteg = 1 };
            var generera = new GenereraRumOchDörrar(skapare, väljare);
            generera.Generera();
            Assert.That(skapare.AnropadesMedRum[0], Is.EqualTo(new Spelvärldsområde(1, 1, 3, 3)));
        }

        //[Ignore("1. Implementera new Spelvärldsområde(position, yta)")]
        [Test]
        public void Genererar_en_karta_med_ett_4x4_rum_på_1_1()
        {
            var skapare = new SpelvärldsskapareMock();
            var väljare = new RumOchDörrarVäljareMock { AntalSteg = 1 };
            var generera = new GenereraRumOchDörrar(skapare, väljare);
            generera.Generera();
            Assert.That(skapare.AnropadesMedRum[0], Is.EqualTo(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(3, 3))));
        }
    }
}
