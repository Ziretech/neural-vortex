using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex.Spec
{
    [TestFixture]
    public class SpelvärldsområdeSpec
    {
        [Test]
        public void Har_topp_botten_höger_vänster()
        {
            var område = new Spelvärldsområde(1, 2, 3, 4);
            Assert.That(område.Vänster, Is.EqualTo(1));
            Assert.That(område.Botten, Is.EqualTo(2));
            Assert.That(område.Höger, Is.EqualTo(3));
            Assert.That(område.Topp, Is.EqualTo(4));
        }

        [Test]
        public void Har_topp_botten_höger_vänster_från_yta_position()
        {
            var område = new Spelvärldsområde(new Spelvärldsposition(10, 20), new Spelvärldsyta(30, 40));
            Assert.That(område.Vänster, Is.EqualTo(10));
            Assert.That(område.Botten, Is.EqualTo(20));
            Assert.That(område.Höger, Is.EqualTo(40));
            Assert.That(område.Topp, Is.EqualTo(60));
        }

        [Test]
        public void Kan_skapas_med_position_och_dimension()
        {
            var område = new Spelvärldsområde(new Spelvärldsposition(1, 2), new Spelvärldsyta(3, 4));
            Assert.That(område.Vänster, Is.EqualTo(1));
            Assert.That(område.Botten, Is.EqualTo(2));
            Assert.That(område.Höger, Is.EqualTo(4));
            Assert.That(område.Topp, Is.EqualTo(6));
        }

        [Test]
        public void Kan_skapas_som_1x1_område()
        {
            var område = new Spelvärldsområde(new Spelvärldsposition(0, 0), new Spelvärldsyta(1, 1));
            Assert.That(område.Vänster, Is.EqualTo(0));
            Assert.That(område.Botten, Is.EqualTo(0));
            Assert.That(område.Höger, Is.EqualTo(1));
            Assert.That(område.Topp, Is.EqualTo(1));
            // OBS, om man betraktar elementen som "ytor" är detta lite ointuitivt.
            // Då behöver man generellt se Höger och Topp som exklusiva [0, 1),
            // alltså att man loopar for(int x = Vänster; x < Höger; x++)    (Notera: x < Höger istf. x <= Höger)
        }

        [Test]
        public void Gör_undantag_för_om_höger_är_mindre_än_vänster()
        {
            try
            {
                var område = new Spelvärldsområde(4, 1, 3, 2);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("område"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("vänster"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("höger"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("3"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("4"));
            }            
        }

        [Test]
        public void Gör_undantag_för_om_topp_är_mindre_än_botten()
        {
            try
            {
                var område = new Spelvärldsområde(1, 4, 2, 3);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (ArgumentException undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("område"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("botten"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("topp"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("3"));
                Assert.That(undantag.Message.ToLower(), Does.Contain("4"));
            }
        }

        [Test]
        public void Omsluter_annat_område_som_är_mindre()
        {
            Assert.That(new Spelvärldsområde(0, 0, 3, 3).Omsluter(new Spelvärldsområde(1, 1, 2, 2)));
        }
        [Test]
        public void Omsluter_annat_område_med_samma_dimensioner()
        {
            Assert.That(new Spelvärldsområde(0, 0, 3, 3).Omsluter(new Spelvärldsområde(0, 0, 3, 3)));
        }
        [Test]
        public void Omsluter_inte_område_vars_vänster_är_längre_åt_vänster()
        {
            Assert.That(!new Spelvärldsområde(1, 2, 3, 4).Omsluter(new Spelvärldsområde(0, 2, 3, 4)));
        }
        [Test]
        public void Omsluter_inte_område_vars_botten_är_längre_ner()
        {
            Assert.That(!new Spelvärldsområde(1, 2, 3, 4).Omsluter(new Spelvärldsområde(1, 1, 3, 4)));
        }
        [Test]
        public void Omsluter_inte_område_vars_höger_är_längre_åt_höger()
        {
            Assert.That(!new Spelvärldsområde(1, 2, 3, 4).Omsluter(new Spelvärldsområde(1, 2, 4, 4)));
        }
        [Test]
        public void Omsluter_inte_område_vars_topp_är_längre_upp()
        {
            Assert.That(!new Spelvärldsområde(1, 2, 3, 4).Omsluter(new Spelvärldsområde(1, 2, 3, 5)));
        }

        [TestCase(1, 2, 3, 4)]
        public void Är_likvärdig_med_område_med_samma_värden(int vänster, int botten, int höger, int topp)
        {
            Assert.That(new Spelvärldsområde(vänster, botten, höger, topp), Is.EqualTo(new Spelvärldsområde(vänster, botten, höger, topp)));
        }

        [TestCase(0, 0, 1, 1, 0, 0, 1, 2)]
        public void Inte_är_likvärdig_med_position_med_andra_värden(int vänster1, int botten1, int höger1, int topp1, int vänster2, int botten2, int höger2, int topp2)
        {
            Assert.That(new Spelvärldsområde(vänster1, botten1, höger1, topp1).Equals(new Spelvärldsområde(vänster2, botten2, höger2, topp2)) == false);
        }

        [TestCase(1, 2, 3, 4)]
        public void Har_samma_hash_code_när_de_är_likvärdiga(int vänster, int botten, int höger, int topp)
        {
            Assert.That(new Spelvärldsområde(vänster, botten, höger, topp).GetHashCode(), Is.EqualTo(new Spelvärldsområde(vänster, botten, höger, topp).GetHashCode()));
        }

        [TestCase(1, 2, 3, 4, "(1,2)-(3,4)")]
        [TestCase(13, 24, 74, 123, "(13,24)-(74,123)")]
        public void Beskriver_sig_med_vänsterbotten_högertopp(int vänster, int botten, int höger, int topp, string beskrivning)
        {
            Assert.That(new Spelvärldsområde(vänster, botten, höger, topp).ToString(), Is.EqualTo(beskrivning));
        }
    }
}
