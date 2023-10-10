using OpenQA.Selenium;

namespace TestmonitorProject.Pages;

public abstract class BasePage
{
    protected static IWebDriver Driver = null!;

    protected abstract void OpenPage();

    protected BasePage(IWebDriver driver, bool openPageByUrl)
    {
        Driver = driver;

        if (openPageByUrl)
        {
            OpenPage();
        }
    }
}
