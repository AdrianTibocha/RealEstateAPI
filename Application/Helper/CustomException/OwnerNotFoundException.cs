using System;

namespace Application.Helper.CustomException
{
    public class OwnerNotFoundException : Exception
    {
        public OwnerNotFoundException()
        {
        }

        public OwnerNotFoundException(string message)
            : base(message)
        {
        }

        public OwnerNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
