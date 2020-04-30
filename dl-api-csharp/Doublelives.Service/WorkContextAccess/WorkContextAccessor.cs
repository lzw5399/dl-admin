using Doublelives.Domain.WorkContext;
using System.Threading;

namespace Doublelives.Service.WorkContextAccess
{
    public class WorkContextAccessor : IWorkContextAccessor
    {
        private static AsyncLocal<WorkContext> _workContextCurrent = new AsyncLocal<WorkContext>();

        public WorkContext WorkContext
        {
            get => _workContextCurrent.Value;

            set => _workContextCurrent.Value = value;
        }
    }
}