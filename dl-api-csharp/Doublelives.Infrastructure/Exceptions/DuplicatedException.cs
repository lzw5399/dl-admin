using System;
using System.Runtime.Serialization;

namespace Doublelives.Infrastructure.Exceptions
{
    [Serializable]
    public class DuplicatedException : Exception
    {
        public ErrorMessage ErrorMessage { get; private set; } = new ErrorMessage();

        public DuplicatedException() 
            : base()
        {
        }

        public DuplicatedException(string code, string message)
            : base(message)
        {
            ErrorMessage = new ErrorMessage(code, message);
        }

        protected DuplicatedException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}
