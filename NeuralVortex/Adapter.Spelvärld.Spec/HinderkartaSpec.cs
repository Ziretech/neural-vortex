using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace Adapter.Spelvärld.Spec
{
    [TestFixture]
    public class HinderkartaSpec
    {
        [Test]
        public void Kan_skapas_utan_hinder()
        {
            var hinderkarta = new Hinderkarta(null, 0);
            Assert.That(!hinderkarta.Hindrar(new Spelvärldsposition(1, 2)));
        }

        [Test]
        public void Hindrar_när_kartans_enda_fält_är_ett_hinder()
        {
            var hinderkarta = new Hinderkarta(new bool[] { true }, 1);
            Assert.That(hinderkarta.Hindrar(new Spelvärldsposition(0, 0)));
        }

        [Test]
        public void Hindrar_inte_när_kartans_enda_fält_inte_är_ett_hinder()
        {
            var hinderkarta = new Hinderkarta(new bool[] { false }, 1);
            Assert.That(!hinderkarta.Hindrar(new Spelvärldsposition(0, 0)));
        }

        [Test]
        public void Hindrar_när_kartans_tredje_fält_är_ett_hinder()
        {
            var hinderkarta = new Hinderkarta(new bool[] { false, false, true }, 3);
            Assert.That(hinderkarta.Hindrar(new Spelvärldsposition(2, 0)));
        }

        [Test]
        public void Hindrar_när_kartans_tredje_fält_är_utanför_kartan()
        {
            var hinderkarta = new Hinderkarta(new bool[] { false, false }, 2);
            Assert.That(hinderkarta.Hindrar(new Spelvärldsposition(2, 0)));
        }

        [Test]
        public void Hindrar_när_kartans_tredje_fält_är_utanför_kartan_åt_vänster()
        {
            var hinderkarta = new Hinderkarta(new bool[] { false, false }, 2);
            Assert.That(hinderkarta.Hindrar(new Spelvärldsposition(-1, 0)));
        }

        [Test]
        public void Hindrar_när_kartans_andra_fält_på_höjden_är_ett_hinder()
        {
            var hinderkarta = new Hinderkarta(new bool[] { false, true }, 1);
            Assert.That(hinderkarta.Hindrar(new Spelvärldsposition(0, 1)));
        }

        [Test]
        public void Hindrar_när_2x2_kartans_3_fält_är_ett_hinder()
        {
            var hinderkarta = new Hinderkarta(new bool[] { false, false, true, false }, 2);
            Assert.That(hinderkarta.Hindrar(new Spelvärldsposition(0, 1)));
        }

        [Test]
        public void Hindrar_när_2x2_kartans_4_fält_är_ett_hinder()
        {
            var hinderkarta = new Hinderkarta(new bool[] { false, false, false, true }, 2);
            Assert.That(hinderkarta.Hindrar(new Spelvärldsposition(1, 1)));
        }

        // TODO Hinderkarta
        // testar hinder på position utanför kartan (felhantering)
    }
}
