using Adapter.OpenTK.Grafik;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.OpenTK.Spec.Grafik
{
    [TestFixture]
    public class GrafikHändelserSpec
    {
        [Test]
        public void Visning_tömmer_ritytan()
        {
            var visaSpelvärld = new VisaMock();
            var visaStatus = new VisaMock();
            var grafikkommandon = new GrafikkommandonMock();
            var buffertväxlare = Substitute.For<IBuffertväxlare>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus);
            grafikhändelser.Visa(null, null);

            Assert.That(grafikkommandon.TömRitytaHarAnropats, Is.True);
        }

        [Test]
        public void Visning_växlar_skärmbuffert()
        {
            var visaSpelvärld = new VisaMock();
            var visaStatus = new VisaMock();
            var grafikkommandon = new GrafikkommandonMock();
            var buffertväxlare = Substitute.For<IBuffertväxlare>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus);
            grafikhändelser.Visa(null, null);

            buffertväxlare.Received().VäxlaBuffert();
        }

        [Test]
        public void Visar_spelvärld()
        {
            var visaSpelvärld = new VisaMock();
            var visaStatus = new VisaMock();
            var grafikkommandon = new GrafikkommandonMock();
            var buffertväxlare = Substitute.For<IBuffertväxlare>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus);
            grafikhändelser.Visa(null, null);

            Assert.That(visaSpelvärld.VisaHarAnropats, Is.True);
        }

        [Test]
        public void Visar_status()
        {
            var visaSpelvärld = new VisaMock();
            var visaStatus = new VisaMock();
            var grafikkommandon = new GrafikkommandonMock();
            var buffertväxlare = Substitute.For<IBuffertväxlare>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus);
            grafikhändelser.Visa(null, null);

            Assert.That(visaStatus.VisaHarAnropats, Is.True);
        }
    }
}
