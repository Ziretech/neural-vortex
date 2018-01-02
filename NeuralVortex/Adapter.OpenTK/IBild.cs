using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.OpenTK
{
    public interface IBild
    {
        IBildData LåsBilddata32ARGB();
        void FrigörBilddata();
        int Bredd { get; }
        int Höjd { get; }
    }
}
