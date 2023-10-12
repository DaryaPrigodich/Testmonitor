using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Pages;

namespace TestmonitorProject.Steps;

public class LoginStep : BaseStep
{
    public LoginStep(IWebDriver driver) : base(driver)
    {
    }

    [AllureStep("Log in with valid credentials, login - {0} and password - {1}")]
    public ProjectOverviewPage LoginWithValidCredentials(string username,string password)
    {
        LoginPage.InputUsernameAndPassword(username,password)
            .SubmitLoginForm();
        
        return new ProjectOverviewPage(Driver);
    }
    
    [AllureStep("Log in with invalid credentials, login - {0} and password - {1}")]
    public string LoginWithInvalidCredentials(string username,string password)
    {
        var loginErrorMessage = LoginPage
            .InputUsernameAndPassword(username,password)
            .SubmitLoginForm()
            .GetErrorMessage();
        
        return loginErrorMessage ;
    }
}
