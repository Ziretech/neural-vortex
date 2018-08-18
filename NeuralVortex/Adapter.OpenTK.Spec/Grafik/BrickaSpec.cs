using Adapter.OpenTK.Grafik;
using NUnit.Framework;
using System;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Spec.Grafik
{
    [TestFixture]
    [TestOf(typeof(Bricka))]
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

        [TestCase(0, 0, 0, 0, 0, 0)]
        [TestCase(1, 2, 0, 0, 1, 2)]
        [TestCase(1, 2, 3, 4, 4, 6)]
        public void Kan_skapas_med_brickans_centrum_angivet(int centrumX, int centrumY, int visaX, int visaY, int resultatX, int resultatY)
        {
            var glMock = new GrafikkommandonMock();
            var bricka = new Bricka(glMock, new Skärmposition(0, 0), new Skärmyta(16, 16), new Skärmposition(centrumX, centrumY));
            bricka.Visa(new Skärmposition(visaX, visaY));

            Assert.That(glMock.Hörnverifierare.Count, Is.EqualTo(1));
            Assert.That(glMock.Hörnverifierare[0].StämmerHörn1(resultatX, resultatY));
        }

        private Bricka AnropaKonstruktor(int konstruktor, IGrafikkommandon glMock, Kamera kamera, Skärmposition texturPosition, Skärmyta dimensioner, Skärmposition centrum)
        {
            switch (konstruktor)
            {
                case 1:
                    return new Bricka(glMock, texturPosition, dimensioner);
                case 2:
                    return new Bricka(glMock, kamera, texturPosition, dimensioner);
                case 3:
                    return new Bricka(glMock, texturPosition, dimensioner, centrum);
                case 4:
                    return new Bricka(glMock, kamera, texturPosition, dimensioner, centrum);
            }
            return null;
        }
                
        [Test]
        public void Gör_undantag_från_att_skapas_utan_obligatorisk_parameter([Range(1, 4)] int konstruktor, [Values("grafikkommando", "texturposition", "dimensioner")] string parameter)
        {
            var glMock = parameter == "grafikkommando" ? null : new GrafikkommandonMock();
            var kamera = new Kamera(new Skärmyta(100, 100), new Skärmposition(10, 5));
            var texturposition = parameter == "texturposition" ? null : new Skärmposition(0, 0);
            var dimensioner = parameter == "dimensioner" ? null : new Skärmyta(16, 16);

            try
            {
                AnropaKonstruktor(konstruktor, glMock, kamera, texturposition, dimensioner, new Skärmposition(0, 0));
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain(parameter));
            }
        }

        // FIXA Tester för att visa på center botten
        // FIXA Tester för att visa på center botten med andel

        // REFACTOR Tag bort Kamera (och ansvaret att transformera) ur Bricka. Låt istället anroparen ha ansvaret. Undersök om det blir problem för Brickfält.
        // REFACTOR Kolla över tester för Skärmområde, Spelvärldsområde och Område...
    }
}