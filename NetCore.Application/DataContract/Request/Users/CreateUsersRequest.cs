namespace NetCore.Application.DataContract.Request.Users;

public sealed class CreateUsersRequest
{
    public string? Name { get; set; }
    public string? Login { get; set; }
    public string? PasswordHash { get; set; }
}