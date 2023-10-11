using OpenQA.Selenium;
using TestmonitorProject.Pages;

namespace TestmonitorProject.Steps;

public class BaseStep
{
    protected readonly IWebDriver Driver;
    protected readonly LoginPage LoginPage;

    public BaseStep(IWebDriver driver)
    {
        Driver = driver;
        
        LoginPage = new LoginPage(Driver,true);
    }
}
