using System;

namespace UseCase.NeuralVortex.Spec
{
    internal class DödaKritisktSkadadeMock : IDödaKritisktSkadade
    {
        internal bool DödaHarAnropats { get; private set; }

        public void Döda()
        {
            DödaHarAnropats = true;
        }
    }
}