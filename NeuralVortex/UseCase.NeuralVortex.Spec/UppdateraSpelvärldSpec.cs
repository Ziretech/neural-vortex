using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.AI;
using UseCase.NeuralVortex.Kontroll;
using UseCase.NeuralVortex.Spec.AI;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class UppdateraSpelvärldSpec
    {
        [Test]
        public void Flyttar_varelser()
        {
            var flyttaVarelser = new FlyttaVarelserMock();
            var uppdateraSpelvärld = new UppdateraSpelvärld(flyttaVarelser, null, null);

            uppdateraSpelvärld.Uppdatera(Tangent.Upp);

            Assert.That(flyttaVarelser.FlyttadesAvTangent, Is.EqualTo(Tangent.Upp));
        }

        [Test]
        public void Utdelar_skada()
        {
            var utdelaSkada = new UtdelaSkadaMock();
            var uppdateraSpelvärld = new UppdateraSpelvärld(null, utdelaSkada, null);

            uppdateraSpelvärld.Uppdatera(Tangent.Upp);

            Assert.That(utdelaSkada.UtdelaHarAnropats, Is.True);
        }

        [Test]
        public void Dödar_kritiskt_skadade()
        {
            var dödaKritisktSkadade = Substitute.For<IDödaKritisktSkadade>();
            var uppdateraSpelvärld = new UppdateraSpelvärld(null, null, dödaKritisktSkadade);

            uppdateraSpelvärld.Uppdatera(Tangent.Upp);

            dödaKritisktSkadade.Received().Döda();
        }

        [Test]
        public void Avslutar_spelet_om_dödar_kritiskt_skadade_avslutar_spelet()
        {
            var dödaKritisktSkadade = Substitute.For<IDödaKritisktSkadade>();
            dödaKritisktSkadade.Döda().Returns(SpeletsFortsättning.Avsluta);
            var uppdateraSpelvärld = new UppdateraSpelvärld(null, null, dödaKritisktSkadade);

            var avslutning = uppdateraSpelvärld.Uppdatera(Tangent.Upp);

            Assert.That(avslutning, Is.EqualTo(SpeletsFortsättning.Avsluta));
        }

        [Test]
        public void Fortsätter_spelet_om_dödar_kritiskt_skadade_inte_avslutar_spelet()
        {
            var dödaKritisktSkadade = Substitute.For<IDödaKritisktSkadade>();
            dödaKritisktSkadade.Döda().Returns(SpeletsFortsättning.Fortsätt);
            var uppdateraSpelvärld = new UppdateraSpelvärld(null, null, dödaKritisktSkadade);

            var avslutning = uppdateraSpelvärld.Uppdatera(Tangent.Upp);

            Assert.That(avslutning, Is.EqualTo(SpeletsFortsättning.Fortsätt));
        }
    }
}
