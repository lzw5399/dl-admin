using System;
using System.Runtime.Serialization;

namespace Doublelives.Infrastructure.Exceptions
{
    [Serializable]
    public class InternalException : Exception
    {
        public ErrorMessage ErrorMessage { get; private set; } = new ErrorMessage();

        public InternalException()
            : base()
        {
        }

        public InternalException(string code, string message)
            : base(message)
        {
            ErrorMessage = new ErrorMessage(code, message);
        }

        protected InternalException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}