using AdvanceProjectMars_Task5.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProjectMars_Task5.Pages
{
    public class HomeToSkillPage : CommonDriver
    {
        public void NavigateToSkill()
        {
            IWebElement profileTab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[2]"));
            profileTab.Click();

            IWebElement skillsOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsOption.Click();
            Thread.Sleep(2000);
        }
    }
}
