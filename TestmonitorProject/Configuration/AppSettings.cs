namespace TestmonitorProject.Configuration;

public class AppSettings
{
    public string ApiUrl { get; init; } = null!;
    public string UiUrl { get; init; } = null!;
    public string Browser { get; init; } = null!;
    public int WaitTimeout { get; init; } 
}
