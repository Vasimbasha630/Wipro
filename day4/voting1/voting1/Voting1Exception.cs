using System;
using System.Runtime.Serialization;

namespace voting1
{
    [Serializable]
    internal class Voting1Exception : Exception
    {
        public Voting1Exception()
        {
        }

        public Voting1Exception(string message) : base(message)
        {
        }

        public Voting1Exception(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Voting1Exception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}