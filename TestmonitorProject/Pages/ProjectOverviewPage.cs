using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class ProjectOverviewPage : BasePage
{
    private const string Endpoint = "my-projects";
    
    private UiElement Project(string projectName) => new (Driver, By.XPath($"//*[text()='{projectName}']"));
    private UiElement SupportPopUp => new(Driver, By.XPath("//*[@class='support-widget-button']"));
    private UiElement HelpCenterButton => new(Driver, By.XPath("//*[contains(text(),'Visit our knowledge base')]"));

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
    
    [AllureStep("Open \"{0}\" project repository")]
    public ProjectPage OpenProjectByName(string projectName)
    {
        Project(projectName).Click();

        return new ProjectPage(Driver);
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

        Driver.SwitchTo().Window(Driver.WindowHandles[1]);

        return new HelpCenterPage(Driver);
    }
}
