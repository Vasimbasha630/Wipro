using System;
using System.Runtime.Serialization;

namespace ExceptionHandling
{
    [Serializable]
    internal class FilterException : Exception
    {
        public FilterException()
        {
        }

        public FilterException(string message) : base(message)
        {
        }

        public FilterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FilterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}