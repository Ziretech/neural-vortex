using System;

namespace Adapter.OpenTK
{
    public interface IVisare
    {
        // Castar till EventArgs för att slippa beroende på OpenTK i adaptern
        void Visa(object avsändare, EventArgs händelse);
    }
}
