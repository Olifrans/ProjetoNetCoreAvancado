using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Application.DataContract.Request.Users
{
    public class AuthRequest
    {
        public string? Login { get; set; }
        public string? Password { get; set; }

    }
}
