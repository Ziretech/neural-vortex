using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Spelvärld.Spec
{
    [TestFixture]
    public class KartaSpec
    {
        [Test]
        public void Skapas_med_bredd_höjd_och_indexar()
        {
            var karta = new Karta(1, 2, new[] { 3, 4 });
            Assert.That(karta.Bredd, Is.EqualTo(1));
            Assert.That(karta.Höjd, Is.EqualTo(2));
            Assert.That(karta.Indexar, Is.EqualTo(new[] { 3, 4 }));
        }

        [Test]
        [Ignore("Fixa hinderkartas jämförelse först")]
        public void Skapar_hinderkarta_från_hinderlista()
        {
            var karta = new Karta(2, 2, new[] { 1, 2, 2, 1 });
            var hinderkarta = karta.SkapaHinderkarta(new[] { 1 });
            Assert.That(hinderkarta, Is.EqualTo(new Hinderkarta(new[] { false, true, true, false }, 2)));
        }

        // TODO:
        // Skapa hinderkarta (från lista med definitioner)
        // Loopa över ett område för att få ut definitioner (som Brickfält.Visa använder)
    }
}
