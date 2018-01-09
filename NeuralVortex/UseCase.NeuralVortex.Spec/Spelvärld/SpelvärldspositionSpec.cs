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
