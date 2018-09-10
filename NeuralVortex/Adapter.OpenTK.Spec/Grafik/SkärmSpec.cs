using Adapter.OpenTK.Grafik;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Visning;

namespace Adapter.OpenTK.Spec.Grafik
{
    [TestFixture]
    public class SkärmSpec
    {
        private ISkärm _skärm;

        [SetUp]
        public void Givet()
        {
            _skärm = new Skärm();
        }

        [TestCase(2, 2, 2, 2, 0, 0)]
        [TestCase(2, 2, 4, 4, 1, 0)]
        [TestCase(80, 2, 1600, 4, 760, 0)]
        public void Beräknar_position_för_bricka_centrerad_i_botten(int brickbredd, int brickhöjd, int skärmbredd, int skärmhöjd, int x, int y)
        {
            var brickansDimensioner = new Skärmyta(brickbredd, brickhöjd);
            var skärmensDimensioner = new Skärmyta(skärmbredd, skärmhöjd);
            var brickansPosition = new Skärmposition(x, y);

            _skärm.ÄndraStorlek(skärmensDimensioner);
            Assert.That(_skärm.PositionCentreradIBotten(brickansDimensioner), Is.EqualTo(brickansPosition));
        }
    }
}
