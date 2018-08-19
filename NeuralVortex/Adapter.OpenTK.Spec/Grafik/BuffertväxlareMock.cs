using Adapter.OpenTK.Grafik;

namespace Adapter.OpenTK.Spec.Grafik
{
    internal class BuffertväxlareMock : IBuffertväxlare
    {
        public bool VäxlaBuffertHarAnropats { get; private set; }
        public void VäxlaBuffert()
        {
            VäxlaBuffertHarAnropats = true;
        }

        // REFACTOR använd NSubstitute istället
    }
}