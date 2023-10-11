using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestmonitorProject.Services.UI;

namespace TestmonitorProject.Wrappers;

public class UiElement : IWebElement
{
    private readonly IWebElement _webElement;
    private readonly IWebDriver _driver;
    private readonly By _by;
    private readonly Actions _actions;
    private readonly IJavaScriptExecutor _jsExecutor;
    private readonly WaitService _waitService;
    
    public string TagName => _webElement.TagName;

    public string Text => _webElement.Text;

    public bool Enabled => _webElement.Enabled;

    public bool Selected => _webElement.Selected;

    public Point Location => _webElement.Location;

    public Size Size => _webElement.Size;

    public bool Displayed => _webElement.Displayed;

    public UiElement(IWebDriver driver, By by)
    {
        _driver = driver;
        _by = by;
        _actions = new Actions(_driver);
        _waitService = new WaitService(_driver);
        _webElement = _waitService.GetExistElement(_by);
        _jsExecutor = (IJavaScriptExecutor)driver;
    }
    
    public IWebElement FindElement(By by)
    {
        return _webElement.FindElement(by);
    }

    public ReadOnlyCollection<IWebElement> FindElements(By by)
    {
        return _webElement.FindElements(by);
    }

    public void Clear()
    {
        _webElement.Clear();
    }

    public void SendKeys(string text)
    {
        _webElement.SendKeys(text);
    }

    public void Submit()
    {
        _webElement.Submit();
    }

    public void Click()
    {
        try
        {
           _waitService.WaitElementIsClickable(_webElement).Click();
        }
        catch (Exception)
        {
            try
            {
               _actions.MoveToElement(_webElement).Click().Build().Perform();
            }
            catch (Exception)
            {
                _jsExecutor.ExecuteScript("arguments[0].click()", _webElement);
            }
        }
    }

    public string GetAttribute(string attributeName)
    {
        return _webElement.GetAttribute(attributeName);
    }

    public string GetDomAttribute(string attributeName)
    {
        return _webElement.GetDomAttribute(attributeName);
    }

    public string GetDomProperty(string propertyName)
    {
        return _webElement.GetDomProperty(propertyName);
    }

    public string GetCssValue(string propertyName)
    {
        return _webElement.GetCssValue(propertyName);
    }

    public ISearchContext GetShadowRoot()
    {
        return _webElement.GetShadowRoot();
    }
}
