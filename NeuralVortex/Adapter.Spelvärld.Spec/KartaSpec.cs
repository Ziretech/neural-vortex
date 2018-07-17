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
        public void Skapar_1x1_hinderkarta_utan_hinder_från_lista_utan_definitioner()
        {
            var karta = new Karta(1, 1, new[] { 1 });
            var hinderkarta = karta.SkapaHinderkarta(new int[0]);
            Assert.That(hinderkarta, Is.EqualTo(new Hinderkarta(new[] { false }, 1)));
        }

        [Test]
        public void Skapar_1x1_hinderkarta_med_hinder()
        {
            var karta = new Karta(1, 1, new[] { 1 });
            var hinderkarta = karta.SkapaHinderkarta(new[] { 1 });
            Assert.That(hinderkarta, Is.EqualTo(new Hinderkarta(new[] { true }, 1)));
        }

        [Test]
        public void Skapar_1x1_hinderkarta_utan_hinder()
        {
            var karta = new Karta(1, 1, new[] { 1 });
            var hinderkarta = karta.SkapaHinderkarta(new[] { 2 });
            Assert.That(hinderkarta, Is.EqualTo(new Hinderkarta(new[] { false }, 1)));
        }

        [Test]
        public void Skapar_1x2_hinderkarta_utan_hinder()
        {
            var karta = new Karta(1, 2, new[] { 1, 1 });
            var hinderkarta = karta.SkapaHinderkarta(new[] { 2 });
            Assert.That(hinderkarta, Is.EqualTo(new Hinderkarta(new[] { false, false }, 1)));
        }

        [Test]
        public void Skapar_1x2_hinderkarta_med_ett_hinder()
        {
            var karta = new Karta(1, 2, new[] { 1, 2 });
            var hinderkarta = karta.SkapaHinderkarta(new[] { 2 });
            Assert.That(hinderkarta, Is.EqualTo(new Hinderkarta(new[] { false, true }, 1)));
        }

        [Test]
        public void Skapar_2x1_hinderkarta_med_ett_hinder()
        {
            var karta = new Karta(2, 1, new[] { 1, 2 });
            var hinderkarta = karta.SkapaHinderkarta(new[] { 2 });
            Assert.That(hinderkarta, Is.EqualTo(new Hinderkarta(new[] { false, true }, 2)));
        }

        [Test]
        public void Skapar_2x2_hinderkarta_med_två_olika_hinder()
        {
            var karta = new Karta(2, 2, new[] { 1, 2, 3, 4 });
            var hinderkarta = karta.SkapaHinderkarta(new[] { 2, 3 });
            Assert.That(hinderkarta, Is.EqualTo(new Hinderkarta(new[] { false, true, true, false }, 2)));
        }

        // TODO:
        // Loopa över ett område för att få ut definitioner (som Brickfält.Visa använder)

        [TestCase(0)]
        [TestCase(-1)]
        public void Kan_inte_skapas_med_bredd_mindre_än_1(int bredd)
        {
            try
            {
                new Karta(bredd, 1, new[] { 1 });
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("bredd"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("mindre än 1"));
                Assert.That(undantag.Message.ToLower(), Does.Contain(bredd.ToString()));
            }
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Kan_inte_skapas_med_höjd_mindre_än_1(int höjd)
        {
            try
            {
                new Karta(1, höjd, new[] { 1 });
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("höjd"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("mindre än 1"));
                Assert.That(undantag.Message.ToLower(), Does.Contain(höjd.ToString()));
            }
        }

        [Test]
        public void Kan_inte_skapas_utan_indexar()
        {
            try
            {
                new Karta(1, 1, null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("index"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("inte vara null"));
            }
        }

        [Test]
        public void Kan_inte_skapas_om_inte_bredd_x_höjd_1_är_lika_med_antal_indexar_0()
        {
            try
            {
                new Karta(1, 1, new int[0]);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("antal index"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("inte lika med"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("bredd * höjd"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("0"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("1"));
            }
        }

        [Test]
        public void Kan_inte_skapas_om_inte_bredd_x_höjd_4_är_lika_med_antal_indexar_2()
        {
            try
            {
                new Karta(2, 2, new[] { 1, 2 });
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("antal index"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("inte lika med"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("bredd * höjd"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("4"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("2"));
            }
        }
    }
}
