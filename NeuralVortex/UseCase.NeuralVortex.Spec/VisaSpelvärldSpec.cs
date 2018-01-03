using NUnit.Framework;
using System;
using System.Collections.Generic;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public partial class VisaSpelvärldSpec
    {
        [Test]
        public void VisaSpelvärld_borde_inte_krascha_när_det_inte_finns_något_att_visa()
        {
            // Arrange
            var spelvärld = new SpelvärldMock { KameraPosition = new Spelvärldsposition(0, 0) };
            var visaSpelvärld = new VisaSpelvärld(spelvärld, new Rektangel(16, 16));

            // Act
            visaSpelvärld.Visa(new Rektangel(100, 100));

            // Assert
            Assert.Pass("No exceptions thrown.");
        }

        [Test]
        public void VisaSpelvärld_borde_visa_huvudkaraktären_på_den_position_som_bestäms_av_kameran()
        {
            // Arrange
            var huvudkaraktärensGrafik = new GrafikMock();
            var huvudkaraktärensPosition = new Spelvärldsposition(1, 2);
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Grafik = huvudkaraktärensGrafik, Position = huvudkaraktärensPosition }, KameraPosition = new Spelvärldsposition(0, 0) };
            var visaSpelvärld = new VisaSpelvärld(spelvärld, new Rektangel(16, 32));

            // Act
            visaSpelvärld.Visa(new Rektangel(100, 100));

            // Assert
            Assert.That(huvudkaraktärensGrafik.HarVisatsPåPosition.X, Is.EqualTo(1 * 16));
            Assert.That(huvudkaraktärensGrafik.HarVisatsPåPosition.Y, Is.EqualTo(2 * 32));
        }

        [Test]
        public void VisaSpelvärld_borde_visa_miljö()
        {
            // Arrange            
            var miljögrafik = new GrafikfältMock();
            var spelvärld = new SpelvärldMock { MiljöGrafik = miljögrafik, KameraPosition = new Spelvärldsposition(3, 5) };
            var visaSpelvärld = new VisaSpelvärld(spelvärld, new Rektangel(16, 24));

            // Act
            visaSpelvärld.Visa(new Rektangel(13, 17));

            // Assert
            Assert.That(miljögrafik.HarVisatYta.Topp, Is.EqualTo(22*24));
            Assert.That(miljögrafik.HarVisatYta.Botten, Is.EqualTo(5*24));
            Assert.That(miljögrafik.HarVisatYta.Vänster, Is.EqualTo(3*16));
            Assert.That(miljögrafik.HarVisatYta.Höger, Is.EqualTo(16*16));
        }

        [Test]
        public void VisaSpelvärld_borde_visa_fienden()
        {
            // Arrange
            var fiendegrafik = new GrafikMock();
            var visaSpelvärld = new VisaSpelvärld(
                new SpelvärldMock
                {
                    Fienden = new List<Fiende>
                    {
                        new Fiende
                        {
                            Grafik = fiendegrafik,
                            Position = new Spelvärldsposition(2, 3)
                        }
                    },
                    KameraPosition = new Spelvärldsposition(5, 12)
                }, new Rektangel(16, 16));

            // Act
            visaSpelvärld.Visa(new Rektangel(100, 100));

            // Assert
            Assert.That(fiendegrafik.HarVisatsPåPosition.X, Is.EqualTo(7 * 16));
            Assert.That(fiendegrafik.HarVisatsPåPosition.Y, Is.EqualTo(15 * 16));
        }
    }
}
