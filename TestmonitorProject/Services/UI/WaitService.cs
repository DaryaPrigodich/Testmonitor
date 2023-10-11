using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestmonitorProject.Configuration;

namespace TestmonitorProject.Services.UI;

public class WaitService
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _waitService;

    public WaitService(IWebDriver driver)
    {
        _driver = driver;
        _waitService = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configurator.AppSettings.WaitTimeout));
    }
    
    public IWebElement GetExistElement(By by)
    {
        return _waitService.Until(ExpectedConditions.ElementExists(by));
    }
    
    public IWebElement WaitElementIsClickable(IWebElement webElement)
    {
        return _waitService.Until(ExpectedConditions.ElementToBeClickable(webElement));
    }
    
    public bool IsElementInvisible(By by)
    {
        return _waitService.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
    }
    
    public IWebElement GetVisibleElement(By by)
    {
        return _waitService.Until(ExpectedConditions.ElementIsVisible(by));
    }
    
    public void WaitTillElementsVisible(ReadOnlyCollection<IWebElement> elements)
    {
        _waitService.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(elements));
    }
}
