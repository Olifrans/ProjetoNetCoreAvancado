namespace NetCore.Application.DataContract.Response.Users;

public sealed class UsersResponse
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Login { get; set; }
    public string? PasswordHash { get; set; }
}