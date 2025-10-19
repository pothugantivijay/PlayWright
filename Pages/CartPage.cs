using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class CartPage
    {
        private readonly IPage _page;

        public CartPage(IPage page)
        {
            _page = page;
        }

        private ILocator CartTitle => _page.Locator(".title");
        private ILocator CartItems => _page.Locator(".cart_item");

        public async Task<bool> IsDisplayedAsync()
        {
            await CartTitle.WaitForAsync();
            var title = await CartTitle.TextContentAsync();
            return title == "Your Cart";
        }

        public async Task<int> GetItemCountAsync()
        {
            return await CartItems.CountAsync();
        }
    }
}