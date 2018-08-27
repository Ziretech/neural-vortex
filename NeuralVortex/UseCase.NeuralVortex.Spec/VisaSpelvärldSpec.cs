using NSubstitute;
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
            var visaSpelvärld = new VisaSpelvärld(new SpelvärldMock(), konverterare);

            // Act
            visaSpelvärld.Visa();

            // Assert
            Assert.Pass("No exceptions thrown.");
        }

        [Test]
        public void VisaSpelvärld_borde_visa_huvudkaraktären_på_den_position_som_bestäms_av_kameran()
        {
            // Arrange
            var huvudkaraktärensGrafik = Substitute.For<IGrafik>();
            var konverterare = new Positionskonverterare(new Skärmyta(1, 1));
            var spelvärld = new SpelvärldMock { Huvudkaraktär = new Huvudkaraktär { Grafik = huvudkaraktärensGrafik, Position = new Spelvärldsposition(1, 2) } };
            var visaSpelvärld = new VisaSpelvärld(spelvärld, konverterare);

            // Act
            visaSpelvärld.Visa();

            // Assert
            huvudkaraktärensGrafik.Received().Visa(new Skärmposition(1, 2));
        }

        [Test]
        public void VisaSpelvärld_borde_visa_miljö()
        {
            // Arrange
            var miljögrafik = Substitute.For<IGrafik>();
            var spelvärld = new SpelvärldMock { MiljöGrafik = miljögrafik };
            var visaSpelvärld = new VisaSpelvärld(spelvärld, Substitute.For<IPositionskonverterare>());

            // Act
            visaSpelvärld.Visa();

            // Assert
            miljögrafik.Received().Visa(Arg.Any<Skärmposition>());
        }

        [Test]
        public void VisaSpelvärld_borde_visa_fienden()
        {
            // Arrange
            var fiendegrafik = Substitute.For<IGrafik>();
            var spelvärld = new SpelvärldMock
            {
                Fienden = new List<Fiende>
                    {
                        new Fiende
                        {
                            Grafik = fiendegrafik,
                            Position = new Spelvärldsposition(2, 3)
                        }
                    }
            };
            var konverterare = Substitute.For<IPositionskonverterare>();
            konverterare.TillPunkt(new Spelvärldsposition(2, 3)).Returns(new Skärmposition(20, 30));
            var visaSpelvärld = new VisaSpelvärld(spelvärld, konverterare);

            // Act
            visaSpelvärld.Visa();

            // Assert
            fiendegrafik.Received().Visa(new Skärmposition(20, 30));
        }

        [Test]
        public void Huvudkaraktären_borde_visas_ovanpå_miljön()
        {
            // Arrange
            var grafik = Substitute.For<IGrafik>();
            var huvudkaraktär = new Huvudkaraktär { Grafik = grafik, Position = new Spelvärldsposition(1, 2) };
            var spelvärld = new SpelvärldMock { MiljöGrafik = grafik, Huvudkaraktär = huvudkaraktär };
            var konverterare = Substitute.For<IPositionskonverterare>();
            konverterare.TillPunkt(new Spelvärldsposition(1, 2)).Returns(new Skärmposition(8, 16));
            var visaSpelvärld = new VisaSpelvärld(spelvärld, konverterare);

            // Act
            visaSpelvärld.Visa();

            // Assert
            grafik.Received().Visa(new Skärmposition(8, 16));
        }
    }
}
