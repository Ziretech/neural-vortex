using Adapter.OpenTK.Grafik;
using NUnit.Framework;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Spec.Grafik
{
    [TestFixture]
    public class GrafikSpec
    {
        [Test]
        public void Visar_bild_1_2_10_20_på_position_20_30_på_skärmen()
        {
            var glMock = new GrafikkommandonMock();
            var bricka = new Bricka(glMock, new Kamera(new Skärmyta(1, 1)), new Skärmposition(1, 2), new Skärmyta(10, 20));
            bricka.Visa(new Skärmposition(20, 30));

            Assert.That(glMock.Texturverifierare.Count, Is.EqualTo(1));
            Assert.That(glMock.Texturverifierare[0].StämmerHörn1(1, 22));
            Assert.That(glMock.Texturverifierare[0].StämmerHörn2(11, 2));

            Assert.That(glMock.Hörnverifierare.Count, Is.EqualTo(1));
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn1(20, 30));
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn2(30, 50));
        }

        [Ignore("Kamera.Tranformera behövs")]
        [Test]
        public void Visar_bild_på_20_30_när_brickan_är_vid_30_40_och_kameran_vid_10_10()
        {
            var kamera = new Kamera(new Skärmyta(100, 100), new Skärmposition(10, 10));
            var glMock = new GrafikkommandonMock();
            var bricka = new Bricka(glMock, kamera, new Skärmposition(0, 0), new Skärmyta(16, 16));
            bricka.Visa(new Skärmposition(30, 40));

            Assert.That(glMock.Hörnverifierare.Count, Is.EqualTo(1), "Antal fyrkanter stämmer inte");
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn1(20, 30), "Position stämmer inte");
        }
    }
}