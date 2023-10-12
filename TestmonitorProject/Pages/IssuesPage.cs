using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class IssuesPage : BasePage
{
    private string Endpoint(string projectId) => $"{projectId}/projects";
    
    private UiElement IssueCheckBox(string issueName) => new(Driver, By.XPath($"//*[contains(text(),'{issueName}')]/parent::*/preceding-sibling::*//label"));
    private DropDownMenu IssueSettings => new(Driver, By.XPath("//*[contains(text(),'selected')]")); 
    private UiElement DeleteOption => new(Driver, By.XPath("//*[contains(text(),'Delete')]")); 
    private UiElement DeletionConfirmationCheckBox => new(Driver, By.XPath("//*[@class='check is-danger']"));
    private UiElement DeleteButton => new(Driver, By.XPath("//button[contains(@class,'is-danger')]"));
    private Table Issues => new(Driver, By.XPath("//table"));

    public IssuesPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public IssuesPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
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
