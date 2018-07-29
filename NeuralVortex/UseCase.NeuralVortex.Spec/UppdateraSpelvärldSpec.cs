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
            var uppdateraSpelvärld = new UppdateraSpelvärld(flyttaVarelser, null);

            uppdateraSpelvärld.Uppdatera(Tangent.Upp);

            Assert.That(flyttaVarelser.FlyttadesAvTangent, Is.EqualTo(Tangent.Upp));
        }

        [Test]
        public void Utdelar_skada()
        {
            var utdelaSkada = new UtdelaSkadaMock();
            var uppdateraSpelvärld = new UppdateraSpelvärld(null, utdelaSkada);

            uppdateraSpelvärld.Uppdatera(Tangent.Upp);

            Assert.That(utdelaSkada.UtdelaHarAnropats, Is.True);
        }
    }
}
