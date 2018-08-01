using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Visning
{
    [TestFixture]
    public class KameraSpec
    {
        [Test]
        public void Finns_på_0_0_från_början()
        {
            var kamera = new Kamera(new Skärmyta(1, 1));
            Assert.That(kamera.Position.X, Is.EqualTo(0));
            Assert.That(kamera.Position.Y, Is.EqualTo(0));
        }

        [Test]
        public void Kan_inte_skapas_med_bredd_mindre_än_1()
        {
            try
            {
                new Kamera(new Skärmyta(0, 1));
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("kamera"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("skärmyta"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("bredd"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("mindre än 1"));
            }
        }

        [Test]
        public void Kan_inte_skapas_med_höjd_mindre_än_1()
        {
            try
            {
                new Kamera(new Skärmyta(1, 0));
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("kamera"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("skärmyta"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("höjd"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("mindre än 1"));
            }
        }

        [TestCase(1, 1, 2, 2, 0, 0)]
        [TestCase(2, 2, 2, 2, 1, 1)]
        [TestCase(2, 2, 4, 4, 0, 0)]
        public void Placeras_korrekt_efter_centrering(int centreradX, int centreradY, int bredd, int höjd, int resultatX, int resultatY)
        {
            var kamera = new Kamera(new Skärmyta(bredd, höjd));
            kamera.CentreraKameraMot(new Skärmposition(centreradX, centreradY));
            Assert.That(kamera.Position, Is.EqualTo(new Skärmposition(resultatX, resultatY)));
        }

        [Test]
        public void Finns_på_12_34_när_kameran_startar_på_12_34()
        {
            var kamera = new Kamera(new Skärmyta(1, 1), new Skärmposition(12, 34));
            Assert.That(kamera.Position, Is.EqualTo(new Skärmposition(12, 34)));
        }

        [TestCase(0, 0, 1, 2, 1, 2)]
        [TestCase(20, 10, 35, 11, 15, 1)]
        public void Transformerar_1_2_till_1_2_när_kameran_befinner_sig_vid_0_0(int kameraX, int kameraY, int positionX, int positionY, int resultatX, int resultatY)
        {
            var kamera = new Kamera(new Skärmyta(1, 1), new Skärmposition(kameraX, kameraY));
            var transformeradPosition = kamera.Transformera(new Skärmposition(positionX, positionY));
            Assert.That(transformeradPosition, Is.EqualTo(new Skärmposition(resultatX, resultatY)));
        }

        [TestCase(200, 100)]
        [TestCase(1, 1)]
        public void Ändrar_storlek_på_kamerans_dimensioner(int bredd, int höjd)
        {
            var kamera = new Kamera(new Skärmyta(1, 1));
            kamera.Dimensioner = new Skärmyta(bredd, höjd);
            Assert.That(kamera.Dimensioner.Bredd, Is.EqualTo(bredd));
            Assert.That(kamera.Dimensioner.Höjd, Is.EqualTo(höjd));
        }

        [TestCase(0, 1, "bredd")]
        [TestCase(1, 0, "höjd")]
        [TestCase(0, 0, "bredd")]
        [TestCase(10000, -10000, "höjd")]
        public void Gör_undantag_för_om_kamerans_dimensioner_skulle_ändras_till_mindre_än_1(int bredd, int höjd, string felaktigDimension)
        {
            var kamera = new Kamera(new Skärmyta(1, 1));
            try
            {
                kamera.Dimensioner = new Skärmyta(bredd, höjd);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("kamera"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("skärmyta"));
                Assert.That(undantag.Message.ToLower(), Does.Contain(felaktigDimension));
                Assert.That(undantag.Message.ToLower(), Does.Contain("mindre än 1"));
            }
        }

        [TestCase(1, 1, 3, 8, 1, 1, 3, 8)]
        [TestCase(4, 7, 13, 2, 4, 7, 16, 8)]
        [TestCase(0, 0, 4, 4, 0, 0, 3, 3)]
        public void Kameran_anger_sitt_synlighetsområde(int x, int y, int bredd, int höjd, int vänster, int botten, int höger, int topp)
        {
            var kamera = new Kamera(new Skärmyta(bredd, höjd), new Skärmposition(x, y));
            var synlighetsområde = kamera.Synlighetsområde;
            Assert.That(synlighetsområde.Vänster, Is.EqualTo(vänster), "vänster");
            Assert.That(synlighetsområde.Botten, Is.EqualTo(botten), "botten");
            Assert.That(synlighetsområde.Höger, Is.EqualTo(höger), "höger");
            Assert.That(synlighetsområde.Topp, Is.EqualTo(topp), "topp");
        }
    }
}
