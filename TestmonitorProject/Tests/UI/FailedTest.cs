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
[AllureEpic("Project")]
public class FailedTest : BaseUiTest
{
    private Project _project = null!;
    private ProjectResponse _createdProject = null!;

    private ProjectOverviewPage _projectOverviewPage = null!;
    
    [SetUp]
    [Description("Execution of pre-condition steps")]
    public void SetUpPreconditionSteps()
    {
        _project = new ProjectFaker().Generate();
        _createdProject = ProjectService.CreateProject(_project);

        _projectOverviewPage = LoginSteps
            .LoginWithValidCredentials(Configurator.Admin.Username, Configurator.Admin.Password);
    }
    
    [Test]
    [Category("Negative")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureName("Open a particular project repository")]
    [TestCase("Projects|TestMonitor")]
    public void OpenProjectRepository(string incorrectTitle)
    {
         _projectOverviewPage
            .OpenProjectByName(_project.Name);

         Driver.Title.Should().Be(incorrectTitle);
    }
    
    [TearDown]
    [Description("Execution of post-condition steps")]
    public void SetUpPostConditionSteps()
    {
        var statusCode = ProjectService.ArchiveProject(_createdProject.Data.Id.ToString());
        statusCode.Should().Be(HttpStatusCode.OK);
    }
}
