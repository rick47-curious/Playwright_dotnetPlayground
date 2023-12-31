using PlaywrightDemo.Pages;
using PlaywrightDemo.Reusables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemo.Tests
{
    internal class PlaywrightWaitTests: Setup
    {
        [Test]
        public async Task WaitForResponseTest() 
        {
            HRMPage hrmPage = new(page);

            await hrmPage.EnterLoginCredentials("Admin", "admin123");

            await hrmPage.ClickLogin();        
        }

        [Test]
        public async Task WaitForRequestTest() 
        {
            HRMPage hrmPage = new(page);

            await hrmPage.EnterLoginCredentials("Admin", "admin123");

            await hrmPage.ClickLogin();

            await hrmPage.ClickNavigationOption("Leave");
        }
    }
}
