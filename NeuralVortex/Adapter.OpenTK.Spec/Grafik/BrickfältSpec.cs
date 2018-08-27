using Adapter.OpenTK.Grafik;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Spelvärld;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Spec.Grafik
{
    [TestFixture]
    public class BrickfältSpec
    {
        [TestCase(0, 0)]
        [TestCase(3, 3)]
        [TestCase(12, 34)]
        public void Visa_enda_brickan_i_1x1_brickfält_på_position(int x, int y)
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var brickstorlek = new Skärmyta(1, 1);
            var definitioner = new Bricka[] { new Bricka(gl, new Skärmposition(0, 0), brickstorlek) };            
            var karta = new int[] { 0 };
            var fält = new Brickfält(definitioner, karta, 1, brickstorlek);

            fält.Visa(new Skärmposition(x, y));

            gl.Received().KopieraTexturrektangelTillRityta(0, 0, x, y, 1, 1);
        }

        [Test]
        public void Visa_andra_brickan_i_1x1_brickfält()
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var brickstorlek = new Skärmyta(1, 1);
            var definitioner = new Bricka[] {
                new Bricka(gl, new Skärmposition(0, 0), brickstorlek),
                new Bricka(gl, new Skärmposition(11, 22), brickstorlek) };
            var karta = new int[] { 1 };
            var fält = new Brickfält(definitioner, karta, 1, brickstorlek);

            fält.Visa(new Skärmposition(0, 0));

            gl.Received().KopieraTexturrektangelTillRityta(11, 22, 0, 0, 1, 1);
        }

        [Test]
        public void Visar_två_brickor_i_1x2_brickfält()
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var brickstorlek = new Skärmyta(2, 2);
            var definitioner = new Bricka[] {
                new Bricka(gl, new Skärmposition(1, 2), brickstorlek),
                new Bricka(gl, new Skärmposition(3, 4), brickstorlek) };
            var karta = new int[] { 0, 1 };
            var fält = new Brickfält(definitioner, karta, 1, brickstorlek);

            fält.Visa(new Skärmposition(0, 0));

            Received.InOrder(() =>
            {
                gl.KopieraTexturrektangelTillRityta(1, 2, 0, 0, 2, 2);
                gl.KopieraTexturrektangelTillRityta(3, 4, 0, 2, 2, 2);
            });
        }

        [Test]
        public void Visar_två_brickor_i_1x3_brickfält()
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var brickstorlek = new Skärmyta(2, 2);
            var definitioner = new Bricka[] {
                new Bricka(gl, new Skärmposition(1, 2), brickstorlek),
                new Bricka(gl, new Skärmposition(3, 4), brickstorlek) };
            var karta = new int[] { 0, 1, 0 };
            var fält = new Brickfält(definitioner, karta, 1, brickstorlek);

            fält.Visa(new Skärmposition(0, 0));

            Received.InOrder(() =>
            {
                gl.KopieraTexturrektangelTillRityta(1, 2, 0, 0, 2, 2);
                gl.KopieraTexturrektangelTillRityta(3, 4, 0, 2, 2, 2);
                gl.KopieraTexturrektangelTillRityta(1, 2, 0, 4, 2, 2);
            });
        }

        [Test]
        public void Visar_fyra_brickor_i_2x2_brickfält()
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var brickstorlek = new Skärmyta(4, 4);
            var definitioner = new Bricka[] {
                new Bricka(gl, new Skärmposition(1, 2), brickstorlek),
                new Bricka(gl, new Skärmposition(3, 4), brickstorlek) };
            var karta = new int[] { 0, 1, 0, 1 };
            var fält = new Brickfält(definitioner, karta, 2, brickstorlek);

            fält.Visa(new Skärmposition(0, 0));

            Received.InOrder(() =>
            {
                gl.KopieraTexturrektangelTillRityta(1, 2, 0, 0, 4, 4);
                gl.KopieraTexturrektangelTillRityta(3, 4, 4, 0, 4, 4);
                gl.KopieraTexturrektangelTillRityta(1, 2, 0, 4, 4, 4);
                gl.KopieraTexturrektangelTillRityta(3, 4, 4, 4, 4, 4);
            });
        }

        // FIXA Testa konstruktorparametrar


        [Test]
        public void Visar_brickfält_där_typ_bestäms_av_kartan()
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var definitioner = new Bricka[] {
                new Bricka(gl, new Skärmposition(4 * 1, 4 * 1), new Skärmyta(4, 4)),
                new Bricka(gl, new Skärmposition(4 * 2, 4 * 1), new Skärmyta(4, 4))
            };
            var brickstorlek = new Skärmyta(4, 4);
            var kartbredd = 2;
            var karta = new int[] { 0, 1 };
            var fält = new Brickfält(definitioner, karta, kartbredd, brickstorlek);

            fält.Visa(new Skärmposition(0, 0));

            Received.InOrder(() =>
            {
                gl.KopieraTexturrektangelTillRityta(4, 4, 0, 0, 4, 4);
                gl.KopieraTexturrektangelTillRityta(8, 4, 4, 0, 4, 4);
            });
        }

        [Test]
        public void Visar_brickfält_där_kameran_går_utanför_kartan()
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var kamera = new Kamera(new Skärmyta(8, 8));
            var definitioner = new Bricka[] {
                new Bricka(gl, new Skärmposition(4 * 1, 4 * 1), new Skärmyta(4, 4))
            };
            var brickstorlek = new Skärmyta(4, 4);
            var kartbredd = 1;
            var karta = new int[] { 0 };
            var fält = new Brickfält(definitioner, karta, kartbredd, brickstorlek);

            fält.Visa(new Skärmposition(0, 0));

            gl.Received().KopieraTexturrektangelTillRityta(4, 4, 0, 0, 4, 4);
        }

        [TestCase(4, 4)]
        [TestCase(1, 2)]
        public void Har_samma_dimensioner_som_rutan_när_det_bara_är_en_ruta(int x, int y)
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var brickstorlek = new Skärmyta(x, y);
            var definitioner = new Bricka[] {
                new Bricka(gl, new Skärmposition(0, 0), brickstorlek)
            };
            var fält = new Brickfält(definitioner, new int[] { 0 }, 1, brickstorlek);

            Assert.That(fält.Dimensioner, Is.EqualTo(new Skärmyta(x, y)));
        }

        [Test]
        [Ignore("Skärmyta behöver kunna multiplicera")]
        public void Har_samma_dimensioner_som_rutans_storlek_multiplicerad_med_kartans_dimensioner()
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var brickstorlek = new Skärmyta(4, 4);
            var definitioner = new Bricka[] {
                new Bricka(gl, new Skärmposition(0, 0), brickstorlek)
            };
            var karta = new int[6];
            var fält = new Brickfält(definitioner, karta, 3, brickstorlek);

            Assert.That(fält.Dimensioner, Is.EqualTo(new Skärmyta(12, 8)));
        }

        [Test]
        [Ignore("Tidigare tester")]
        public void Har_dimensioner_8x15_när_brickfältet_är_2x3_4x5_rutor()
        {
            var gl = Substitute.For<IGrafikkommandon>();
            var kamera = new Kamera(new Skärmyta(20, 20), new Skärmposition(0, 0));
            var definitioner = new Bricka[] {
                new Bricka(gl, new Skärmposition(0, 0), new Skärmyta(4, 5))
            };
            var brickstorlek = new Skärmyta(4, 5);
            var kartbredd = 2;
            var karta = new int[] { 0, 0, 0, 0, 0, 0 };
            var fält = new Brickfält(definitioner, karta, kartbredd, brickstorlek);

            Assert.That(fält.Dimensioner, Is.EqualTo(new Skärmyta(8, 15)));
        }
    }
}
