using OpenQA.Selenium;
using TestmonitorProject.Configuration;

namespace TestmonitorProject.Pages;

public class IssuesPage : BasePage
{
    private string Endpoint(string projectId) => $"{projectId}/projects";

    public IssuesPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public IssuesPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
}
