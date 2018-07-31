using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Spec.Spelvärld
{
    [TestFixture]
    public class HuvudkaraktärSpec
    {
        [Test]
        public void Är_kritiskt_skadad_när_den_har_0_i_hälsa()
        {
            var huvudkaraktär = new Huvudkaraktär(0);
            Assert.That(huvudkaraktär.ÄrKritisktSkadad, Is.True);
        }
        [Test]
        public void Är_inte_kritiskt_skadad_när_den_har_1_i_hälsa()
        {
            var huvudkaraktär = new Huvudkaraktär(1);
            Assert.That(huvudkaraktär.ÄrKritisktSkadad, Is.False);
        }
        [Test]
        public void Är_kritiskt_skadad_när_den_har_1_i_hälsa_och_tar_1_i_skada()
        {
            var huvudkaraktär = new Huvudkaraktär(1);
            huvudkaraktär.Skada();
            Assert.That(huvudkaraktär.ÄrKritisktSkadad, Is.True);
        }
        [Test]
        public void Är_inte_kritiskt_skadad_när_den_har_2_i_hälsa_och_tar_1_i_skada()
        {
            var huvudkaraktär = new Huvudkaraktär(2);
            huvudkaraktär.Skada();
            Assert.That(huvudkaraktär.ÄrKritisktSkadad, Is.False);
        }
    }
}
