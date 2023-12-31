using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightDemo.Pages
{
    public  class HRMPage
    {
        private IPage _page;

        public HRMPage(IPage page) => _page = page;

        private ILocator UserNameTextBox => _page.Locator("//*[@name='username']").First;
        private ILocator PasswordTextBox => _page.Locator("//*[@name='password']").First;

        private ILocator LoginBtn => _page.Locator("//button[contains(@class,'login')]").First;

        private ILocator SelectNavigationOption(string option) => _page.Locator($"//span[text()='{option}']/ancestor::li").First;

        public async Task EnterLoginCredentials(string username, string password) 
        {
            await UserNameTextBox.FillAsync(username);
            await PasswordTextBox.FillAsync(password);
        }

        public async Task ClickLogin() 
        {
            //Response async wait
            //var response = await _page.RunAndWaitForResponseAsync(async() =>
            //{
            //    await LoginBtn.ClickAsync();
            //},x=> x.Url.Contains("/dashboard/index") && x.Status == 200);

            //Alternatively for above
            //await LoginBtn.ClickAsync();
            //await _page.WaitForResponseAsync("**/files"); (example)

            //Navigation async wait
            //RunAndWaitForNavigationAsync deprecated, alternative below
            await LoginBtn.ClickAsync();
            await _page.WaitForURLAsync("**/dashboard/index");
        }

        public async Task ClickNavigationOption(string option) 
        {
            
            //await SelectNavigationOption(option).ClickAsync();
            //await _page.WaitForRequestAsync("**/leave-requests/");


            //Alternatively use RunAndWaitForRequestAsync
            var request = await _page.RunAndWaitForRequestAsync(async () =>
            {
                await SelectNavigationOption(option).ClickAsync();
            }, x => x.Url.Contains("/leave/employees/leave-requests") && x.Method == "GET");
        }
    }
}
