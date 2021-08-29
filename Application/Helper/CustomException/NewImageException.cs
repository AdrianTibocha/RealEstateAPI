using System;

namespace Application.Helper.CustomException
{
    public class NewImageException : Exception
    {
        public NewImageException()
        {
        }

        public NewImageException(string message)
            : base(message)
        {
        }

        public NewImageException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
