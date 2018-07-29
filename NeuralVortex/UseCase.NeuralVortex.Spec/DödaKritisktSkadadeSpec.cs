using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class DödaKritisktSkadadeSpec
    {
        [Test]
        [Ignore("Fixa hantering av speletsfortsättning i uppdatera spelvärlden först")]
        public void Avslutar_inte_spelet_om_huvudkaraktären_saknas()
        {
            var dödaKritisktSkadade = new DödaKritisktSkadade();
            Assert.That(dödaKritisktSkadade.Döda(), Is.EqualTo(SpeletsFortsättning.Fortsätt));
        }
    }
}
