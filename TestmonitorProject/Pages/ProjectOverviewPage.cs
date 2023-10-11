using OpenQA.Selenium;
using TestmonitorProject.Configuration;

namespace TestmonitorProject.Pages;

public class ProjectOverviewPage : BasePage
{
    private const string Endpoint = "my-projects";
    
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
}
