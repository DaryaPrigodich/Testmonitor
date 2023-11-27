using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Pages;
using TestmonitorProject.Services.UI;

namespace TestmonitorProject.Steps;

public class LoginStep : BaseStep
{
    [AllureStep("Log in with valid credentials, login - {0} and password - {1}")]
    public ProjectOverviewPage LoginWithValidCredentials(string username,string password)
    {
        LoginPage.InputUsernameAndPassword(username,password)
            .SubmitLoginForm();
        
        return new ProjectOverviewPage(BrowserService.Driver);
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
