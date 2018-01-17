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
        [Test]
        public void Genererar_en_tom_karta()
        {
            var skapare = new SpelvärldsskapareMock();
            var generera = new GenereraRumOchDörrar(skapare);
            generera.Generera();
            Assert.That(skapare.Rum, Is.Empty);
            Assert.That(skapare.Dörrar, Is.Empty);
        }

        [Ignore("implementera Spelvärldsområde.Equals först")]
        [Test]
        public void Genererar_en_karta_med_ett_3x3_rum_på_1_1()
        {
            var skapare = new SpelvärldsskapareMock();
            var generera = new GenereraRumOchDörrar(skapare);
            generera.Generera();
            Assert.That(skapare.Rum[0], Is.EqualTo(new Spelvärldsområde(1, 1, 3, 3)));
        }

        // exception om skapare = null
    }
}
