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
            }).Generera(1);
            Assert.That(skapare.AnropadesMedRum[0], Is.EqualTo(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(bredd, höjd))));
        }
        [TestCase(GenereraRumOchDörrar.Riktning.Höger, 3, 1, 2, 1)]
        [TestCase(GenereraRumOchDörrar.Riktning.Uppåt, 1, 3, 1, 2)]
        public void Genererar_karta_med_två_1x1_rum_och_en_dörr(GenereraRumOchDörrar.Riktning riktning, int rum2X, int rum2Y, int dörrX, int dörrY)
        {
            var skapare = new SpelvärldsskapareMock(1); // TODO: Tag bort antalet steg (används inte för stunden)
            new GenereraRumOchDörrar(skapare, new RumOchDörrarVäljareMock
            {
                RumStorlekar = new[] { new Spelvärldsyta(1, 1), new Spelvärldsyta(1, 1) },
                Riktningar = new[] { riktning }
            }).Generera(2);
            Assert.That(skapare.AnropadesMedRum.Count, Is.EqualTo(2), "Antal rum");
            Assert.That(skapare.AnropadesMedRum[0], Is.EqualTo(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(1, 1))), "Första rummet");
            Assert.That(skapare.AnropadesMedRum[1], Is.EqualTo(new Spelvärldsområde(new Spelvärldsposition(rum2X, rum2Y), new Spelvärldsyta(1, 1))), "Andra rummet");
            Assert.That(skapare.AnropadesMedDörr.Count, Is.EqualTo(1), "Antal dörrar");
            Assert.That(skapare.AnropadesMedDörr[0], Is.EqualTo(new Spelvärldsposition(dörrX, dörrY)), "Dörrens placering");
        }

        /// TODO: GenereraRumOchDörrar
        /// Ett rum med 2x1 måste välja var på bredden dörren ska sitta
        /// Ett rum med 1x2 måste välja var på höjden dörren ska sitta
        /// Ännu större rum med ännu fler möjligheter
        /// Tre rum som sitter ihop
        /// Ännu fler rum som sitter ihop

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
