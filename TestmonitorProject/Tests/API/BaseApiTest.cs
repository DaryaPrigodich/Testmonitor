using NUnit.Framework;
using TestmonitorProject.Clients;
using TestmonitorProject.Models.Enum;
using TestmonitorProject.Services.API;

namespace TestmonitorProject.Tests.API;

public class BaseApiTest
{
    protected ProjectService ProjectService { get; private set; } = null!;
    protected IssueService IssueService { get; private set; } = null!;

    [OneTimeSetUp]
    public void SetUpClient()
    {
        var restClient = new RestClientExtended(UserType.Admin);

        ProjectService = new ProjectService(restClient);
        IssueService = new IssueService(restClient);
    }
}
