﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnosis.Core
{
    public interface IMediaSchemaFactory
    {
        IMediaSchema Create(Uri identifier);

        void Add(IMediaSchema schema);
        void Remove(IMediaSchema schema);
    }
}
