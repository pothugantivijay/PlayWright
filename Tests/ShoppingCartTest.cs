using NUnit.Framework;
using PlaywrightTests.Pages;
using PlaywrightTests.Support;

namespace PlaywrightTests.Tests
{
    [TestFixture]
    public class ShoppingCartTests : TestBase
    {
        private LoginPage _loginPage = null!;
        private ProductsPage _productsPage = null!;

        [SetUp]
        public async Task Setup()
        {
            _loginPage = new LoginPage(Page);
            _productsPage = new ProductsPage(Page);
            
            await _loginPage.NavigateAsync();
            await _loginPage.LoginAsync("standard_user", "secret_sauce");
        }

        [Test]
        [Category("Cart")]
        public async Task AddSingleItem_ToCart()
        {
            // Act
            await _productsPage.AddBackpackToCartAsync();

            // Assert
            var cartCount = await _productsPage.GetCartCountAsync();
            Assert.That(cartCount, Is.EqualTo("1"),
                "Cart badge should show 1 item");
        }

        [Test]
        [Category("Cart")]
        public async Task AddMultipleItems_ToCart()
        {
            // Act
            await _productsPage.AddBackpackToCartAsync();
            await _productsPage.AddBikeLightToCartAsync();

            // Assert
            var cartCount = await _productsPage.GetCartCountAsync();
            Assert.That(cartCount, Is.EqualTo("2"),
                "Cart badge should show 2 items");
        }

        [Test]
        [Category("Cart")]
        public async Task VerifyCart_ContainsAddedItem()
        {
            // Arrange
            await _productsPage.AddBackpackToCartAsync();

            // Act
            await _productsPage.GoToCartAsync();

            // Assert
            var cartPage = new CartPage(Page);
            Assert.That(await cartPage.IsDisplayedAsync(), Is.True,
                "Cart page should be displayed");
            Assert.That(await cartPage.GetItemCountAsync(), Is.EqualTo(1),
                "Cart should contain 1 item");
        }
    }
}