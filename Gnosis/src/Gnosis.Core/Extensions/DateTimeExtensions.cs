﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnosis.Core
{
    public static class DateTimeExtensions
    {
        public static string ToRfc3339String(this DateTime self)
        {
            return self.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fff") + "Z";
        }

        public static string ToRfc822String(this DateTime self)
        {
            return Rfc822DateTime.ToString(self.ToUniversalTime());
        }
    }
}