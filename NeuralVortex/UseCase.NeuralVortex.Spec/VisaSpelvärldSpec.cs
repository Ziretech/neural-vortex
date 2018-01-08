using NUnit.Framework;
using System.Collections.Generic;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{

    [TestFixture]
    public partial class VisaSpelvärldSpec
    {
        [Test]
        public void VisaSpelvärld_borde_inte_krascha_när_det_inte_finns_något_att_visa()
        {
            // Arrange
            var konverterare = new Positionskonverterare(new Skärmyta(1, 1));
            var visaSpelvärld = new VisaSpelvärld(new SpelvärldMock(), new KameraMock(), konverterare);

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
            var konverterare = new Positionskonverterare(new Skärmyta(1, 1));
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Grafik = huvudkaraktärensGrafik, Position = new Spelvärldsposition(1, 2) } };
            var visaSpelvärld = new VisaSpelvärld(spelvärld, new KameraMock(), konverterare);

            // Act
            visaSpelvärld.Visa();

            // Assert
            Assert.That(huvudkaraktärensGrafik.HarVisatsPåPosition.X, Is.EqualTo(1));
            Assert.That(huvudkaraktärensGrafik.HarVisatsPåPosition.Y, Is.EqualTo(2));
        }

        [Test]
        public void VisaSpelvärld_borde_visa_miljö()
        {
            // Arrange
            var kamera = new KameraMock();
            var miljögrafik = new GrafikMock();
            var spelvärld = new SpelvärldMock { MiljöGrafik = miljögrafik };
            var visaSpelvärld = new VisaSpelvärld(spelvärld, kamera, new PositionskonverterareMock());

            // Act
            visaSpelvärld.Visa();

            // Assert
            Assert.That(miljögrafik.HarVisatsPåPosition, Is.Not.Null);
        }

        [Test]
        public void VisaSpelvärld_borde_visa_fienden()
        {
            // Arrange
            var fiendegrafik = new GrafikMock();
            var spelvärld = new SpelvärldMock {
                Fienden = new List<Fiende>
                    {
                        new Fiende
                        {
                            Grafik = fiendegrafik,
                            Position = new Spelvärldsposition(2, 3)
                        }
                    }
            };
            var visaSpelvärld = new VisaSpelvärld(spelvärld, new KameraMock(), new PositionskonverterareMock());

            // Act
            visaSpelvärld.Visa();

            // Assert
            Assert.That(fiendegrafik.HarVisatsPåPosition.X, Is.EqualTo(2));
            Assert.That(fiendegrafik.HarVisatsPåPosition.Y, Is.EqualTo(3));
        }

        [Test]
        public void Huvudkaraktären_borde_visas_ovanpå_miljön()
        {
            // Arrange
            var kamera = new KameraMock();
            var grafik = new GrafikMock();
            var huvudkaraktär = new Huvudkaraktär { Grafik = grafik, Position = new Spelvärldsposition(1, 2) };
            var spelvärld = new SpelvärldMock { MiljöGrafik = grafik, Huvudkaraktär = huvudkaraktär };
            var visaSpelvärld = new VisaSpelvärld(spelvärld, kamera, new PositionskonverterareMock());

            // Act
            visaSpelvärld.Visa();

            // Assert
            Assert.That(grafik.HarVisatsPåPosition, Is.EqualTo(new Skärmposition(1, 2)));
            // Eftersom de använder gemensam grafik, borde den enligt mocken visats på huvudkaraktärens position sist, annars felaktigt miljöns position (0, 0)
        }
    }
}
