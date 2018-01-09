using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Kontroll;
using UseCase.NeuralVortex.Spelvärld;

namespace Adapter.Spelvärld
{
    public class Hinderkarta : IHinderkarta
    {
        private bool[] _hinder;
        private readonly int _kartbredd;

        public Hinderkarta(bool[] hinder, int kartbredd)
        {
            _hinder = hinder;
            _kartbredd = kartbredd;
        }

        public bool Hindrar(Spelvärldsposition position)
        {
            if(_hinder != null)
            {
                if(position.X < _kartbredd && position.X >= 0)
                {
                    return _hinder[position.X + position.Y * _kartbredd];
                }
                return true;
            }
            return false;
        }
    }
}
