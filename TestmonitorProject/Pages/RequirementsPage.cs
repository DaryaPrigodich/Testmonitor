using System.Reflection;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestmonitorProject.Configuration;
using TestmonitorProject.Services.UI;
using TestmonitorProject.Wrappers;

namespace TestmonitorProject.Pages;

public class RequirementsPage : BasePage
{
    private const string Endpoint = "projects";

    private static UiElement AddRequirementButton => new(BrowserService.Driver.Value!, By.XPath("//*[contains(text(),'Add Requirement')]"));
    private static UiElement CreateRequirementButton => new(BrowserService.Driver.Value!, By.XPath("//*[@type='submit']"));
    private static UiElement CreateRequirementForm => new(BrowserService.Driver.Value!, By.XPath("//*[@class='modal-card']"));
    private static UiElement RequirementNameInput => new(BrowserService.Driver.Value!, By.XPath("//*[@name='name']"));
    private static UiElement RequirementName => new(BrowserService.Driver.Value!, By.XPath("//td[@data-label='Name']//span"));
    private static DropDownMenu RequirementSettings => new(BrowserService.Driver.Value!, By.XPath("//*[@class='dropdown-component']//*[contains(@class,'is-bottom-left')]"));
    private static UiElement ImportOption => new(BrowserService.Driver.Value!, By.XPath("//*[contains(text(),'Import')]"));
    private static UiElement ImportField => new(BrowserService.Driver.Value!, By.XPath("//input[@type='file']"));
    private static UiElement Mapping => new(BrowserService.Driver.Value!, By.XPath("//*[contains(text(),'Mapping')]/parent::button"));
    private static UiElement MapColumn => new(BrowserService.Driver.Value!, By.XPath("//span[contains(text(),'Map')]"));
    private static UiElement NameOption => new(BrowserService.Driver.Value!, By.XPath("//span[contains(text(),'name')]"));
    private static UiElement DescriptionOption => new(BrowserService.Driver.Value!, By.XPath("(//span[contains(text(),'description')])[2]"));
    private static UiElement TypeOption => new(BrowserService.Driver.Value!, By.XPath("(//span[contains(text(),'type')])[3]"));
    private static UiElement Next => new(BrowserService.Driver.Value!, By.XPath("//button//*[contains(text(),'Next')]"));
    private static UiElement ConfirmationButton => new(BrowserService.Driver.Value!, By.XPath("//button//span[contains(text(),'Confirm')]"));
    private static UiElement ImportButton => new(BrowserService.Driver.Value!, By.XPath("//button//span[contains(text(),'Import')]"));
    private static UiElement BackButton => new(BrowserService.Driver.Value!, By.XPath("//button[contains(@class,'success')]"));
    private static Table Requirements => new(BrowserService.Driver.Value!, By.XPath("//table"));
    
    public RequirementsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public RequirementsPage(IWebDriver driver) : base(driver, false)
    {
    }

    protected override void OpenPage()
    {
        BrowserService.Driver.Value!.Navigate().GoToUrl(Configurator.AppSettings.UiUrl + Endpoint);
    }

    [AllureStep("Click \"Import\" in requirements settings")]
    private void OpenImportSettings()
    {
        RequirementSettings.OpenDropDownMenu();
        ImportOption.Click();
    }

    private static string GetFilePath()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        return Path.Combine(basePath, $"TestData{Path.DirectorySeparatorChar}", "requirements-import-example.xlsx");
    }

    [AllureStep("Upload \"requirements-import-example\" file")]
    private void UploadFile()
    {
        var filePath = GetFilePath();

        ImportField.SendKeys(filePath);
        Mapping.Click();
    }

    [AllureStep("Match file columns")]
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

    [AllureStep("Click confirmation buttons")]
    private void ConfirmImport()
    {
        ImportButton.Click();
        BackButton.Click();
    }

    [AllureStep("Populate requirement data")]
    private void PopulateRequirementData(int requirementNameLength)
    {
        var requirementName = new Bogus.Faker().Lorem.Letter(requirementNameLength);

        RequirementNameInput.SendKeys(requirementName);
    }

    [AllureStep("Submit requirement form")]
    private void SubmitRequirementForm()
    {
        CreateRequirementButton.Click();
    }

    [AllureStep("Import \"requirements-import-example\" file")]
    public bool ImportFile()
    {
        OpenImportSettings();
        UploadFile();
        MappingFile();
        ConfirmImport();

        return Requirements.IsTableContentVisible();
    }

    [AllureStep("Click on \"Add Requirement\" button")]
    public RequirementsPage ClickAddRequirementButton()
    {
        AddRequirementButton.Click();

        return this;
    }

    [AllureStep("Click on \"Create\" button")]
    public bool ClickCreateButton()
    {
        CreateRequirementButton.Click();

        return CreateRequirementForm.Displayed;
    }
    
    [AllureStep("Create requirement with \"{0}\" characters in requirement name input")]
    public RequirementsPage CreateRequirement(int requirementNameLength)
    {
        PopulateRequirementData(requirementNameLength);
        SubmitRequirementForm();
        
        return this;
    }
    
    public int GetRequirementNameLength()
    {
        return RequirementName.Text.Length;
    }
}
