using NUnit.Framework;
using System;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class VisaSpelvärldSpec
    {
        [Test]
        public void VisaSpelvärld_borde_inte_krascha_när_det_inte_finns_något_att_visa()
        {
            // Arrange
            var spelvärld = new SpelvärldMock();
            var visaSpelvärld = new VisaSpelvärld(spelvärld, new Rektangel(100, 100), new Spelvärldsposition(0, 0));

            // Act
            visaSpelvärld.Visa();

            // Assert
            Assert.Pass("No exceptions thrown.");
        }

        [Test]
        public void VisaSpelvärld_borde_visa_huvudkaraktären_på_den_position_som_bestäms_av_kameran()
        {
            // Arrange
            var huvudkaraktärensGrafik = new GrafikMock();
            var huvudkaraktärensPosition = new Spelvärldsposition(1, 2);
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Grafik = huvudkaraktärensGrafik, Position = huvudkaraktärensPosition } };
            var visaSpelvärld = new VisaSpelvärld(spelvärld, new Rektangel(100, 100), new Spelvärldsposition(0, 0));

            // Act
            visaSpelvärld.Visa();

            // Assert
            Assert.That(huvudkaraktärensGrafik.HarVisatsPåPosition.X, Is.EqualTo(1));
            Assert.That(huvudkaraktärensGrafik.HarVisatsPåPosition.Y, Is.EqualTo(2));
        }

        //[Test]
        //public void VisaSpelvärld_borde_visa_miljö()
        //{
        //}
        
        // borde visa fienden

        private class SpelvärldMock : ISpelvärld
        {
            public Huvudkaraktär Huvudkaraktär { get; set; }
        }

        private class GrafikMock : IGrafik
        {
            public Skärmposition HarVisatsPåPosition { get; private set; }

            public void Visa(Skärmposition position)
            {
                HarVisatsPåPosition = position;
            }            
        }
    }
}
