using System;

namespace Application.Helper.CustomException
{
    public class ImageUploadFailedException : Exception
    {
        public ImageUploadFailedException()
        {
        }

        public ImageUploadFailedException(string message)
            : base(message)
        {
        }

        public ImageUploadFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
