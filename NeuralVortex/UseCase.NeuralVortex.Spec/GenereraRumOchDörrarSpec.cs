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
        public void Gör_undantag_om_skapare_saknas_så_att_de_inte_behöver_kontrolleras_senare(bool användSkapare, bool användVäljare, string beskrivning)
        {
            var skapare = användSkapare ? new SpelvärldsskapareMock(1) : null;
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
        public void Genererar_en_karta_med_ett_3x3_rum_på_1_1_så_att_ett_initialt_rum_skapas()
        {
            var skapare = new SpelvärldsskapareMock(1);
            var väljare = new RumOchDörrarVäljareMock { RumStorlekar = new[] { new Spelvärldsyta(3, 3) }};
            var generera = new GenereraRumOchDörrar(skapare, väljare);
            generera.Generera();
            Assert.That(skapare.AnropadesMedRum[0], Is.EqualTo(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(3, 3))));
        }

        [Test]
        public void Genererar_en_karta_med_ett_4x4_rum_på_1_1_så_att_ett_initialt_rum_skapas()
        {
            var skapare = new SpelvärldsskapareMock(1);
            var väljare = new RumOchDörrarVäljareMock { RumStorlekar = new[] { new Spelvärldsyta(4, 4) } };
            var generera = new GenereraRumOchDörrar(skapare, väljare);
            generera.Generera();
            Assert.That(skapare.AnropadesMedRum[0], Is.EqualTo(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(4, 4))));
        }

        [Test]
        public void Genererar_rum_3x3_med_dörr_vid_4_2_och_3x4_rum_vid_5_1_så_att_flera_rum_skapas()
        {
            var skapare = new SpelvärldsskapareMock(2);
            var väljare = new RumOchDörrarVäljareMock
            {
                RumStorlekar = new[] { new Spelvärldsyta(3, 3), new Spelvärldsyta(3, 4) },
                Dörrpositioner = new[] { new [] { new Spelvärldsposition(4, 2) }},
                Rumpositioner = new[] { new Spelvärldsposition(5, 1)}
            };
            new GenereraRumOchDörrar(skapare, väljare).Generera();
            Assert.That(skapare.AnropadesMedRum[0], Is.EqualTo(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(3, 3))));
            Assert.That(skapare.AnropadesMedDörr[0], Is.EqualTo(new Spelvärldsposition(4, 2)));
            Assert.That(skapare.AnropadesMedRum[1], Is.EqualTo(new Spelvärldsområde(new Spelvärldsposition(5, 1), new Spelvärldsyta(3, 4))));
        }
    }
}
