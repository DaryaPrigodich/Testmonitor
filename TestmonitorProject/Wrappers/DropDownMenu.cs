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
}
