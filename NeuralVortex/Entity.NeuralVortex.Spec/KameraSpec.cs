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
                new Kamera(0, 0, 0, 1, 1, 1);
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
                new Kamera(0, 0, 1, 0, 1, 1);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException exception)
            {
                Assert.That(exception.Message.ToLower(), Does.Contain("höjd"));
                Assert.That(exception.Message.ToLower(), Does.Contain("mindre än 1"));
            }
        }

        // brickhöjd får inte vara mindre än 1 i någon dimension

        [Test]
        public void Kamera_vid_0_översätter_1_2_med_brickstorlek_12_16_till_12_32()
        {
            var kamera = new Kamera(0, 0, 1, 1, 12, 16);
            Assert.That(kamera.BeräknaXPosition(1), Is.EqualTo(12));
            Assert.That(kamera.BeräknaYPosition(2), Is.EqualTo(32));
        }

        [Test]
        public void Kamera_vid_3_5_översätter_3_5_med_brickstorlek_11_13_till_66_130()
        {
            var kamera = new Kamera(3, 5, 1, 1, 11, 13);
            Assert.That(kamera.BeräknaXPosition(3), Is.EqualTo(66));
            Assert.That(kamera.BeräknaYPosition(5), Is.EqualTo(130));
        }

        [Test]
        public void Kamera_vid_1_2_med_dimensioner_3_4_för_brickstorlek_10_20_borde_ange_yta_120_40_10_40()
        {
            var kamera = new Kamera(1, 2, 3, 4, 10, 20);
            Assert.That(kamera.Topp, Is.EqualTo(120));
            Assert.That(kamera.Botten, Is.EqualTo(40));
            Assert.That(kamera.Vänster, Is.EqualTo(10));
            Assert.That(kamera.Höger, Is.EqualTo(40));
        }
    }
}
