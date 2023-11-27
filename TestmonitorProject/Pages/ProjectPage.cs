using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Services.UI;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class ProjectPage : BasePage
{
    private string Endpoint(string projectId) => $"{projectId}";
    
    private static UiElement Requirements => new (BrowserService.Driver.Value!, By.XPath("//span[contains(text(),'requirements')]"));
    private static UiElement TestCases => new (BrowserService.Driver.Value!, By.XPath("//span[contains(text(),'test cases')]"));
    private static UiElement Issues => new (BrowserService.Driver.Value!, By.XPath("//span[contains(text(),'issue')]"));

    public ProjectPage(IWebDriver driver, bool openPageByUrl, string projectId) : base(driver, openPageByUrl)
    {
    }
    
    public ProjectPage(IWebDriver driver) : base(driver,false)
    {
    }
    
    protected override void OpenPage()
    {
        BrowserService.Driver.Value!.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
    
    [AllureStep("Click \"requirements\" button")]
    public RequirementsPage OpenProjectRequirements()
    {
        Requirements.Click();

        return new RequirementsPage(BrowserService.Driver.Value!);
    }
    
    [AllureStep("Click \"test cases\" button")]
    public TestSuitesPage OpenProjectTestCases()
    {
        TestCases.Click();

        return new TestSuitesPage(BrowserService.Driver.Value!);
    }
    
    [AllureStep("Click \"issues\" button")]
    public IssuesPage OpenProjectIssues()
    {
        Issues.Click();

        return new IssuesPage(BrowserService.Driver.Value!);
    }
}
