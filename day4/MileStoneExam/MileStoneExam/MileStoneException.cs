using System;
using System.Runtime.Serialization;

namespace ExceptionHandling
{
    [Serializable]
    internal class MileStoneException : Exception
    {
        public MileStoneException()
        {
        }

        public MileStoneException(string message) : base(message)
        {
        }

        public MileStoneException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MileStoneException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}