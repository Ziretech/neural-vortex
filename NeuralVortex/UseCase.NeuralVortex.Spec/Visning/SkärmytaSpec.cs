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
    public class SkärmytaSpec
    {
        [Test]
        public void Har_angiven_bredd()
        {
            var yta = new Skärmyta(2, 5);
            Assert.That(yta.Bredd, Is.EqualTo(2));
        }

        [Test]
        public void Har_angiven_höjd()
        {
            var yta = new Skärmyta(2, 5);
            Assert.That(yta.Höjd, Is.EqualTo(5));
        }

        [TestCase(2, 5)]
        [TestCase(9, 4)]
        public void Är_likvärdig_med_annan_skärmyta_med_samma_dimensioner(int bredd, int höjd)
        {
            var yta = new Skärmyta(bredd, höjd);
            var likadanYta = new Skärmyta(bredd, höjd);
            Assert.That(yta.Equals(likadanYta), Is.True);
        }

        [TestCase(2, 4, 3, 4)]
        public void Är_inte_likvärdig_med_annan_skärmyta_med_andra_dimensioner(int bredd, int höjd, int annanBredd, int annanHöjd)
        {
            var yta = new Skärmyta(bredd, höjd);
            var annanYta = new Skärmyta(annanBredd, annanHöjd);
            Assert.That(yta.Equals(annanYta), Is.False);
        }

        [TestCase(2, 5)]
        [TestCase(9, 4)]
        public void Har_samma_hashcode_som_likadan_yta(int bredd, int höjd)
        {
            var yta = new Skärmyta(bredd, höjd);
            var likadanYta = new Skärmyta(bredd, höjd);
            Assert.That(yta.GetHashCode(), Is.EqualTo(likadanYta.GetHashCode()));
        }

        [TestCase(2, 4, 3, 4)]
        public void Har_inte_samma_hashcode_som_vissa_andra_ytor(int bredd, int höjd, int annanBredd, int annanHöjd)
        {
            var yta = new Skärmyta(bredd, höjd);
            var annanYta = new Skärmyta(annanBredd, annanHöjd);
            Assert.That(yta.GetHashCode(), Is.Not.EqualTo(annanYta.GetHashCode()));
        }
    }
}
