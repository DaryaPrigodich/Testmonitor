using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class LoginPage : BasePage
{
    private const string Endpoint = "login";
    
    private UiElement EmailInput => new (Driver, By.Id("email"));
    private UiElement PasswordInput => new (Driver, By.Id("password"));
    private UiElement LoginButton => new (Driver, By.XPath("//*[@type='submit']"));
    private UiElement ErrorMessage => new (Driver, By.XPath("//*[@class='message-body']"));

    public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
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
