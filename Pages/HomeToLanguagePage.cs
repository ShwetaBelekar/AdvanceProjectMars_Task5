using AdvanceProjectMars_Task5.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class HomeToLanguagePage : CommonDriver
    {
        private IWebElement profileTab => driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]"));
        private IWebElement languageOption => driver.Value.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));
        public void NavigateToLanguage()
        {
            Thread.Sleep(2000);
            profileTab.Click();
            languageOption.Click();
            

        }
    }
}
