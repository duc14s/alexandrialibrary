﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotR.Core
{
    public interface IGame
    {
        IScenario Scenario { get; }
        IEnumerable<IPlayer> Players { get; }
        
        IPlayer FirstPlayer { get; }
        IRound CurrentRound { get; }
        IEnumerable<IRound> PreviousRounds { get; }

        IDeck<IEncounterCard> EncounterDeck { get; }
        IDeck<IEncounterCard> EncounterDiscardPile { get; }
        IDeck<IQuestCard> QuestDeck { get; }

        IStagingArea StagingArea { get; }
        ILocationInPlay ActiveLocation { get; }
        IQuestCardInPlay ActiveQuest { get; }
        IVictoryDisplay VictoryDisplay { get; }
        IOutOfPlayArea OutOfPlay { get; }

        void ChangeActiveLocation(ILocationInPlay location);
        void ClearActiveLocation();
        void ChangeActiveQuest(IQuestCardInPlay quest);

        ICardInPlay GetCardInPlay(ICard card);
        int GetScore();

        bool IsComplete { get; }
        void Start();
        void Complete();
    }
}