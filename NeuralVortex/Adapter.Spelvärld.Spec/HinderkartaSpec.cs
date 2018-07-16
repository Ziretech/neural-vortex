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
        public void Kan_skapas_utan_hinder() // eftersom det gör att man kan köra en karta helt utan hinder
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

        [Test]
        public void Anser_att_två_2x2_kartor_är_likadana()
        {
            var första = new Hinderkarta(new bool[] { true, false, false, true }, 2);
            var andra = new Hinderkarta(new bool[] { true, false, false, true }, 2);
            Assert.That(första.Equals(andra), Is.True);
        }

        [Test]
        public void Anser_att_två_kartor_med_olika_antal_element_är_olika()
        {
            var första = new Hinderkarta(new bool[] { true, false, false, true }, 1);
            var andra = new Hinderkarta(new bool[] { true, false }, 1);
            Assert.That(första.Equals(andra), Is.False);
        }

        [Test]
        public void Anser_att_två_kartor_med_olika_bredd_är_olika()
        {
            var första = new Hinderkarta(new bool[] { true, false, false, true }, 1);
            var andra = new Hinderkarta(new bool[] { true, false, false, true }, 2);
            Assert.That(första.Equals(andra), Is.False);
        }

        [Test]
        public void Anser_att_två_kartor_med_olika_innehåll_är_olika()
        {
            var första = new Hinderkarta(new bool[] { true, false, false, true }, 2);
            var andra = new Hinderkarta(new bool[] { true, false, true, true }, 2);
            Assert.That(första.Equals(andra), Is.False);
        }

        [Test]
        public void Anser_att_två_kartor_utan_hinder_är_likadana()
        {
            var första = new Hinderkarta(null, 0);
            var andra = new Hinderkarta(null, 0);
            Assert.That(första.Equals(andra), Is.True);
        }

        [Test]
        public void Anser_att_karta_med_hinder_inte_är_likadan_som_karta_utan_hinder()
        {
            var första = new Hinderkarta(new[] { true }, 0);
            var andra = new Hinderkarta(null, 0);
            Assert.That(första.Equals(andra), Is.False);
        }

        [Test]
        public void Anser_att_karta_utan_hinder_inte_är_likadan_som_karta_med_hinder()
        {
            var första = new Hinderkarta(null, 0);
            var andra = new Hinderkarta(new[] { true }, 0);            
            Assert.That(första.Equals(andra), Is.False);
        }

        [Test]
        public void Representerar_hinderkarta_med_2x2()
        {
            var representation = new Hinderkarta(new bool[] { true, false, false, true }, 2).ToString();
            Assert.That(representation, Is.EqualTo("2x2"));
        }

        [Test]
        public void Representerar_hinderkarta_med_3x2()
        {
            var representation = new Hinderkarta(new bool[] { true, false, false}, 3).ToString();
            Assert.That(representation, Is.EqualTo("3x1"));
        }

        [Test]
        public void Representerar_hinderkarta_utan_hinder()
        {
            var representation = new Hinderkarta(null, 0).ToString();
            Assert.That(representation, Is.EqualTo("Hinderkarta utan hinder"));
        }
    }
}
