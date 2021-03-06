﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LotR.States;

namespace LotR.Effects.Phases.Any
{
    public interface IDuringEncounterCardRevealed
        : IEffect
    {
        void DuringEncounterCardRevealed(IGame game);
    }
}
