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

        [Ignore("Behöver implementera method i kamera för att mata ut synlighetsområdet")]
        [Test]
        public void Konverterar_skärmområde_till_spelvärldsområde()
        {
            
        }
    }
}
