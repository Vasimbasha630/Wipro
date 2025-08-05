using System;
using System.Runtime.Serialization;

namespace voting1
{
    [Serializable]
    internal class VotingException : Exception
    {
        public VotingException()
        {
        }

        public VotingException(string message) : base(message)
        {
        }

        public VotingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VotingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}