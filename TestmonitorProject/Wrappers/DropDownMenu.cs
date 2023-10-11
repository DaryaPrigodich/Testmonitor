using OpenQA.Selenium;
using TestmonitorProject.Services.UI;

namespace TestmonitorProject.Wrappers;

public class DropDownMenu
{
    private UiElement _uiElement;
    private readonly WaitService _waitService;

    public DropDownMenu(IWebDriver driver, By by)
    {
        _uiElement = new UiElement(driver, by);
        _waitService = new WaitService(driver);
    }
    
    private bool IsOptionsVisible()
    {
        try
        {
            var options = _uiElement.FindElements(By.XPath("//*[@class='dropdown-menu']//a[@role='listitem']"));

            _waitService.WaitTillElementsVisible(options);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public void OpenDropDownMenu()
    {
        var isOptionVisible = IsOptionsVisible();

        if (isOptionVisible)
        {
            throw new InvalidOperationException("Dropdown is already open.");
        }

        _uiElement.Click();
    }
}
