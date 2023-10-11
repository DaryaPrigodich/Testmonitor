using FluentAssertions;
using NUnit.Framework;

namespace TestmonitorProject.Tests.UI;

public class AuthorizationTest: BaseUiTest
{
    [Test]
    [TestCase("invalid@email", "123", "These credentials do not match our records.")]
    public void AuthorizationUsingInvalidCredentials(string username, string password, string errorMessage)
    {
        var loginErrorMessage = LoginSteps
            .LoginWithInvalidCredentials(username,password);

        loginErrorMessage.Should().Be(errorMessage, "User with invalid credentials has an access to the app.");
    }
}
