using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Kontroll;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class UppdateraSpelvärldSpec
    {
        [Test]
        public void Flytta_huvudkaraktären_uppåt()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(0, 0) } };
            var uppdateraSpelvärld = new UppdateraSpelvärld(spelvärld, new KameraMock());

            uppdateraSpelvärld.Uppdatera(Tangent.Upp);

            Assert.That(spelvärld.Huvudkaraktär.Position.Y, Is.EqualTo(1));
        }

        [Test]
        public void Flytta_huvudkaraktären_nedåt()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(2, 3) } };
            var uppdateraSpelvärld = new UppdateraSpelvärld(spelvärld, new KameraMock());

            uppdateraSpelvärld.Uppdatera(Tangent.Ner);

            Assert.That(spelvärld.Huvudkaraktär.Position.Y, Is.EqualTo(2));
        }

        [Test]
        public void Flytta_huvudkaraktären_vänster()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(2, 3) } };
            var uppdateraSpelvärld = new UppdateraSpelvärld(spelvärld, new KameraMock());

            uppdateraSpelvärld.Uppdatera(Tangent.Vänster);

            Assert.That(spelvärld.Huvudkaraktär.Position.X, Is.EqualTo(1));
        }

        [Test]
        public void Flytta_huvudkaraktären_höger()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(2, 13) } };
            var uppdateraSpelvärld = new UppdateraSpelvärld(spelvärld, new KameraMock());

            uppdateraSpelvärld.Uppdatera(Tangent.Höger);

            Assert.That(spelvärld.Huvudkaraktär.Position.X, Is.EqualTo(3));
        }

        [Ignore("Implementera Spelvärldsposition.Equals")]
        [Test]
        public void Hindrar_förflyttning_till_ruta_med_hinder()
        {
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(1, 1) } };
            var uppdateraSpelvärld = new UppdateraSpelvärld(spelvärld, new KameraMock());

            uppdateraSpelvärld.Uppdatera(Tangent.Höger);

            Assert.That(spelvärld.Huvudkaraktär.Position.X, Is.EqualTo(1));
        }
    }

    public class HinderkartaMock : IHinderkarta
    {
        private readonly Spelvärldsposition[] _hinder;

        public HinderkartaMock(Spelvärldsposition[] hinder)
        {
            _hinder = hinder;
        }

        public bool Hindrar(Spelvärldsposition position)
        {
            return _hinder.Any(h => h.Equals(position));
        }
    }
}
