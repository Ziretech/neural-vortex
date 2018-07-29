using System;

namespace UseCase.NeuralVortex.Spec
{
    internal class DödaKritisktSkadadeMock : IDödaKritisktSkadade
    {
        internal  SpeletsFortsättning Fortsättning { get; set; }
        internal bool DödaHarAnropats { get; private set; }

        public DödaKritisktSkadadeMock()
        {
            Fortsättning = SpeletsFortsättning.Fortsätt;
        }

        public SpeletsFortsättning Döda()
        {
            DödaHarAnropats = true;
            return Fortsättning;
        }
    }
}