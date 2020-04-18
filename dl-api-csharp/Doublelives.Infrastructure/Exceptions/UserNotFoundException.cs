using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Infrastructure.Exceptions
{
    [Serializable]
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        {
        }

        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
