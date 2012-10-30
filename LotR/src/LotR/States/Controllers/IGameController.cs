﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LotR.Effects;
using LotR.Effects.Choices;
using LotR.Effects.Costs;
using LotR.Effects.Payments;

namespace LotR.States.Controllers
{
    public interface IGameController
    {
        void RegisterChoiceOfferedCallback(Action<IEffect, IChoice> callback);
        void RegisterEffectAddedCallback(Action<IEffect> callback);
        void RegisterEffectResolvedCallback(Action<IEffect, IPayment, IChoice> callback);
        void RegisterGetPaymentCallback(Func<IEffect, ICost, IPayment> callback);
        void RegisterPaymentRejectedCallback(Action<IEffect, IPayment, IChoice> callback);

        void ChoiceOffered(IEffect effect, IChoice choice);
        void EffectAdded(IEffect effect);
        void EffectResolved(IEffect effect, IPayment payment, IChoice choice);
        IPayment GetPayment(IEffect effect, ICost cost);
        void PaymentRejected(IEffect effect, IPayment payment, IChoice choice);
    }
}
