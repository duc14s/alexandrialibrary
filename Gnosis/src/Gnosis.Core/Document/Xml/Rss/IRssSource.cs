﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnosis.Core.Document.Xml.Rss
{
    public interface IRssSource
        : IRssElement
    {
        Uri Url { get; }
        string SourceName { get; }
    }
}