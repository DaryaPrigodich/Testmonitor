using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class ProjectPage : BasePage
{
    private string Endpoint(string projectId) => $"{projectId}";
    
    private UiElement Requirements => new (Driver, By.XPath("//span[contains(text(),'requirements')]"));
    private UiElement TestCases => new (Driver, By.XPath("//span[contains(text(),'test cases')]"));

    public ProjectPage(IWebDriver driver, bool openPageByUrl, string projectId) : base(driver, openPageByUrl)
    {
    }
    
    public ProjectPage(IWebDriver driver) : base(driver,false)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
    
    public RequirementsPage OpenProjectRequirements()
    {
        Requirements.Click();

        return new RequirementsPage(Driver);
    }
    
    public TestSuitesPage OpenProjectTestCases()
    {
        TestCases.Click();

        return new TestSuitesPage(Driver);
    }
}
