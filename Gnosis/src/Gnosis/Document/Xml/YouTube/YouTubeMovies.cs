﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnosis.Document.Xml.YouTube
{
    public class YouTubeMovies
        : YouTubeSimpleContentElement, IYouTubeMovies
    {
        public YouTubeMovies(INode parent, IQualifiedName name)
            : base(parent, name)
        {
        }
    }
}