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
    [TestFixture]
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
            var hälsomätarram = new GrafikMock(new Skärmyta(16, 16));
            var hälsomätare = new GrafikMock(new Skärmyta(16, 16));
            var huvudkaraktär = new Huvudkaraktär();
            var visaStatus = new VisaStatus(hälsomätarram, hälsomätare, huvudkaraktär);
            visaStatus.Visa();
            Assert.That(hälsomätare.HarVisatsPåCenterBottenMedAndel, Is.EqualTo(new Andel(1.0)));
        }

        [TestCase(2, 0.5)]
        [TestCase(3, 0.66)]
        [TestCase(4, 0.75)]
        [TestCase(1, 0.0)]
        public void Visar_inte_full_hälsomätare_när_huvudkaraktären_har_tagit_skada(int maxhälsa, double andel)
        {
            var hälsomätarram = new GrafikMock(new Skärmyta(16, 16));
            var hälsomätare = new GrafikMock(new Skärmyta(16, 16));
            var huvudkaraktär = new Huvudkaraktär(maxhälsa);
            huvudkaraktär.Skada();
            var visaStatus = new VisaStatus(hälsomätarram, hälsomätare, huvudkaraktär);
            visaStatus.Visa();
            Assert.That(hälsomätare.HarVisatsPåCenterBottenMedAndel, Is.EqualTo(new Andel(andel)));
        }

        // FIXA VisaStatus kollar konstruktorargument

        // REFACTOR Ta bort alla mockar i applikationen och använd NSubstitute istället.
        // REFACTOR Behövs IKamera eller bör den tas bort?
        // REFACTOR Gillar verkligen inte att IGrafik berättar om bredd/höjd, varför ska UC känna till det? Lämpa över beräkningarna till grafikadaptern istället.
    }
}
