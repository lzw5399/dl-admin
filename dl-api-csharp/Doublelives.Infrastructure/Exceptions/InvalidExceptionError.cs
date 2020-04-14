using System.Collections.Generic;

namespace Doublelives.Infrastructure.Exceptions
{
    public class InvalidExceptionError
    {
        public string FieldName { get; set; }

        public ICollection<ErrorMessage> ErrorMessages { get; set; }
    }
}
