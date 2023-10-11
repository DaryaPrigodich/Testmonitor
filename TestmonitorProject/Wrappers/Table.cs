using OpenQA.Selenium;
using TestmonitorProject.Services.UI;

namespace TestmonitorProject.Wrappers;

public class Table
{
    private readonly UiElement _uiElement;
    private readonly WaitService _waitService;
    
    public Table(IWebDriver driver, By by)
    {
        _uiElement = new UiElement(driver, by);
        _waitService = new WaitService(driver);
    }
    
    
    public bool IsRowInvisible(string rowName) => _waitService
        .IsElementInvisible(By.XPath($"//td//*[contains(text(),'{rowName}')]"));

    public bool IsTableContentVisible() => _waitService.GetVisibleElement(By.XPath("//tbody")).Displayed;
}
