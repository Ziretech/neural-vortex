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

        [TestCase(1.0, "100%")]
        [TestCase(0.8, "80%")]
        [TestCase(0.3, "30%")]
        [TestCase(0.0, "0%")]
        [TestCase(0.12, "12%")]
        [TestCase(0.123, "12%")]
        [TestCase(0.12999, "12%")]
        public void Representeras_som_värde_med_procent(double värde, string representation)
        {
            Assert.That(new Andel(värde).ToString(), Is.EqualTo(representation));
        }

        [TestCase(1.0, 1.0)]
        [TestCase(0.8, 0.8)]
        [TestCase(0.71, 0.71)]
        [TestCase(0.0, 0.0)]
        [TestCase(0.341, 0.342)]
        public void Är_likadan_som_annan_andel_med_samma_värde(double värde1, double värde2)
        {
            Assert.That(new Andel(värde1), Is.EqualTo(new Andel(värde2)));
        }

        [TestCase(1.0, 0.9)]
        [TestCase(0.4, 0.41)]
        [TestCase(0.34, 0.339)]
        public void Är_inte_likadan_som_annan_andel_med_annat_värde(double värde1, double värde2)
        {
            Assert.That(new Andel(värde1), Is.Not.EqualTo(new Andel(värde2)));
        }
    }
}
