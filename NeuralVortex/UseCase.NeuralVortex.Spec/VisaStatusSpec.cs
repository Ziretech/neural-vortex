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
            var hälsomätarram = new GrafikMock(new Skärmyta(mätarbredd, 16));
            var hälsomätare = new GrafikMock(new Skärmyta(16, 16));
            var kamera = new Kamera(new Skärmyta(skärmbredd, 100));
            var visaStatus = new VisaStatus(kamera, hälsomätarram, hälsomätare);
            visaStatus.Visa();
            Assert.That(hälsomätarram.HarVisatsPåCenterBotten, Is.True);
        }

        [Test]
        [Ignore("lägg till koppling för huvudkaraktär till VisaStatus")]
        public void Visar_full_hälsomätare_när_huvudkaraktären_har_full_hälsa()
        {
            var hälsomätarram = new GrafikMock(new Skärmyta(16, 16));
            var hälsomätare = new GrafikMock(new Skärmyta(16, 16));
            var kamera = new Kamera(new Skärmyta(16, 16));
            var huvudkaraktär = new Huvudkaraktär();
            var visaStatus = new VisaStatus(kamera, hälsomätarram, hälsomätare/*, huvudkaraktär*/);
            visaStatus.Visa();
            Assert.That(hälsomätare.HarVisatsPåCenterBottenMedAndel, Is.EqualTo(new Andel(1.0)));
        }
        
        // FIXA VisaStatus visar hälsomätaren hur mycket hälsa huvudkaraktären har kvar
        // FIXA VisaStatus kollar konstruktorargument

        // REFACTOR Behövs IKamera eller bör den tas bort?
        // REFACTOR Gillar verkligen inte att IGrafik berättar om bredd/höjd, varför ska UC känna till det? Lämpa över beräkningarna till grafikadaptern istället.
    }
}
