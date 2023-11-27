using NUnit.Framework;
using TestmonitorProject.Clients;
using TestmonitorProject.Models.Enum;
using TestmonitorProject.Services.API;

namespace TestmonitorProject.Tests.API;

public class BaseApiTest
{
    private RestClientExtended _client = null!;
    protected ProjectService ProjectService { get; private set; } = null!;
    protected IssueService IssueService { get; private set; } = null!;

    [OneTimeSetUp]
    public void SetUpClient()
    {
        _client = new RestClientExtended(UserType.Admin);

        ProjectService = new ProjectService(_client);
        IssueService = new IssueService(_client);
    }
    
    [OneTimeTearDown]
    public void DisposeClient()
    {
        _client.Dispose();
    }
}
