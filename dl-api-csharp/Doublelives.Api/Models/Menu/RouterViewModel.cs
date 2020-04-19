using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Api.Models.Menu
{
    public class RouterViewModel
    {
        public List<RouterViewModel> Children { get; set; }

        public string Component { get; set; }

        public bool Hidden { get; set; }

        public long Id { get; set; }

        public MetaViewModel Meta { get; set; }

        public string Name { get; set; }

        public long Num { get; set; }

        public long ParentId { get; set; }

        public string Path { get; set; }
    }

    public class MetaViewModel
    {
        public string Icon { get; set; }

        public string Title { get; set; }
    }
}
