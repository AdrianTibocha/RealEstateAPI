using System;

namespace Application.Helper.CustomException
{
    public class NewPropertyException : Exception 
    {
        public NewPropertyException()
        {
        }

        public NewPropertyException(string message)
            : base(message)
        {
        }

        public NewPropertyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
