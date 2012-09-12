﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotR.Core.Phases.Quest
{
    public interface IAfterCommitingToQuest
    {
        void Setup(ICommitToQuestStep step);
        void Resolve(ICommitToQuestStep step, IPayment payment);
    }
}