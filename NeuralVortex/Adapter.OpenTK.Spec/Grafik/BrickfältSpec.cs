using Adapter.OpenTK.Grafik;
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
        [Ignore("kolla kamerans synlighetsområde")]
        [Test]
        public void Visar_brickfält_när_en_bricka_syns()
        {
            var gl = new GrafikkommandonMock();
            var kamera = new Kamera(new Skärmyta(4, 4));
            var definitioner = new Bricka[] { new Bricka(gl, kamera, new Skärmposition(4 * 1, 4 * 1), new Skärmyta(4, 4)) };
            var brickstorlek = new Skärmyta(4, 4);
            var kartbredd = 1;
            var karta = new int[] { 0 };
            var konverterare = new Positionskonverterare(brickstorlek);
            var fält = new Brickfält(gl, kamera, konverterare, definitioner, brickstorlek, kartbredd, karta);

            fält.Visa(new Skärmposition(0, 0));

            Assert.That(gl.Hörnverifierare.Count, Is.EqualTo(1));
            Assert.That(gl.Hörnverifierare[0].StämmerHörn1(0, 0));
            Assert.That(gl.Texturverifierare[0].StämmerHörn1(4, 4 + 4));
        }

        [Ignore("kolla kamerans synlighetsområde")]
        [Test]
        public void Visar_brickfält_när_två_brickor_på_bredden_syns()
        {
            var gl = new GrafikkommandonMock();
            var kamera = new Kamera(new Skärmyta(4, 8));
            var definitioner = new Bricka[] {
                new Bricka(gl, kamera, new Skärmposition(4 * 1, 4 * 1), new Skärmyta(4, 4)),
                new Bricka(gl, kamera, new Skärmposition(4 * 2, 4 * 2), new Skärmyta(4, 4))
            };
            var brickstorlek = new Skärmyta(4, 4);
            var kartbredd = 2;
            var karta = new int[] { 0, 1 };
            var konverterare = new Positionskonverterare(brickstorlek);
            var fält = new Brickfält(gl, kamera, konverterare, definitioner, brickstorlek, kartbredd, karta);

            fält.Visa(new Skärmposition(0, 0));

            Assert.That(gl.Hörnverifierare.Count, Is.EqualTo(2), "antal polygoner");
            Assert.That(gl.Hörnverifierare[0].StämmerHörn1(0, 0));
            Assert.That(gl.Texturverifierare[0].StämmerHörn1(4, 4 + 4));

            Assert.That(gl.Hörnverifierare[0].StämmerHörn1(0, 0));
            Assert.That(gl.Texturverifierare[0].StämmerHörn1(4, 4 + 4));
        }
    }
}
