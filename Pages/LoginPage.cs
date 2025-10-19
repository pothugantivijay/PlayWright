using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        private ILocator UsernameField => _page.Locator("#user-name");
        private ILocator PasswordField => _page.Locator("#password");
        private ILocator LoginButton => _page.Locator("#login-button");
        private ILocator ErrorMessage => _page.Locator("[data-test='error']");

        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task LoginAsync(string username, string password)
        {
            await UsernameField.FillAsync(username);
            await PasswordField.FillAsync(password);
            await LoginButton.ClickAsync();
        }

        public async Task<bool> IsErrorVisibleAsync()
        {
            return await ErrorMessage.IsVisibleAsync();
        }

        public async Task<string> GetErrorTextAsync()
        {
            return await ErrorMessage.TextContentAsync() ?? "";
        }
    }
}