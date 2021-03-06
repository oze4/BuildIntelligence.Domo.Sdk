﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BuildIntelligence.Domo.Sdk.Exceptions
{
    public class LimitNotWithinBoundsException : Exception
    {
        public LimitNotWithinBoundsException()
        {
        }

        public LimitNotWithinBoundsException(string message) : base(message)
        {
        }

        public LimitNotWithinBoundsException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
