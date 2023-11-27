using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Services.UI;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class LoginPage : BasePage
{
    private const string Endpoint = "login";
    
    private static UiElement EmailInput => new (BrowserService.Driver.Value!, By.Id("email"));
    private static UiElement PasswordInput => new (BrowserService.Driver.Value!, By.Id("password"));
    private static UiElement LoginButton => new (BrowserService.Driver.Value!, By.XPath("//*[@type='submit']"));
    private static UiElement ErrorMessage => new (BrowserService.Driver.Value!, By.XPath("//*[@class='message-body']"));

    public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        BrowserService.Driver.Value!.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
    
    [AllureStep("Populate authorization data with: username {0} password {1}")]
    public LoginPage InputUsernameAndPassword(string username, string password)
    {
        EmailInput.SendKeys(username);
        PasswordInput.SendKeys(password);

        return this;
    }

    [AllureStep("Submit authorization form")]
    public LoginPage SubmitLoginForm()
    {
        LoginButton.Click();
        
        return this;
    }
    
    public string GetErrorMessage()
    {
        return ErrorMessage.Text; 
    }
}
