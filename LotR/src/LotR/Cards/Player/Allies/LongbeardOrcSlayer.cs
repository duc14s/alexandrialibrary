﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotR.Cards.Player.Allies
{
    public class LongbeardOrcSlayer
        : AllyCardBase
    {
        public LongbeardOrcSlayer()
            : base("Longbeard Orc Slayer", CardSet.Core, 18, Sphere.Leadership, 4, 0, 2, 1, 3)
        {
            AddTrait(Trait.Dwarf);
            AddTrait(Trait.Warrior);
        }
    }
}
