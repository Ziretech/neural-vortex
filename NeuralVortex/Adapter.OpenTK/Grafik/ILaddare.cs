using System;

namespace Adapter.OpenTK.Grafik
{
    public interface ILaddare
    {
        void Ladda(object avsändare, EventArgs händelse);
    }
}
