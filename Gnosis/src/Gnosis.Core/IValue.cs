﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Gnosis.Core
{
    public interface IValue
    {
        Guid Id { get; }
        Guid Parent { get; }
        uint Sequence { get; }

        bool IsNew();
        bool IsMoved();
        bool IsRemoved();

        void Move(uint sequence);
        void Remove();
        void Save();
    }
}
