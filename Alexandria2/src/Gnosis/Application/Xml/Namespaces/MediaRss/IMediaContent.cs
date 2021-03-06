﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gnosis.Culture;

namespace Gnosis.Application.Xml.Namespaces.MediaRss
{
    public interface IMediaContent
        : IPrimaryMediaRssElement
    {
        Uri Url { get; }
        long FileSize { get; }
        MediaRssMedium Medium { get; }
        bool IsDefault { get; }
        MediaRssExpression Expression { get; }
        int BitRate { get; }
        int SamplingRate { get; }
        int Channels { get; }
        int Duration { get; }
        int Height { get; }
        int Width { get; }
        ILanguageTag Lang { get; }
        string MediaType { get; }
    }
}
