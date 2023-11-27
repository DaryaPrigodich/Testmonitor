using System.Collections.Concurrent;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using TestmonitorProject.Configuration;

namespace TestmonitorProject.Services.UI;

public class BrowserService
{
    
    private static readonly ConcurrentDictionary<string, IWebDriver> DriverCollection = new();

    public static IWebDriver Driver
    {
        get
        {
            DriverCollection.TryGetValue(TestContext.CurrentContext.Test.Name, out var driver);
                
            return driver!;
        }

        private set => DriverCollection.TryAdd(TestContext.CurrentContext.Test.Name, value);
    }

    public static void InitBrowser()
    {
        Driver = Configurator.AppSettings.Browser switch
        {
            "chrome" => new ChromeDriver(DriverOptionsProvider.GetChromeDriverOptions()),
            "firefox" => new FirefoxDriver(DriverOptionsProvider.GetFirefoxDriverOptions()),
            _ => throw new ArgumentException("Check that your Browser property in appsettings.json is set to either chrome or firefox.")
        };

        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
}
