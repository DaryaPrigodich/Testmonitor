using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestmonitorProject.Configuration;

namespace TestmonitorProject.Services.UI;

public class BrowserService
{
    
    [field: ThreadStatic]
    public static ThreadLocal<IWebDriver> Driver { get; private set; } = null!;
    
    public static void InitBrowser()
    {
        Driver = Configurator.AppSettings.Browser switch
        {
            "chrome" => new ThreadLocal<IWebDriver>(() => new ChromeDriver(DriverOptionsProvider.GetChromeDriverOptions())),
            "firefox" => new ThreadLocal<IWebDriver>(() => new FirefoxDriver(DriverOptionsProvider.GetFirefoxDriverOptions())),
            _ => throw new ArgumentException("Check that your Browser property in appsettings.json is set to either chrome or firefox.")
        };

        Driver.Value.Manage().Window.Maximize();
        Driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
}
