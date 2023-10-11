using System.Net;
using NUnit.Framework;
using FluentAssertions;
using TestmonitorProject.Configuration;
using TestmonitorProject.Fakers;
using TestmonitorProject.Models;
using TestmonitorProject.Pages;

namespace TestmonitorProject.Tests.UI;

public class RequirementsTest : BaseUiTest
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
    public void CreateRequirementWithBlankNameInput()
    {
        var isSuiteNotCreated = _projectOverviewPage
            .OpenProjectByName(_project.Name)
            .OpenProjectRequirements()
            .ClickAddRequirementButton()
            .ClickCreateButton();
        
        isSuiteNotCreated.Should().BeTrue("Suite has created with blank required suite name input.");
    }
    
    [Test]
    [TestCase(1), TestCase(99), TestCase(100)]
    public void CreateRequirementPassingAllowedNumberOfCharacters(int requirementNameLength)
    {
        var nameLength = _projectOverviewPage
            .OpenProjectByName(_project.Name)
            .OpenProjectRequirements()
            .ClickAddRequirementButton()
            .CreateRequirement(requirementNameLength)
            .GetRequirementNameLength();

        nameLength.Should().Be(requirementNameLength,"Suite hasn't created with allowed number of characters in suite name input.");
    }
    
    [Test]
    [TestCase(101,100)]
    public void CreateRequirementWithInvalidNumberOfCharacters(int requirementNameLength, int expectedNameLength)
    {
        var nameLength = _projectOverviewPage
            .OpenProjectByName(_project.Name)
            .OpenProjectRequirements()
            .ClickAddRequirementButton()
            .CreateRequirement(requirementNameLength)
            .GetRequirementNameLength();
        
        nameLength.Should().Be(expectedNameLength,"Requirement has created with not allowed number of characters in requirement name input.");
    }

    [TearDown]
    [Description("Execution of post-condition steps")]
    public void SetUpPostConditionSteps()
    {
        var statusCode = ProjectService.ArchiveProject(_createdProject.Data.Id.ToString());
        statusCode.Should().Be(HttpStatusCode.OK);
    }
}
