using Microsoft.Playwright;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HerokuappLoginTests.scr.Pages
{
    public class LoginPage(IPage page)
    {

        // Locators for the elements on the page
        public ILocator UsernameInput => page.Locator("#username");
        public ILocator PasswordInput => page.Locator("#password");
        public ILocator LoginButton => page.Locator("button[type='submit']");
        public ILocator CloseFlashMessageButton => page.Locator("a.close");
        public ILocator FlashMessage => page.Locator("#flash");

        // Standard constructor for better clarity
      
        public async Task NavigateToBaseUrlAsync()
        {
            await page.GotoAsync(Constants.Constants.LoginUrl);
        }

        public async Task LoginAsync(string username, string password)
        {
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }

    }
}
