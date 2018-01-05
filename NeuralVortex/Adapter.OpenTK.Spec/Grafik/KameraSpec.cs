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

        [Test]
        public void Finns_på_0_0_efter_att_ha_centererats_på_1_1_när_ytan_är_2_2()
        {
            var kamera = new Kamera(new Skärmyta(2, 2));
            kamera.CentreraKameraMot(new Skärmposition(1, 1));
            Assert.That(kamera.Position.X, Is.EqualTo(0));
            Assert.That(kamera.Position.Y, Is.EqualTo(0));
        }

        [Test]
        public void Finns_på_1_1_efter_att_ha_centererats_på_2_2_när_ytan_är_2_2()
        {
            var kamera = new Kamera(new Skärmyta(2, 2));
            kamera.CentreraKameraMot(new Skärmposition(2, 2));
            Assert.That(kamera.Position.X, Is.EqualTo(1));
            Assert.That(kamera.Position.Y, Is.EqualTo(1));
        }

        [Test]
        public void Finns_på_0_0_efter_att_ha_centererats_på_2_2_när_ytan_är_4_4()
        {
            var kamera = new Kamera(new Skärmyta(4, 4));
            kamera.CentreraKameraMot(new Skärmposition(2, 2));
            Assert.That(kamera.Position.X, Is.EqualTo(0));
            Assert.That(kamera.Position.Y, Is.EqualTo(0));
        }

        [Test]
        public void Finns_på_12_34_när_kameran_startar_på_12_34()
        {
            var kamera = new Kamera(new Skärmyta(1, 1), new Skärmposition(12, 34));
            Assert.That(kamera.Position.X, Is.EqualTo(12));
            Assert.That(kamera.Position.Y, Is.EqualTo(34));
        }

        [Ignore("2. Behöver Skärmposition.Minus")]
        [Test]
        public void Transformerar_1_2_till_1_2_när_kameran_befinner_sig_vid_0_0()
        {
            var kamera = new Kamera(new Skärmyta(1, 1), new Skärmposition(0, 0));
            var transformeradPosition = kamera.Transformera(new Skärmposition(1, 2));
            Assert.That(transformeradPosition.X, Is.EqualTo(1));
            Assert.That(transformeradPosition.Y, Is.EqualTo(2));
        }
    }
}
