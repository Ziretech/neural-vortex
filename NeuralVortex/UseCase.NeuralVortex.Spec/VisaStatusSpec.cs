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

        // TODO VisaStatus visar innehållet för hälsomätaren beroende på hur mycket hälsa huvudkaraktären har
        // TODO VisaStatus kollar konstruktorargument
        // TODO [R] Behövs IKamera eller bör den tas bort?
    }
}
