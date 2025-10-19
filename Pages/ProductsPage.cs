using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class ProductsPage
    {
        private readonly IPage _page;

        public ProductsPage(IPage page)
        {
            _page = page;
        }

        private ILocator ProductsTitle => _page.Locator(".title");
        private ILocator AddBackpackButton => _page.Locator("#add-to-cart-sauce-labs-backpack");
        private ILocator AddBikeLightButton => _page.Locator("#add-to-cart-sauce-labs-bike-light");
        private ILocator CartBadge => _page.Locator(".shopping_cart_badge");
        private ILocator CartIcon => _page.Locator(".shopping_cart_link");

        public async Task<bool> IsDisplayedAsync()
        {
            await ProductsTitle.WaitForAsync();
            var title = await ProductsTitle.TextContentAsync();
            return title == "Products";
        }

        public async Task AddBackpackToCartAsync()
        {
            await AddBackpackButton.ClickAsync();
        }

        public async Task AddBikeLightToCartAsync()
        {
            await AddBikeLightButton.ClickAsync();
        }

        public async Task<string> GetCartCountAsync()
        {
            try
            {
                return await CartBadge.TextContentAsync() ?? "0";
            }
            catch
            {
                return "0";
            }
        }

        public async Task GoToCartAsync()
        {
            await CartIcon.ClickAsync();
        }
    }
}