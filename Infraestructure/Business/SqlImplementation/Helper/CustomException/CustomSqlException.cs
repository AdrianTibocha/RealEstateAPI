using System;

namespace Infraestructure.Business.SqlImplementation.Helper.CustomException
{
    public class CustomSqlException : Exception
    {
        public CustomSqlException()
        {
        }

        public CustomSqlException(string message)
            : base(message)
        {
        }

        public CustomSqlException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
