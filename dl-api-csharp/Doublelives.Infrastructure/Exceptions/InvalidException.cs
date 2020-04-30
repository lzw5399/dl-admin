using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Doublelives.Infrastructure.Exceptions
{
    [Serializable]
    public class InvalidException : Exception
    {
        public IEnumerable<InvalidExceptionError> Errors { get; private set; } =
            Enumerable.Empty<InvalidExceptionError>();

        public InvalidException()
            : base()
        {
        }

        public InvalidException(InvalidExceptionError error)
        {
            Errors = new List<InvalidExceptionError>
            {
                error
            };
        }

        public InvalidException(IEnumerable<InvalidExceptionError> errors)
        {
            Errors = errors;
        }

        public InvalidException(string fieldName, string code, string message)
            : base(message)
        {
            Errors = new List<InvalidExceptionError>
            {
                new InvalidExceptionError
                {
                    FieldName = fieldName,
                    ErrorMessages = new List<ErrorMessage>
                    {
                        new ErrorMessage(code, message)
                    }
                }
            };
        }

        public InvalidException(string fieldName, IEnumerable<ErrorMessage> errorMessages)
        {
            Errors = new List<InvalidExceptionError>
            {
                new InvalidExceptionError
                {
                    FieldName = fieldName,
                    ErrorMessages = errorMessages.ToList()
                }
            };
        }

        protected InvalidException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}