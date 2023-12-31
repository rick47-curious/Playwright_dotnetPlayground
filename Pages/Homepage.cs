using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemo.Pages
{
    public class Homepage
    {
        private IPage? _page;

        public Homepage(IPage page) => _page = page;

        private ILocator GreenLogo => _page.Locator("//div[@class='brand greenLogo']").First;
        private ILocator CartIcon => _page.Locator("//a[@class='cart-icon']").First;
        private ILocator EmptyCartHeader => _page.Locator("//div[@class='empty-cart']/h2").First;

        public async Task<string> ReturnGreenLogoText() => await GreenLogo.TextContentAsync();

        public async Task ClickShoppingCart() => await CartIcon.ClickAsync();

        public async Task<string> ReturnEmptyCartHeaderText() => await EmptyCartHeader.TextContentAsync();
    }
}
