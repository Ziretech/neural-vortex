using System;

namespace Adapter.OpenTK
{
    public interface IUppdaterare
    {
        // Castar till EventArgs för att slippa beroende på OpenTK i adaptern
        void Uppdatera(object avsändare, EventArgs händelse);
    }
}
