using OpenQA.Selenium;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class HelpCenterPage : BasePage
{
    private string SupportURL => "https://help.testmonitor.com/";
    
    private UiElement HelpCategories => new (Driver, By.XPath("//*[@class='content-container']"));

    public HelpCenterPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }
    
    public HelpCenterPage(IWebDriver driver) : base(driver,false)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(SupportURL);
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
