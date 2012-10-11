﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LotR.Cards;
using LotR.Effects;
using LotR.States;

namespace LotR.Effects.Phases
{
    public interface IPhaseStep
    {
        IPhase Phase { get; }
        IPlayer Player { get; }

        ICard GetCard(Guid id);
        ICardInPlay<ICard> GetCardInPlay(Guid id);
        bool CardIsInPlay(Guid id);
        IPlayer GetController(Guid id);
        IPlayer GetOwner(Guid id);

        IEnumerable<IEffect> Effects { get; }
        void AddEffect(IEffect effect);

        void AddStep(IPhaseStep step);

        void AddProgressToCurrentQuest(byte value);
        void RemoveProgressFromCurrentQuest(byte value);
    }
}
