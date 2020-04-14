using System;
using System.Runtime.Serialization;

namespace Doublelives.Infrastructure.Exceptions
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public ErrorMessage ErrorMessage { get; private set; } = new ErrorMessage();

        public BadRequestException()
            : base()
        {
        }

        public BadRequestException(string code, string message)
            : base(message)
        {
            ErrorMessage = new ErrorMessage(code, message);
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) 
        : base(info, context)
        {
        }
    }
}
