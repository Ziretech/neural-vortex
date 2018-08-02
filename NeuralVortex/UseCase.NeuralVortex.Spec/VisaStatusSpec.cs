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
            var kamera = new Kamera(new Skärmyta(skärmbredd, 100));
            var visaStatus = new VisaStatus(kamera, hälsomätarram);
            visaStatus.Visa();
            Assert.That(hälsomätarram.HarVisatsPåPosition, Is.EqualTo(new Skärmposition(x, 0)));
        }

        [Test]
        [Ignore("Fundera på problemet nedan...")]
        public void Visar_full_hälsomätare_när_huvudkaraktären_har_full_hälsa()
        {
            //var hälsomätarram = new GrafikMock(new Skärmyta(16, 16));
            //var hälsomätare = new GrafikMock(new Skärmyta(16, 16));
            //var kamera = new Kamera(new Skärmyta(16, 16));
            //var visaStatus = new VisaStatus(kamera, hälsomätarram, hälsomätare);
            //visaStatus.Visa();
            //Assert.That(hälsomätare.HarVisatsPåPosition, Is.EqualTo(new Skärmposition(0, 0)));
            //Assert.That(hälsomätare.HarVisatsMedOmråde, Is.EqualTo(new Skärmområde(new Skärmyta(16, 16))));
        }

        // Problem: Vi behöver ett gränssnitt för att styra grafik som har parametrar för visningen... Att lägga till Visning på Bricka hjälpte alltså inte alls... och det är dålig CA.
        // UC behöver kunna berätta för grafiken att anpassa visningen beroende på ett värde
        // UC vill inte veta exakt hur många pixlar mätaren handlar om...
        // I vissa fall kan man tänka sig mätare med diskreta värden dock
        // Men en procentmätare borde absolut vara ange input som procent...

        // Hur mycket ska finnas i adaptern? UC styr vilka mätare som ska visas och när...

        // FIXA Vertikalt justerande bricka som implementerar interfacet ovan
        // FIXA VisaStatus visar hälsomätaren hur mycket hälsa huvudkaraktären har kvar
        // FIXA VisaStatus kollar konstruktorargument

        // REFACTOR Behövs IKamera eller bör den tas bort?
        // REFACTOR Gillar verkligen inte att IGrafik berättar om bredd/höjd, varför ska UC känna till det? Lämpa över beräkningarna till grafikadaptern istället.
    }
}
