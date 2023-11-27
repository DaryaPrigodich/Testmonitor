using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Services.UI;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class IssuesPage : BasePage
{
    private string Endpoint(string projectId) => $"{projectId}/projects";
    
    private static UiElement IssueCheckBox(string issueName) => new(BrowserService.Driver.Value!, By.XPath($"//*[contains(text(),'{issueName}')]/parent::*/preceding-sibling::*//label"));
    private static DropDownMenu IssueSettings => new(BrowserService.Driver.Value!, By.XPath("//*[contains(text(),'selected')]")); 
    private static UiElement DeleteOption => new(BrowserService.Driver.Value!, By.XPath("//*[contains(text(),'Delete')]")); 
    private static UiElement DeletionConfirmationCheckBox => new(BrowserService.Driver.Value!, By.XPath("//*[@class='check is-danger']"));
    private static UiElement DeleteButton => new(BrowserService.Driver.Value!, By.XPath("//button[contains(@class,'is-danger')]"));
    private static Table Issues => new(BrowserService.Driver.Value!, By.XPath("//table"));

    public IssuesPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public IssuesPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        BrowserService.Driver.Value!.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }

    [AllureStep("Open issue settings")]
    private void OpenIssueSettings(string issueName)
    {
        IssueCheckBox(issueName).Click();
        IssueSettings.OpenDropDownMenu();
    }

    [AllureStep("Click Delete option")]
    private void SelectDeleteOption()
    {
        DeleteOption.Click();
    }

    [AllureStep("Confirm deletion")]
    private void ConfirmDeletion()
    {
        DeletionConfirmationCheckBox.Click();
        DeleteButton.Click();
    }
    
    [AllureStep("Delete \"{0}\" issue")]
    public bool DeleteIssue(string issueName)
    {
        OpenIssueSettings(issueName);
        SelectDeleteOption();
        ConfirmDeletion();
        
        return Issues.IsRowInvisible(issueName);
    }
}
