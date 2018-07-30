using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class PositionSpec
    {
        [TestCase(0, 0, 0, 1)]
        [TestCase(0, 4, 0, 5)]
        [TestCase(0, 5, 0, 4)]
        [TestCase(0, 0, 1, 0)]
        [TestCase(6, 0, 7, 0)]
        [TestCase(7, 0, 6, 0)]
        public void Är_bredvid_position_ett_steg_ifrån(int x1, int y1, int x2, int y2)
        {
            Assert.That(new Position(x1, y1).ÄrBredvid(new Position(x2, y2)), Is.True);
        }

        [TestCase(0, 0, 0, 2)]
        [TestCase(0, 0, 1, 1)]
        [TestCase(1, 1, 0, 0)]
        [TestCase(0, 1, 1, 0)]
        [TestCase(1, 0, 0, 1)]
        public void Är_inte_bredvid_position_mer_än_ett_steg_ifrån(int x1, int y1, int x2, int y2)
        {
            Assert.That(new Position(x1, y1).ÄrBredvid(new Position(x2, y2)), Is.False);
        }

        [TestCase(0, 0, 0, 1, 0, 1)]
        [TestCase(0, 0, 2, 7, 2, 7)]
        [TestCase(1, 1, 2, 7, 1, 6)]
        [TestCase(3, 5, 4, 9, 1, 4)]
        [TestCase(4, 9, 3, 5, 1, 4)]
        public void Har_avstånd_till_annan_position(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            Assert.That(new Position(x1, y1).AvståndTill(new Position(x2, y2)), Is.EqualTo(new Position(x3, y3)));
        }

        [TestCase(0, 0, 0, 1, 1)]
        [TestCase(0, 0, 0, 2, 2)]
        [TestCase(0, 0, 2, 0, 2)]
        [TestCase(1, 4, 2, 3, 2)]
        [TestCase(1, 2, 3, 4, 4)]
        [TestCase(7, 6, 4, 1, 8)]
        public void Har_manhattanavstånd_till_annan_position(int x1, int y1, int x2, int y2, int avstånd)
        {
            Assert.That(new Position(x1, y1).ManhattanAvståndTill(new Position(x2, y2)), Is.EqualTo(avstånd));
        }
    }
}
