﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.NeuralVortex.Visning
{
    public interface IGrafik
    {
        Skärmyta Dimensioner { get; }
        void Visa(Skärmposition position);
    }
}
