using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Services.UI;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class TestSuitesPage : BasePage
{
    private string Endpoint(string projectId) => $"{projectId}/design/test-suites";

    private static UiElement AddTestSuiteButton => new(BrowserService.Driver.Value!, By.XPath("//*[contains(text(),'Add Test Suite')]"));
    private static UiElement TestSuiteNameInput => new(BrowserService.Driver.Value!, By.XPath("//*[@name='name']")); 
    private static UiElement CreateTestSuiteButton => new(BrowserService.Driver.Value!, By.XPath("//*[@type='submit']"));
    private static UiElement SuccessCreatedMessage => new(BrowserService.Driver.Value!, By.XPath("//*[@role='alert']//*[contains(text(),'suite')]"));
    
    public TestSuitesPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public TestSuitesPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        BrowserService.Driver.Value!.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
   
    [AllureStep("Populate test suite data")]
    private void PopulateTestSuiteData()
    {
        var testSuiteName = new Bogus.Faker().Lorem.Word();

        TestSuiteNameInput.SendKeys(testSuiteName);
    }

    [AllureStep("Submit test suite form")]
    private void SubmitTestSuiteForm()
    {
        CreateTestSuiteButton.Click();
    }

    [AllureStep("Click on \"Add Test Suite\" button")]
    public TestSuitesPage ClickAddTestSuiteButton()
    {
        AddTestSuiteButton.Click();

        return this;
    }
 
    [AllureStep("Create test suite")]
    public bool CreateTestSuite()
    {
        PopulateTestSuiteData();
        SubmitTestSuiteForm();
        
        return SuccessCreatedMessage.Displayed;
    }
}
