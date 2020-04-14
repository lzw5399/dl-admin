using System;
using System.Runtime.Serialization;

namespace Doublelives.Infrastructure.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public ErrorMessage ErrorMessage { get; private set; } = new ErrorMessage();

        public NotFoundException() 
            : base()
        {
        }

        public NotFoundException(string code, string message)
            : base(message)
        {
            ErrorMessage = new ErrorMessage(code, message);
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}
