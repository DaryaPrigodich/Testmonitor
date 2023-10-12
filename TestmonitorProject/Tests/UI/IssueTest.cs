using System.Net;
using Allure.Commons;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using TestmonitorProject.Configuration;
using TestmonitorProject.Fakers;
using TestmonitorProject.Models;
using TestmonitorProject.Pages;

namespace TestmonitorProject.Tests.UI;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureEpic("Issue")]
public class IssueTest : BaseUiTest
{
    private Project _project = null!;
    private Issue _issue = null!;
    private ProjectResponse _createdProject = null!;

    private ProjectOverviewPage _projectOverviewPage = null!;
    
    [SetUp]
    [Description("Execution of pre-condition steps")]
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
    [Category("Positive")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureName("Delete a particular issue")]
    public void DeleteIssue()
    {
        var isIssueInvisible = _projectOverviewPage
            .OpenProjectByName(_project.Name)
            .OpenProjectIssues()
            .DeleteIssue(_issue.Name);

        isIssueInvisible.Should().BeTrue("Issue hasn't deleted.");
    }
    
    [TearDown]
    [Description("Execution of post-condition steps")]
    public void SetUpPostConditionSteps()
    {
        var statusCode = ProjectService.ArchiveProject(_createdProject.Data.Id.ToString());
        statusCode.Should().Be(HttpStatusCode.OK);
    }
}
