using System;

namespace Application.Helper.CustomException
{
    public class PropertySearchException : Exception
    {
        public PropertySearchException()
        {
        }

        public PropertySearchException(string message)
            : base(message)
        {
        }

        public PropertySearchException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
