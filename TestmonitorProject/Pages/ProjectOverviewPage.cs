using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Services.UI;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class ProjectOverviewPage : BasePage
{
    private const string Endpoint = "my-projects";
    
    private static UiElement Project(string projectName) => new (BrowserService.Driver, By.XPath($"//*[text()='{projectName}']"));
    private static UiElement SupportPopUp => new(BrowserService.Driver, By.XPath("//*[@class='support-widget-button']"));
    private static UiElement HelpCenterButton => new(BrowserService.Driver, By.XPath("//*[contains(text(),'Visit our knowledge base')]"));

    public ProjectOverviewPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public ProjectOverviewPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        BrowserService.Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
    
    [AllureStep("Open \"{0}\" project repository")]
    public ProjectPage OpenProjectByName(string projectName)
    {
        Project(projectName).Click();

        return new ProjectPage(BrowserService.Driver);
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

        BrowserService.Driver.SwitchTo().Window(BrowserService.Driver.WindowHandles[1]);

        return new HelpCenterPage(BrowserService.Driver);
    }
}
