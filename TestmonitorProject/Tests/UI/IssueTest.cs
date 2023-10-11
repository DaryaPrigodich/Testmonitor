using System.Net;
using FluentAssertions;
using NUnit.Framework;
using TestmonitorProject.Configuration;
using TestmonitorProject.Fakers;
using TestmonitorProject.Models;
using TestmonitorProject.Pages;

namespace TestmonitorProject.Tests.UI;

public class IssueTest : BaseUiTest
{
    private Project _project = null!;
    private Issue _issue = null!;
    private ProjectResponse _createdProject = null!;

    private ProjectOverviewPage _projectOverviewPage = null!;
    
    [SetUp]
    public void SetUpPreconditionSteps()
    {
        _project = new ProjectFaker().Generate();
        _createdProject = ProjectService.CreateProject(_project);

        _issue = new IssueFaker().Generate();
        _issue.ProjectId = _createdProject.Data.Id;
        IssueService.CreateIssue(_issue);

        _projectOverviewPage = LoginSteps
            .LoginWithValidCredentials(Configurator.Admin.Username, Configurator.Admin.Password);
    }
    
    
    [Test]
    public void DeleteIssue()
    {
        var isIssueInvisible = _projectOverviewPage
            .OpenProjectByName(_project.Name)
            .OpenProjectIssues()
            .DeleteIssue(_issue.Name);

        isIssueInvisible.Should().BeTrue("Issue hasn't deleted.");
    }
    
    [TearDown]
    public void SetUpPostConditionSteps()
    {
        var statusCode = ProjectService.ArchiveProject(_createdProject.Data.Id.ToString());
        statusCode.Should().Be(HttpStatusCode.OK);
    }
}
