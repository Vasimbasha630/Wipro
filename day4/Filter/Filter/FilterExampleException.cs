using System;
using System.Runtime.Serialization;

namespace ExceptionHandling
{
    [Serializable]
    internal class FilterExampleException : Exception
    {
        public FilterExampleException()
        {
        }

        public FilterExampleException(string message) : base(message)
        {
        }

        public FilterExampleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FilterExampleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}