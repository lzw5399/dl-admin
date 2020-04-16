using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Api.Models.Account
{
    public class LoginViewModel
    {
        public LoginViewModel(string token)
        {
            Token = token;
        }

        public string Token { get; }
    }
}
