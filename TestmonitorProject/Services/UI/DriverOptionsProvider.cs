using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace TestmonitorProject.Services.UI;

public class DriverOptionsProvider
{
    public ChromeOptions GetChromeDriverOptions() 
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--incognito"); 
        chromeOptions.AddArguments("--disable-gpu"); 
        chromeOptions.AddArguments("--disable-extensions");
        //chromeOptions.AddArguments("--headless");
          
        chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
        chromeOptions.SetLoggingPreference(LogType.Driver, LogLevel.All);

        return chromeOptions;
    }

    public FirefoxOptions GetFirefoxDriverOptions()
    {
        var mimeTypes = "image/png,image/gif,image/jpeg,image/pjpeg,application/pdf,text/csv,application/vnd.ms-excel," +
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" +
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document"; 
          
        var ffOptions = new FirefoxOptions();  
        var profile = new FirefoxProfile();
          
        profile.SetPreference("browser.download.folderList", 2); 
        profile.SetPreference("browser.helperAsk.neverAsk.saveToDisk", mimeTypes);
        profile.SetPreference("browser.helperAsk.neverAsk.openFile", mimeTypes);
        ffOptions.Profile = profile;
          
        ffOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
        ffOptions.SetLoggingPreference(LogType.Driver, LogLevel.All);
          
        return ffOptions;
    }
}
