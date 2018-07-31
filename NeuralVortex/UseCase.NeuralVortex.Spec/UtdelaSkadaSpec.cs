using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class UtdelaSkadaSpec
    {
        [TestCase(1, 0, 1, 1)]
        [TestCase(1, 2, 1, 1)]
        [TestCase(1, 2, 2, 2)]
        [TestCase(3, 2, 2, 2)]
        public void Utdelar_skada_till_huvudkaraktären_när_den_står_bredvid_fienden(int x1, int y1, int x2, int y2)
        {
            var spelvärld = new SpelvärldMock();
            spelvärld.Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(x1, y1) };
            spelvärld.Fienden = new[] { new Fiende { Position = new Spelvärldsposition(x2, y2) } };
            var utdelaSkada = new UtdelaSkada(spelvärld);
            utdelaSkada.Utdela();
            Assert.That(spelvärld.Huvudkaraktär.ÄrKritisktSkadad, Is.True);
        }

        [TestCase(1, 3, 1, 1)]
        [TestCase(1, 3, 1, 3)]
        [TestCase(1, 3, 0, 2)]
        [TestCase(1, 3, 3, 3)]
        [TestCase(1, 3, 2, 4)]
        public void Utdelar_inte_skada_till_huvudkaraktären_när_den_inte_står_bredvid_fienden(int x1, int y1, int x2, int y2)
        {
            var spelvärld = new SpelvärldMock();
            spelvärld.Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(x1, y1) };
            spelvärld.Fienden = new[] { new Fiende { Position = new Spelvärldsposition(x2, y2) } };
            var utdelaSkada = new UtdelaSkada(spelvärld);
            utdelaSkada.Utdela();
            Assert.That(spelvärld.Huvudkaraktär.ÄrKritisktSkadad, Is.False);
        }

        [TestCase(1, 1, 4, 7, 1, 2)]
        [TestCase(1, 1, 1, 2, 4, 7)]
        public void Utdelar_skada_till_huvudkaraktären_när_den_står_bredvid_andra_fienden(int x, int y, int f1x, int f1y, int f2x, int f2y)
        {
            var spelvärld = new SpelvärldMock();
            spelvärld.Huvudkaraktär = new Huvudkaraktär { Position = new Spelvärldsposition(x, y) };
            spelvärld.Fienden = new[] 
            {
                new Fiende { Position = new Spelvärldsposition(f1x, f1y) },
                new Fiende { Position = new Spelvärldsposition(f2x, f2y) }
            };
            var utdelaSkada = new UtdelaSkada(spelvärld);
            utdelaSkada.Utdela();
            Assert.That(spelvärld.Huvudkaraktär.ÄrKritisktSkadad, Is.True);
        }

        // TODO: [R] Använd hälsa (int) för att utdela kritiskt skada
        // TODO: Karaktären tål mer än en träff
    }
}
