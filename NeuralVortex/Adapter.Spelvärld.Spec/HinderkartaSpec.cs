using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace Adapter.Spelvärld.Spec
{
    [TestFixture]
    public class HinderkartaSpec
    {
        [Test]
        public void Kan_skapas_utan_hinder()
        {
            var hinderkarta = new Hinderkarta(null, 0);
            Assert.That(!hinderkarta.Hindrar(new Spelvärldsposition(1, 2)));
        }
    }
}
