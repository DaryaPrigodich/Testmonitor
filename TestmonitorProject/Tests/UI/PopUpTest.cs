using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using TestmonitorProject.Configuration;
using TestmonitorProject.Pages;

namespace TestmonitorProject.Tests.UI;

public class PopUpTest : BaseUiTest
{
    private ProjectOverviewPage _projectOverviewPage = null!;
    
    [SetUp]
    [Description("Execution of pre-condition steps")]
    public void SetUpPreconditionSteps()
    {
        _projectOverviewPage = LoginSteps
            .LoginWithValidCredentials(Configurator.Admin.Username, Configurator.Admin.Password);
    }
    
    [Test]
    public void InteractWithSupportPopUp()
    {
        var helpCenterPage = _projectOverviewPage
            .ShowSupportPopUp()
            .OpenHelpCenter();

        using (new AssertionScope())
        {
            helpCenterPage.IsPageOpened().Should().BeTrue("Help Center page hasn't open.");
            Driver.WindowHandles.Count.Should().Be(2, "Help Center page hasn't open.");
        }
    }
}
