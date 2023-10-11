using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class ProjectOverviewPage : BasePage
{
    private const string Endpoint = "my-projects";
    
    private UiElement Project(string projectName) => new (Driver, By.XPath($"//*[text()='{projectName}']"));

    public ProjectOverviewPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public ProjectOverviewPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
    
    public ProjectPage OpenProjectByName(string projectName)
    {
        Project(projectName).Click();

        return new ProjectPage(Driver);
    }
}
