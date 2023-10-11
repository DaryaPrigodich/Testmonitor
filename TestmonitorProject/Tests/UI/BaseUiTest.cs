using NUnit.Framework;
using OpenQA.Selenium;
using TestmonitorProject.Clients;
using TestmonitorProject.Configuration;
using TestmonitorProject.Models.Enum;
using TestmonitorProject.Services.API;
using TestmonitorProject.Services.UI;
using TestmonitorProject.Steps;

namespace TestmonitorProject.Tests.UI;

public class BaseUiTest
{
    protected static IWebDriver Driver = null!;
    
    protected ProjectService ProjectService = null!;
    protected IssueService IssueService = null!;
    
    protected LoginStep LoginSteps = null!;
    
    [SetUp]
    public void SetUpApiAndBrowser()
    {
        var client = new RestClientExtended(UserType.Admin);
        ProjectService = new ProjectService(client);
        IssueService = new IssueService(client);
                
        Driver = new BrowserService(Configurator.AppSettings.Browser).WebDriver;
        LoginSteps = new LoginStep(Driver);
    }
    
    [TearDown]
    public void CloseBrowser()
    {
        Driver.Quit();
    }
}
