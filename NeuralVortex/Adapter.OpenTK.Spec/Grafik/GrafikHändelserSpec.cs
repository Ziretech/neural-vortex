using Adapter.OpenTK.Grafik;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;

namespace Adapter.OpenTK.Spec.Grafik
{
    [TestFixture]
    public class GrafikHändelserSpec
    {
        [Test]
        public void Visning_tömmer_ritytan()
        {
            var visaSpelvärld = Substitute.For<IVisa>();
            var visaStatus = Substitute.For<IVisa>();
            var grafikkommandon = Substitute.For<IGrafikkommandon>();
            var buffertväxlare = Substitute.For<IBuffertväxlare>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus);
            grafikhändelser.Visa(null, null);

            grafikkommandon.Received().TömRityta();
        }

        [Test]
        public void Visning_växlar_skärmbuffert()
        {
            var visaSpelvärld = Substitute.For<IVisa>();
            var visaStatus = Substitute.For<IVisa>();
            var grafikkommandon = Substitute.For<IGrafikkommandon>();
            var buffertväxlare = Substitute.For<IBuffertväxlare>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus);
            grafikhändelser.Visa(null, null);

            buffertväxlare.Received().VäxlaBuffert();
        }

        [Test]
        public void Visar_spelvärld()
        {
            var visaSpelvärld = Substitute.For<IVisa>();
            var visaStatus = Substitute.For<IVisa>();
            var grafikkommandon = Substitute.For<IGrafikkommandon>();
            var buffertväxlare = Substitute.For<IBuffertväxlare>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus);
            grafikhändelser.Visa(null, null);

            visaSpelvärld.Received().Visa();
        }

        [Test]
        public void Visar_status()
        {
            var visaSpelvärld = Substitute.For<IVisa>();
            var visaStatus = Substitute.For<IVisa>();
            var grafikkommandon = Substitute.For<IGrafikkommandon>();
            var buffertväxlare = Substitute.For<IBuffertväxlare>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus);
            grafikhändelser.Visa(null, null);

            visaStatus.Received().Visa();
        }
    }
}
