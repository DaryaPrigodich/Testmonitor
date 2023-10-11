using OpenQA.Selenium;
using TestmonitorProject.Configuration;

namespace TestmonitorProject.Pages;

public class ProjectPage : BasePage
{
    private string Endpoint(string projectId) => $"{projectId}";

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
}
