using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex
{
    public class UtdelaSkada : IUtdelaSkada
    {
        private ISpelvärld _spelvärld;

        public UtdelaSkada(ISpelvärld spelvärld)
        {
            _spelvärld = spelvärld;
        }

        public  void Utdela()
        {
            foreach (var fiende in _spelvärld.Fienden)
            {
                if (_spelvärld.Huvudkaraktär.Position.ÄrBredvid(fiende.Position))
                {
                    _spelvärld.Huvudkaraktär.Skada();
                }
            }
        }
    }
}
