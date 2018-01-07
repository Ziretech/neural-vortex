using NUnit.Framework;
using System;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class PositionskonverterareSpec
    {
        [Test]
        public void Får_inte_ha_brickbredd_mindre_än_1()
        {
            try
            {
                var konverterare = new Positionskonverterare(new Skärmyta(0, 1));
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("positionskonverterare"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("brickyta"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("bredd"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("mindre än 1"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("0"));
            }            
        }

        [Test]
        public void Får_inte_ha_brickhöjd_mindre_än_1()
        {
            try
            {
                var konverterare = new Positionskonverterare(new Skärmyta(1, -1));
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("positionskonverterare"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("brickyta"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("höjd"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("mindre än 1"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("-1"));
            }
        }

        [TestCase(0, 0, 0, 0, 16, 16)]
        [TestCase(1, 2, 16, 32, 16, 16)]
        [TestCase(-1, 0, -16, 0, 16, 16)]
        public void Konverterar_spelvärldsposition_till_skärmposition_när_brickytan_är_given(int världX, int världY, int skärmX, int skärmY, int brickBredd, int brickHöjd)
        {
            var konverterare = new Positionskonverterare(new Skärmyta(brickBredd, brickHöjd));
            var resultat = konverterare.TillPunkt(new Spelvärldsposition(världX, världY));
            Assert.That(resultat.X, Is.EqualTo(skärmX));
            Assert.That(resultat.Y, Is.EqualTo(skärmY));
        }

        [TestCase(0, 0, 1, 1, 4, 4, 0, 0, 0, 0)]
        [TestCase(0, 0, 4, 1, 4, 4, 0, 0, 1, 0)]
        [TestCase(0, 0, 1, 4, 4, 4, 0, 0, 0, 1)]
        [TestCase(0, 0, 7, 7, 4, 4, 0, 0, 1, 1)]
        [TestCase(4, 0, 7, 7, 4, 4, 1, 0, 1, 1)]
        [TestCase(4, 4, 7, 7, 4, 4, 1, 1, 1, 1)]
        [TestCase(4, 15, 16, 32, 16, 16, 0, 0, 1, 2)]
        public void Konverterar_skärmområde_till_spelvärldsområde(int vänster, int botten, int höger, int topp, int brickbredd, int brickhöjd, int resultatVänster, int resultatBotten, int resultatHöger, int resultatTopp)
        {
            var konverterare = new Positionskonverterare(new Skärmyta(brickbredd, brickhöjd));
            var område = konverterare.TillOmråde(new Skärmområde(vänster, botten, höger, topp));
            Assert.That(område.Vänster, Is.EqualTo(resultatVänster), "vänster");
            Assert.That(område.Botten, Is.EqualTo(resultatBotten), "botten");
            Assert.That(område.Höger, Is.EqualTo(resultatHöger), "höger");
            Assert.That(område.Topp, Is.EqualTo(resultatTopp), "topp");
        }
    }
}
