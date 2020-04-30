using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Domain.Sys.Dto
{
    public class RouterDto
    {
        public List<RouterDto> Children { get; set; }

        public string Component { get; set; }

        public bool Hidden { get; set; }

        public long Id { get; set; }

        public MetaDto Meta { get; set; }

        public string Name { get; set; }

        public long Num { get; set; }

        public long ParentId { get; set; }

        public string Path { get; set; }
    }

    public class MetaDto
    {
        public string Icon { get; set; }

        public string Title { get; set; }
    }
}