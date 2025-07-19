using Microsoft.Playwright;

namespace HerokuappLoginTests.Pages
{
    public class SecurePage(IPage page)
    {
        // Locators
        public ILocator LogoutButton => page.Locator("a.button.secondary[href='/logout']");        
    }
}
