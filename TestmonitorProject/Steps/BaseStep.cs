using TestmonitorProject.Pages;
using TestmonitorProject.Services.UI;

namespace TestmonitorProject.Steps;

public class BaseStep
{
    protected readonly LoginPage LoginPage = new(BrowserService.Driver,true);
}
