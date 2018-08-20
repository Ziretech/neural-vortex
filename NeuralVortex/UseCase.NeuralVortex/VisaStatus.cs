using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Visning;

namespace UseCase.NeuralVortex
{
    public class VisaStatus : IVisa
    {
        private IGrafik _hälsomätarram;
        private IGradvisGrafik _hälsomätare;
        private Huvudkaraktär _huvudkaraktär;

        public VisaStatus(IGrafik hälsomätarram, IGradvisGrafik hälsomätare, Huvudkaraktär huvudkaraktär)
        {
            _hälsomätarram = hälsomätarram ?? throw new ArgumentException("VisaStatus kan inte skapas utan hälsomätarram.");
            _hälsomätare = hälsomätare ?? throw new ArgumentException("VisaStatus kan inte skapas utan hälsomätare.");
            _huvudkaraktär = huvudkaraktär ?? throw new ArgumentException("VisaStatus kan inte skapas utan huvudkaraktär");
        }

        public void Visa()
        {
            _hälsomätarram.VisaCenterBotten();
            _hälsomätare.VisaCenterBotten(new Andel(_huvudkaraktär.Hälsa, _huvudkaraktär.MaxHälsa));
        }
    }
}
