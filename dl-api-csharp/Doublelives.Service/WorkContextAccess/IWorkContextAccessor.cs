using System;
using System.Collections.Generic;
using System.Text;
using Doublelives.Domain.WorkContext;

namespace Doublelives.Service.WorkContextAccess
{
    public interface IWorkContextAccessor
    {
        WorkContext WorkContext { get; set; }
    }
}