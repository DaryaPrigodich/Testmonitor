using Allure.Commons;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace TestmonitorProject.Tests.UI;

[AllureNUnit]
[AllureParentSuite("UI")]
[AllureEpic("Authorization")]
public class AuthorizationTest: BaseUiTest
{
    [Test]
    [Category("Negative")][Category("Security")]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureName("Authorization with invalid credentials")]
    [TestCase("invalid@email", "123", "These credentials do not match our records.")]
    public void AuthorizationUsingInvalidCredentials(string username, string password, string errorMessage)
    {
        var loginErrorMessage = LoginSteps
            .LoginWithInvalidCredentials(username,password);

        loginErrorMessage.Should().Be(errorMessage, "User with invalid credentials has an access to the app.");
    }
}
