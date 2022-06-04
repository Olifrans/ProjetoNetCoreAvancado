using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Application.DataContract.Response.Users;

public class AuthResponse
{
    public string? Token { get; set; }
    public string? Type { get; set; }
    public int ExpireIn { get; set; }
}
