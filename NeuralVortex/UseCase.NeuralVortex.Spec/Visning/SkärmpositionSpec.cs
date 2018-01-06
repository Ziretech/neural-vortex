using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex.Spec.Visning
{
    [TestFixture]
    public class SkärmpositionSpec
    {
        [Test]
        public void Har_angiven_x_position()
        {
            var position = new Skärmposition(1, 2);
            Assert.That(position.X, Is.EqualTo(1));
        }

        [Test]
        public void Har_angiven_y_position()
        {
            var position = new Skärmposition(1, 2);
            Assert.That(position.Y, Is.EqualTo(2));
        }

        [Test]
        public void Ha_position_11_22_som_resultat_av_1_2_plus_10_20()
        {
            var position1 = new Skärmposition(1, 2);
            var position2 = new Skärmposition(10, 20);
            var resultat = position1.Plus(position2);
            Assert.That(resultat.X, Is.EqualTo(11));
            Assert.That(resultat.Y, Is.EqualTo(22));
        }

        [Test]
        public void Ha_position_6_10_som_resultat_av_1_2_plus_5_8()
        {
            var position1 = new Skärmposition(1, 2);
            var position2 = new Skärmposition(5, 8);
            var resultat = position1.Plus(position2);
            Assert.That(resultat.X, Is.EqualTo(6));
            Assert.That(resultat.Y, Is.EqualTo(10));
        }

        [Test]
        public void Ha_position_11_22_som_resultat_av_1_2_plus_yta_med_dimensioner_10_20()
        {
            var position = new Skärmposition(1, 2);
            var yta = new Skärmyta(10, 20);
            var resultat = position.Plus(yta);
            Assert.That(resultat.X, Is.EqualTo(11));
            Assert.That(resultat.Y, Is.EqualTo(22));
        }

        [Test]
        public void Ha_position_6_10_som_resultat_av_1_2_plus_yta_med_dimensioner_5_8()
        {
            var position = new Skärmposition(1, 2);
            var yta = new Skärmyta(5, 8);
            var resultat = position.Plus(yta);
            Assert.That(resultat.X, Is.EqualTo(6));
            Assert.That(resultat.Y, Is.EqualTo(10));
        }

        [Test]
        public void Har_position_1_2_som_resultat_av_1_2_minus_0_0()
        {
            var resultat = new Skärmposition(1, 2).Minus(new Skärmposition(0, 0));
            Assert.That(resultat.X, Is.EqualTo(1));
            Assert.That(resultat.Y, Is.EqualTo(2));
        }

        [Test]
        public void Har_position_3_6_som_resultat_av_4_8_minus_1_2()
        {
            var resultat = new Skärmposition(4, 8).Minus(new Skärmposition(1, 2));
            Assert.That(resultat.X, Is.EqualTo(3));
            Assert.That(resultat.Y, Is.EqualTo(6));
        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 0, 1, 0)]
        [TestCase(14, 9999, 14, 9999)]
        public void Är_likvärdig_med_position_med_samma_x_y_värden(int p1x, int p1y, int p2x, int p2y)
        {
            Assert.That(new Skärmposition(p1x, p1y).Equals(new Skärmposition(p2x, p2y)));
        }

        [TestCase(0, 0, 1, 0)]
        [TestCase(0, 0, 0, 1)]
        [TestCase(14, 9999, 14, 9998)]
        public void Inte_är_likvärdig_med_position_med_andra_x_y_värden(int p1x, int p1y, int p2x, int p2y)
        {
            Assert.That(new Skärmposition(p1x, p1y).Equals(new Skärmposition(p2x, p2y)) == false);
        }

        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 0, 1, 0)]
        [TestCase(14, 9999, 14, 9999)]
        public void Har_samma_hash_code_när_de_är_likvärdiga(int p1x, int p1y, int p2x, int p2y)
        {
            Assert.That(new Skärmposition(p1x, p1y).GetHashCode(), Is.EqualTo(new Skärmposition(p2x, p2y).GetHashCode()));
        }

        [TestCase(1, 2, "1x2")]
        [TestCase(13, 24, "13x24")]
        public void Beskriver_sig_med_XxY(int x, int y, string beskrivning)
        {
            Assert.That(new Skärmposition(x, y).ToString(), Is.EqualTo(beskrivning));
        }
    }
}
