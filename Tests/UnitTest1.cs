using Microsoft.Playwright;
using PlaywrightDemo.Pages;
using PlaywrightDemo.Reusables;

namespace PlaywrightDemo.Tests
{
    public class Tests : Setup
    {

        [Test]
        public async Task HomepageTest()
        {
            Homepage homepage = new(page);

            Assert.That(await homepage.ReturnGreenLogoText(), Is.EqualTo("GREENKART"));

            await homepage.ClickShoppingCart();

            Assert.That(await homepage.ReturnEmptyCartHeaderText(), Contains.Substring("cart is empty"));

        }
    }
}