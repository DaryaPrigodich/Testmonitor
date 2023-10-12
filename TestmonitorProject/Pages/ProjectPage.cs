﻿using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class ProjectPage : BasePage
{
    private string Endpoint(string projectId) => $"{projectId}";
    
    private UiElement Requirements => new (Driver, By.XPath("//span[contains(text(),'requirements')]"));
    private UiElement TestCases => new (Driver, By.XPath("//span[contains(text(),'test cases')]"));
    private UiElement Issues => new (Driver, By.XPath("//span[contains(text(),'issue')]"));

    public ProjectPage(IWebDriver driver, bool openPageByUrl, string projectId) : base(driver, openPageByUrl)
    {
    }
    
    public ProjectPage(IWebDriver driver) : base(driver,false)
    {
    }
    
    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }
    
    [AllureStep("Open project requirements overview page")]
    public RequirementsPage OpenProjectRequirements()
    {
        Requirements.Click();

        return new RequirementsPage(Driver);
    }
    
    [AllureStep("Open project test cases overview page")]
    public TestSuitesPage OpenProjectTestCases()
    {
        TestCases.Click();

        return new TestSuitesPage(Driver);
    }
    
    [AllureStep("Open project issues overview page")]
    public IssuesPage OpenProjectIssues()
    {
        Issues.Click();

        return new IssuesPage(Driver);
    }
}
