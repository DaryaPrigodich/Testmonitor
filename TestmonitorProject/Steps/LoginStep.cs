using OpenQA.Selenium;
using TestmonitorProject.Pages;

namespace TestmonitorProject.Steps;

public class LoginStep : BaseStep
{
    public LoginStep(IWebDriver driver) : base(driver)
    {
    }

    public ProjectOverviewPage LoginWithValidCredentials(string username,string password)
    {
        LoginPage.InputUsernameAndPassword(username,password)
            .SubmitLoginForm();
        
        return new ProjectOverviewPage(Driver);
    }
}
