using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Core.Models
{
    public class ErrorResponseModel
    {
        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}