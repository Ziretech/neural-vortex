using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec.Spelvärld
{
    [TestFixture]
    public class SpelvärldspositionSpec
    {
        [Test]
        public void Har_angiven_x_position()
        {
            var position = new Spelvärldsposition(1, 2);
            Assert.That(position.X, Is.EqualTo(1));
        }

        [Test]
        public void Har_angiven_y_position()
        {
            var position = new Spelvärldsposition(1, 2);
            Assert.That(position.Y, Is.EqualTo(2));
        }

        [TestCase(1, 2, 10, 20, 11, 22)]
        [TestCase(1, 2, 5, 8, 6, 10)]
        public void Addera_positioner(int x1, int y1, int x2, int y2, int resultatX, int resultatY)
        {
            var förstaPositionen = new Spelvärldsposition(x1, y1);
            var andraPositionen = new Spelvärldsposition(x2, y2);

            var resultat = förstaPositionen.Plus(andraPositionen);

            Assert.That(resultat, Is.EqualTo(new Spelvärldsposition(resultatX, resultatY)));
        }

        [TestCase(1, 2, 10, 20, 11, 22)]
        [TestCase(1, 2, 5, 8, 6, 10)]
        public void Addera_position_med_yta(int x, int y, int bredd, int höjd, int resultatX, int resultatY)
        {
            var position = new Spelvärldsposition(x, y);
            var yta = new Spelvärldsyta(bredd, höjd);

            var resultat = position.Plus(yta);

            Assert.That(resultat, Is.EqualTo(new Spelvärldsposition(resultatX, resultatY)));
        }

        [TestCase(1, 2, 0, 0, 1, 2)]
        [TestCase(4, 8, 1, 2, 3, 6)]
        public void Subtrahera_från_position(int x1, int y1, int x2, int y2, int resultatX, int resultatY)
        {
            var förstaPosition = new Spelvärldsposition(x1, y1);
            var andraPosition = new Spelvärldsposition(x2, y2);
            var resultat = förstaPosition.Minus(andraPosition);
            Assert.That(resultat, Is.EqualTo(new Spelvärldsposition(resultatX, resultatY)));
        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 0, 1, 0)]
        [TestCase(14, 9999, 14, 9999)]
        public void Är_likvärdig_med_position_med_samma_x_y_värden(int p1x, int p1y, int p2x, int p2y)
        {
            Assert.That(new Spelvärldsposition(p1x, p1y).Equals(new Spelvärldsposition(p2x, p2y)));
        }

        [TestCase(0, 0, 1, 0)]
        [TestCase(0, 0, 0, 1)]
        [TestCase(14, 9999, 14, 9998)]
        public void Inte_är_likvärdig_med_position_med_andra_x_y_värden(int p1x, int p1y, int p2x, int p2y)
        {
            Assert.That(new Spelvärldsposition(p1x, p1y).Equals(new Spelvärldsposition(p2x, p2y)) == false);
        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 0, 1, 0)]
        [TestCase(14, 9999, 14, 9999)]
        public void Har_samma_hash_code_när_de_är_likvärdiga(int p1x, int p1y, int p2x, int p2y)
        {
            Assert.That(new Spelvärldsposition(p1x, p1y).GetHashCode(), Is.EqualTo(new Spelvärldsposition(p2x, p2y).GetHashCode()));
        }

        [TestCase(1, 2, "1x2")]
        [TestCase(13, 24, "13x24")]
        public void Beskriver_sig_med_XxY(int x, int y, string beskrivning)
        {
            Assert.That(new Spelvärldsposition(x, y).ToString(), Is.EqualTo(beskrivning));
        }
    }
}
