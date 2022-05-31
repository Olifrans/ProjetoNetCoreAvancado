namespace NetCore.Domain.Models;

public class UsersModel : EntityBase
{
    public string? Name { get; set; }
    public string? Login { get; set; }
    public string? PasswordHash { get; set; }
}


