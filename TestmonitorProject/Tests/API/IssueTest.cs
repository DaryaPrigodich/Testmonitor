using System.Net;
using Allure.Commons;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using TestmonitorProject.Fakers;
using TestmonitorProject.Models;

namespace TestmonitorProject.Tests.API;

[AllureNUnit]
[AllureParentSuite("API")]
[AllureEpic("Issue")]
public class IssueTest : BaseApiTest
{
    private Project _project = null!;
    private Issue _issue = null!;
    private ProjectResponse _createdProject = null!;
    
    [SetUp]
    public void SetUpPreconditionSteps()
    {
        _project = new ProjectFaker().Generate();
        _createdProject = ProjectService.CreateProject(_project);

        _issue = new IssueFaker().Generate();
        _issue.ProjectId = _createdProject.Data.Id;
        IssueService.CreateIssue(_issue);
    }
    
    [Test]
    [Category("Negative")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureName("Get non existent issue")]
    [TestCase("incorrect")]
    public void GetNonExistentIssue(string incorrectIssueId)
    {
        var statusCode = IssueService.GetIssue(incorrectIssueId);

        statusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [TearDown]
    [Description("Execution of post-condition steps")]
    public void SetUpPostConditionSteps()
    {
        var statusCode = ProjectService.ArchiveProject(_createdProject.Data.Id.ToString());
        statusCode.Should().Be(HttpStatusCode.OK);
    }
}
