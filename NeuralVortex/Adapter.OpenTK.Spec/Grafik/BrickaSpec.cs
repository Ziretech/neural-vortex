using Adapter.OpenTK.Grafik;
using NUnit.Framework;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Spec.Grafik
{
    [TestFixture]
    public class BrickaSpec
    {
        [Test]
        public void Visar_bild_0_0_16_16_på_position_0_0_på_skärmen()
        {
            var glMock = new GrafikkommandonMock();
            var bricka = new Bricka(glMock, new Kamera(new Skärmyta(1, 1)), new Skärmposition(0, 0), new Skärmyta(16, 16));
            bricka.Visa(new Skärmposition(0, 0));

            Assert.That(glMock.Texturverifierare.Count, Is.EqualTo(1));
            Assert.That(glMock.Texturverifierare[0].StämmerHörn1(0, 16));
            Assert.That(glMock.Texturverifierare[0].StämmerHörn2(16, 0));

            Assert.That(glMock.Hörnverifierare.Count, Is.EqualTo(1));
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn1(0, 0));
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn2(16, 16));
        }

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

        [Test]
        public void Visar_bild_på_20_35_när_brickan_är_vid_30_40_och_kameran_vid_10_5()
        {
            var kamera = new Kamera(new Skärmyta(100, 100), new Skärmposition(10, 5));
            var glMock = new GrafikkommandonMock();
            var bricka = new Bricka(glMock, kamera, new Skärmposition(0, 0), new Skärmyta(16, 16));
            bricka.Visa(new Skärmposition(30, 40));

            Assert.That(glMock.Hörnverifierare.Count, Is.EqualTo(1), "Antal fyrkanter stämmer inte");
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn1(20, 35), "Position stämmer inte");
        }

        [Test]
        public void Har_dimensioner()
        {
            var kamera = new Kamera(new Skärmyta(100, 100), new Skärmposition(10, 5));
            var glMock = new GrafikkommandonMock();
            var bricka = new Bricka(glMock, kamera, new Skärmposition(0, 0), new Skärmyta(16, 16));

            Assert.That(bricka.Dimensioner, Is.EqualTo(new Skärmyta(16, 16)));
        }

        [TestCase(1, 2)]
        [TestCase(16, 9)]
        public void Utan_kamera_görs_ingen_transformation(int x, int y)
        {
            var glMock = new GrafikkommandonMock();
            var bricka = new Bricka(glMock, new Skärmposition(4, 5), new Skärmyta(16, 16));
            bricka.Visa(new Skärmposition(x, y));

            Assert.That(glMock.Hörnverifierare.Count, Is.EqualTo(1), "Antal fyrkanter");
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn1(x, y));
        }

        [TestCase(1.0, 16, 16)]
        [TestCase(0.5, 16, 8)]
        [TestCase(0.5, 10, 5)]
        public void Visar_del_av_bilden(double procent, int maxBredd, int bredd)
        {
            var glMock = new GrafikkommandonMock();
            var bricka = new Bricka(glMock, new Skärmposition(0, 0), new Skärmyta(maxBredd, 16));
            bricka.Visa(new Skärmposition(0, 0), new Andel(procent));

            Assert.That(glMock.Texturverifierare.Count, Is.EqualTo(1), "Antal fyrhörningar (textur)");
            Assert.That(glMock.Texturverifierare[0].StämmerHörn1(0, 16), "Texturhörn 1");
            Assert.That(glMock.Texturverifierare[0].StämmerHörn2(bredd, 0), "Texturhörn 2");

            Assert.That(glMock.Hörnverifierare.Count, Is.EqualTo(1), "Antal fyrhörningar (bild)");
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn1(0, 0), "Bildhörn 1");
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn2(bredd, 16), "Bildhörn 2");
        }

        [Test]
        public void Visar_inte_bilden_om_delen_som_ska_visas_är_mindre_än_1()
        {
            var glMock = new GrafikkommandonMock();
            var bricka = new Bricka(glMock, new Skärmposition(0, 0), new Skärmyta(16, 16));
            bricka.Visa(new Skärmposition(0, 0), new Andel(1.0 / 16.0 - 0.01));

            Assert.That(glMock.Texturverifierare.Count, Is.EqualTo(0));
        }

        // REFACTOR Tag bort Kamera (och ansvaret att transformera) ur Bricka. Låt istället anroparen ha ansvaret. Undersök om det blir problem för Brickfält.
        // REFACTOR Kolla över tester för Skärmområde, Spelvärldsområde och Område...
    }
}