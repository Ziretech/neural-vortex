using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class DödaKritisktSkadadeSpec
    {
        [Test]
        public void Avslutar_inte_spelet_om_huvudkaraktären_saknas()
        {
            var spelvärld = new SpelvärldMock();
            var dödaKritisktSkadade = new DödaKritisktSkadade(spelvärld);
            Assert.That(dödaKritisktSkadade.Döda(), Is.EqualTo(SpeletsFortsättning.Fortsätt));
        }

        [Test]
        public void Avslutar_spelet_om_huvudkaraktären_är_kritiskt_skadad()
        {
            var spelvärld = new SpelvärldMock();
            spelvärld.Huvudkaraktär = new Huvudkaraktär();
            // hur ska man sätta hälsa?
            var dödaKritisktSkadade = new DödaKritisktSkadade(spelvärld);
            Assert.That(dödaKritisktSkadade.Döda(), Is.EqualTo(SpeletsFortsättning.Avsluta));
        }

        // TODO: Hur ska man göra med hälsa?
        // Interface där man kan fråga om någon är kritiskt skadad?
        // Borde huvudkaraktären ha ett interface isåfall?
        // Borde man isåfall slå ihop huvudkaraktären och fienden? Vad skiljer dem åt egentligen just nu?
        // Eller ska man göra det enklaste just nu: man skapar ett fält hälsa för huvudkaraktären?
        // Och när det är dags att göra samma för fienden så upptäcker man att/om det blir duplicering?

        // TODO: Gör undantag för att skapas utan spelvärld
    }
}
