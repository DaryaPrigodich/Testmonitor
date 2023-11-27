using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Services.UI;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class ProjectOverviewPage : BasePage
{
    private const string Endpoint = "my-projects";
    
    private static UiElement Project(string projectName) => new (BrowserService.Driver.Value!, By.XPath($"//*[text()='{projectName}']"));
    private static UiElement SupportPopUp => new(BrowserService.Driver.Value!, By.XPath("//*[@class='support-widget-button']"));
    private static UiElement HelpCenterButton => new(BrowserService.Driver.Value!, By.XPath("//*[contains(text(),'Visit our knowledge base')]"));

    public ProjectOverviewPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public ProjectOverviewPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        BrowserService.Driver.Value!.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
    
    [AllureStep("Open \"{0}\" project repository")]
    public ProjectPage OpenProjectByName(string projectName)
    {
        Project(projectName).Click();

        return new ProjectPage(BrowserService.Driver.Value!);
    }
    
    [AllureStep("Click \"support pop-up\" button")]
    public ProjectOverviewPage ShowSupportPopUp()
    {
        SupportPopUp.Click();
        
        return this;
    }
   
    [AllureStep("Click \"Help center\" option")]
    public HelpCenterPage OpenHelpCenter()
    {
        HelpCenterButton.Click();

        BrowserService.Driver.Value!.SwitchTo().Window(BrowserService.Driver.Value!.WindowHandles[1]);

        return new HelpCenterPage(BrowserService.Driver.Value!);
    }
}
