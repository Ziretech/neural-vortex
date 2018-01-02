using System;

namespace Adapter.OpenTK
{
    public interface ILaddare
    {
        void Ladda(object avsändare, EventArgs händelse);
    }
}
