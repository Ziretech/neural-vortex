using Adapter.OpenTK.Grafik;
using NSubstitute;
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
        [TestCase(0, 0)]
        [TestCase(4, 9)]
        [TestCase(1234, 9876)]
        public void Visar_bild_med_rätt_texturpunkt(int x, int y)
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var bricka = new Bricka(gl, new Skärmposition(x, y), new Skärmyta(1, 1));
            bricka.Visa(new Skärmposition(0, 0));
            gl.Received().KopieraTexturrektangelTillRityta(x, y, 0, 0, 1, 1);
        }

        [TestCase(1, 1)]
        [TestCase(16, 16)]
        [TestCase(123, 789)]
        public void Visar_bild_med_rätt_dimensioner(int bredd, int höjd)
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var bricka = new Bricka(gl, new Skärmposition(0, 0), new Skärmyta(bredd, höjd));
            bricka.Visa(new Skärmposition(0, 0));
            gl.Received().KopieraTexturrektangelTillRityta(0, 0, 0, 0, bredd, höjd);
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(4, 6)]
        public void Visar_bild_på_rätt_skärmposition(int x, int y)
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var bricka = new Bricka(gl, new Skärmposition(0, 0), new Skärmyta(1, 1));
            bricka.Visa(new Skärmposition(x, y));
            gl.Received().KopieraTexturrektangelTillRityta(0, 0, x, y, 1, 1);
        }

        [Test]
        public void Har_dimensioner()
        {
            var glMock = Substitute.For<IGrafikkommandon>();
            var bricka = new Bricka(glMock, new Skärmposition(0, 0), new Skärmyta(16, 16));

            Assert.That(bricka.Dimensioner, Is.EqualTo(new Skärmyta(16, 16)));
        }

        [TestCase(1.0, 16, 16)]
        [TestCase(0.5, 16, 8)]
        [TestCase(0.5, 10, 5)]
        public void Visar_bilden_över_angiven_andel_av_skärmen(double procent, int maxBredd, int bredd)
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var bricka = new Bricka(gl, new Skärmposition(0, 0), new Skärmyta(maxBredd, 16));
            bricka.Visa(new Skärmposition(0, 0), new Andel(procent));
            gl.Received().KopieraTexturrektangelTillRityta(0, 0, 0, 0, bredd, 16);
        }

        [TestCase(1.0, 16, 16)]
        [TestCase(0.5, 16, 8)]
        [TestCase(0.5, 10, 5)]
        public void Visar_bilden_klippt_enligt_andel(double procent, int maxBredd, int bredd)
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var bricka = new Bricka(gl, new Skärmposition(0, 0), new Skärmyta(maxBredd, 16));
            bricka.Visa(new Skärmposition(0, 0), new Andel(procent));
            gl.Received().KopieraTexturrektangelTillRityta(0, 0, 0, 0, bredd, 16);
        }

        [Test]
        public void Visar_inte_bilden_om_delen_som_ska_visas_är_mindre_än_1()
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var bricka = new Bricka(gl, new Skärmposition(0, 0), new Skärmyta(16, 16));
            bricka.Visa(new Skärmposition(0, 0), new Andel(1.0 / 16.0 - 0.01));
            gl.DidNotReceive().DefinieraFyrkanter();
        }

        [Test]
        public void Gör_undantag_från_att_skapas_utan_obligatorisk_parameter([Range(1, 4)] int konstruktor, [Values("grafikkommando", "texturposition", "dimensioner")] string parameter)
        {
            var gl = parameter == "grafikkommando" ? null : Substitute.For<IGrafikkommandon>();
            var texturposition = parameter == "texturposition" ? null : new Skärmposition(0, 0);
            var dimensioner = parameter == "dimensioner" ? null : new Skärmyta(16, 16);

            try
            {
                new Bricka(gl, texturposition, dimensioner);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain(parameter));
            }
        }

        // REFACTOR Kolla över tester för Skärmområde, Spelvärldsområde och Område...
    }
}