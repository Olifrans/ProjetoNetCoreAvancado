namespace NetCore.Application.DataContract.Response.Users;

public class AuthResponse
{
    public string? Token { get; set; }
    public string? Type { get; set; }
    public int ExpireIn { get; set; }
}