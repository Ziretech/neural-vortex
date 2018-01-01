using NUnit.Framework;
using System;

namespace Entity.NeuralVortex.Spec
{
    [TestFixture]
    public class KameraSpec
    {
        [Test]
        public void Kamerans_bredd_får_inte_vara_mindre_än_1()
        {
            try
            {
                new Kamera(0, 0, 0, 1);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(ArgumentException exception)
            {
                Assert.That(exception.Message.ToLower(), Does.Contain("bredd"));
                Assert.That(exception.Message.ToLower(), Does.Contain("mindre än 1"));
            }
        }

        [Test]
        public void Kamerans_höjd_får_inte_vara_mindre_än_1()
        {
            try
            {
                new Kamera(0, 0, 1, 0);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException exception)
            {
                Assert.That(exception.Message.ToLower(), Does.Contain("höjd"));
                Assert.That(exception.Message.ToLower(), Does.Contain("mindre än 1"));
            }
        }

        [Test]
        public void Kamera_vid_0_översätter_1_2_till_1_2()
        {
            var kamera = new Kamera(0, 0, 1, 1);
            Assert.That(kamera.BeräknaXPosition(1), Is.EqualTo(1));
            Assert.That(kamera.BeräknaYPosition(2), Is.EqualTo(2));
        }

        [Test]
        public void Kamera_vid_3_5_översätter_3_5__till_6_10()
        {
            var kamera = new Kamera(3, 5, 1, 1);
            Assert.That(kamera.BeräknaXPosition(3), Is.EqualTo(6));
            Assert.That(kamera.BeräknaYPosition(5), Is.EqualTo(10));
        }

        [Test]
        public void Kamera_vid_1_2_med_dimensioner_3_4_borde_ange_yta_6_2_1_4()
        {
            var kamera = new Kamera(1, 2, 3, 4);
            Assert.That(kamera.Topp, Is.EqualTo(6));
            Assert.That(kamera.Botten, Is.EqualTo(2));
            Assert.That(kamera.Vänster, Is.EqualTo(1));
            Assert.That(kamera.Höger, Is.EqualTo(4));
        }
    }
}
