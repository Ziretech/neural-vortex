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
        [TestCase(5, 5)]
        [TestCase(4, 3)]
        public void Genererar_karta_med_ett_rum(int bredd, int höjd)
        {
            var skapare = new SpelvärldsskapareMock(1);
            new GenereraRumOchDörrar(skapare, new RumOchDörrarVäljareMock {
                RumStorlekar = new[] {new Spelvärldsyta(bredd, höjd)}
            }).Generera();
            Assert.That(skapare.AnropadesMedRum[0], Is.EqualTo(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(bredd, höjd))));
        }

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
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("genererarumochdörrar"));
                Assert.That(undantag.Message.ToLower(), Does.Contain(beskrivning));
            }
        }
    }
}
