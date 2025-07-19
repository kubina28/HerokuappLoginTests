using HerokuappLoginTests.Pages;
using HerokuappLoginTests.scr.Constants;
using HerokuappLoginTests.scr.Pages;
using Microsoft.Playwright.NUnit;


namespace HerokuappLoginTests.tests
{
    [TestFixture]
    public class LoginTests : PageTest
    {
        private LoginPage loginPage => new(Page);
        private SecurePage securePage => new(Page);

        [SetUp]
        public async Task TestSetup()
        {
            await loginPage.NavigateToBaseUrlAsync();
        }

        [Test(Description = "Test successful login with valid credentials")]
        public async Task ShouldLoginSuccessfullyWithValidCredentials()
        {
            // Act: Perform login using constants for credentials
            await loginPage.LoginAsync(Constants.ValidCredentials.Username, Constants.ValidCredentials.Password);

            // Assert: Verify the result using constants for messages and URLs
            await Expect(loginPage.FlashMessage).ToContainTextAsync(Constants.SuccessfulLoginMessage);
            await Expect(Page).ToHaveURLAsync(Constants.SecureAreaUrl);
        }

        [Test(Description = "Test unsuccessful login with invalid credentials")]
        public async Task ShouldFailLoginWithInvalidCredentials()
        {
            // Act: Perform login using constants for invalid credentials
            await loginPage.LoginAsync(Constants.InvalidCredentials.Username, Constants.InvalidCredentials.Password);

            // Assert: Verify the error message using a constant
            await Expect(loginPage.FlashMessage).ToContainTextAsync(Constants.InvalidUsernameMessage);
        }

        [Test(Description = "Test successful logout after login")]
        public async Task ShouldLogoutSuccessfully()
        {
            // Arrange: Login first
            await loginPage.LoginAsync(Constants.ValidCredentials.Username, Constants.ValidCredentials.Password);
            await Expect(Page).ToHaveURLAsync(Constants.SecureAreaUrl);

            // Act: Logout
            await securePage.LogoutButton.ClickAsync();

            // Assert
            await Expect(Page).ToHaveURLAsync(Constants.LoginUrl);
            await Expect(loginPage.FlashMessage).ToContainTextAsync(Constants.SuccessfulLogoutMessage);
        }

        [Test(Description = "Case-sensitive username")]
        public async Task ShouldFailLoginWithCaseSensitiveCredentials()
        {
            // Act
            await loginPage.LoginAsync(Constants.CaseSensitiveInvalidCredentials.Username, Constants.CaseSensitiveInvalidCredentials.Password);

            // Assert
            await Expect(loginPage.FlashMessage).ToContainTextAsync(Constants.InvalidUsernameMessage);
        }

        // Note: The following three tests could be replaced by a single, parameterized [TestCase] test.It's just sample. 
        // At first doesn't work now for invalid password message (easy to fix), but this approach is not used here because it can add a level of abstraction that is difficult for inexperienced users.
        //[TestCase("", "", Description = "Empty username and password")]
        //[TestCase(Constants.ValidCredentials.Username, "", Description = "Empty password")]
        //[TestCase("", Constants.ValidCredentials.Password, Description = "Empty username")]
        //public async Task ShouldFailLoginWithEmptyCredentials(string username, string password)
        //{
        //    // Act
        //    await loginPage.LoginAsync(username, password);

        //    // Assert
        //    await Expect(loginPage.FlashMessage).ToContainTextAsync(Constants.InvalidUsernameMessage);
        //}

        [Test(Description = "Test login failure with empty username and password")]
        public async Task ShouldFailLoginWithBothCredentialsEmpty()
        {
            // Act
            await loginPage.LoginAsync("", "");

            // Assert
            await Expect(loginPage.FlashMessage).ToContainTextAsync(Constants.InvalidUsernameMessage);
        }

        [Test(Description = "Test login failure with empty password")]
        public async Task ShouldFailLoginWithEmptyPassword()
        {
            // Act
            await loginPage.LoginAsync(Constants.ValidCredentials.Username, "");

            // Assert
            await Expect(loginPage.FlashMessage).ToContainTextAsync(Constants.InvalidPasswordMessage);
        }

        [Test(Description = "Test login failure with empty username")]
        public async Task ShouldFailLoginWithEmptyUsername()
        {
            // Act
            await loginPage.LoginAsync("", Constants.ValidCredentials.Password);

            // Assert
            await Expect(loginPage.FlashMessage).ToContainTextAsync(Constants.InvalidUsernameMessage);
        }

        [Test(Description = "Test that the login button is enabled on page load")]
        public async Task ShouldHaveEnabledLoginButton()
        {
            // Assert
            await Expect(loginPage.LoginButton).ToBeEnabledAsync();
        }
    }
}

