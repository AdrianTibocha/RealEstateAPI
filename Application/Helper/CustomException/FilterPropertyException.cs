using System;

namespace Application.Helper.CustomException
{
    public class FilterPropertyException : Exception
    {
        public FilterPropertyException()
        {
        }

        public FilterPropertyException(string message)
            : base(message)
        {
        }

        public FilterPropertyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
