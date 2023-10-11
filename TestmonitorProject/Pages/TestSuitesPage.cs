using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class TestSuitesPage : BasePage
{
    private string Endpoint(string projectId) => $"{projectId}/design/test-suites";

    private UiElement AddTestSuiteButton => new(Driver, By.XPath("//*[contains(text(),'Add Test Suite')]"));
    private UiElement TestSuiteNameInput => new(Driver, By.XPath("//*[@name='name']")); 
    private UiElement CreateTestSuiteButton => new(Driver, By.XPath("//*[@type='submit']"));
    private UiElement SuccessCreatedMessage => new(Driver, By.XPath("//*[@role='alert']//*[contains(text(),'suite')]"));
    
    public TestSuitesPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public TestSuitesPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }

    public TestSuitesPage ClickAddTestSuiteButton()
    {
        AddTestSuiteButton.Click();

        return this;
    }
 
    public bool CreateTestSuite()
    {
        var testSuiteName = new Bogus.Faker().Lorem.Word();

        TestSuiteNameInput.SendKeys(testSuiteName);
        CreateTestSuiteButton.Click();

        return SuccessCreatedMessage.Displayed;
    }
}
