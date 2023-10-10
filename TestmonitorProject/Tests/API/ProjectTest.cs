using System.Net;
using FluentAssertions;
using NUnit.Framework;
using TestmonitorProject.Fakers;
using TestmonitorProject.Models;

namespace TestmonitorProject.Tests.API;

public class ProjectTest : BaseApiTest
{
    private Project _project = null!;
    private ProjectResponse _createdProject = null!;

    [Test]
    public void CreateProject()
    {
        _project = new ProjectFaker().Generate();
        _createdProject = ProjectService.CreateProject(_project);

        _createdProject.Data.Name.Should().Be(_project.Name);
    }
    
    [OneTimeTearDown]
    public void SetUpPostConditionSteps()
    {
        var statusCode = ProjectService.ArchiveProject(_createdProject.Data.Id.ToString());
        statusCode.Should().Be(HttpStatusCode.OK);
    }
}
