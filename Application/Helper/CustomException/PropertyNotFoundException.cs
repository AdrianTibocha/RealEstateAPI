﻿using System;

namespace Application.Helper.CustomException
{
    public class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException()
        {
        }

        public PropertyNotFoundException(string message)
            : base(message)
        {
        }

        public PropertyNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
