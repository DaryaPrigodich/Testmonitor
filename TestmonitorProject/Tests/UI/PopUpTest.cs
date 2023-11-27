using Allure.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using TestmonitorProject.Configuration;
using TestmonitorProject.Pages;
using TestmonitorProject.Services.UI;

namespace TestmonitorProject.Tests.UI;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureEpic("Support pop-up")]
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
    [Category("Positive")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureName("Open help center using support pop-up")]
    public void InteractWithSupportPopUp()
    {
        var helpCenterPage = _projectOverviewPage
            .ShowSupportPopUp()
            .OpenHelpCenter();

        using (new AssertionScope())
        {
            helpCenterPage.IsPageOpened().Should().BeTrue("Help Center page hasn't open.");
            BrowserService.Driver.WindowHandles.Count.Should().Be(2, "Help Center page hasn't open.");
        }
    }
}
