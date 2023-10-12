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
[AllureEpic("Project")]
public class ProjectTest : BaseApiTest
{
    private Project _project = null!;
    private ProjectResponse _createdProject = null!;

    [Test]
    [Category("Positive")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureName("Create project")]
    public void CreateProject()
    {
        _project = new ProjectFaker().Generate();
        _createdProject = ProjectService.CreateProject(_project);

        _createdProject.Data.Name.Should().Be(_project.Name);
    }
    
    [Test]
    [Category("Positive")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureName("Get project")]
    public void GetProject()
    {
        var statusCode = ProjectService.GetProject(_createdProject.Data.Id.ToString());

        statusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Test]
    [Category("Negative")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureName("Get non existent project")]
    [TestCase("incorrect")]
    public void GetNonExistentProject(string incorrectProjectId)
    {
        var statusCode = ProjectService.GetProject(incorrectProjectId);

        statusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
    [Test]
    public void SetUpPostConditionSteps()
    {
        var statusCode = ProjectService.ArchiveProject(_createdProject.Data.Id.ToString());
        statusCode.Should().Be(HttpStatusCode.OK);
    }
}
