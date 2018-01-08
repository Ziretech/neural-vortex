﻿using Adapter.OpenTK.Grafik;
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
            var fält = new Brickfält(gl, kamera, konverterare, definitioner, kartbredd, karta);

            fält.Visa(new Skärmposition(0, 0));

            Assert.That(gl.Hörnverifierare.Count, Is.EqualTo(1));
            Assert.That(gl.Hörnverifierare[0].StämmerHörn1(0, 0));
            Assert.That(gl.Texturverifierare[0].StämmerHörn1(4, 4 + 4));
        }

        [Test]
        public void Visar_brickfält_när_två_brickor_på_bredden_syns()
        {
            var gl = new GrafikkommandonMock();
            var kamera = new Kamera(new Skärmyta(8, 4));
            var definitioner = new Bricka[] {
                new Bricka(gl, kamera, new Skärmposition(4 * 1, 4 * 1), new Skärmyta(4, 4))
            };
            var brickstorlek = new Skärmyta(4, 4);
            var kartbredd = 2;
            var karta = new int[] { 0, 0 };
            var konverterare = new Positionskonverterare(brickstorlek);
            var fält = new Brickfält(gl, kamera, konverterare, definitioner, kartbredd, karta);

            fält.Visa(new Skärmposition(0, 0));

            Assert.That(gl.Hörnverifierare.Count, Is.EqualTo(2), "antal polygoner");
            Assert.That(gl.Hörnverifierare[0].StämmerHörn1(0, 0), "1 hörn1");
            Assert.That(gl.Hörnverifierare[0].StämmerHörn2(4, 4), "1 hörn2");
            Assert.That(gl.Hörnverifierare[1].StämmerHörn1(4, 0), "2 hörn1");
            Assert.That(gl.Hörnverifierare[1].StämmerHörn2(8, 4), "2 hörn2");
        }

        [Test]
        public void Visar_brickfält_när_två_brickor_på_höjden_syns()
        {
            var gl = new GrafikkommandonMock();
            var kamera = new Kamera(new Skärmyta(4, 8));
            var definitioner = new Bricka[] {
                new Bricka(gl, kamera, new Skärmposition(4 * 1, 4 * 1), new Skärmyta(4, 4))
            };
            var brickstorlek = new Skärmyta(4, 4);
            var kartbredd = 1;
            var karta = new int[] { 0, 0 };
            var konverterare = new Positionskonverterare(brickstorlek);
            var fält = new Brickfält(gl, kamera, konverterare, definitioner, kartbredd, karta);

            fält.Visa(new Skärmposition(0, 0));

            Assert.That(gl.Hörnverifierare.Count, Is.EqualTo(2), "antal polygoner");
            Assert.That(gl.Hörnverifierare[0].StämmerHörn1(0, 0), "1 hörn1");
            Assert.That(gl.Hörnverifierare[0].StämmerHörn2(4, 4), "1 hörn2");
            Assert.That(gl.Hörnverifierare[1].StämmerHörn1(0, 4), "2 hörn1");
            Assert.That(gl.Hörnverifierare[1].StämmerHörn2(4, 8), "2 hörn2");
        }

        [Test]
        public void Visar_brickfält_när_2x2_brickor_syns()
        {
            var gl = new GrafikkommandonMock();
            var kamera = new Kamera(new Skärmyta(8, 8));
            var definitioner = new Bricka[] {
                new Bricka(gl, kamera, new Skärmposition(4 * 1, 4 * 1), new Skärmyta(4, 4))
            };
            var brickstorlek = new Skärmyta(4, 4);
            var kartbredd = 2;
            var karta = new int[] { 0, 0, 0, 0 };
            var konverterare = new Positionskonverterare(brickstorlek);
            var fält = new Brickfält(gl, kamera, konverterare, definitioner, kartbredd, karta);

            fält.Visa(new Skärmposition(0, 0));

            Assert.That(gl.Hörnverifierare.Count, Is.EqualTo(4), "antal polygoner");
            Assert.That(gl.Hörnverifierare[0].StämmerHörn1(0, 0), "bricka 1");
            Assert.That(gl.Hörnverifierare[1].StämmerHörn1(4, 0), "bricka 2");
            Assert.That(gl.Hörnverifierare[2].StämmerHörn1(0, 4), "bricka 3");
            Assert.That(gl.Hörnverifierare[3].StämmerHörn1(4, 4), "bricka 4");
        }

        [Test]
        public void Visar_brickfält_där_typ_bestäms_av_kartan()
        {
            var gl = new GrafikkommandonMock();
            var kamera = new Kamera(new Skärmyta(8, 4));
            var definitioner = new Bricka[] {
                new Bricka(gl, kamera, new Skärmposition(4 * 1, 4 * 1), new Skärmyta(4, 4)),
                new Bricka(gl, kamera, new Skärmposition(4 * 2, 4 * 1), new Skärmyta(4, 4))
            };
            var brickstorlek = new Skärmyta(4, 4);
            var kartbredd = 2;
            var karta = new int[] { 0, 1 };
            var konverterare = new Positionskonverterare(brickstorlek);
            var fält = new Brickfält(gl, kamera, konverterare, definitioner, kartbredd, karta);

            fält.Visa(new Skärmposition(0, 0));

            Assert.That(gl.Hörnverifierare.Count, Is.EqualTo(2), "antal polygoner");
            Assert.That(gl.Hörnverifierare[0].StämmerHörn1(0, 0), "bricka 1");
            Assert.That(gl.Texturverifierare[0].StämmerHörn1(4, 8), "bricka 2 - texturhörn 1");
            Assert.That(gl.Texturverifierare[0].StämmerHörn2(8, 4), "bricka 2 - texturhörn 2");
            Assert.That(gl.Hörnverifierare[1].StämmerHörn1(4, 0), "bricka 2");
            Assert.That(gl.Texturverifierare[1].StämmerHörn1(8, 8), "bricka 2 - texturhörn 1");
            Assert.That(gl.Texturverifierare[1].StämmerHörn2(12, 4), "bricka 2 - texturhörn 2");
        }

        [Test]
        public void Visar_brickfält_där_kameran_går_utanför_kartan()
        {
            var gl = new GrafikkommandonMock();
            var kamera = new Kamera(new Skärmyta(8, 8));
            var definitioner = new Bricka[] {
                new Bricka(gl, kamera, new Skärmposition(4 * 1, 4 * 1), new Skärmyta(4, 4))
            };
            var brickstorlek = new Skärmyta(4, 4);
            var kartbredd = 1;
            var karta = new int[] { 0 };
            var konverterare = new Positionskonverterare(brickstorlek);
            var fält = new Brickfält(gl, kamera, konverterare, definitioner, kartbredd, karta);

            fält.Visa(new Skärmposition(0, 0));

            Assert.That(gl.Hörnverifierare.Count, Is.EqualTo(1), "antal polygoner");
            Assert.That(gl.Hörnverifierare[0].StämmerHörn1(0, 0), "bricka");
        }

        [Test]
        public void Visar_brickfält_förskjutet_när_kameran_flyttats()
        {
            var gl = new GrafikkommandonMock();
            var kamera = new Kamera(new Skärmyta(8, 8), new Skärmposition(2, 2));
            var definitioner = new Bricka[] {
                new Bricka(gl, kamera, new Skärmposition(4 * 1, 4 * 1), new Skärmyta(4, 4))
            };
            var brickstorlek = new Skärmyta(4, 4);
            var kartbredd = 1;
            var karta = new int[] { 0 };
            var konverterare = new Positionskonverterare(brickstorlek);
            var fält = new Brickfält(gl, kamera, konverterare, definitioner, kartbredd, karta);

            fält.Visa(new Skärmposition(0, 0));

            Assert.That(gl.Hörnverifierare.Count, Is.EqualTo(1), "antal polygoner");
            Assert.That(gl.Hörnverifierare[0].StämmerHörn1(-2, -2), "bricka");
        }

        [Test]
        public void Visar_inte_bricka_som_inte_syns()
        {
            var gl = new GrafikkommandonMock();
            var kamera = new Kamera(new Skärmyta(8, 8), new Skärmposition(4, 4));
            var definitioner = new Bricka[] {
                new Bricka(gl, kamera, new Skärmposition(4 * 1, 4 * 1), new Skärmyta(4, 4))
            };
            var brickstorlek = new Skärmyta(4, 4);
            var kartbredd = 1;
            var karta = new int[] { 0 };
            var konverterare = new Positionskonverterare(brickstorlek);
            var fält = new Brickfält(gl, kamera, konverterare, definitioner, kartbredd, karta);

            fält.Visa(new Skärmposition(0, 0));

            Assert.That(gl.Hörnverifierare.Count, Is.EqualTo(0), "antal polygoner");
        }
    }
}
