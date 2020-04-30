using Doublelives.Api.Models.Account;
using System.Collections.Generic;

namespace Doublelives.Api.Models.Users
{
    public class UserPagedListViewModel
    {
        public int Current { get; set; }

        public int Pages { get; set; }

        public int Size { get; set; }

        public string Sort { get; set; }

        public int Total { get; set; }

        public List<AccountProfileViewModel> Records { get; set; }
    }
}