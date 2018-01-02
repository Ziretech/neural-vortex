using NUnit.Framework;
using System;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Spec
{
    [TestFixture]
    public class GrafikSpec
    {
        [Test]
        public void Grafik_borde_visa_en_bild_på_angiven_position()
        {
            var grafik = new Grafik();
            grafik.Visa(new Skärmposition(20, 30));
        }
    }
}
