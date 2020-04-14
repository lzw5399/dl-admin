using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Domain.Infrastructure
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
