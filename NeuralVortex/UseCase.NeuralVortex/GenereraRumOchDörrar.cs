﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.NeuralVortex.Kartgenerering;
using UseCase.NeuralVortex.Spelvärld;

namespace UseCase.NeuralVortex
{
    public class GenereraRumOchDörrar
    {
        private readonly ISpelvärldsskapare _skapare;
        private readonly IRumOchDörrarVäljare _väljare;
        private readonly Spelvärldsposition _förstaRummetPosition;

        public GenereraRumOchDörrar(ISpelvärldsskapare skapare, IRumOchDörrarVäljare väljare)
        {
            _skapare = skapare ?? throw new ArgumentException("GenereraRumOchDörrar kan inte skapas utan Spelvärldsskapare");
            _väljare = väljare ?? throw new ArgumentException("GenereraRumOchDörrar kan inte skapas utan RumOchDörrarVäljare");
            _förstaRummetPosition = new Spelvärldsposition(1, 1);

        }

        public void Generera()
        {
            var yta = _väljare.VäljRumstorlek();
            _skapare.SkapaRum(new Spelvärldsområde(_förstaRummetPosition, yta));
        }

        //public void Generera()
        //{
        //    _skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(1, 1), new Spelvärldsyta(5, 5)));
        //    _skapare.SkapaDörr(new Spelvärldsposition(6, 3));
        //    _skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(7, 2), new Spelvärldsyta(4, 3)));
        //    _skapare.SkapaDörr(new Spelvärldsposition(11, 3));
        //    _skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(12, 1), new Spelvärldsyta(3, 6)));
        //    _skapare.SkapaDörr(new Spelvärldsposition(8, 5));
        //    _skapare.SkapaRum(new Spelvärldsområde(new Spelvärldsposition(7, 6), new Spelvärldsyta(4, 4)));
        //}
    }
}
