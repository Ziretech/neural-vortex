using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class AndelSpec
    {
        [TestCase(1.0, 10, 10)]
        [TestCase(1.0, 5, 5)]
        [TestCase(0.5, 10, 5)]
        [TestCase(0.2, 5, 1)]
        [TestCase(0.0, 7, 0)]
        [TestCase(0.9, 1, 0)]
        public void Ger_angiven_andel_av_maxvärdet(double procent, int max, int värde)
        {
            var andel = new Andel(procent);
            Assert.That(andel.Av(max), Is.EqualTo(värde));
        }

        [Test]
        public void Gör_undantag_för_att_skapas_med_värde_mindre_än_0()
        {
            try
            {
                new Andel(-0.1);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("mindre än 0"));
            }            
        }

        [Test]
        public void Gör_undantag_för_att_skapas_med_värde_större_än_1()
        {
            try
            {
                new Andel(1.1);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("större än 1"));
            }
        }
    }
}
