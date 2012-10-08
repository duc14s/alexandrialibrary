﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotR.Attachments
{
    public class HornOfGondor
        : AttachmentCardBase
    {
        public HornOfGondor()
            : base("Horn of Gondor", CardSet.Core, 42, Sphere.Tactics, 1, true, true)
        {
            AddTrait(Trait.Item);
            AddTrait(Trait.Artifact);
        }

        public override bool CanBeAttachedTo(IPhaseStep step, ICardInPlay cardInPlay)
        {
            if (cardInPlay == null)
                throw new ArgumentNullException("cardInPlay");

            return (cardInPlay.Card is IHeroCard);
        }
    }
}
