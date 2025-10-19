using NUnit.Framework;
using PlaywrightTests.Pages;
using PlaywrightTests.Support;

namespace PlaywrightTests.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        [Category("Smoke")]
        public async Task SuccessfulLogin_WithValidCredentials()
        {
            // Arrange
            var loginPage = new LoginPage(Page);
            await loginPage.NavigateAsync();

            // Act
            await loginPage.LoginAsync("standard_user", "secret_sauce");

            // Assert
            var productsPage = new ProductsPage(Page);
            Assert.That(await productsPage.IsDisplayedAsync(), Is.True, 
                "Products page should be displayed after successful login");
        }

        [Test]
        [Category("Negative")]
        public async Task FailedLogin_WithInvalidCredentials()
        {
            // Arrange
            var loginPage = new LoginPage(Page);
            await loginPage.NavigateAsync();

            // Act
            await loginPage.LoginAsync("invalid_user", "wrong_password");

            // Assert
            Assert.That(await loginPage.IsErrorVisibleAsync(), Is.True,
                "Error message should be displayed");
            
            var errorText = await loginPage.GetErrorTextAsync();
            Assert.That(errorText, Does.Contain("Epic sadface"),
                "Error message should contain 'Epic sadface'");
        }

        [Test]
        [Category("Negative")]
        public async Task FailedLogin_WithLockedOutUser()
        {
            // Arrange
            var loginPage = new LoginPage(Page);
            await loginPage.NavigateAsync();

            // Act
            await loginPage.LoginAsync("locked_out_user", "secret_sauce");

            // Assert
            Assert.That(await loginPage.IsErrorVisibleAsync(), Is.True);
            var errorText = await loginPage.GetErrorTextAsync();
            Assert.That(errorText, Does.Contain("locked out"));
        }
    }
}