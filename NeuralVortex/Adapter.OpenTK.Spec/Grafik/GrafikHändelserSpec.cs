using Adapter.OpenTK.Grafik;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex;
using UseCase.NeuralVortex.Visning;

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
            var skärm = Substitute.For<ISkärm>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus, skärm);
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
            var skärm = Substitute.For<ISkärm>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus, skärm);
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
            var skärm = Substitute.For<ISkärm>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus, skärm);
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
            var skärm = Substitute.For<ISkärm>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, null, visaStatus, skärm);
            grafikhändelser.Visa(null, null);

            visaStatus.Received().Visa();
        }

        [Test]
        public void Uppdaterar_skärmens_storlek_med_en_faktor_4()
        {
            var visaSpelvärld = Substitute.For<IVisa>();
            var visaStatus = Substitute.For<IVisa>();
            var grafikkommandon = Substitute.For<IGrafikkommandon>();
            var buffertväxlare = Substitute.For<IBuffertväxlare>();
            var kamera = new Kamera(new Skärmyta(10, 10));
            var skärm = Substitute.For<ISkärm>();
            var grafikhändelser = new GrafikHändelser(grafikkommandon, null, buffertväxlare, visaSpelvärld, kamera, visaStatus, skärm);
            grafikhändelser.ÄndraStorlek(16, 20);

            skärm.Received().ÄndraStorlek(new Skärmyta(4, 5));
        }
    }
}
