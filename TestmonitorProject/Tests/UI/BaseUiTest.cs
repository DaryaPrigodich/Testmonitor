using Allure.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TestmonitorProject.Clients;
using TestmonitorProject.Models.Enum;
using TestmonitorProject.Services.API;
using TestmonitorProject.Services.UI;
using TestmonitorProject.Steps;

namespace TestmonitorProject.Tests.UI;

public class BaseUiTest
{
   private RestClientExtended _client = null!;

    protected ProjectService ProjectService = null!;
    protected IssueService IssueService = null!;

    protected LoginStep LoginSteps = null!;
    
    [SetUp]
    public void SetUpApiAndBrowser()
    {
        _client = new RestClientExtended(UserType.Admin);
        ProjectService = new ProjectService(_client);
        IssueService = new IssueService(_client);
        
        BrowserService.InitBrowser();
        
        LoginSteps = new LoginStep();
    }

    [TearDown]
    public void CloseBrowser()
    {
        if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        {
            var screenshot = ((ITakesScreenshot)BrowserService.Driver).GetScreenshot().AsByteArray;
            AllureLifecycle.Instance.AddAttachment("Attachment", "image/png", screenshot);
        }

        BrowserService.Driver.Value!.Quit();
    }
}