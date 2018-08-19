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
        [TestCase(100, 100, 0)]
        [TestCase(2, 4, 1)]
        [TestCase(80, 100, 10)]
        public void Visar_ramen_för_hälsomätaren_centrerad_på_skärmen(int mätarbredd, int skärmbredd, int x)
        {
            var hälsomätarram = Substitute.For<IGrafik>();
            var hälsomätare = Substitute.For<IGradvisGrafik>();
            var visaStatus = new VisaStatus(hälsomätarram, hälsomätare, new Huvudkaraktär());
            visaStatus.Visa();
            hälsomätarram.Received().VisaCenterBotten();
        }

        [Test]
        public void Visar_full_hälsomätare_när_huvudkaraktären_har_full_hälsa()
        {
            var hälsomätarram = Substitute.For<IGrafik>();
            var hälsomätare = Substitute.For<IGradvisGrafik>();
            var huvudkaraktär = new Huvudkaraktär();
            var visaStatus = new VisaStatus(hälsomätarram, hälsomätare, huvudkaraktär);
            visaStatus.Visa();
            hälsomätare.Received().VisaCenterBotten(new Andel(1.0));
        }

        [TestCase(2, 0.5)]
        [TestCase(3, 0.66)]
        [TestCase(4, 0.75)]
        [TestCase(1, 0.0)]
        public void Visar_inte_full_hälsomätare_när_huvudkaraktären_har_tagit_skada(int maxhälsa, double andel)
        {
            var hälsomätarram = Substitute.For<IGrafik>();
            var hälsomätare = Substitute.For<IGradvisGrafik>();
            var huvudkaraktär = new Huvudkaraktär(maxhälsa);
            huvudkaraktär.Skada();
            var visaStatus = new VisaStatus(hälsomätarram, hälsomätare, huvudkaraktär);
            visaStatus.Visa();
            hälsomätare.Received().VisaCenterBotten(new Andel(andel));
        }

        [TestCase("hälsomätarram")]
        [TestCase("hälsomätare")]
        [TestCase("huvudkaraktär")]
        public void Gör_undantag_från_att_skapas_utan_obligatorisk_parameter(string parameter)
        {
            try
            {
                var hälsomätarram = parameter == "hälsomätarram" ? null : Substitute.For<IGrafik>();
                var hälsomätare = parameter == "hälsomätare" ? null : Substitute.For<IGradvisGrafik>();
                var huvudkaraktär = parameter == "huvudkaraktär" ? null : new Huvudkaraktär();
                new VisaStatus(hälsomätarram, hälsomätare, huvudkaraktär);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain(parameter));
            }
        }
    }
}
