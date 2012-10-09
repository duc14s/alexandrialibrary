﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LotR.Effects.Phases.Any;

namespace LotR.Cards
{
    public interface IWillpowerfulCard
        : ICard
    {
        void DetermineWillpower(IDetermineWillpowerStep step);
    }
}
