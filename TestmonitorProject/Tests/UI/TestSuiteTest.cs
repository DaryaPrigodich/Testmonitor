using System.Net;
using FluentAssertions;
using NUnit.Framework;
using TestmonitorProject.Configuration;
using TestmonitorProject.Fakers;
using TestmonitorProject.Models;
using TestmonitorProject.Pages;

namespace TestmonitorProject.Tests.UI;

public class TestSuiteTest : BaseUiTest
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
    public void CreateTestSuite()
    {
        var isSuiteCreated = _projectOverviewPage
            .OpenProjectByName(_project.Name)
            .OpenProjectTestCases()
            .ClickAddTestSuiteButton()
            .CreateTestSuite();
        
        isSuiteCreated.Should().BeTrue("Test Suite hasn't created.");
    }
    
    [TearDown]
    [Description("Execution of post-condition steps")]
    public void SetUpPostConditionSteps()
    {
        var statusCode = ProjectService.ArchiveProject(_createdProject.Data.Id.ToString());
        statusCode.Should().Be(HttpStatusCode.OK);
    }
}
