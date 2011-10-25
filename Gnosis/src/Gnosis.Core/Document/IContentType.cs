﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnosis.Core.Document
{
    public interface IContentType
    {
        IMediaType Type { get; }
        ICharacterSet CharSet { get; }
        string Boundary { get; }
    }
}