using System.Reflection;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class RequirementsPage : BasePage
{
    private const string Endpoint = "projects";

    private UiElement AddRequirementButton => new(Driver, By.XPath("//*[contains(text(),'Add Requirement')]"));
    private UiElement CreateRequirementButton => new(Driver, By.XPath("//*[@type='submit']"));
    private UiElement CreateRequirementForm => new(Driver, By.XPath("//*[@class='modal-card']"));
    private UiElement RequirementNameInput => new(Driver, By.XPath("//*[@name='name']"));
    private UiElement RequirementName => new(Driver, By.XPath("//td[@data-label='Name']//span"));

    public RequirementsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public RequirementsPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }

    public RequirementsPage ClickAddRequirementButton()
    {
        AddRequirementButton.Click();

        return this;
    }

    public bool ClickCreateButton()
    {
        CreateRequirementButton.Click();

        return CreateRequirementForm.Displayed;
    }
    
    public RequirementsPage CreateRequirement(int requirementNameLength)
    {
        var requirementName = new Bogus.Faker().Lorem.Letter(requirementNameLength);

        RequirementNameInput.SendKeys(requirementName);
        CreateRequirementButton.Click();

        return this;
    }
    
    public int GetRequirementNameLength()
    {
        return RequirementName.Text.Length;
    }
}
