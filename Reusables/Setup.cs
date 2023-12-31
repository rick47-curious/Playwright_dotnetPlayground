using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemo.Reusables
{
    public class Setup
    {
        public IPlaywright? playwright;
        public IBrowser? browser;
        public IPage? page;

        
        [OneTimeSetUp]
        public async Task InitializePlaywright() 
        {
            playwright = await Playwright.CreateAsync();

            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
            {
                Headless = false,
                Timeout = 30000,
                Channel = "chrome",
                Args = new[] { "--start-maximized" }
            });

            page = await browser.NewPageAsync(new BrowserNewPageOptions()
            {
                ViewportSize = ViewportSize.NoViewport
            });
            //RsA: https://rahulshettyacademy.com/seleniumPractise/#/
            //HRM: https://opensource-demo.orangehrmlive.com/web/index.php/auth/login
            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            page.SetDefaultNavigationTimeout(60000);
        }

        //[OneTimeTearDown]
        //public async Task TearDown() 
        //{
        //    await page.CloseAsync();

        //    await browser.CloseAsync();
        //}
    }
}
