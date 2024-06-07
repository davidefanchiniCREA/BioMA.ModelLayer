using System;
using System.Runtime.Serialization;

namespace CRA.ModelLayer.Core
{
    [Serializable]
    public class PreconditionErrorException : Exception
    {
        public PreconditionErrorException()
        {
        }

        public PreconditionErrorException(string message) : base(message)
        {
        }

        public PreconditionErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public static PreconditionErrorException GetInnerPreconditionsErrorException(Exception e)
        {
            if (e == null)
                return null;
            if (e is PreconditionErrorException)
                return (PreconditionErrorException)e;
            return GetInnerPreconditionsErrorException(e.InnerException);
        }
    }
}