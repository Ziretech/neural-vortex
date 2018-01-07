using Adapter.OpenTK.Grafik;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Spec.Grafik
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

        [Test]
        public void Ändrar_storlek_på_synlighetytan_till_200_100()
        {
            var kamera = new Kamera(new Skärmyta(1, 1));
            kamera.Dimensioner = new Skärmyta(200, 100);
            Assert.That(kamera.Dimensioner.Bredd, Is.EqualTo(200));
            Assert.That(kamera.Dimensioner.Höjd, Is.EqualTo(100));
        }
    }
}
