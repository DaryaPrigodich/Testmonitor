using OpenQA.Selenium;
using TestmonitorProject.Services.UI;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class HelpCenterPage : BasePage
{
    private string SupportURL => "https://help.testmonitor.com/";
    
    private static UiElement HelpCategories => new (BrowserService.Driver.Value!, By.XPath("//*[@class='content-container']"));

    public HelpCenterPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    
    public HelpCenterPage(IWebDriver driver) : base(driver,false)
    {
    }
    
    protected override void OpenPage()
    {
        BrowserService.Driver.Value!.Navigate().GoToUrl(SupportURL);
    }
    
    public bool IsPageOpened()
    {
        try
        {
            return HelpCategories.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
