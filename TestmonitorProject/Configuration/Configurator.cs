using System.Reflection;
using Microsoft.Extensions.Configuration;
using TestmonitorProject.Models.Enum;

namespace TestmonitorProject.Configuration;

public class Configurator
{
    private static readonly Lazy<IConfiguration> _configuration;
    
    private static IConfiguration Configuration => _configuration.Value;

    static Configurator()
    {
        _configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");

        return builder.Build();
    }

    public static AppSettings AppSettings
    {
        get
        {
            var appSettings = new AppSettings
            {
                ApiUrl = Configuration["AppSettings:ApiURL"]
                         ?? throw new InvalidOperationException(
                             "URL for API requests not found. Check your appsetting.json file."),
                UiUrl = Configuration["AppSettings:UiURL"]
                        ?? throw new InvalidOperationException("UI URL not found. Check your appsetting.json file."),
                Browser = Configuration["AppSettings:Browser"]
                          ?? throw new InvalidOperationException(
                              "Browser not found. Check your appsetting.json file."),
                WaitTimeout = int.Parse(Configuration["AppSettings:WaitTimeout"] 
                                        ?? throw new InvalidOperationException(
                                            "Default wait timeout not set. Check your appsetting.json file."))
            };

            return appSettings;
        }
    }

    private static List<User?> Users
    {
        get
        {
            var users = new List<User?>();
            var child = Configuration.GetSection("Users");
            foreach (var section in child.GetChildren())
            {
                var user = new User { Password = section["Password"]!, Username = section["Username"]!, Token = section["Token"]!};
                user.UserType = section["UserType"]!.ToLower() switch
                {
                    "admin" => UserType.Admin,
                    _ => user.UserType
                };
                users.Add(user);
            }

            return users;
        }
    }

    public static User? Admin => Users.Find(x => x?.UserType == UserType.Admin);
}
