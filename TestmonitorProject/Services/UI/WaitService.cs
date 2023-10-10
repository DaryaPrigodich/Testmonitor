using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
}
