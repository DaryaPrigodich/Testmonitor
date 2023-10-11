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
    private DropDownMenu RequirementSettings => new(Driver, By.XPath("//*[@class='dropdown-component']//*[contains(@class,'is-bottom-left')]"));
    private UiElement ImportOption => new(Driver, By.XPath("//*[contains(text(),'Import')]"));
    private UiElement ImportField => new(Driver, By.XPath("//input[@type='file']"));
    private UiElement Mapping => new(Driver, By.XPath("//*[contains(text(),'Mapping')]/parent::button"));
    private UiElement MapColumn => new(Driver, By.XPath("//span[contains(text(),'Map')]"));
    private UiElement NameOption => new(Driver, By.XPath("//span[contains(text(),'name')]"));
    private UiElement DescriptionOption => new(Driver, By.XPath("(//span[contains(text(),'description')])[2]"));
    private UiElement TypeOption => new(Driver, By.XPath("(//span[contains(text(),'type')])[3]"));
    private UiElement Next => new(Driver, By.XPath("//button//*[contains(text(),'Next')]"));
    private UiElement ConfirmationButton => new(Driver, By.XPath("//button//span[contains(text(),'Confirm')]"));
    private UiElement ImportButton => new(Driver, By.XPath("//span[contains(text(),'Import')]"));
    private UiElement BackButton => new(Driver, By.XPath("//button[contains(@class,'success')]"));
    private Table Requirements => new(Driver, By.XPath("//table"));
    
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
    
    private static string GetFilePath()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        return Path.Combine(basePath, $"TestData{Path.DirectorySeparatorChar}", "requirements-import-example.xlsx");
    }

    private void UploadFile()
    {
        var filePath = GetFilePath();

        ImportField.SendKeys(filePath);
        Mapping.Click();
    }

    private void MappingFile()
    {
        MapColumn.Click();
        NameOption.Click();
        Next.Click();
        MapColumn.Click();
        DescriptionOption.Click();
        Next.Click();
        MapColumn.Click();
        TypeOption.Click();
        Next.Click();
        ConfirmationButton.Click();
    }
    
    public bool ImportFile()
    {
        RequirementSettings.OpenDropDownMenu();
        ImportOption.Click();
        UploadFile();
        MappingFile();
        ImportButton.Click();
        BackButton.Click();

        return Requirements.IsTableContentVisible();
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
