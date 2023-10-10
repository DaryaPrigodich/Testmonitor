using TestmonitorProject.Models.Enum;

namespace TestmonitorProject.Configuration;

public record User
{
    public UserType UserType { get; set; }
    public string Username { get; init; } = null!;
    public string Password { get; init; } = null!;
}
