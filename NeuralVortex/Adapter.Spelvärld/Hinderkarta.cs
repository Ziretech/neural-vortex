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
        private int Höjd => _hinder.Count() / _kartbredd;

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

        public override bool Equals(object obj)
        {
            var hinderkarta = obj as Hinderkarta;
            return hinderkarta != null &&
                   LikadanaHinder(hinderkarta._hinder) &&
                   _kartbredd == hinderkarta._kartbredd;
        }

        private bool LikadanaHinder(bool[] andraHinder)
        {
            if (_hinder == null && andraHinder == null)
                return true;
            if (_hinder == null && andraHinder != null ||
                _hinder != null && andraHinder == null)
                return false;
            if (_hinder.Count() != andraHinder.Count())
                return false;

            for(var i = 0; i < _hinder.Count(); i++)
            {
                if (_hinder[i] != andraHinder[i])
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = -2146417801;
            hashCode = hashCode * -1521134295 + EqualityComparer<bool[]>.Default.GetHashCode(_hinder);
            hashCode = hashCode * -1521134295 + _kartbredd.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return _hinder == null ? "Hinderkarta utan hinder" : $"{ _kartbredd }x{ Höjd }";
        }
    }
}
