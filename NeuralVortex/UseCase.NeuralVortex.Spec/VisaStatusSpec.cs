using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture(TestOf = typeof(VisaStatus))]
    public class VisaStatusSpec
    {
        [Test]
        public void Visar_ramen_för_hälsomätaren_centrerad_på_skärmen()
        {
            var hälsomätarram = Substitute.For<IGrafik>();
            var hälsomätare = Substitute.For<IGradvisGrafik>();
            var skärm = Substitute.For<ISkärm>();
            var dimensioner = new Skärmyta(1, 2);
            var beräknadPosition = new Skärmposition(3, 4);
            hälsomätarram.Dimensioner.Returns(dimensioner);
            skärm.PositionCentreradIBotten(dimensioner).Returns(beräknadPosition);

            new VisaStatus(hälsomätarram, hälsomätare, new Huvudkaraktär(), skärm)
                .Visa();

            hälsomätarram.Received().Visa(beräknadPosition);
        }

        [Test]
        public void Visar_full_hälsomätare_när_huvudkaraktären_har_full_hälsa()
        {
            var hälsomätarram = Substitute.For<IGrafik>();
            var hälsomätare = Substitute.For<IGradvisGrafik>();
            var skärm = Substitute.For<ISkärm>();
            var dimensioner = new Skärmyta(1, 2);
            var beräknadPosition = new Skärmposition(3, 4);
            hälsomätarram.Dimensioner.Returns(dimensioner);
            skärm.PositionCentreradIBotten(dimensioner).Returns(beräknadPosition);

            new VisaStatus(hälsomätarram, hälsomätare, new Huvudkaraktär(), skärm)
                .Visa();

            hälsomätare.Received().Visa(beräknadPosition, new Andel(1.0));
        }

        [TestCase(2, 0.5)]
        [TestCase(3, 0.66)]
        [TestCase(4, 0.75)]
        [TestCase(1, 0.0)]
        public void Visar_inte_full_hälsomätare_när_huvudkaraktären_har_tagit_skada(int maxhälsa, double andel)
        {
            var hälsomätarram = Substitute.For<IGrafik>();
            var hälsomätare = Substitute.For<IGradvisGrafik>();
            var skärm = Substitute.For<ISkärm>();
            var dimensioner = new Skärmyta(1, 2);
            var beräknadPosition = new Skärmposition(3, 4);
            hälsomätarram.Dimensioner.Returns(dimensioner);
            skärm.PositionCentreradIBotten(dimensioner).Returns(beräknadPosition);
            var huvudkaraktär = new Huvudkaraktär(maxhälsa);
            huvudkaraktär.Skada();

            new VisaStatus(hälsomätarram, hälsomätare, huvudkaraktär, skärm)
                .Visa();

            hälsomätare.Received().Visa(beräknadPosition, new Andel(andel));
        }

        [TestCase("hälsomätarram")]
        [TestCase("hälsomätare")]
        [TestCase("huvudkaraktär")]
        [TestCase("skärm")]
        public void Gör_undantag_från_att_skapas_utan_obligatorisk_parameter(string parameter)
        {
            try
            {
                var hälsomätarram = parameter == "hälsomätarram" ? null : Substitute.For<IGrafik>();
                var hälsomätare = parameter == "hälsomätare" ? null : Substitute.For<IGradvisGrafik>();
                var huvudkaraktär = parameter == "huvudkaraktär" ? null : new Huvudkaraktär();
                var skärm = parameter == "skärm" ? null : Substitute.For<ISkärm>();
                new VisaStatus(hälsomätarram, hälsomätare, huvudkaraktär, skärm);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain(parameter));
            }
        }
    }
}
