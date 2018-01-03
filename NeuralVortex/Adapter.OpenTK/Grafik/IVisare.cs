using System;

namespace Adapter.OpenTK.Grafik
{
    public interface IVisare
    {
        // Castar till EventArgs för att slippa beroende på OpenTK i adaptern
        void Visa(object avsändare, EventArgs händelse);
    }
}
